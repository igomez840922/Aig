using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Text;
using Aig.Farmacoterapia.Domain.Common;
using Aig.Farmacoterapia.Domain.Interfaces;
using Aig.Farmacoterapia.Infrastructure.Identity;
using Aig.Farmacoterapia.Infrastructure.Interfaces;
using Aig.Farmacoterapia.Infrastructure.Mail;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.WebUtilities;
using Microsoft.EntityFrameworkCore;
using System.Linq.Expressions;
using System.Text.Encodings.Web;
using Aig.Farmacoterapia.Infrastructure.Extensions;
using Aig.Farmacoterapia.Domain.Identity;
using Aig.Farmacoterapia.Domain.Entities.Enums;

namespace Aig.Farmacoterapia.Infrastructure.Services
{
    public class UserService : IUserService
    {
        private readonly UserManager<ApplicationUser> _userManager;
        private readonly RoleManager<IdentityRole> _roleManager;
        private readonly SignInManager<ApplicationUser> _signInManager;
        private readonly IMailService _mailService;
        private readonly IUploadService _uploadService;
        private readonly ICurrentUserService _currentUserService;
        private readonly ISystemLogger _logger;

        public UserService(
            UserManager<ApplicationUser> userManager,
            RoleManager<IdentityRole> roleManager,
            SignInManager<ApplicationUser> signInManager,
            IMailService mailService,
            IUploadService uploadService,
            ICurrentUserService currentUserService,
            ISystemLogger logger)
        {
            _userManager = userManager;
            _roleManager = roleManager;
            _mailService = mailService;
            _uploadService = uploadService;
            _currentUserService = currentUserService;
            _signInManager = signInManager;
            _logger = logger;
        }

