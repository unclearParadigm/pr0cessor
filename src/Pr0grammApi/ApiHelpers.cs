using System;

using Pr0cessor.Models.Pr0grammApi.Responses;

namespace Pr0cessor.Pr0grammApi {
  public static class ApiHelpers {

    public static Uri GetDownloadLink(Item item) {
      var preparedImageUrl =
        item.ImageUriRelative.Replace("\\", "");

      if (IsVideo(item))
        return new Uri($"{ApiConstants.VideoEndpoint}/{preparedImageUrl}");

      if (IsImage(item))
        return new Uri($"{ApiConstants.ImageEndpoint}/{preparedImageUrl}");

      throw new Exception("This File-Extension is not yet supported. (Do you maybe use an outdated version of pr0cessor?).");
    }
    public static bool IsVideo(Item item) {
      switch (item.FileExtension.ToLower()) {
        case ".mp4":
        case ".webm":
          return true;

        default:
          return false;
      }
    }

    public static bool IsImage(Item item) {
      switch (item.FileExtension.ToLower()) {
        case ".jpg":
        case ".png":
        case ".gif":
        case ".jpeg":
          return true;

        default:
          return false;
      }
    }
  }
}
