using System;
using System.Net.Http;
using System.Collections.Generic;

using Pr0cessor.Models.Pr0grammApi;

namespace Pr0cessor.Models.Pr0grammApi.Requests {
  public class FavsRequest {
    public string Likes { get; set; }
    public string Flags { get; set; }

    public FavsRequest(string likes, Flags flags) {
      Likes = likes;
      Flags = Convert.ToString((int)flags);
    }
    
    public FormUrlEncodedContent ToFormUrlEncodedContent() {
      var dict = new Dictionary<string, string> {
            {"likes", Likes },
            {"flags", Flags.ToString() }
      };
      return new FormUrlEncodedContent(dict);
    }
  }
}
