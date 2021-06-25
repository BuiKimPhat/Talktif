using System.Collections.Generic;
using Microsoft.AspNetCore.Http;
using Newtonsoft.Json;
using Talktif.Models;
using Talktif.Repository;

namespace Talktif.Service
{
    public interface IChatService
    {
        List<Room_Infor> FetchAllChatRoom(HttpRequest Request, HttpResponse Response);
        List<Message> FetchMessage(HttpRequest Request, HttpResponse Response, int ID_Room, int TopMessage);
        ChatRoom_Info GetChatRoomInfo(HttpRequest Request, HttpResponse Response, int ID_Room);
        void AddMessage(HttpRequest Request, HttpResponse Response, string message, int IDChatRoom);
    }
    public class ChatService : IChatService
    {
        private IChatRepo _chatRepo;
        private IUserService _userService;
        public ChatService(IChatRepo chatRepo, IUserService userService)
        {
            _chatRepo = chatRepo;
            _userService = userService;
        }
        public List<Room_Infor> FetchAllChatRoom(HttpRequest Request, HttpResponse Response)
        {
            var cookie = _userService.ReadCookie(Request);
            var result = _chatRepo.FetchAllChatRoom(cookie.id, cookie.token);
            string a = result.Content.ReadAsStringAsync().Result;
            if (result.IsSuccessStatusCode)
            {
                return JsonConvert.DeserializeObject<List<Room_Infor>>(a);
            }
            else
            {
                _userService.RefreshToken(Response, cookie);
                cookie = _userService.ReadCookie(Request);
                result = _chatRepo.FetchAllChatRoom(cookie.id, cookie.token);
                a = result.Content.ReadAsStringAsync().Result;

                return JsonConvert.DeserializeObject<List<Room_Infor>>(a);
            }
        }
        public List<Message> FetchMessage(HttpRequest Request, HttpResponse Response, int ID_Room, int TopMessage)
        {
            var cookie = _userService.ReadCookie(Request);
            var result = _chatRepo.FecthMessage(cookie.id, ID_Room, TopMessage, cookie.token);
            string a = result.Content.ReadAsStringAsync().Result;
            if (result.IsSuccessStatusCode)
            {
                return JsonConvert.DeserializeObject<List<Message>>(a);
            }
            else
            {
                _userService.RefreshToken(Response, cookie);
                cookie = _userService.ReadCookie(Request);
                result = _chatRepo.FecthMessage(cookie.id, ID_Room, TopMessage, cookie.token);
                a = result.Content.ReadAsStringAsync().Result;

                return JsonConvert.DeserializeObject<List<Message>>(a);
            }
        }
        public ChatRoom_Info GetChatRoomInfo(HttpRequest Request, HttpResponse Response, int ID_Room)
        {
            var cookie = _userService.ReadCookie(Request);
            var result = _chatRepo.GetChatRoomInfo(ID_Room, cookie.id, cookie.token);
            string a = result.Content.ReadAsStringAsync().Result;
            if (result.IsSuccessStatusCode)
            {
                return JsonConvert.DeserializeObject<ChatRoom_Info>(a);
            }
            else
            {
                _userService.RefreshToken(Response, cookie);
                cookie = _userService.ReadCookie(Request);
                result = _chatRepo.GetChatRoomInfo(ID_Room, cookie.id, cookie.token);
                a = result.Content.ReadAsStringAsync().Result;

                return JsonConvert.DeserializeObject<ChatRoom_Info>(a);
            }
        }
        public void AddMessage(HttpRequest Request, HttpResponse Response, string message, int IDChatRoom)
        {
            var cookie = _userService.ReadCookie(Request);
            var result = _chatRepo.AddMessage(message, cookie.id, IDChatRoom, cookie.token);
            if (!(result.IsSuccessStatusCode))
            {
                _userService.RefreshToken(Response, cookie);
                cookie = _userService.ReadCookie(Request);
                result = _chatRepo.AddMessage(message, cookie.id, IDChatRoom, cookie.token);
            }
        }
    }
}