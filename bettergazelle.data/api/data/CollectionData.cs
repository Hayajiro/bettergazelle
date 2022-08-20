using System.Text.Json.Serialization;

namespace bettergazelle.data.api.data
{
    [Serializable]
    public class CollectionData
    {
        [JsonPropertyName("id")]
        public int Id { get; set; }

        [JsonPropertyName("name")]
        public string Name { get; set; }

        [JsonPropertyName("bbDescription")]
        public string BBDescription { get; set; }

        [JsonPropertyName("description")]
        public string Description { get; set; }

        [JsonPropertyName("image")]
        public string Image { get; set; }

        [JsonPropertyName("packUrl")]
        public string PackUrl { get; set; }

        [JsonPropertyName("deleted")]
        public bool Deleted { get; set; }

        [JsonPropertyName("collageCategoryID")]
        public int CollageCategoryId { get; set; }

        [JsonPropertyName("collageCategoryName")]
        public string CollageCategoryName { get; set; }

        [JsonPropertyName("locked")]
        public bool Locked { get; set; }

        [JsonPropertyName("torrentGroupIDList")]
        public List<string> TorrentGroupIdList { get; set; }
    }
}