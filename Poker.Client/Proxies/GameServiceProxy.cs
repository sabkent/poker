using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Net.Http.Formatting;
using System.Threading.Tasks;
using System.Web;
using Microsoft.Ajax.Utilities;
using Poker.Client.Models;

namespace Poker.Client.Proxies
{
    public interface IGameServiceProxy
    {
        Task<IEnumerable<GameListItem>> GetGames();
        Task<GameSummary> GetGame(Guid gameId);

        Task BuyIn(Guid gameId);
    }

    public class GameServiceProxy : IGameServiceProxy
    {
        private readonly HttpClient _httpClient;

        public GameServiceProxy()
        {
            _httpClient = new HttpClient
            {
                BaseAddress = new Uri("http://localhost:51387/")
            };
        }

        public async Task<IEnumerable<GameListItem>> GetGames()
        {
            var response = await _httpClient.GetAsync("api/games");

            return await response.Content.ReadAsAsync<IEnumerable<GameListItem>>();
        }

        public async Task<GameSummary> GetGame(Guid gameId)
        {
            var response = await _httpClient.GetAsync(String.Format("api/games/{0}", gameId));
            return await response.Content.ReadAsAsync<GameSummary>();
        }

        public async Task BuyIn(Guid gameId)
        {
            var response = await _httpClient.PostAsync(String.Format("api/games/{0}/players", gameId), new { }, new JsonMediaTypeFormatter());
            var result = await response.Content.ReadAsAsync<HttpResponseMessage>();
        }
    }
}