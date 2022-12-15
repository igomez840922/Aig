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

        public static class UserEndpoints
        {
            public static string Login = "api/account/login";
            public static string Avatar(string image)
            {
                return $"api/account/avatar/{image}";
            }
            public static string Refresh = "api/account/token/refresh";
            public static string Register = "api/account/register";
            public static string ChangePassword = "api/account/changepassword";
            public static string UpdateProfile = "api/account/updateprofile";
        }

        public static class AccountEndpoints
        {
            public static string Register = "api/identity/account/register";
            public static string ChangePassword = "api/identity/account/changepassword";
            public static string UpdateProfile = "api/identity/account/updateprofile";

            public static string GetProfilePicture(string userId)
            {
                return $"api/identity/account/profile-picture/{userId}";
            }

            public static string UpdateProfilePicture(string userId)
            {
                return $"api/identity/account/profile-picture/{userId}";
            }
        }

        public static class AigMedicamentoEndpoints
        {
            public static string Search = "api/medicament/search";
            public static string Save = "api/medicament/save";
            public static string Delete(string id)
            {
                return $"api/medicaments/{id}";
            }

        }

    }
}
