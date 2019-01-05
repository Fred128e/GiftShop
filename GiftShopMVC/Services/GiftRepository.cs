using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Net.Http;
using GiftShop.Models;
using GiftShopMVC.Models;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;

namespace GiftShopMVC.Services
{
    public class GiftRepository : IGiftRepository
    {
        private const string baseUrl = "https://localhost:44347/";
        private readonly IHttpClientFactory _httpClientFactory;
        public GiftRepository(IHttpClientFactory httpClientFactory)
        {
            _httpClientFactory = httpClientFactory;
        }

        public async Task<IEnumerable<GiftViewModel>> GetGifts()
        {
            List<GiftViewModel> gift = null;
            var httpClient = _httpClientFactory.CreateClient();
            var response = await httpClient
                .GetAsync($"{baseUrl}api/gifts/");
            if (response.IsSuccessStatusCode)
            {
                gift = JsonConvert.DeserializeObject<List<GiftViewModel>>(await response.Content.ReadAsStringAsync());
            }

            return gift;
        }

        public async Task<IEnumerable<GiftViewModel>> GetGenderGift(int id)
        {
            List<GiftViewModel> gift = null;
            var httpClient = _httpClientFactory.CreateClient();
            var response = await httpClient
                .GetAsync($"{baseUrl}api/gifts/gender/{id}");
            if (response.IsSuccessStatusCode)
            {
                gift = JsonConvert.DeserializeObject<List<GiftViewModel>>(await response.Content.ReadAsStringAsync());
            }

            return gift;
        }

        public async Task AddGift(GiftViewModel gift)
        {
            var httpClient = _httpClientFactory.CreateClient();
            var response = await httpClient.PostAsJsonAsync($"{baseUrl}api/gifts", gift);
            if (response.IsSuccessStatusCode)
            {
                JsonConvert.DeserializeObject<List<GiftViewModel>>(await response.Content.ReadAsStringAsync());
            }
        }
    }
}
