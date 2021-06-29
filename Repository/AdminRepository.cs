using System;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Threading.Tasks;
using Talktif.Models;

namespace Talktif.Repository
{
    public interface IAdminRepo
    {
        Task<HttpResponseMessage> Statistic(string token);
        Task<HttpResponseMessage> GetAllUser(long From, long To, string token);
        Task<HttpResponseMessage> GetAllReport(long From, long To, string token);
        Task<HttpResponseMessage> UpdateReport(UpdateReportRequest request, string token);
        Task<HttpResponseMessage> UpdateUser(UpdateUserRequest request, string token);
        Task<HttpResponseMessage> DeleteUser(int id, string token);
        Task<HttpResponseMessage> DeleteNonReferenceChatRoom(string token);
        Task<HttpResponseMessage> CreateNewAdmin(SignUpRequest request, string token);
    }
    public class AdminRepo : IAdminRepo
    {
        private const string UriString = "https://talktifapi.azurewebsites.net/api/Admin/";
        public async Task<HttpResponseMessage> Statistic(string token)
        {
            using (var client = new HttpClient())
            {
                client.BaseAddress = new Uri(UriString);
                client.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", token);
                var statistics = await client.GetAsync("Count");
                return statistics;
            }
        }
        public async Task<HttpResponseMessage> GetAllUser(long From, long To, string token)
        {
            using (var client = new HttpClient())
            {
                client.BaseAddress = new Uri(UriString);
                client.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", token);
                var getAllUser = await client.GetAsync("GetAllUser/" + From + "/" + To + "/UserId");
                return getAllUser;
            }
        }
        public async Task<HttpResponseMessage> GetAllReport(long From, long To, string token)
        {
            using (var client = new HttpClient())
            {
                client.BaseAddress = new Uri(UriString);
                client.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", token);
                var getAllReport = await client.GetAsync("GetAllReport/" + From + "/" + To + "/ReportId");
                return getAllReport;
            }
        }
        public async Task<HttpResponseMessage> UpdateReport(UpdateReportRequest request, string token)
        {
            using (var client = new HttpClient())
            {
                client.BaseAddress = new Uri(UriString);
                client.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", token);
                var upDateReport = await client.PutAsJsonAsync("UpdateReport", request);
                return upDateReport;
            }
        }
        public async Task<HttpResponseMessage> UpdateUser(UpdateUserRequest request, string token)
        {
            using (var client = new HttpClient())
            {
                client.BaseAddress = new Uri(UriString);
                client.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", token);
                var upDateUser = await client.PutAsJsonAsync("UpdateUser", request);
                return upDateUser;
            }
        }
        public async Task<HttpResponseMessage> DeleteUser(int id, string token)
        {
            using (var client = new HttpClient())
            {
                client.BaseAddress = new Uri(UriString);
                client.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", token);
                var deleteUser = await client.DeleteAsync("DeleteUser/" + id);
                return deleteUser;
            }
        }
        public async Task<HttpResponseMessage> DeleteNonReferenceChatRoom(string token)
        {
            using (var client = new HttpClient())
            {
                client.BaseAddress = new Uri(UriString);
                client.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", token);
                var deleteNonReferenceChatRoom = await client.DeleteAsync("DeleteNonReferenceChatRoom");
                return deleteNonReferenceChatRoom;
            }
        }
        public async Task<HttpResponseMessage> CreateNewAdmin(SignUpRequest request, string token)
        {
            using (var client = new HttpClient())
            {
                client.BaseAddress = new Uri(UriString);
                client.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", token);
                var createNewAdmin = await client.PostAsJsonAsync("CreateNewAdmin", request);
                return createNewAdmin;
            }
        }
    }
}