        public async Task<PaginatedResult<ApplicationUser>> ListAsync(PageSearchArgs args)
        {
            if (args == null) throw new Exception();
            var result = new PaginatedResult<ApplicationUser>(new List<ApplicationUser>());
            try
            {
                var orderByList = new List<Tuple<SortingOption, Expression<Func<ApplicationUser, object>>>>();
                var filterList = new List<Expression<Func<ApplicationUser, bool>>>();

                if (args.SortingOptions != null)
                {
                    foreach (var sortingOption in args.SortingOptions)
                    {
                        switch (sortingOption.Field)
                        {
                            case "name":
                                orderByList.Add(new(sortingOption, c => c.UserName));
                                break;
                        }
                    }
                }
                if (args?.FilteringOptions != null)
                {
                    foreach (var filteringOption in args.FilteringOptions)
                    {
                        switch (filteringOption.Field)
                        {
                            case "term":
                                {
                                    Expression<Func<ApplicationUser, bool>> expression = f =>
                                    f.FirstName.ToLower().Contains(((string)filteringOption.Value).ToLower()) ||
                                    f.LastName.ToLower().Contains(((string)filteringOption.Value).ToLower()) ||
                                    f.UserName.ToLower().Contains(((string)filteringOption.Value).ToLower());
                                    filterList.Add(expression);
                                }
                                break;

                        }
                    }
                }
               
                var filterSpec = new UserSpecification(filterList);
                result =  await _userManager.Users
                                          .OrderBy(orderByList)
                                          .WhereBy(filterSpec)
                                          .PaginatedByAsync(args.PageIndex, args.PageSize);
            }
            catch (Exception exc)
            {
                _logger.Error(exc.Message, exc);
            }
            return result;
        }
        public async Task<Result<List<ApplicationUser>>> GetAllAsync()
        {
            var users = await _userManager.Users.ToListAsync();
            return await Result<List<ApplicationUser>>.SuccessAsync(users);
        }
        public async Task<IResult> SaveAsync(ApplicationUser data)
        {
           
            data.Email = data.UserName;
            var user = await _userManager.FindByIdAsync(data.Id);
            if (user != null) {
                var result = await _userManager.UpdateAsync(user);
                if (result.Succeeded)
                    return await Result<string>.SuccessAsync(user.Id, string.Format("Usuario {0} actualizado correctamente !", user.UserName));
                else
                  return await Result.FailAsync(result.Errors.Select(a => a.Description.ToString()).ToList());
            }
            else
            {
                var result = await _userManager.CreateAsync(data, data.Password);
                if (result.Succeeded)
                {
                    result = await _userManager.AddToRoleAsync(data, RoleConstants.Administrator);
                    if (result.Succeeded)
                        return await Result<string>.SuccessAsync(data.UserName, string.Format("Usuario {0} Registrado correctamente !.", data.UserName));
                    else
                      return await Result.FailAsync(result.Errors.Select(a => a.Description.ToString()).ToList());
                }
                else
                    return await Result.FailAsync(result.Errors.Select(a => a.Description.ToString()).ToList());
            }
        }
        public async Task<IResult> ChangePasswordAsync(ApplicationUser data)
        {
            var user = await _userManager.FindByIdAsync(data.Id);
            if (user != null){
                user.PasswordHash = _userManager.PasswordHasher.HashPassword(data,data.Password);
                var result = await _userManager.UpdateAsync(user);
                if (result.Succeeded)
                    return await Result<string>.SuccessAsync(user.Id, string.Format("Contraseña actualizada correctamente !"));
                else
                    return await Result.FailAsync(result.Errors.Select(a => a.Description.ToString()).ToList());
            }
            return await Result.FailAsync("Error durante la operación");
        }
        public async Task<IResult> RegisterAsync(RegisterRequest request, string origin="")
        {
            var userWithSameUserName = await _userManager.FindByNameAsync(request.UserName);
            if (userWithSameUserName != null)
            {
                return await Result.FailAsync(string.Format("El nombre de usuario {0} ya está en uso.", request.UserName));
            }

            var user = new ApplicationUser
            {
                Email = request.Email,
                FirstName = request.FirstName,
                LastName = request.LastName,
                UserName = request.UserName,
                PhoneNumber = request.PhoneNumber,
                EmailConfirmed = request.AutoConfirmEmail,
                ProfilePicture = request.ProfilePicture,
                Role = request.Role
            };

            if (!string.IsNullOrWhiteSpace(request.PhoneNumber))
            {
                var userWithSamePhoneNumber = await _userManager.Users.FirstOrDefaultAsync(x => x.PhoneNumber == request.PhoneNumber);
                if (userWithSamePhoneNumber != null)
                {
                    return await Result.FailAsync(string.Format("El número de teléfono {0} ya está registrado.", request.PhoneNumber));
                }
            }
            var userWithSameEmail = await _userManager.FindByEmailAsync(request.Email);
            if (userWithSameEmail == null)
            {
                var result = await _userManager.CreateAsync(user, request.Password);
                if (result.Succeeded)
                {
                    await _userManager.AddToRoleAsync(user, request.Role.ToString());
                    if (!request.AutoConfirmEmail)
                    {
                        var verificationUri = await SendVerificationEmail(user, origin);
                        //var mailRequest = new MailRequest
                        //{
                        //    From = "mail@codewithmukesh.com",
                        //    To = user.Email,
                        //    Body = string.Format("Please confirm your account by <a href='{0}'>clicking here</a>.", verificationUri),
                        //    Subject = "Confirm Registration"
                        //};
                        //await _mailService.SendAsync(mailRequest);
                        return await Result<string>.SuccessAsync(user.Id, string.Format("User {0} Registered. Please check your Mailbox to verify!", user.UserName));
                    }
                    return await Result<string>.SuccessAsync(user.Id, string.Format("Usuario {0} registrado correctamente !.", user.UserName));
                }
                else
                {
                    return await Result.FailAsync(result.Errors.Select(a => a.Description.ToString()).ToList());
                }
            }
            else
            {
                return await Result.FailAsync(string.Format("Email {0} is already registered.", request.Email));
            }
        }
        public async Task<IResult> ChangePasswordAsync(ChangePasswordRequest model)
        {
            var user = await _userManager.FindByIdAsync(model.UserId);
            if (user != null)
            {
                user.PasswordHash = _userManager.PasswordHasher.HashPassword(user, model.NewPassword);
                var result = await _userManager.UpdateAsync(user);
                if (result.Succeeded)
                    return await Result<string>.SuccessAsync(user.Id, string.Format("Contraseña actualizada correctamente !"));
                else
                    return await Result.FailAsync(result.Errors.Select(a => a.Description.ToString()).ToList());
            }
            return await Result.FailAsync("Error durante la operación");
        }
        public async Task<IResult> UpdateProfileAsync(UpdateProfileRequest request)
        {

            if (!string.IsNullOrWhiteSpace(request.PhoneNumber))
            {
                var userWithSamePhoneNumber = await _userManager.Users.FirstOrDefaultAsync(x => x.PhoneNumber == request.PhoneNumber && x.Id != request.Id);
                if (userWithSamePhoneNumber != null)
                {
                    return await Result.FailAsync(string.Format("El número de teléfono {0} ya está en uso.", request.PhoneNumber));
                }
            }
          
            var userWithSameEmail = await _userManager.FindByEmailAsync(request.Email);
            if (userWithSameEmail == null || userWithSameEmail.Id == request.Id)
            {
                var user = await _userManager.FindByIdAsync(request.Id);
                if (user == null)
                {
                    return await Result.FailAsync("Usuario no encontrado.");
                }
                if (!string.IsNullOrEmpty(request.ProfilePicture) && !string.IsNullOrEmpty(user.ProfilePicture)) {
                    if (request.ProfilePicture!=user.ProfilePicture)
                        await _uploadService.DeleteAsync(UploadType.Users, user.ProfilePicture!);
                }
                user.ProfilePicture = request.ProfilePicture;
                user.FirstName = request.FirstName;
                user.LastName = request.LastName;
                user.PhoneNumber = request.PhoneNumber;
                user.UserName =user.Email = request.Email;
                var phoneNumber = await _userManager.GetPhoneNumberAsync(user);
                if (request.PhoneNumber != phoneNumber)
                {
                    var setPhoneResult = await _userManager.SetPhoneNumberAsync(user, request.PhoneNumber);
                }
                var identityResult = await _userManager.UpdateAsync(user);
                var errors = identityResult.Errors.Select(e => e.Description.ToString()).ToList();
                await _signInManager.RefreshSignInAsync(user);
                return identityResult.Succeeded ? await Result.SuccessAsync() : await Result.FailAsync(errors);
            }
            else
            {
                return await Result.FailAsync(string.Format("El correo electrónico {0} ya está en uso.", request.Email));
            }
        }
        private async Task<string> SendVerificationEmail(ApplicationUser user, string origin)
        {
            var code = await _userManager.GenerateEmailConfirmationTokenAsync(user);
            code = WebEncoders.Base64UrlEncode(Encoding.UTF8.GetBytes(code));
            var route = "api/identity/user/confirm-email/";
            var endpointUri = new Uri(string.Concat($"{origin}/", route));
            var verificationUri = QueryHelpers.AddQueryString(endpointUri.ToString(), "userId", user.Id);
            verificationUri = QueryHelpers.AddQueryString(verificationUri, "code", code);
            return verificationUri;
        }
        public async Task<ApplicationUser> GetAsync(string userId)
        {
            var user = await _userManager.Users.Where(u => u.Id == userId).FirstOrDefaultAsync();
            return user;
        }
        public async Task<ApplicationUser> GetUserByNameAsync(string userName)
        {
            var user = await _userManager.Users.Where(u => u.UserName == userName).FirstOrDefaultAsync();
            return user;
        }
        public ApplicationUser GetUserByName(string userName)
        {
            var task = Task.Run(async () => await GetUserByNameAsync(userName));
            return task.Result;
        }
        public ApplicationUser GetUserByPhone(string phone)
        {   
            var user =  _userManager.Users.Where(u => u.PhoneNumber == phone).FirstOrDefault();
            return user;
        }
        public async Task<IResult> DeleteAsync(string id)
        {
            var user = await _userManager.FindByIdAsync(id);
            if (user!=null) {
                var result = await _userManager.DeleteAsync(user);
                if (result.Succeeded)
                {
                    if (!string.IsNullOrEmpty(user.ProfilePicture))
                        await _uploadService.DeleteAsync(UploadType.Users,user.ProfilePicture);
                    return await Result<string>.SuccessAsync(user.UserName, string.Format("Usuario {0} eliminado correctamente !.", user.UserName));
                }  
                else
                    return await Result.FailAsync(result.Errors.Select(a => a.Description.ToString()).ToList());
            }
            else
              return await Result.FailAsync("Error durante la operación");
        }
        public async Task<IResult> ToggleUserStatusAsync(string userId,bool activate)
        {
            var user = await _userManager.Users.Where(u => u.Id == userId).FirstOrDefaultAsync();
            var isAdmin = await _userManager.IsInRoleAsync(user, RoleConstants.Administrator);

            if (isAdmin)
            {
                return await Result.FailAsync("Administrators Profile's Status cannot be toggled");
            }
            if (user != null)
            {
                user.IsActive = activate;
                var identityResult = await _userManager.UpdateAsync(user);
            }
            return await Result.SuccessAsync();
        }
        public async Task<IResult<UserRolesResponse>> GetRolesAsync(string userId)
        {
            var viewModel = new List<UserRoleModel>();
            var user = await _userManager.FindByIdAsync(userId);
            var roles = await _roleManager.Roles.ToListAsync();

            foreach (var role in roles)
            {
                var userRolesViewModel = new UserRoleModel
                {
                    RoleName = role.Name
                };
                if (await _userManager.IsInRoleAsync(user, role.Name))
                {
                    userRolesViewModel.Selected = true;
                }
                else
                {
                    userRolesViewModel.Selected = false;
                }
                viewModel.Add(userRolesViewModel);
            }
            var result = new UserRolesResponse { UserRoles = viewModel };
            return await Result<UserRolesResponse>.SuccessAsync(result);
        }
        public async Task<IResult> UpdateRolesAsync(UpdateUserRolesRequest request)
        {
            var user = await _userManager.FindByIdAsync(request.UserId);
            var currentUser = await _userManager.FindByIdAsync(_currentUserService.UserId);
            if (!await _userManager.IsInRoleAsync(currentUser, RoleType.Admin.ToString()))
                return await Result.FailAsync("Usted no tienen permisos para actualizar roles de usuarios.");
            var result = await _userManager.RemoveFromRoleAsync(user, user.Role.ToString());
            result = await _userManager.AddToRoleAsync(user, request.Role.ToString());
            user.Role = request.Role;
            result = await _userManager.UpdateAsync(user);
            return await Result.SuccessAsync("Rol de usuario actulizado correctamente.");
        }
        public async Task<IResult<string>> ConfirmEmailAsync(string userId, string code)
        {
            var user = await _userManager.FindByIdAsync(userId);
            code = Encoding.UTF8.GetString(WebEncoders.Base64UrlDecode(code));
            var result = await _userManager.ConfirmEmailAsync(user, code);
            if (result.Succeeded)
            {
                return await Result<string>.SuccessAsync(user.Id, string.Format("Account Confirmed for {0}. You can now use the /api/identity/token endpoint to generate JWT.", user.Email));
            }
            else
            {
                throw new Exception(string.Format("An error occurred while confirming {0}", user.Email));
            }
        }
        public async Task<IResult> ForgotPasswordAsync(ForgotPasswordRequest request, string origin)
        {
            var user = await _userManager.FindByEmailAsync(request.Email);
            if (user == null || !(await _userManager.IsEmailConfirmedAsync(user)))
            {
                // Don't reveal that the user does not exist or is not confirmed
                return await Result.FailAsync("An Error has occurred!");
            }
            // For more information on how to enable account confirmation and password reset please
            // visit https://go.microsoft.com/fwlink/?LinkID=532713
            var code = await _userManager.GeneratePasswordResetTokenAsync(user);
            code = WebEncoders.Base64UrlEncode(Encoding.UTF8.GetBytes(code));
            var route = "account/reset-password";
            var endpointUri = new Uri(string.Concat($"{origin}/", route));
            var passwordResetURL = QueryHelpers.AddQueryString(endpointUri.ToString(), "Token", code);
            var mailRequest = new MailRequest
            {
                Body = string.Format("Please reset your password by <a href='{0}'>clicking here</a>.", HtmlEncoder.Default.Encode(passwordResetURL)),
                Subject = "Reset Password",
                To = request.Email
            };
            await _mailService.SendAsync(mailRequest);
            return await Result.SuccessAsync("Password Reset Mail has been sent to your authorized Email.");
        }
        public async Task<IResult> ResetPasswordAsync(ResetPasswordRequest request)
        {
            var user = await _userManager.FindByEmailAsync(request.Email);
            if (user == null)
            {
                // Don't reveal that the user does not exist
                return await Result.FailAsync("An Error has occured!");
            }

            var result = await _userManager.ResetPasswordAsync(user, user.RefreshToken, request.Password);
            if (result.Succeeded)
            {
                return await Result.SuccessAsync("Password Reset Successful!");
            }
            else
            {
                return await Result.FailAsync("An Error has occured!");
            }
        }
        public async Task<int> GetCountAsync()
        {
            var count = await _userManager.Users.CountAsync();
            return count;
        }
    }
}
