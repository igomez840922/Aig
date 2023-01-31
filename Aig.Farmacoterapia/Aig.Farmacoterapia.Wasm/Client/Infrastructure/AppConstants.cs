using Aig.Farmacoterapia.Domain.Entities.Enums;

namespace Aig.Farmacoterapia.Wasm.Client.Infrastructure
{
    public static class AppConstants
    {
        public static class Local
        {
            public static string AuthToken = "authToken";
            public static string RefreshToken = "refreshToken";
            public static string UserImageURL = "userImageURL";
        }
        public static class IdentityEndpoints
        {
            public static string Login = "api/identity/login";
            public static string Refresh = "api/identity/token/refresh";
        }
        public static class UsersEndpoints
        {
            public static string Search = "api/user/search";
            public static string Register = "api/user/register";
            public static string UpdateProfile = "api/user/updateprofile";
            public static string UpdateRoles = "api/user/updateroles";
            public static string ChangePassword = "api/user/changepassword";
            public static string Avatar(string image) => $"api/user/avatar/{image}";
            public static string UsernameExists(string userName)
            {
                return $"api/user/username/{userName}";
            }
            public static string PhoneExists(string phone)
            {
                return $"api/user/phone/{phone}";
            }
            //public static string Delete(string id)
            //{
            //    return $"api/user/{id}";
            //}
            public static string Delete=$"api/user/delete";

            //public static string Get(string userName)
            //{
            //    return $"api/user/{userName}";
            //}

            public static string Get = $"api/user";
            
        }

        public static class MediaEndpoints
        {
            public static string Upload()
            {
                return $"api/media/upload";
            }
            //public static string DeleteFile(UploadType uploadType, string image) => $"api/media/{uploadType.ToString()}/{image}";
            public static string DeleteFile = $"api/media/delete";

        }
        public static class MedicamentEndpoints
        {
            public static string Dashboard = "api/medicament/dashboard";
            public static string AdminSearch = "api/medicament/adminsearch";
            public static string Update = "api/medicament/update";
            public static string Pharmaceutica= $"api/medicament/pharmaceutica";
            public static string MedicationRoutel = $"api/medicament/medicationroute";
            public static string Marker = $"api/medicament/marker";
            //public static string Delete(long id)=> $"api/medicament/{id}";
            public static string Delete = $"api/medicament/delete";
            public static string Get(long id)
            {
                return $"api/medicament/{id}";
            }
            public static string DataSheetURL(string file) => $"api/medicament/datasheet/{file}";
            public static string ProspectusURL(string file) => $"api/medicament/prospectus/{file}";
        }

        public static class EstudioDNFDEndpoints
        {
            public static string Search = "api/studiesdnfd/search";
            public static string Update = "api/studiesdnfd/update";
            public static string Delete = $"api/studiesdnfd/delete";
            public static string Get(long id) => $"api/studiesdnfd/study/{id}";
            
        }

    }
}
