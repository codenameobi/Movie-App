using System;
using System.Net.Http.Json;
using TimesNewsApp.Models;

namespace TimesNewsApp.Services
{
	public class NewsApiManager
	{

        List<NewsModel> topNewsList = new();
        HttpClient httpClient;

        public NewsApiManager()
        {
            this.httpClient = new HttpClient();
        }

        public async Task<List<NewsModel>> GetTopNews()
        {
            if (topNewsList.Count > 0)
                return topNewsList;

            var response = await httpClient.GetAsync("https://api.nytimes.com/svc/topstories/v2/world.json?api-key=TRiLxeUVTvjS7YN2P1fpAztxlk5uEBLh");

            if (response.IsSuccessStatusCode)
            {
                topNewsList = await response.Content.ReadFromJsonAsync<List<NewsModel>>();
            }

            return topNewsList;

        }
    }
}

