using System;

using Pr0cessor.Models.Pr0grammApi.Responses;


namespace Pr0cessor.Pr0grammApi {
  public static class ApiHelpers {

    public static Uri GetDownloadLink(FavoriteItem item) {
      var preparedImageUrl = item.ImageUriRelative.Replace("\\", "");
      switch (item.FileExtension.ToLower()) {
        case "webm":
        case "mp4":
          return new Uri($"{ApiConstants.VideoEndpoint}/{preparedImageUrl}");
        default:
          return new Uri($"{ApiConstants.ImageEndpoint}/{preparedImageUrl}");
      }
    }
  }
}
