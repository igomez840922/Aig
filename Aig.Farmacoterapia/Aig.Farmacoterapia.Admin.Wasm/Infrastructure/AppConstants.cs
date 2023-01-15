using Aig.Farmacoterapia.Domain.Entities.Enums;

namespace Aig.Farmacoterapia.Admin.Wasm.Infrastructure
{
    public static class AppConstants
    {
        public static class Local
        {
            public static string AuthToken = "authToken";
            public static string RefreshToken = "refreshToken";
            public static string UserImageURL = "userImageURL";
        }

        public static class AccountEndpoints
        {
            public static string Login = "api/account/login";
            public static string Avatar(string image) => $"api/account/avatar/{image}";
            public static string Refresh = "api/account/token/refresh";
            public static string Register = "api/account/register";
            public static string ChangePassword = "api/account/changepassword";
            public static string UpdateProfile = "api/account/updateprofile";
        }

        public static class UsersEndpoints
        {
            public static string Search = "api/user/search";
            public static string Save = "api/user/save";
            public static string UsernameExists(string userName)
            {
                return $"api/user/username/{userName}";
            }
            public static string PhoneExists(string phone)
            {
                return $"api/user/phone/{phone}";
            }
            public static string Delete(string id)
            {
                return $"api/user/{id}";
            }
        }

        //public static class AccountEndpoints
        //{
        //    public static string Register = "api/identity/account/register";
        //    public static string ChangePassword = "api/identity/account/changepassword";
        //    public static string UpdateProfile = "api/identity/account/updateprofile";
        //    public static string GetProfilePicture(string userId) => $"api/identity/account/profile-picture/{userId}";

        //}

        public static class MediaEndpoints
        {
            public static string Upload()
            {
                return $"api/media/upload";
            }
            public static string DeleteFile(UploadType uploadType, string image) => $"api/media/{uploadType.ToString()}/{image}";

        }
        public static class AigMedicamentoEndpoints
        {
            public static string Search = "api/medicament/search";
            public static string Save = "api/medicament/save";
            public static string Delete(string id)
            {
                return $"api/medicament/{id}";
            }
        }

    }
}
