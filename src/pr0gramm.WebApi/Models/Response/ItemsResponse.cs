using System.Collections.Generic;
using Newtonsoft.Json;
using pr0gramm.WebApi.Models.Data;

namespace pr0gramm.WebApi.Models.Response {
  public class ItemsResponse : BaseApiResponse {
    [JsonProperty(PropertyName = "atEnd")]
    public bool EndOfItemsReached { get; set; }
    [JsonProperty(PropertyName = "atStart")]
    public bool AtBeginningOfItems { get; set; }

    [JsonProperty(PropertyName = "error")] 
    public string Error { get; set; }

    [JsonProperty(PropertyName = "items")]
    public List<Item> Items { get; set; }
  }
}
