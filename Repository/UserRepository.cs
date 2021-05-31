using System;
using System.Net.Http;
using System.Net.Http.Headers;
using Talktif.Models;

namespace Talktif.Repository
{
    public class UserRepo
    {
        public User_Infor data { get; set; }
        private static UserRepo _Instance;
        public static UserRepo Instance {
            get 
            {
                if(_Instance == null)
                {
                    _Instance = new UserRepo();
                    //_Instance.data = new User_Infor();
                } 
                return _Instance;
            }
            private set { }
        }
        private const string UriString = "https://talktifapi.azurewebsites.net/api/Users/";
        public HttpResponseMessage Sign_Up(SignUpRequest Sr)
        {
            using(var client = new HttpClient())
            {
                client.BaseAddress = new Uri(UriString);
                var signUp = client.PostAsJsonAsync("SignUp",Sr);
                signUp.Wait();
                var SignUpResult = signUp.Result;
                Console.WriteLine(signUp.Result);
                return SignUpResult;
            }
        }
        public HttpResponseMessage Sign_In(LoginRequest lr){
            using(var client = new HttpClient())
            {
                client.BaseAddress = new Uri(UriString);
                //client.DefaultRequestHeaders.Accept.Clear();
                //client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
                var login = client.PostAsJsonAsync("SignIn",lr);
                login.Wait();
                var loginResult = login.Result;
                return loginResult;
            }
        }
        public HttpResponseMessage ResetPass(ResetPassRequest r)
        {
            using(var client = new HttpClient())
            {
                client.BaseAddress = new Uri(UriString);
                var resetPass = client.PostAsJsonAsync("ResetPass",r);
                resetPass.Wait();
                var resetPassResult = resetPass.Result;
                return resetPassResult;
            }
        }
        public HttpResponseMessage ResetPasswordEmail(ResetPassEmailRequest r)
        {
            using(var client = new HttpClient())
            {
                client.BaseAddress = new Uri(UriString);
                var resetPasswordEmail = client.PostAsJsonAsync("ResetPasswordEmail",r);
                resetPasswordEmail.Wait();
                var resetPasswordEmailResult = resetPasswordEmail.Result;
                return resetPasswordEmailResult;
            }
        }
        public HttpResponseMessage GetAllCountry()
        {
            using(var client = new HttpClient())
            {
                client.BaseAddress = new Uri(UriString);
                var getAllCountry = client.GetAsync("GetAllCountry");
                getAllCountry.Wait();
                var result = getAllCountry.Result;
                return result;
            }
        }
        public HttpResponseMessage GetAllCityCountry(int id)
        {
            using (var client = new HttpClient())
            {
                client.BaseAddress = new Uri(UriString);
                var getAllCityCountry = client.GetAsync("GetAllCityCountry/"+id);
                getAllCityCountry.Wait();
                var result = getAllCityCountry.Result;
                return result;
            }
        }
        public HttpResponseMessage GetUserByID(int id)
        {
            using(var client = new HttpClient())
            {
                client.BaseAddress = new Uri(UriString);
                client.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer",UserRepo.Instance.data.token);
                var getUserByID = client.PostAsJsonAsync(id.ToString(),id);
                getUserByID.Wait();
                var result = getUserByID.Result;
                return result;
            }
        }
        public HttpResponseMessage UpdateUserInfor(UpdateInfoRequest update)
        {
            using(var client = new HttpClient())
            {
                client.BaseAddress = new Uri(UriString);
                client.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer",UserRepo.Instance.data.token);
                var upDateUser = client.PostAsJsonAsync("UpdateInfo",update);
                upDateUser.Wait();
                var result = upDateUser.Result;
                return result;
            }
        }
        public HttpResponseMessage InActiveUser(int id)
        {
            using(var client = new HttpClient())
            {
                client.BaseAddress = new Uri(UriString);
                client.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer",UserRepo.Instance.data.token);
                var inActiveUser = client.GetAsync("InActiveUser/"+ id);
                inActiveUser.Wait();
                var result = inActiveUser.Result;
                return result;
            }
        }
        public HttpResponseMessage RefreshToken(RefreshTokenRequest r)
        {
            using(var client = new HttpClient())
            {
                client.BaseAddress = new Uri(UriString);
                var refreshToken = client.PostAsJsonAsync("refresh-token",r);
                refreshToken.Wait();
                var refreshTokenResult = refreshToken.Result;
                return refreshTokenResult;
            }
        }
        public HttpResponseMessage Report(ReportRequest request)
        {
            using(var client = new HttpClient())
            {
                client.BaseAddress = new Uri(UriString);
                client.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", UserRepo.Instance.data.token);
                var rePort = client.PostAsJsonAsync("Report", request);
                rePort.Wait();
                var result = rePort.Result;
                return result;
            }
        }
        public void ShowInformation()
        {
            Console.WriteLine("ID= {0}\nName= {1}\nEmail= {2}\nGender= {3}\nisAdmin= {4}\nisActive= {5}\nHobbies= {6}\nToken= {7}",
            data.id,data.name,data.email,data.gender,data.isAdmin,data.isActive,data.hobbies,data.token);
        }
    }
}