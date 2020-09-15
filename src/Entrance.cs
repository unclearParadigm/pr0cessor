using System;
using System.Threading.Tasks;

using CommandLine;
using pr0cessor.Models.CliArguments;
using Pr0cessor.Pr0grammApi.Factories;

namespace Pr0cessor {
    public class Entrance {
    static async Task Main(string[] args) {
      PrintHeader();

      var sessionStorage = 
        SessionStorageFactory.Create(StorageType.Json, ".pr0auth.json");

      await CommandLine.Parser.Default
      .ParseArguments<Auth, Favs, Uploads>(args)
      .MapResult(
        (Auth authArgs) => Subroutines.AuthMain(authArgs, sessionStorage),
        (Favs favArgs) => Subroutines.FavoritesMain(favArgs, sessionStorage),
        (Uploads upsArgs) => Subroutines.UploadsMain(upsArgs, sessionStorage),
        errors => Task.FromResult<int>(Constants.EXITCODE_FAILURE));
    }

    private static void PrintHeader() {
      Console.WriteLine("------------------------------------------");
      Console.WriteLine(Constants.HEADER);
      Console.WriteLine("------------------------------------------");
    }
  }
}
