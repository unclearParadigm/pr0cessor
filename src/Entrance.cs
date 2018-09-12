using System;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using System.Collections.Generic;

using CommandLine;
using CSharpFunctionalExtensions;

using Pr0cessor.Pr0grammApi;
using Pr0cessor.Pr0grammApi.Factories;

using Pr0cessor.Models.Configuration;
using Pr0cessor.Models.Pr0grammApi.Responses;

namespace Pr0cessor {
  public class Entrance {
    private static readonly ISessionStorage sessionStorage;
    static Entrance() {
      sessionStorage = SessionStorageFactory.Create(StorageType.Json, ".pr0auth.json");
    }

    static async Task Main(string[] args) {
      PrintHeader();

      await CommandLine.Parser.Default
      .ParseArguments<Auth, Favs, Stats>(args)
      .MapResult(
        (Auth authArgs) => AuthMain(authArgs),
        (Favs favArgs) => FavsMain(favArgs),
        (Stats statArgs) => StatsMain(statArgs),
        errors => Task.FromResult<int>(Constants.EXITCODE_FAILURE));
    }

    public static async Task<int> AuthMain(Auth authArgs) {
      var api = await Pr0grammApiFactory.Create(
        authArgs.Username,
        authArgs.Password,
        sessionStorage);

      if (api.IsSuccess) {
        Console.WriteLine($"Success! You are now permanently logged in as {authArgs.Username.Trim()}");
        return Constants.EXITCODE_SUCCESS;
      } else {
        Console.WriteLine(api.Error);
        return 0;
      }
    }

    public static async Task<int> FavsMain(Favs favArgs) {
      var api =
        await Pr0grammApiFactory.Create(favArgs.Username, favArgs.Password, sessionStorage);
      if (api.IsFailure) {
        Console.WriteLine(api.Error);
        return Constants.EXITCODE_AUTHERR;
      }

      var favorites = await api.Value.GetFavoritesAsync(favArgs.User.Trim());
      if (favorites.IsFailure) {
        Console.WriteLine(favorites.Error);
        return Constants.EXITCODE_FAILURE;
      }

      var filteredFavorites = favorites.Value
        .Where(fav => (favArgs.ImagesOnly && ApiHelpers.IsImage(fav))
                      || (favArgs.VideosOnly && ApiHelpers.IsVideo(fav))
                      || (favArgs.Everything)).ToList();

      return await DownloadWithProgressIndicator(
        filteredFavorites,
        favArgs.Destination.Trim());
    }

    private static async Task<int> StatsMain(Stats statArgs) {
      await Task.Delay(1);
      throw new NotImplementedException("Status is not implemented yet.");
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

    private static void PrintHeader() {
      Console.WriteLine("------------------------------------------");
      Console.WriteLine(Constants.HEADER);
      Console.WriteLine("------------------------------------------");
    }
  }
}
