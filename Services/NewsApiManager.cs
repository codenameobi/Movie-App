using System;
using System.Net.Http.Json;
using Newtonsoft.Json;
using TimesNewsApp.Models;

namespace TimesNewsApp.Services
{
	public class NewsApiManager
	{
        string BaseUrl = "https://api.themoviedb.org/3/";
        string ApiKey = "bf1ae26421bd8938d17efbcbac4e0d58";
        Movie movie = new();
        HttpClient httpClient;

        public NewsApiManager()
        {
            this.httpClient = new HttpClient();
        }

        public async Task<Movie> GetPopularMovie()
        {
            var response = await httpClient.GetAsync(BaseUrl + "movie/popular?api_key=" + ApiKey +"&language=en-US&page=1");

            if (response.IsSuccessStatusCode)
            {
                movie = await response.Content.ReadFromJsonAsync<Movie>();
            }

            return movie;

        }

        
        public async Task<Movie> GetMovie(string title)
        {
            var response = await httpClient.GetAsync(BaseUrl + "search/movie?api_key="+ ApiKey + "&language=en-US&page=1&include_adult=false&query=" + title);

            if (response.IsSuccessStatusCode)
            {
                movie = await response.Content.ReadFromJsonAsync<Movie>();
            }

            return movie;

        }

        
    }
}

