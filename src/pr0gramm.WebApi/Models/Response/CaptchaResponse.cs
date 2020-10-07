using Newtonsoft.Json;

namespace pr0gramm.WebApi.Models.Response {
  public class CaptchaResponse : BaseApiResponse {
    [JsonProperty(PropertyName = "token")]
    public string Token { get; set; }
    
    [JsonProperty(PropertyName = "captcha")]
    public string Captcha { get; set; }
  }
}
