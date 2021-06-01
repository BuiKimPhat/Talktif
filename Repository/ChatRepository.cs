using System;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Text;
using Newtonsoft.Json;
using Talktif.Models;

namespace Talktif.Repository
{
    public class ChatRepo
    {
        private static ChatRepo _Instance;
        public static ChatRepo Instance {
            get 
            {
                if(_Instance == null)
                _Instance = new ChatRepo();
                return _Instance;
            }
            private set { }
        }
        private const string UriString = "https://talktifapi.azurewebsites.net/api/Chat/";
        public HttpResponseMessage CreateChatRoom(CreateChatRoomRequest newchatroom)
        {
            using(var client = new HttpClient())
            {
                client.BaseAddress = new Uri(UriString);
                client.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer",UserRepo.Instance.data.token);
                var createchatroom = client.PostAsJsonAsync("CreateChatRoom",newchatroom);
                createchatroom.Wait();
                var result = createchatroom.Result;
                return result;
            }
        }
        public HttpResponseMessage FetchAllChatRoom(int userid)
        {
            using (var client = new HttpClient())
            {
                client.BaseAddress = new Uri(UriString);
                client.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer",UserRepo.Instance.data.token);
                var fetchallchatroom = client.GetAsync("FetchAllChatRoom/" + userid);
                fetchallchatroom.Wait();
                var result = fetchallchatroom.Result;
                return result;
            }
        }
        public HttpResponseMessage FecthMessage(FetchMessageRequest request)
        {
            using(var client = new HttpClient())
            {
                client.BaseAddress = new Uri(UriString);
                client.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer",UserRepo.Instance.data.token);
                var fetchMessage = client.GetAsync("FetchMessage/" + request.RoomId +"/" + request.Top);
                fetchMessage.Wait();
                var result = fetchMessage.Result;
                return result;
            }
        }
        public HttpResponseMessage GetChatRoomInfo(GetChatRoomInfoRequest room)
        {
            using (var client = new HttpClient())
            {
                client.BaseAddress = new Uri(UriString);
                client.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer",UserRepo.Instance.data.token);
                var addMessage = client.GetAsync("GetChatRoomInfo/" + room.Id + "/" + room.UserId);
                addMessage.Wait();
                var  result = addMessage.Result;
                return result;
            }
        }
        public HttpResponseMessage AddMessage(AddMessageRequest mess)
        {
            using (var client = new HttpClient())
            {
                client.BaseAddress = new Uri(UriString);
                client.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer",UserRepo.Instance.data.token);
                var addMessage = client.PostAsJsonAsync("AddMessage",mess);
                addMessage.Wait();
                var request = addMessage.Result;
                return request;
            }
        }
        public HttpResponseMessage  DeleteChatRoom(DeleteChatRoomRequest d)
        {
            using(var client = new HttpClient())
            {
                client.BaseAddress = new Uri(UriString);
                client.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer",UserRepo.Instance.data.token);
                var deleteChatRoom = client.DeleteAsync("Delete/" + d.UserId + "/" + d.RoomId);
                deleteChatRoom.Wait();
                var request = deleteChatRoom.Result;
                return request;
            }
        }
    } 
}