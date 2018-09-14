using System;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using System.Collections.Generic;

using CommandLine;
using CSharpFunctionalExtensions;

using Pr0cessor.Pr0grammApi;
using Pr0cessor.Pr0grammApi.Factories;

using Pr0cessor.Models.Pr0grammApi.Responses;
using Pr0cessor.Models.Configuration.CmdVerbs;
using Pr0cessor.Models.Configuration.CmdVerbs.Shared;

namespace Pr0cessor {
  public static class Subroutines {
    public static async Task<int> AuthMain(Auth authArgs, ISessionStorage sessionStorage) {
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

    public static async Task<int> FavoritesMain(Favs favArgs, ISessionStorage sessionStorage) {
      var api = await Pr0grammApiFactory.Create(favArgs.Username, favArgs.Password, sessionStorage);
      if (api.IsFailure) {
        Console.WriteLine(api.Error);
        return Constants.EXITCODE_AUTHERR;
      }

      var favorites = await api.Value.GetFavoritesAsync(favArgs.User.Trim());
      if (favorites.IsFailure) {
        Console.WriteLine(favorites.Error);
        return Constants.EXITCODE_FAILURE;
      }

      return await ItemLoader.DownloadWithProgressIndicator(
        favorites.Value.ApplyFilter(favArgs),
        favArgs.Destination.Trim());
    }

    public static async Task<int> UploadsMain(Uploads upsArgs, ISessionStorage sessionStorage) {
      var api = await Pr0grammApiFactory.Create(upsArgs.Username, upsArgs.Password, sessionStorage);
      if (api.IsFailure) {
        Console.WriteLine(api.Error);
        return Constants.EXITCODE_AUTHERR;
      }

      var favorites = await api.Value.GetUploadsAsync(upsArgs.User.Trim());
      if (favorites.IsFailure) {
        Console.WriteLine(favorites.Error);
        return Constants.EXITCODE_FAILURE;
      }
      
      return await ItemLoader.DownloadWithProgressIndicator(
        favorites.Value.ApplyFilter(upsArgs),
        upsArgs.Destination.Trim());
    }

    private static IEnumerable<Item> ApplyFilter(this IEnumerable<Item> items, ItemsFilter itemsFilter) {
      return items
        .Where(fav => (
            itemsFilter.ImagesOnly && ApiHelpers.IsImage(fav))
            || (itemsFilter.VideosOnly && ApiHelpers.IsVideo(fav))
            || (itemsFilter.Everything))
        .ToList();
    }
  }
}
