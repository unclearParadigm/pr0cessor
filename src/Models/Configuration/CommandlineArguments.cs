using System;
using CommandLine;

namespace Pr0cessor.Models.Configuration {
  [Verb("auth", HelpText = "Permanent authentication of specific user (no need to enter username and password everytime)")]
  public class Auth {
    [Option('u', "username", Required = true, HelpText = "Your username, required for authentication")]
    public string Username { get; set; }

    [Option('p', "password", Required = true, HelpText = "Your password, required for authentication")]
    public string Password { get; set; }
  }

  [Verb("favs", HelpText = "Download favs / liked content from pr0gramm")]
  public class Favs {
    [Option('f', "from", Required = true, HelpText = "The username the favs belong to")]
    public string User { get; set; }

    [Option('u', "username", Required = false, Default = null, HelpText = "Your username, required for authentication (if not authed already)")]
    public string Username { get; set; }

    [Option('p', "password", Required = false, Default = null, HelpText = "Your password, required for authentication (if not authed already)")]
    public string Password { get; set; }

    [Option('e', "everything", Default = false, HelpText = "Downloads everything")]
    public bool Everything { get; set; }

    [Option('i', "imagesOnly", Default = false, HelpText = "Downloads only images")]
    public bool ImagesOnly { get; set; }

    [Option('v', "videosOnly", Default = false, HelpText = "Downloads only videos")]
    public bool VideosOnly { get; set; }

    [Option('d', "destination", Default = "", HelpText = "Where to download the files")]
    public string Destination { get; set; }
  }

  [Verb("stats", HelpText = "View live-stats by User from pr0gramm")]
  public class Stats {
    [Option('f', "from", Required = true, HelpText = "The username the favs belong to")]
    public string User { get; set; }

    [Option('u', "username", Required = true, HelpText = "Your username, required for authentication")]
    public string Username { get; set; }

    [Option('p', "password", Required = true, HelpText = "Your password, required for authentication")]
    public string Password { get; set; }
  }
}
