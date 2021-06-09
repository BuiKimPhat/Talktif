using System;
using System.Collections.Generic;
using System.Net.Http;
using Newtonsoft.Json;
using Talktif.Models;
using Talktif.Repository;

namespace Talktif.Service
{
    public interface IAdminService
    {
        Statistic GetStatisticData(Cookie_Data user);
        List<user> GetUser(long first, long last, Cookie_Data user);
        long GetNumberofUser(Cookie_Data cookie);
        string GetNameCity(int cityID);
    }
    public class AdminService : IAdminService
    {
        private IUserService _userService;
        private IAdminRepo _adminRepo;
        public AdminService(
            IAdminRepo adminRepo,
            IUserService userService)
        {
            _userService = userService;
            _adminRepo = adminRepo;
        }
        public Statistic GetStatisticData(Cookie_Data user)
        {
            var result = _adminRepo.Statistic(user.token);
            var statisticsResult = result.Content.ReadAsStringAsync().Result;
            return JsonConvert.DeserializeObject<Statistic>(statisticsResult);
        }
        public List<user> GetUser(long first, long last, Cookie_Data user)
        {
            List<user> users = new List<user>();
            HttpResponseMessage result = _adminRepo.GetAllUser(first, last, user.token);
            string a = result.Content.ReadAsStringAsync().Result;
            users = JsonConvert.DeserializeObject<List<user>>(a);
            for (int i = 0; i < users.Count; i++)
            {
                users[i].cityID = GetNameCity(Int32.Parse(users[i].cityID));
            }
            return users;
        }
        public long GetNumberofUser(Cookie_Data cookie)
        {
            Statistic a = GetStatisticData(cookie);
            return a.numOfUser;
        }
        public string GetNameCity(int cityID)
        {
            foreach (var city in _userService.GetCity())
            {
                if (cityID == city.id) return city.name;
            }
            return "";
        }
    }
}