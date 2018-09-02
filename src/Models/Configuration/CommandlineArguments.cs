using System;
using CommandLine;

namespace Pr0cessor.Models.Configuration {
  [Verb("favs", HelpText = "Download favs / liked content from pr0gramm")]
  public class Favs {
    [Option('f', "from", Required = true, HelpText = "The username the favs belong to")]
    public string User { get; set; }

    [Option('u', "username", Required = true, HelpText = "Your username, required for authentication")]
    public string Username { get; set; }

    [Option('p', "password", Required = true, HelpText = "Your password, required for authentication")]
    public string Password { get; set; }

    [Option('e', "everything", Default = true, HelpText = "Downloads everything")]
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
