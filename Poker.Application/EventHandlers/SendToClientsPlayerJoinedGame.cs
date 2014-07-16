using System.Text;
using Newtonsoft.Json;
using Poker.Core.Events;
using System;
using System.Configuration;
using System.Net.Http;

namespace Poker.Application.EventHandlers
{
    public sealed class SendToClientsPlayerJoinedGame : ISubscribeToEvent<PlayerJoinedGame>
    {
        private readonly string _clientNotificationEndpoint;

        public SendToClientsPlayerJoinedGame()
        {
            _clientNotificationEndpoint = ConfigurationManager.AppSettings["clientNotificationEndpoint"];
        }

        public async void Notify(PlayerJoinedGame playerJoinedGame)
        {
            using (var httpClient = new HttpClient())
            {
                httpClient.BaseAddress = new Uri(_clientNotificationEndpoint);
                var payLoad = JsonConvert.SerializeObject(playerJoinedGame);
                var response = await httpClient.PostAsync("/api/lobby-events/players", new StringContent(payLoad, Encoding.UTF8, "application/json"));
                if(response.IsSuccessStatusCode == false)
                    throw new Exception();
            }
        }
    }
}