using Microsoft.AspNet.SignalR;
using Microsoft.AspNet.SignalR.Hubs;

namespace Server
{
    [HubName("TestHub")]
    public class TestHub: Hub
    {
        public void Transporter(string data)
        {
            Clients.All.GetData(data);
        }

        
    }
}
