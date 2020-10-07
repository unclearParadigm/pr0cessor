using Newtonsoft.Json;

namespace pr0gramm.WebApi.Models.Response {
  public class LoginResponse : BaseApiResponse {
    /* {"success":false,"ban":null,"error":"invalidLogin","ts":1601063591,"cache":null,"rt":5,"qc":2} */
    
    [JsonProperty(PropertyName = "success")]
    public bool WasSuccessful { get; set; }
    
    [JsonProperty(PropertyName = "error")]
    public string Error { get; set; }
    
    
    public int Rt { get; set; }
    public int Qt { get; set; }
  }
}
