using System;
using System.Net.Http.Json;
using Newtonsoft.Json;
using TimesNewsApp.Models;

namespace TimesNewsApp.Services
{
	public class NewsApiManager
	{
        string BaseUrl = "http://www.omdbapi.com/?t=captain+america&apikey=a1ee0ea6";
        NewsModel topNewsList = new();
        Movie movie = new();
        HttpClient httpClient;
        NewsModel reviews = new();

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

        public async Task<Movie> GetMovie(string title)
        {
            var response = await httpClient.GetAsync("http://www.omdbapi.com/?t=" + title + "&apikey=a1ee0ea6");

            if (response.IsSuccessStatusCode)
            {
                movie = await response.Content.ReadFromJsonAsync<Movie>();
            }

            return movie;

        }

        public async Task<NewsModel> GetReviews(string name)
        {
            var response = await httpClient.GetAsync("https://api.nytimes.com/svc/movies/v2/reviews/search.json?query=" + name + "&api-key=TRiLxeUVTvjS7YN2P1fpAztxlk5uEBLh");

            if (response.IsSuccessStatusCode)
            {
                reviews = await response.Content.ReadFromJsonAsync<NewsModel>();
            }

            return reviews;

        }
    }
}

