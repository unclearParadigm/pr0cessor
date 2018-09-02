using System;
using System.Collections.Generic;

using Newtonsoft.Json;

namespace Pr0cessor.Models.Pr0grammApi.Responses {
  public class FavsResponse {
    [JsonProperty(PropertyName = "error")]
    public string Error { get; set; }

    [JsonProperty(PropertyName = "atEnd")]
    public bool AtEnd { get; set; }

    [JsonProperty(PropertyName = "atStart")]
    public bool AtStart { get; set; }

    [JsonProperty(PropertyName = "items")]
    public IEnumerable<FavoriteItem> Favorites { get; set; }

    public bool HasError => !string.IsNullOrEmpty(Error);
  }

  public class FavoriteItem {
    [JsonProperty(PropertyName = "id")]
    public long Id { get; set; }

    [JsonProperty(PropertyName = "promoted")]
    public long Promoted { get; set; }

    [JsonProperty(PropertyName = "up")]
    public long Upvotes { get; set; }

    [JsonProperty(PropertyName = "down")]
    public long Downvotes { get; set; }

    [JsonProperty(PropertyName = "created")]
    public long CreatedTimestamp { get; set; }

    [JsonProperty(PropertyName = "image")]
    public string ImageUriRelative { get; set; }
    [JsonProperty(PropertyName = "thumb")]
    public string ThumbUriRelative { get; set; }

    [JsonProperty(PropertyName = "height")]
    public int Height { get; set; }
    [JsonProperty(PropertyName = "width")]
    public int Width { get; set; }

    [JsonProperty(PropertyName = "source")]
    public string Source { get; set; }

    [JsonProperty(PropertyName = "user")]
    public string Uploader { get; set; }

    [JsonProperty(PropertyName = "flags")]
    public int FlagsRaw { get; set; }

    public Flags Flags => (Flags)FlagsRaw;
    public DateTime CreationDate => DateTimeOffset
                                    .FromUnixTimeSeconds(CreatedTimestamp)
                                    .DateTime;

    public string FileExtension => System.IO.Path.GetExtension(ImageUriRelative);
  }
}
