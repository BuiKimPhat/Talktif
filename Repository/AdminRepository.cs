using System;
using System.Net.Http;
using System.Net.Http.Headers;
using Talktif.Models;

namespace Talktif.Repository
{
    public class AdminRepo
    {
        private static AdminRepo _Instance;
        public static AdminRepo Instance {
            get 
            {
                if(_Instance == null)
                _Instance = new AdminRepo();
                return _Instance;
            }
            private set { }
        }
        private const string UriString = "https://talktifapi.azurewebsites.net/api/Admin/";
        public HttpResponseMessage Statistic()
        {
            using(var client = new HttpClient())
            {
                client.BaseAddress = new Uri(UriString);
                client.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer",UserRepo.Instance.data.token);
                var statistics = client.GetAsync("Count");
                statistics.Wait();
                return statistics.Result;
            }
        }
        public HttpResponseMessage GetAllUser(GetAllUserRequest request)
        {
            using(var client = new HttpClient())
            {
                client.BaseAddress = new Uri(UriString);
                client.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer",UserRepo.Instance.data.token);
                var getAllUser = client.GetAsync("GetAllUser/" + request.From + "/" + request.To + "/UserId");
                getAllUser.Wait();
                return getAllUser.Result;
            }
        }
        public HttpResponseMessage GetAllReport(GetAllReportRequest request)
        {
            using(var client = new HttpClient())
            {  
                client.BaseAddress = new Uri(UriString);
                client.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", UserRepo.Instance.data.token);
                var getAllReport = client.GetAsync("GetAllReport/" + request.From + "/" + request.To + "/ReportId");
                getAllReport.Wait();
                return getAllReport.Result;
            }
        }
        public HttpResponseMessage UpdateReport(UpdateReportRequest request)
        {
            using(var client = new HttpClient())
            { 
                client.BaseAddress = new Uri(UriString);
                client.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer",UserRepo.Instance.data.token);
                var upDateReport = client.PutAsJsonAsync("UpdateReport",request);
                upDateReport.Wait();
                return upDateReport.Result;
            }
        }
        public HttpResponseMessage UpdateUser(UpdateUserRequest request)
        {
            using(var client = new HttpClient())
            {
                client.BaseAddress = new Uri(UriString);
                client.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer",UserRepo.Instance.data.token);
                var upDateUser = client.PutAsJsonAsync("UpdateUser",request);
                upDateUser.Wait();
                return upDateUser.Result;
            }
        }
        public HttpResponseMessage DeleteUser(int id)
        {
            using(var client = new HttpClient())
            {
                client.BaseAddress = new Uri(UriString);
                client.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer",UserRepo.Instance.data.token);
                var deleteUser = client.DeleteAsync("DeleteUser/" + id);
                deleteUser.Wait();
                return deleteUser.Result;
            }
        }
        public HttpResponseMessage DeleteNonReferenceChatRoom()
        {
            using(var client = new HttpClient())
            {
                client.BaseAddress = new Uri(UriString);
                client.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer",UserRepo.Instance.data.token);
                var deleteNonReferenceChatRoom = client.DeleteAsync("DeleteNonReferenceChatRoom");
                deleteNonReferenceChatRoom.Wait();
                return deleteNonReferenceChatRoom.Result;
            }
        }
        public HttpResponseMessage CreateNewAdmin(SignUpRequest request)
        {
            using(var client = new HttpClient())
            {
                client.BaseAddress = new Uri(UriString);
                client.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer",UserRepo.Instance.data.token);
                var createNewAdmin = client.PostAsJsonAsync("CreateNewAdmin",request);
                createNewAdmin.Wait();
                return createNewAdmin.Result;
            }
        }
    }
}