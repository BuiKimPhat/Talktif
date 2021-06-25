using System;
using System.Net.Http;
using System.Net.Http.Headers;
using Talktif.Models;

namespace Talktif.Repository
{
    public interface IChatRepo
    {
        HttpResponseMessage CreateChatRoom(int this_UserID,int that_UserID,string this_UserIDNickName,string that_UserIDNickName, string token);
        HttpResponseMessage FetchAllChatRoom(int userid, string token);
        HttpResponseMessage FecthMessage(int UserID, int RoomID, int Top, string token);
        HttpResponseMessage GetChatRoomInfo(int ID,int UserID, string token);
        HttpResponseMessage AddMessage(string message,int IDSender,int IDChatRoom, string token);
        HttpResponseMessage  DeleteChatRoom(int UserID,int RoomID, string token);
    }
    public class ChatRepo : IChatRepo
    {
        private const string UriString = "https://talktifapi.azurewebsites.net/api/Chat/";
        public HttpResponseMessage CreateChatRoom(int this_UserID,int that_UserID,string this_UserIDNickName,string that_UserIDNickName, string token)
        {
            using(var client = new HttpClient())
            {
                CreateChatRoomRequest chatroom = new CreateChatRoomRequest()
                {
                    User1Id = this_UserID,
                    User2Id = that_UserID,
                    User1NickName = this_UserIDNickName,
                    User2NickName = that_UserIDNickName
                };
                client.BaseAddress = new Uri(UriString);
                client.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer",token);
                var createchatroom = client.PostAsJsonAsync("CreateChatRoom",chatroom);
                createchatroom.Wait();
                return createchatroom.Result;
            }
        }
        public HttpResponseMessage FetchAllChatRoom(int userid, string token)
        {
            using (var client = new HttpClient())
            {
                client.BaseAddress = new Uri(UriString);
                client.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", token);
                var fetchallchatroom = client.GetAsync("FetchAllChatRoom/" + userid);
                fetchallchatroom.Wait();
                return fetchallchatroom.Result;
            }
        }
        public HttpResponseMessage FecthMessage(int UserID, int RoomID, int Top, string token)
        {
            using(var client = new HttpClient())
            {
                client.BaseAddress = new Uri(UriString);
                client.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", token);
                var fetchMessage = client.GetAsync("FetchMessage/" + UserID + "/" + RoomID +"/" + Top);
                fetchMessage.Wait();
                return fetchMessage.Result;
            }
        }
        public HttpResponseMessage GetChatRoomInfo(int ID,int UserID, string token)
        {
            using (var client = new HttpClient())
            {
                client.BaseAddress = new Uri(UriString);
                client.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer",token);
                var getChatRoomInfo = client.GetAsync("GetChatRoomInfo/" + ID + "/" + UserID);
                getChatRoomInfo.Wait();
                return getChatRoomInfo.Result;
            }
        }
        public HttpResponseMessage AddMessage(string message,int IDSender,int IDChatRoom, string token)
        {
            using (var client = new HttpClient())
            {
                AddMessageRequest mess = new AddMessageRequest()
                {
                    Message = message,
                    IdSender = IDSender,
                    IdChatRoom = IDChatRoom,
                };
                client.BaseAddress = new Uri(UriString);
                client.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer",token);
                var addMessage = client.PostAsJsonAsync("AddMessage",mess);
                addMessage.Wait();
                return addMessage.Result;
            }
        }
        public HttpResponseMessage  DeleteChatRoom(int UserID,int RoomID, string token)
        {
            using(var client = new HttpClient())
            {
                client.BaseAddress = new Uri(UriString);
                client.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", token);
                var deleteChatRoom = client.DeleteAsync("Delete/" + UserID + "/" + RoomID);
                deleteChatRoom.Wait();
                return deleteChatRoom.Result;
            }
        }
    } 
}