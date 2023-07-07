using DataModel;
using DataModel.Models;
using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Net.Http.Json;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Components;
using MimeKit;

namespace Aig.FarmacoVigilancia.Services
{
    public class AuthService : IAuthService
    {
        private readonly UserManager<ApplicationUser> _userManager;
        private readonly SignInManager<ApplicationUser> _signInManager;
		Random random = new Random();
		private readonly IEmailService emailService;
		public AuthService(UserManager<ApplicationUser> userManager, SignInManager<ApplicationUser> signInManager, IEmailService emailService)
        {
            _userManager = userManager;
            _signInManager = signInManager;
            this.emailService = emailService;

		}
        
        public async Task<ApiResponse> Login(LoginModel request)
        {
            var user = await _userManager.FindByNameAsync(request.UserName);
            if (user == null) return new ApiResponse() { Result=false,Message= "User does not exist" };
            var singInResult = await _signInManager.CheckPasswordSignInAsync(user, request.Password, false);
            if (!singInResult.Succeeded) return new ApiResponse() { Result = false, Message = "Invalid password" };
            await _signInManager.SignInAsync(user, request.RememberMe);
            return new ApiResponse() { Result = true};
        }
        
        public async Task<ApiResponse> Register(RegisterModel parameters)
        {
            var user = new ApplicationUser();
            user.UserName = parameters.UserName;
            var result = await _userManager.CreateAsync(user, parameters.Password);
            if (!result.Succeeded) return new ApiResponse() { Result = false, Message = result.Errors.FirstOrDefault()?.Description };

            return await Login(new LoginModel
            {
                UserName = parameters.UserName,
                Password = parameters.Password
            });
        }
        
        //[Authorize]
        public async Task<ApiResponse> Logout()
        {
            await _signInManager.SignOutAsync();
            return new ApiResponse() { Result = true };
        }
               

        [Authorize]
        public async Task<ApplicationUser> CurrentUserInfo(string username)
        {
            var user = await _userManager.FindByNameAsync(username);
           return user;
        }

        public async Task<ApiResponse> RequestPin(ReqPINModel request)
        {
            var user = await _userManager.FindByEmailAsync(request.Email);
            if (user == null) return new ApiResponse() { Result = false, Message = "este usuario no existe" };

			user.pinNum = random.Next(100000, 999999).ToString();
			user.pinDateValid = DateTime.Now.AddMinutes(10);
			var result = await _userManager.UpdateAsync(user);

			var subject = "Cambio de Contraseña";
			var builder = new BodyBuilder();
			builder.TextBody = string.Format("Estimado {0}\r\n\r\nHemos recibido una solicitud para cambiar su contraseña. Por este medio le enviamos el PIN de seguridad para completar su solicitud, el mismo es válido por 10min: \r\n{1}", user.UserProfile?.FullName, user.pinNum);

			//builder.HtmlBody = string.Format("<p>Estimado {0}<br/><br/>Muchas gracias por suscribirse al Sistema de Notificaciones de notas y alertas emitida por el Centro Nacional de Farmacovigilancia.<br/><br/>" +
			//    "Para cualquier consulta o información adicional puede contactarnos a través del correo electrónico <a href='mailto:fvigilancia@minsa.gob.pa'>fvigilancia@minsa.gob.pa</a>.<br/><br/><br/><br/>" +
			//    "Saludos Cordiales<br/><br/>Centro Nacional de Farmacovigilancia<br/>Departamento de Farmacovigilancia<br/>Dirección Nacional de Farmacia y Drogas<br/>Ministerio de Salud</p>" +
			//    "<p>Nota: para darse de baja de dicho sistema haga click en el siguiente enlace: <a href='{1}'>Darse de Baja</a></p>", data.Nombre, string.Format("{0}{1}", navigationManager.BaseUri, "registrobaja"));


			List<string> lEmails = new List<string>() { user.Email };

			await emailService.SendEmailAsync(lEmails, subject, builder, "Centro Nacional de Farmacovigilancia");

			return new ApiResponse() { Result = true, Message = "se ha enviado un correo con el PIN de seguridad" };
		}

    }
}
