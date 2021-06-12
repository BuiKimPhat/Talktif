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
        Statistic GetStatisticData(string token);
        HttpResponseMessage GetUser(long first, long last, string token);
        HttpResponseMessage GetReport(long first,long last,string token);
        long GetNumberofUser(string token);
        long GetNumberofReport(string token);
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
        public Statistic GetStatisticData(string token)
        {
            var result = _adminRepo.Statistic(token);
            var statisticsResult = result.Content.ReadAsStringAsync().Result;
            return JsonConvert.DeserializeObject<Statistic>(statisticsResult);
        }
        public HttpResponseMessage GetUser(long first, long last, string token)
        {
            return _adminRepo.GetAllUser(first, last, token);
        }
        public HttpResponseMessage GetReport(long first,long last, string token)
        {
            return _adminRepo.GetAllReport(first,last,token);
        }
        public long GetNumberofUser(string token)
        {
            Statistic a = GetStatisticData(token);
            return a.numOfUser;
        }
        public long GetNumberofReport(string token)
        {
            Statistic a = GetStatisticData(token);
            return a.numOfReport;
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