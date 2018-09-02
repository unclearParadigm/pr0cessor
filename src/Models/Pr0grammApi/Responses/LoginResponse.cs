using System;
using Newtonsoft.Json;

namespace Pr0cessor.Models.Pr0grammApi.Responses {
  public class LoginResponse {
    [JsonProperty(PropertyName = "success")]
    public bool Success { get; set; }

    [JsonProperty(PropertyName = "ban")]
    public BanInformation Ban { get; set; }

    [JsonProperty(PropertyName = "ts")]
    public long Timestamp { get; set; }

    public bool UserBanned => Ban != null && Ban.Banned;
  }

  public class BanInformation {
    [JsonProperty(PropertyName = "banned")]
    public bool Banned { get; set; }

    [JsonProperty(PropertyName = "till")]
    public long BannedUntilTs { get; set; }

    [JsonProperty(PropertyName = "reason")]
    public string Reason { get; set; }

    public DateTime Until => DateTimeOffset
                             .FromUnixTimeSeconds(BannedUntilTs)
                             .DateTime;
  }
}
