using Microsoft.AspNet.SignalR;
using Newtonsoft.Json;
using System;
using System.Net.Http;
using System.Text;

namespace Poker.Client.Hubs
{
    public class ActiveGame : Hub
    {
        public async void JoinGame()
        {
            var payload = JsonConvert.SerializeObject(new {PlayerId = Guid.NewGuid()});

            using(var httpClient = new HttpClient())
            {
                var response = await httpClient.PostAsync("http://localhost:51387/api/games/737ce07c-ede5-422b-bc36-720d1ae865fd/players", new StringContent(payload, Encoding.UTF8, "application/json"));
            }
        }
    }
}