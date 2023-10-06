using Aig.Auditoria.Services;
using DataModel;
using DataModel.Models;
using Microsoft.AspNetCore.Components;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Org.BouncyCastle.Asn1.Ocsp;
using System;
using System.Collections.Concurrent;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Net.Http;
using System.Threading.Tasks;

namespace Aig.Auditoria.Helper
{
    public class BlazorCookieLoginMiddleware<TUser> where TUser : class
    {
        #region Static Login Cache

        static IDictionary<Guid, LoginModel> Logins { get; set; }
            = new ConcurrentDictionary<Guid, LoginModel>();

        public static Guid AnnounceLogin(LoginModel loginInfo)
        {
            loginInfo.LoginStarted = DateTime.Now;
            var key = Guid.NewGuid();
            Logins[key] = loginInfo;
            return key;
        }
        public static LoginModel GetLoginInProgress(string key)
        {
            return GetLoginInProgress(Guid.Parse(key));
        }

        public static LoginModel GetLoginInProgress(Guid key)
        {
            if (Logins.ContainsKey(key))
            {
                return Logins[key];
            }
            else
            {
                return null;
            }
        }

        #endregion

        private readonly RequestDelegate _next;

        public BlazorCookieLoginMiddleware(RequestDelegate next)
        {
            _next = next;
        }

        public async Task Invoke(HttpContext context, IAuthService authService)
        {
            try
            {
                if (context.Request.Path.StartsWithSegments(new PathString("/api")))
                {
                   
                }
                else if ( context.Request.Path == "/login" && context.Request.Query.ContainsKey("key"))
                {
                    var key = Guid.Parse(context.Request.Query["key"]);
                    var info = Logins[key];

                    //var result = await signInMgr.PasswordSignInAsync(info.UserName, info.Password, info.RememberMe, lockoutOnFailure: false);
                    var result = await authService.Login(new LoginModel() { UserName= info.UserName, Password= info.Password, RememberMe= info.RememberMe }); //signInMgr.PasswordSignInAsync(info.UserName, info.Password, info.RememberMe, lockoutOnFailure: false);

                    //Uncache password for security:
                    info.Password = null;
                    if (result.Result)
                    {
                        Logins.Remove(key);
                        context.Response.Redirect("./");
                        return;
                    }
                    //else if (result.RequiresTwoFactor)
                    //{
                    //    context.Response.Redirect("./loginwith2fa/" + key);
                    //    return;
                    //}
                    //else if (result.IsLockedOut)
                    //{
                    //    info.Error = "You are locked out. Please contact support.";
                    //}
                    else
                    {
                        info.Error = "Login failed. Check your username and password.";
                    }
                }
                //else if (context.Request.Path.StartsWithSegments("/loginwith2fa"))
                //{
                //    var key = Guid.Parse(context.Request.Path.Value.Split('/').Last());
                //    var info = Logins[key];

                //    if (string.IsNullOrEmpty(info.TwoFactorCode))
                //    {
                //        //user is opening 2FA first time...
                //        //...Get user model and cache it for the 2FA-View:
                //        var user = await signInMgr.GetTwoFactorAuthenticationUserAsync();
                //        //info.User = user;
                //    }
                //    else
                //    {
                //        //user has submitted 2FA, check:
                //        var result = await signInMgr.TwoFactorAuthenticatorSignInAsync(info.TwoFactorCode, info.RememberMe, info.RememberMachine);

                //        if (result.Succeeded)
                //        {
                //            Logins.Remove(key);
                //            context.Response.Redirect(info.ReturnUrl);
                //            return;
                //        }
                //        else if (result.IsLockedOut)
                //        {
                //            info.Error = "You are locked out. Please contact support.";
                //        }
                //        else
                //        {
                //            info.Error = "Invalid authenticator code";
                //        }
                //    }
                //}
                else if (context.Request.Path.StartsWithSegments("/logout"))
                {
                    await authService.Logout();
                    context.Response.Redirect("./login");
                    return;
                }

                //Continue http middleware chain:
                await _next(context);
            }
            catch (Exception ex)
            {
                await authService.Logout();
                context.Response.Redirect("./login");
                return;
            }

        }

    }

}
