using System;
using System.Text.Json;
using TimesNewsApp.Models;

namespace TimesNewsApp.Services
{
    public class FileService
    {

        List<Genre> genre = new();
        public FileService()
        {
        }

        public async Task<List<Genre>> GetGenreAsync()
        {
            //Add FileSystem to read the json and deserialize json to object
            var stream = await FileSystem.OpenAppPackageFileAsync("genrelist.json");
            var reader = new StreamReader(stream);
            var contents = await reader.ReadToEndAsync();
            genre = JsonSerializer.Deserialize<List<Genre>>(contents);

            return genre;
        }
    }
}

