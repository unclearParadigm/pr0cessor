using CommandLine;
using pr0cessor.Models.CliArguments.Shared;

namespace pr0cessor.Models.CliArguments {
  [Verb("favs", HelpText = "Download favs / liked content from pr0gramm")]
  public class Favs : ItemsFilter {
    [Option('f', "from", Required = true, HelpText = "The username the favs belong to")]
    public string User { get; set; }

    [Option('u', "username", Required = false, Default = null, HelpText = "Your username, required for authentication (if not authed already)")]
    public string Username { get; set; }

    [Option('p', "password", Required = false, Default = null, HelpText = "Your password, required for authentication (if not authed already)")]
    public string Password { get; set; }

    [Option('d', "destination", Default = "", HelpText = "Where to download the files")]
    public string Destination { get; set; }
  }
}
