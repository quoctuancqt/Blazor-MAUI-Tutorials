using System.Text.Json.Serialization;

namespace ToDoShared.Models.Common
{
    public class BaseModelResponse
    {
        public string Id { get; set; }
        [JsonIgnore]
        public string CreatedBy { get; set; }
        [JsonIgnore]
        public DateTime Created { get; set; }
        [JsonIgnore]
        public string LastModifiedBy { get; set; }
        [JsonIgnore]
        public DateTime? LastModified { get; set; }
    }
}
