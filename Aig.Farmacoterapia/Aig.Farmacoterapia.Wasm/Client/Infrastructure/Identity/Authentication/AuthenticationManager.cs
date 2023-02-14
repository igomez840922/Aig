﻿using Aig.Farmacoterapia.Domain.Common;
using Aig.Farmacoterapia.Domain.Identity;
using Aig.Farmacoterapia.Domain.Interfaces;
using Aig.Farmacoterapia.Wasm.Client.Extensions;
using Blazored.LocalStorage;
using Microsoft.AspNetCore.Components.Authorization;
using System;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Net.Http.Json;
using System.Security.Claims;
using Aig.Farmacoterapia.Wasm.Client.Infrastructure.Authentication;
using Aig.Farmacoterapia.Wasm.Client.Infrastructure.Identity.Authentication;
using Aig.Farmacoterapia.Wasm.Client.Infrastructure;

namespace Aig.Farmacoterapia.Wasm.ClientInfrastructure.Identity.Authentication
{
    public class AuthenticationManager : IAuthenticationManager
    {
        private readonly HttpClient _httpClient;
        private readonly ILocalStorageService _localStorage;
        private readonly AuthenticationStateProvider _authenticationStateProvider;

        public AuthenticationManager(
            HttpClient httpClient,
            ILocalStorageService localStorage,
            AuthenticationStateProvider authenticationStateProvider)
        {
            _httpClient = httpClient;
            _localStorage = localStorage;
            _authenticationStateProvider = authenticationStateProvider;

        }

        public async Task<ClaimsPrincipal> CurrentUser()
        {
            var state = await _authenticationStateProvider.GetAuthenticationStateAsync();
            return state.User;
        }

        public async Task<IResult> Login(TokenRequest model)
        {
            var uri = AppConstants.IdentityEndpoints.Login;
            var response = await _httpClient.PostAsJsonAsync(AppConstants.IdentityEndpoints.Login, model);
            var result = await response.ToResult<TokenResponse>();
            if (result.Succeeded)
            {
                var token = result.Data.Token;
                var refreshToken = result.Data.RefreshToken;
                var userImageURL = AppConstants.UsersEndpoints.Avatar(result.Data.Avatar);
                await _localStorage.SetItemAsync(AppConstants.Local.AuthToken, token);
                await _localStorage.SetItemAsync(AppConstants.Local.RefreshToken, refreshToken);
                await _localStorage.SetItemAsync(AppConstants.Local.UserImageURL, string.IsNullOrEmpty(result.Data.Avatar)?string.Empty: userImageURL);
                await ((AppStateProvider)this._authenticationStateProvider).StateChangedAsync();

                _httpClient.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", token);

                return await Result.SuccessAsync();
            }
            else
            {
                return await Result.FailAsync(result.Messages);
            }
        }

        public async Task<IResult> Logout()
        {
            await _localStorage.RemoveItemAsync(AppConstants.Local.AuthToken);
            await _localStorage.RemoveItemAsync(AppConstants.Local.RefreshToken);
            await _localStorage.RemoveItemAsync(AppConstants.Local.UserImageURL);
            ((AppStateProvider)_authenticationStateProvider).MarkUserAsLoggedOut();
            _httpClient.DefaultRequestHeaders.Authorization = null;
            return await Result.SuccessAsync();
        }

        public async Task<string> RefreshToken()
        {
            var token = await _localStorage.GetItemAsync<string>(AppConstants.Local.AuthToken);
            var refreshToken = await _localStorage.GetItemAsync<string>(AppConstants.Local.RefreshToken);

            var response = await _httpClient.PostAsJsonAsync(AppConstants.IdentityEndpoints.Refresh, new RefreshTokenRequest { Token = token, RefreshToken = refreshToken });

            var result = await response.ToResult<TokenResponse>();

            if (!result.Succeeded)
            {
                throw new ApplicationException("Something went wrong during the refresh token action");
            }

            token = result.Data.Token;
            refreshToken = result.Data.RefreshToken;
            await _localStorage.SetItemAsync(AppConstants.Local.AuthToken, token);
            await _localStorage.SetItemAsync(AppConstants.Local.RefreshToken, refreshToken);
            _httpClient.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", token);
            return token;
        }

        public async Task<string> TryRefreshToken()
        {
            //check if token exists
            var availableToken = await _localStorage.GetItemAsync<string>(AppConstants.Local.RefreshToken);
            if (string.IsNullOrEmpty(availableToken)) return string.Empty;
            var authState = await _authenticationStateProvider.GetAuthenticationStateAsync();
            var user = authState.User;
            var exp = user.FindFirst(c => c.Type.Equals("exp"))?.Value;
            var expTime = DateTimeOffset.FromUnixTimeSeconds(Convert.ToInt64(exp));
            var timeUTC = DateTime.UtcNow;
            var diff = expTime - timeUTC;
            if (diff.TotalMinutes <= 1)
                return await RefreshToken();
            return string.Empty;
        }

        public async Task<string> TryForceRefreshToken()
        {
            return await RefreshToken();
        }

        public async Task<IResult<long>> GetNotificationAsync()
        {
            var response = await _httpClient.GetAsync(AppConstants.EstudioEndpoints.Notification);
            return await response.ToResult<long>();
        }
     
    }
}