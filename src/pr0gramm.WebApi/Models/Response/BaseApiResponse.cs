using Newtonsoft.Json;
using Newtonsoft.Json.Serialization;

namespace pr0gramm.WebApi.Models.Response {
  public class BaseApiResponse {
    [JsonProperty(PropertyName = "ts")]
    public long Timestamp { get; set; }
    
  }
}
