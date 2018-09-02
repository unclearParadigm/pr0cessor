using System;
using System.Net;
using Pr0cessor.Models.Pr0grammApi.Responses;

namespace Pr0cessor.Models.Pr0grammApi {
  public class Session {
    public LoginResponse Login { get; set; }
    public Cookie PPCookie { get; set; }
    public Cookie MECookie { get; set; }
    public string Username { get; set; }
  }
}
