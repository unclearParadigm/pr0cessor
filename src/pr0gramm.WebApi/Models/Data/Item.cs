using System;
using Newtonsoft.Json;

namespace pr0gramm.WebApi.Models.Data {
  public class Item {
    [JsonProperty(PropertyName = "id")]
    public long Id { get; set; }
    [JsonProperty(PropertyName = "up")]
    public long Upvotes { get; set; }
    [JsonProperty(PropertyName = "down")]
    public long Downvotes { get; set; }
    [JsonProperty(PropertyName = "created")]
    public DateTime UploadDateTime { get; set; }
    [JsonProperty(PropertyName = "userId")]
    public long UserId { get; set; }
    [JsonProperty(PropertyName = "image")]
    public string ImagePath { get; set; }
    [JsonProperty(PropertyName = "thumb")]
    public string ThumbnailPath { get; set; }
    [JsonProperty(PropertyName = "fullsize")]
    public string FullsizeImagePath { get; set; }
    [JsonProperty(PropertyName = "height")]
    public int Height { get; set; }
    [JsonProperty(PropertyName = "width")]
    public int Width { get; set; }
    [JsonProperty(PropertyName = "audio")]
    public bool HasAudio { get; set; }
    [JsonProperty(PropertyName = "source")]
    public string ImageSource { get; set; }
    [JsonProperty(PropertyName = "user")]
    public string Username { get; set; }
    [JsonProperty(PropertyName = "flags")]
    public int Flags { get; set; }
    [JsonProperty(PropertyName = "mark")]
    public int Mark { get; set; }
    [JsonProperty(PropertyName = "gift")]
    public int Gift { get; set; }
  }
}
