using System.Collections.Generic;
using System.Net.Http;

namespace pr0gramm.WebApi.Models.Request {
  public class LoginRequest : BaseApiRequest {
    private readonly string _username;
    private readonly string _password;
    private readonly string _captchaValue;
    private readonly string _captchaToken;

    public LoginRequest(string username, string password, string captchaValue, string captchaToken)
      : base("https", Constants.Pr0gramDomain, "/api/user/login") {
      _username = username;
      _password = password;
      _captchaValue = captchaValue;
      _captchaToken = captchaToken;
    }

    public override HttpContent AsFormUrlEncoded() {
      return new FormUrlEncodedContent(new List<KeyValuePair<string, string>>() {
        new KeyValuePair<string, string>("username", _username),
        new KeyValuePair<string, string>("password", _password),
        new KeyValuePair<string, string>("captcha", _captchaValue),
        new KeyValuePair<string, string>("token", _captchaToken)
      });
    }
  }
}
