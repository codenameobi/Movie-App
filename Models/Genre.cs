using System;
using Newtonsoft.Json;

namespace TimesNewsApp.Models
{
    public class Genre
    {
        [JsonProperty("Id")]
        public string Id { get; set; }

        [JsonProperty("Name")]
        public string Name { get; set; }

        [JsonProperty("Image")]
        public string Image { get; set; }

    }
}

