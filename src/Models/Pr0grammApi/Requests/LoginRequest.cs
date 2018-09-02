using System.Net.Http;
using System.Collections.Generic;

namespace Pr0cessor.Models.Pr0grammApi.Requests {
  public class LoginRequest {
    public string Name { get; set; }
    public string Password { get; set; }

    public LoginRequest(string username, string password) {
      Name = username;
      Password = password;
    }

    public FormUrlEncodedContent ToFormUrlEncodedContent() {
      var dict = new Dictionary<string, string> {
            {"name", Name },
            {"password", Password }
      };
      return new FormUrlEncodedContent(dict);
    }
  }
}
