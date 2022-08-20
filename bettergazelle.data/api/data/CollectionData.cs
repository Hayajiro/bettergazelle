using Newtonsoft.Json;

namespace bettergazelle.data.api.data
{
    [Serializable]
    public class CollectionData
    {
        [JsonProperty("id")]
        public int Id { get; set; }

        [JsonProperty("name")]
        public string Name { get; set; }

        [JsonProperty("bbDescription")]
        public string BBDescription { get; set; }

        [JsonProperty("description")]
        public string Description { get; set; }

        [JsonProperty("image")]
        public string Image { get; set; }

        [JsonProperty("packUrl")]
        public string PackUrl { get; set; }

        [JsonProperty("deleted")]
        public bool Deleted { get; set; }

        [JsonProperty("collageCategoryID")]
        public int CollageCategoryId { get; set; }

        [JsonProperty("collageCategoryName")]
        public string CollageCategoryName { get; set; }

        [JsonProperty("locked")]
        public bool Locked { get; set; }

        [JsonProperty("torrentGroupIDList")]
        public List<string> TorrentGroupIdList { get; set; }
    }
}