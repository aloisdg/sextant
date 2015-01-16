using Newtonsoft.Json;

namespace Goggles.Model
{
    public class GoogleObject
    {
        [JsonProperty(PropertyName = "responseData")]
        public Responsedata ResponseData { get; set; }

        [JsonProperty(PropertyName = "responseDetails")]
        public object ResponseDetails { get; set; }

        [JsonProperty(PropertyName = "responseStatus")]
        public int ResponseStatus { get; set; }
    }

    public class Responsedata
    {
        [JsonProperty(PropertyName = "results")]
        public Result[] Results { get; set; }

        [JsonProperty(PropertyName = "cursor")]
        public Cursor Cursor { get; set; }
    }

    public class Cursor
    {
        [JsonProperty(PropertyName = "resultCount")]
        public string ResultCount { get; set; }

        [JsonProperty(PropertyName = "pages")]
        public Page[] Pages { get; set; }

        [JsonProperty(PropertyName = "estimatedResultCount")]
        public string EstimatedResultCount { get; set; }

        [JsonProperty(PropertyName = "currentPageIndex")]
        public int CurrentPageIndex { get; set; }

        [JsonProperty(PropertyName = "moreResultsUrl")]
        public string MoreResultsUrl { get; set; }

        [JsonProperty(PropertyName = "searchResultTime")]
        public string SearchResultTime { get; set; }
    }

    public class Page
    {
        [JsonProperty(PropertyName = "start")]
        public string Start { get; set; }

        [JsonProperty(PropertyName = "label")]
        public int Label { get; set; }
    }

    public class Result
    {
        public string GsearchResultClass { get; set; }

        [JsonProperty(PropertyName = "unescapedUrl")]
        public string UnescapedUrl { get; set; }

        public string Url { get; set; }

        [JsonProperty(PropertyName = "visibleUrl")]
        public string VisibleUrl { get; set; }

        [JsonProperty(PropertyName = "cacheUrl")]
        public string CacheUrl { get; set; }

        [JsonProperty(PropertyName = "title")]
        public string Title { get; set; }

        [JsonProperty(PropertyName = "titleNoFormatting")]
        public string TitleNoFormatting { get; set; }

        [JsonProperty(PropertyName = "content")]
        public string Content { get; set; }
    }
}
