using System;
using System.Net.Http;
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
        private const string UriString = "https://talktifapi.azurewebsites.net/";
        public HttpResponseMessage Sign_In(LoginRequest lr){
            using(var client = new HttpClient())
            {
                client.BaseAddress = new Uri(UriString);
                //client.DefaultRequestHeaders.Accept.Clear();
                //client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
                
                
                var login = client.PostAsJsonAsync("api/Users/SignIn",lr);
                login.Wait();
                //Console.WriteLine(login.Result.Content.ReadAsStringAsync().Result);
                var loginResult = login.Result;
                return loginResult;
            }
        }
        public HttpResponseMessage Sign_Up(SignUpRequest Sr)
        {
            using(var client = new HttpClient())
            {
                client.BaseAddress = new Uri(UriString);
                var signUp = client.PostAsJsonAsync("api/Users/SignUp",Sr);
                signUp.Wait();
                var SignUpResult = signUp.Result;
                Console.WriteLine(signUp.Result);
                return SignUpResult;
            }
        }
        public HttpResponseMessage ResetPass(ResetPassRequest r)
        {
            using(var client = new HttpClient())
            {
                client.BaseAddress = new Uri(UriString);
                var resetPass = client.PostAsJsonAsync("api/Users/ResetPass",r);
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
                var resetPasswordEmail = client.PostAsJsonAsync("api/Users/ResetPasswordEmail",r);
                resetPasswordEmail.Wait();
                var resetPasswordEmailResult = resetPasswordEmail.Result;
                return resetPasswordEmailResult;
            }
        }
        public HttpResponseMessage VertifyEmail(int id, string token)
        {
            using(var client = new HttpClient())
            {
                client.BaseAddress = new Uri(UriString);var vertify = client.PostAsJsonAsync("api/Users/VertifyEmail",
                                                                                            new VertifyEmailRequest { Id = id, Token = token });
                vertify.Wait();
                var SignUpResult = vertify.Result;
                return SignUpResult;
            }
        }

        public void ShowInformation()
        {
            Console.WriteLine("ID= {0}\nName= {1}\nEmail= {2}\nGender= {3}\nisAdmin= {4}\nisActive= {5}\nHobbies= {6}\nToken= {7}",
            data.id,data.name,data.email,data.gender,data.isAdmin,data.isActive,data.hobbies,data.token);
        }
    }
}