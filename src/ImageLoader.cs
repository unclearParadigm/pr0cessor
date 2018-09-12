using System;
using System.Net;
using System.Threading.Tasks;

using CSharpFunctionalExtensions;

namespace Pr0cessor {
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
  }
}
