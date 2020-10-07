using System.Collections.Generic;
using System.Net.Http;

namespace pr0gramm.WebApi.Models.Request {
  public class BaseApiRequest {
    public string ApiScheme { get; set; }
    public string ApiDomain { get; set; }
    public string ApiEndpoint { get; set; }
    
    public BaseApiRequest(string apiScheme, string apiDomain, string apiEndpoint) {
      ApiScheme = apiScheme;
      ApiDomain = apiDomain;
      ApiEndpoint = apiEndpoint;
    }
    public virtual HttpContent AsFormUrlEncoded() {
      return new FormUrlEncodedContent(new List<KeyValuePair<string, string>>());
    }
  }
}
