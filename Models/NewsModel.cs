using System;
using System.Collections.Generic;

using System.Globalization;
using Newtonsoft.Json;
using Newtonsoft.Json.Converters;

namespace TimesNewsApp.Models
{
	public class NewsModel
	{
        [JsonProperty("status")]
        public string Status { get; set; }

        [JsonProperty("copyright")]
        public string Copyright { get; set; }

        [JsonProperty("section")]
        public string Section { get; set; }

        [JsonProperty("last_updated")]
        public DateTimeOffset LastUpdated { get; set; }

        [JsonProperty("num_results")]
        public long NumResults { get; set; }

        [JsonProperty("results")]
        public Result[] Results { get; set; }
    }

    public partial class Result
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
        public ItemType ItemType { get; set; }

        [JsonProperty("updated_date")]
        public DateTimeOffset UpdatedDate { get; set; }

        [JsonProperty("created_date")]
        public DateTimeOffset CreatedDate { get; set; }

        [JsonProperty("published_date")]
        public DateTimeOffset PublishedDate { get; set; }

        [JsonProperty("material_type_facet")]
        public string MaterialTypeFacet { get; set; }

        [JsonProperty("kicker")]
        public Kicker Kicker { get; set; }

        [JsonProperty("des_facet")]
        public string[] DesFacet { get; set; }

        [JsonProperty("org_facet")]
        public string[] OrgFacet { get; set; }

        [JsonProperty("per_facet")]
        public string[] PerFacet { get; set; }

        [JsonProperty("geo_facet")]
        public string[] GeoFacet { get; set; }

        [JsonProperty("multimedia")]
        public Multimedia[] Multimedia { get; set; }

        [JsonProperty("short_url")]
        public string ShortUrl { get; set; }
    }

    public partial class Multimedia
    {
        [JsonProperty("url")]
        public Uri Url { get; set; }

        [JsonProperty("format")]
        public Format Format { get; set; }

        [JsonProperty("height")]
        public long Height { get; set; }

        [JsonProperty("width")]
        public long Width { get; set; }

        [JsonProperty("type")]
        public TypeEnum Type { get; set; }

        [JsonProperty("subtype")]
        public Subtype Subtype { get; set; }

        [JsonProperty("caption")]
        public string Caption { get; set; }

        [JsonProperty("copyright")]
        public string Copyright { get; set; }
    }

    public enum ItemType { Article, Interactive, Promo };

    public enum Kicker { Empty, Letter266, TheSaturdayProfile };

    public enum Format { LargeThumbnail, SuperJumbo, ThreeByTwoSmallAt2X };

    public enum Subtype { Photo };

    public enum TypeEnum { Image };
}

    