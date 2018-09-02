using System;
using System.Net.Http;
using System.Collections.Generic;

using Pr0cessor.Models.Pr0grammApi;

namespace Pr0cessor.Models.Pr0grammApi.Requests {
  public class FavsRequest {
    public string Likes { get; set; }
    public string Flags { get; set; }

    public bool Self {get; set;}

    public FavsRequest(string likes, Flags flags, bool self) {
      Likes = likes;
      Flags = Convert.ToString((int)flags);
    }
    
    public FormUrlEncodedContent ToFormUrlEncodedContent() {
      var dict = new Dictionary<string, string> {
            {"likes", Likes },
            {"flags", Flags.ToString() },
            {"self", Self.ToString().ToLower()}
      };
      return new FormUrlEncodedContent(dict);
    }
  }
}
