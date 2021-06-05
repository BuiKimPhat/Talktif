using System;
using System.Collections.Generic;
using System.Net.Http;
using Newtonsoft.Json;
using Talktif.Models;
using Talktif.Repository;

namespace Talktif.Service
{
    public class AdminService
    {
        private static AdminService _Instance;
        public static AdminService Instance
        {
            get
            {
                if (_Instance == null)
                {
                    _Instance = new AdminService();
                }
                return _Instance;
            }
            private set { }
        }
        public Statistic GetStatisticData()
        {
            GetData();
            return AdminRepo.Instance.data;
        }
        public void GetData()
        {
            try
            {
                var result = AdminRepo.Instance.Statistic();
                var statisticsResult = result.Content.ReadAsStringAsync().Result;
                AdminRepo.Instance.data = JsonConvert.DeserializeObject<Statistic>(statisticsResult);
            }
            catch (Exception e)
            {
                Console.WriteLine(e.ToString());
                
                UserService.Instance.RefreshToken();

                var result = AdminRepo.Instance.Statistic();
                var statisticsResult = result.Content.ReadAsStringAsync().Result;
                AdminRepo.Instance.data = JsonConvert.DeserializeObject<Statistic>(statisticsResult);
            }
        }
        public List<user> GetUser(long first,long last)
        {
            List<user> users = new List<user>();
            try
            {
                HttpResponseMessage result = AdminRepo.Instance.GetAllUser(first, last);
                string a = result.Content.ReadAsStringAsync().Result;
                users = JsonConvert.DeserializeObject<List<user>>(a);
                for (int i = 0; i < users.Count; i++)
                {
                    users[i].cityID = AdminRepo.Instance.GetNameCity(Int32.Parse(users[i].cityID));
                }
                return users;
            }
            catch (Exception e)
            {
                Console.WriteLine(e.ToString());

                UserService.Instance.RefreshToken();

                HttpResponseMessage result = AdminRepo.Instance.GetAllUser(8, 0);
                string a = result.Content.ReadAsStringAsync().Result;
                users = JsonConvert.DeserializeObject<List<user>>(a);
                for (int i = 0; i < users.Count; i++)
                {
                    users[i].cityID = AdminRepo.Instance.GetNameCity(Int32.Parse(users[i].cityID));
                }
                return users;
            }
        }
        public long GetNumberofUser()
        {
            return AdminRepo.Instance.data.numOfUser;
        }
    }
}