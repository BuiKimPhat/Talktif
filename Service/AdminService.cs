using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Newtonsoft.Json;
using Talktif.Models;
using Talktif.Repository;

namespace Talktif.Service
{
    public interface IAdminService
    {
        Task<Statistic> GetStatisticData(HttpRequest Request, HttpResponse Response);
        Task<List<user>> GetAllUser(HttpRequest Request, HttpResponse Response, long first, long last);
        Task<List<Report_Infor>> GetAllReport(HttpRequest Request, HttpResponse Response, long first, long last);
        Task<long> GetNumberofUser(HttpRequest Request, HttpResponse Response);
        Task<long> GetNumberofReport(HttpRequest Request, HttpResponse Response);
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
        public async Task<Statistic> GetStatisticData(HttpRequest Request, HttpResponse Response)
        {
            Statistic statistic = new Statistic();
            Cookie_Data cookie_Data = _userService.ReadUserCookie(Request);
            var result = await _adminRepo.Statistic(cookie_Data.token);
            string statisticsResult = result.Content.ReadAsStringAsync().Result;
            try
            {
                statistic = JsonConvert.DeserializeObject<Statistic>(statisticsResult);
                return statistic;
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
                await _userService.RefreshToken(Response, cookie_Data);
                cookie_Data = _userService.ReadUserCookie(Request);
                result = await _adminRepo.Statistic(cookie_Data.token);
                statisticsResult = result.Content.ReadAsStringAsync().Result;
                return JsonConvert.DeserializeObject<Statistic>(statisticsResult);
            }
        }
        public async Task<List<user>> GetAllUser(HttpRequest Request, HttpResponse Response, long first, long last)
        {
            List<user> users = new List<user>();
            Cookie_Data cookie_Data = _userService.ReadUserCookie(Request);
            var result = await _adminRepo.GetAllUser(first, last, cookie_Data.token);
            string a = result.Content.ReadAsStringAsync().Result;
            if (result.IsSuccessStatusCode)
            {
                users = JsonConvert.DeserializeObject<List<user>>(a);
                for (int i = 0; i < users.Count; i++)
                {
                    users[i].cityID = await _userService.GetNameCity(Int32.Parse(users[i].cityID));
                }
            }
            else
            {
                await _userService.RefreshToken(Response, cookie_Data);
                cookie_Data = _userService.ReadUserCookie(Request);
                result = await _adminRepo.GetAllUser(first, last, cookie_Data.token);
                a = result.Content.ReadAsStringAsync().Result;
                users = JsonConvert.DeserializeObject<List<user>>(a);
                for (int i = 0; i < users.Count; i++)
                {
                    users[i].cityID = await _userService.GetNameCity(Int32.Parse(users[i].cityID));
                }
            }
            return users;
        }
        public async Task<List<Report_Infor>> GetAllReport(HttpRequest Request, HttpResponse Response, long first, long last)
        {
            List<Report_Infor> reports = new List<Report_Infor>();
            Cookie_Data cookie_Data = _userService.ReadUserCookie(Request);
            var result = await _adminRepo.GetAllReport(first, last, cookie_Data.token);
            string a = result.Content.ReadAsStringAsync().Result;
            if (result.IsSuccessStatusCode)
            {
                Console.WriteLine("Success");
                reports = JsonConvert.DeserializeObject<List<Report_Infor>>(a);
            }
            else
            {
                Console.WriteLine("Toang");
                await _userService.RefreshToken(Response, cookie_Data);
                cookie_Data = _userService.ReadUserCookie(Request);
                result = await _adminRepo.GetAllReport(first, last, cookie_Data.token);
                a = result.Content.ReadAsStringAsync().Result;
                reports = JsonConvert.DeserializeObject<List<Report_Infor>>(a);
            }
            return reports;
        }
        public async Task<long> GetNumberofUser(HttpRequest Request, HttpResponse Response)
        {
            Statistic a = await GetStatisticData(Request, Response);
            return a.numOfUser;
        }
        public async Task<long> GetNumberofReport(HttpRequest Request, HttpResponse Response)
        {
            Statistic a = await GetStatisticData(Request, Response);
            return a.numOfReport;
        }
    }
}