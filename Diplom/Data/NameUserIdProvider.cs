using Microsoft.AspNetCore.SignalR;

namespace Diplom.Data
{
    public class NameUserIdProvider : IUserIdProvider
    {
        public string GetUserId(HubConnectionContext connection) => connection.User?.Identity?.Name;
        
    }
}
