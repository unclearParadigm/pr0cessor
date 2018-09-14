using System;
using System.Net.Http;
using System.Collections.Generic;

using Pr0cessor.Models.Pr0grammApi;

namespace Pr0cessor.Models.Pr0grammApi.Requests {
  public class FavoritesRequest {
    public string Likes { get; set; }
    public string Flags { get; set; }
    public string Older { get; set; }

    public FavoritesRequest(string likes, Flags flags, long? older=null) {
      Likes = likes;
      Flags = Convert.ToString((int)flags);
      Older = older?.ToString();
    }

    public FormUrlEncodedContent ToFormUrlEncodedContent() {
      var dict = new Dictionary<string, string> {
            {"likes", Likes },
            {"flags", Flags.ToString() },
      };

      if(!String.IsNullOrEmpty(Older)){
        dict.Add("older", Older.ToString());
      }

      return new FormUrlEncodedContent(dict);
    }
  }
}
