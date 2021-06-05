using Newtonsoft.Json;
using Talktif.Models;
using Talktif.Repository;

namespace Talktif.Service
{
    public class UserService
    {
        private static UserService _Instance;
        public static UserService Instance
        {
            get
            {
                if (_Instance == null)
                {
                    _Instance = new UserService();
                }
                return _Instance;
            }
            private set { }
        }
        public void RefreshToken()
        {
            RefreshTokenRequest r = new RefreshTokenRequest() { Email = UserRepo.Instance.data.email };
            var refreshToken = UserRepo.Instance.RefreshToken(r);
            var result = refreshToken.Content.ReadAsStringAsync().Result;
            Token t = JsonConvert.DeserializeObject<Token>(result);
            UserRepo.Instance.data.token = t.token;
        }
        public bool IsAdmin()
        {
            return UserRepo.Instance.data.isAdmin;
        }
        public void RemoveData()
        {
            UserRepo.Instance.data = null;
        }
    }
}