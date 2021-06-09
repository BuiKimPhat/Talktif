using System.Collections.Generic;
using System.Net.Http;
using Newtonsoft.Json;
using Talktif.Models;
using Talktif.Repository;
using System;

namespace Talktif.Service
{
    public interface IUserService
    {
        HttpResponseMessage Sign_Up(SignUpRequest sr);
        HttpResponseMessage Sign_In(LoginRequest lr);
        HttpResponseMessage Get_User_Infor(Cookie_Data cd);
        HttpResponseMessage ResetPass(ResetPassRequest resetPassRequest);
        string RefreshToken(User_Infor user);
        List<City> GetCity();
    }
    public class UserService : IUserService
    {
        private IUserRepo _userRepo;
        public UserService(IUserRepo userRepo)
        {
            _userRepo = userRepo;
        }

        public HttpResponseMessage Sign_Up(SignUpRequest sr)
        {
            return _userRepo.Sign_Up(sr);
        }
        public HttpResponseMessage Sign_In(LoginRequest lr)
        {
            return _userRepo.Sign_In(lr);
        }
        public HttpResponseMessage Get_User_Infor(Cookie_Data cd)
        {
            if(cd == null) Console.WriteLine("User Service errol can't get Cookie data");
            return _userRepo.GetUserByID(cd.id,cd.token);
        }
        public HttpResponseMessage ResetPass(ResetPassRequest resetPassRequest)
        {
            return _userRepo.ResetPass(resetPassRequest);
        }
        public string RefreshToken(User_Infor user)
        {
            RefreshTokenRequest r = new RefreshTokenRequest() { Email = user.email };
            var refreshToken = _userRepo.RefreshToken(r, user.token);
            var result = refreshToken.Content.ReadAsStringAsync().Result;
            Token t = JsonConvert.DeserializeObject<Token>(result);
            return t.token;
        }
        public List<City> GetCity()
        {
            List<City> cities = new List<City>();
            var result = _userRepo.GetAllCityCountry(1);
            string Result = result.Content.ReadAsStringAsync().Result;
            cities = JsonConvert.DeserializeObject<List<City>>(Result);
            return cities;
        }
    }
}