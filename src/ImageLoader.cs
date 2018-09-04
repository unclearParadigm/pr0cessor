using System;
using System.Net;
using System.Threading.Tasks;

using CSharpFunctionalExtensions;

namespace Pr0cessor {
  public static class ImageLoader {
    public static async Task<Result<string, string>> DownloadImage(Uri uri, string dest, Action onFinish) {
      try {
      using (WebClient client = new WebClient()) {
        await client.DownloadFileTaskAsync(uri, dest);
        onFinish();
        return Result.Ok<string, string>($"Download Ok: {uri.ToString()}");
      }
      } catch(Exception exc) {
          Console.WriteLine($"WHOOPS, {exc.Message}, {uri.ToString()}");
          return Result.Fail<string, string>(exc.Message);
      }
    }
  }
}
