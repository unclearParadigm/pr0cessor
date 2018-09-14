using System;
using System.Net;
using System.Linq;
using System.Threading.Tasks;
using System.Collections.Generic;

using CSharpFunctionalExtensions;

using Pr0cessor.Models.Pr0grammApi.Responses;

namespace Pr0cessor.Pr0grammApi {
  public static class ItemLoader {
    public static async Task<Result<string, string>> DownloadImage(Uri uri, string dest, Action onFinish) {
      const int maxRetries = 3;
      var retries = 1;

      while (retries <= maxRetries) {
        try {
          using (WebClient client = new WebClient()) {
            await client.DownloadFileTaskAsync(uri, dest);
            onFinish();
            return Result.Ok<string, string>($"Download Ok: {uri.ToString()}");
          }
        } catch {
          // ToDo: Implement Logging (e.g. Log4Net)
        }
        retries++;
      }
      onFinish();
      return Result.Fail<string, string>($"Reached max. retries for {uri.ToString()}");
    }

    public static async Task<int> DownloadWithProgressIndicator(IEnumerable<Item> allItems, string destination) {
      Console.WriteLine($"Downloading {allItems.Count()} elements");
      using (var statusBar = new Pr0gressIndicator()) {
        int readyElements = 0;
        var totalElements = allItems.Count();
        Action update = new Action(() => statusBar.Report((double)readyElements++ / totalElements));

        var downloaderTasks = allItems
          .Select(fav => ItemLoader.DownloadImage(
            ApiHelpers.GetDownloadLink(fav),
            System.IO.Path.Combine(destination, $"{fav.Id.ToString()}_{fav.Uploader}{fav.FileExtension}"),
            update)
          );

        var results = await Task.WhenAll(downloaderTasks);
        return results.All(res => res.IsSuccess)
          ? Constants.EXITCODE_SUCCESS
          : Constants.EXITCODE_FAILURE;
      }
    }
  }
}
