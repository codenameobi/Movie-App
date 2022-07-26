using System;
using System.Net.Http.Json;
using Newtonsoft.Json;
using TimesNewsApp.Models;

namespace TimesNewsApp.Services
{
	public class NewsApiManager
	{

        NewsModel topNewsList = new();
        HttpClient httpClient;

        public NewsApiManager()
        {
            this.httpClient = new HttpClient();
        }

        public async Task<NewsModel> GetTopNews()
        {
            var response = await httpClient.GetAsync("https://api.nytimes.com/svc/topstories/v2/world.json?api-key=TRiLxeUVTvjS7YN2P1fpAztxlk5uEBLh");

            if (response.IsSuccessStatusCode)
            {
                topNewsList = await response.Content.ReadFromJsonAsync<NewsModel>();
            }

            return topNewsList;

        }
    }
}

