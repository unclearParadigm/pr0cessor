using System;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using System.Collections.Generic;

using CommandLine;
using CSharpFunctionalExtensions;

using Pr0cessor.Pr0grammApi;
using Pr0cessor.Models.Configuration;
using Pr0cessor.Models.Pr0grammApi.Responses;

namespace Pr0cessor {
  public class Program {
    static async Task Main(string[] args) {
      PrintHeader();

      await CommandLine.Parser.Default
      .ParseArguments<Favs, Stats>(args)
      .MapResult(
        (Favs favArgs) => FavsMain(favArgs),
        (Stats statArgs) => StatsMain(statArgs),
        errors => Task.FromResult<int>(0));
      
      Console.WriteLine("Ok");
    }

    public static async Task<int> FavsMain(Favs favArgs) {
      var api = CreatePr0grammApi("");

      var login = await api.LoginAsync(favArgs.Username.Trim(), favArgs.Password.Trim());
      if (login.IsFailure) {
        Console.WriteLine(login.Error);
        return Constants.EXITCODE_AUTHERR;
      }

      var favorites = await api.GetFavoritesAsync(favArgs.User.Trim());
      if (favorites.IsFailure) {
        Console.WriteLine(favorites.Error);
        return Constants.EXITCODE_FAILURE;
      }

      var filteredFavorites = favorites.Value
        .Where(fav => (favArgs.ImagesOnly && ApiHelpers.IsImage(fav))
                      || (favArgs.VideosOnly && ApiHelpers.IsVideo(fav))
                      || (favArgs.Everything))
        .ToList();

      return await Download(filteredFavorites, favArgs.Destination.Trim());  
    }

    private static async Task<int> StatsMain(Stats statArgs) {
      await Task.Delay(1);
      throw new NotImplementedException("Status is not implemented yet.");
    }

    private static IPr0grammApi CreatePr0grammApi(string mode) {
      // Factory for future-use
      return new Pr0grammApi.Pr0grammApi();
    }

    public static async Task<int> Download(IEnumerable<FavoriteItem> allItems, string destination) {
      Console.WriteLine($"Downloading {allItems.Count()} elements");
      using (var statusBar = new Pr0gressIndicator()) {
        int readyElements = 0;
        var totalElements = allItems.Count();
        Action update = new Action(() => statusBar.Report((double)readyElements++ / totalElements));

        var downloaderTasks = allItems
          .Select(fav => ImageLoader.DownloadImage(
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

    private static void PrintHeader() {
      Console.WriteLine("----------------------------------------");
      Console.WriteLine(Constants.HEADER);
      Console.WriteLine("----------------------------------------");
    }
  }
}
