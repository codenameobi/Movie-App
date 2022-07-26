
using Newtonsoft.Json;
using Newtonsoft.Json.Converters;

namespace TimesNewsApp.Models
{
    // Root myDeserializedClass = JsonConvert.DeserializeObject<Root>(myJsonResponse);
    public class Multimedium
    {
        [JsonProperty("url")]
        public string Url { get; set; }

        [JsonProperty("format")]
        public string Format { get; set; }

        [JsonProperty("height")]
        public int Height { get; set; }

        [JsonProperty("width")]
        public int Width { get; set; }

        [JsonProperty("type")]
        public string Type { get; set; }

        [JsonProperty("subtype")]
        public string Subtype { get; set; }

        [JsonProperty("caption")]
        public string Caption { get; set; }

        [JsonProperty("copyright")]
        public string Copyright { get; set; }
    }

    public class Result
    {
        [JsonProperty("section")]
        public string Section { get; set; }

        [JsonProperty("subsection")]
        public string Subsection { get; set; }

        [JsonProperty("title")]
        public string Title { get; set; }

        [JsonProperty("abstract")]
        public string Abstract { get; set; }

        [JsonProperty("url")]
        public string Url { get; set; }

        [JsonProperty("uri")]
        public string Uri { get; set; }

        [JsonProperty("byline")]
        public string Byline { get; set; }

        [JsonProperty("item_type")]
        public string ItemType { get; set; }

        [JsonProperty("updated_date")]
        public DateTime UpdatedDate { get; set; }

        [JsonProperty("created_date")]
        public DateTime CreatedDate { get; set; }

        [JsonProperty("published_date")]
        public DateTime PublishedDate { get; set; }

        [JsonProperty("material_type_facet")]
        public string MaterialTypeFacet { get; set; }

        [JsonProperty("kicker")]
        public string Kicker { get; set; }

        [JsonProperty("des_facet")]
        public List<string> DesFacet { get; set; }

        [JsonProperty("org_facet")]
        public List<string> OrgFacet { get; set; }

        [JsonProperty("per_facet")]
        public List<string> PerFacet { get; set; }

        [JsonProperty("geo_facet")]
        public List<string> GeoFacet { get; set; }

        [JsonProperty("multimedia")]
        public List<Multimedium> Multimedia { get; set; }

        [JsonProperty("short_url")]
        public string ShortUrl { get; set; }
    }

    public class NewsModel
    {
        [JsonProperty("status")]
        public string Status { get; set; }

        [JsonProperty("copyright")]
        public string Copyright { get; set; }

        [JsonProperty("section")]
        public string Section { get; set; }

        [JsonProperty("last_updated")]
        public DateTime LastUpdated { get; set; }

        [JsonProperty("num_results")]
        public int NumResults { get; set; }

        [JsonProperty("results")]
        public List<Result> Results { get; set; }
    }
}

