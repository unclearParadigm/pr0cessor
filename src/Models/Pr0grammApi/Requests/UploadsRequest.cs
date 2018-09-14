using System;
using System.Net.Http;
using System.Collections.Generic;

using Pr0cessor.Models.Pr0grammApi;

namespace Pr0cessor.Models.Pr0grammApi.Requests {
  public class UploadsRequest {
    public string User { get; set; }
    public string Flags { get; set; }
    public string Older { get; set; }

    public UploadsRequest(string user, Flags flags, long? older=null) {
      User = user;
      Flags = Convert.ToString((int)flags);
      Older = older?.ToString();
    }
    
    public FormUrlEncodedContent ToFormUrlEncodedContent() {
      var dict = new Dictionary<string, string> {
            {"user", User },
            {"flags", Flags },
      };

      if(!String.IsNullOrEmpty(Older)){
        dict.Add("older", Older.ToString());
      }

      return new FormUrlEncodedContent(dict);
    }
  }
}
