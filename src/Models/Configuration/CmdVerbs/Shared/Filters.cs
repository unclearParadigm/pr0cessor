using System;
using CommandLine;

namespace Pr0cessor.Models.Configuration.CmdVerbs.Shared {
  public class ItemsFilter {
    [Option('e', "everything", Default = false, HelpText = "Downloads everything")]
    public bool Everything { get; set; }

    [Option('i', "imagesOnly", Default = false, HelpText = "Downloads only images")]
    public bool ImagesOnly { get; set; }

    [Option('v', "videosOnly", Default = false, HelpText = "Downloads only videos")]
    public bool VideosOnly { get; set; }
  }
}
