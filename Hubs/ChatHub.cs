using Microsoft.AspNetCore.SignalR;
using System.Threading.Tasks;
using Talktif.Models;

namespace Talktif.Hubs
{
    public class ChatHub : Hub<IChatClient>
    {
        public async Task SendMessage(string message)
        {
            RandomRoom room = RoomManager.Instance.GetRoom(Context.ConnectionId);
            await Clients.Group(room.ID).ReceiveMessage(Context.ConnectionId, message);
        }
        public async Task AddToQueue()
        {
            RandomRoom room = QueueManager.Instance.Enqueue(new WaitUser
            {
                ConnectionID = Context.ConnectionId
            });

            if (room != null)
            {
                foreach (WaitUser usr in room.Members)
                {
                    await Groups.AddToGroupAsync(usr.ConnectionID, room.ID);
                    await Clients.Group(room.ID).BroadcastMessage($"Người dùng {usr.ConnectionID} đã tham gia phòng chat {room.ID}.");
                }
            }
        }

        public async Task LeaveChat()
        {
            RandomRoom room = RoomManager.Instance.RemoveRoom(Context.ConnectionId);
            if (room != null)
            {
                foreach (WaitUser usr in room.Members)
                {
                    await Groups.RemoveFromGroupAsync(Context.ConnectionId, room.ID);
                    await Clients.Group(room.ID).BroadcastMessage($"Người dùng {usr.ConnectionID} đã rời khỏi phòng chat {room.ID}.");
                }
            }
        }
    }
}