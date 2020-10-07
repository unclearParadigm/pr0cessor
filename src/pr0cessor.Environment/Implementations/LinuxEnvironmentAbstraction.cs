using System;
using System.Diagnostics;
using System.IO;
using CSharpFunctionalExtensions;
using pr0cessor.Environment.Interfaces;
using pr0cessor.Environment.Structures;

namespace pr0cessor.Environment.Implementations {
  public class LinuxEnvironmentAbstraction : IEnvironmentAbstraction {
    public Result OpenBrowser(string url) {
      if (string.IsNullOrWhiteSpace(url))
        return Result.Failure("Url must no be null or whitespace");

      if (File.Exists(url) && !url.StartsWith("file://"))
        url = $"file://{url}";

      var processStartInfo = new ProcessStartInfo {FileName = "xdg-open", Arguments = url};
      var process = Process.Start(processStartInfo);
      return process?.HasExited ?? true 
        ? Result.Failure("Could not start Browser") 
        : Result.Success();
    }

    public Result OpenImageViewer(string fileName) {
      if (string.IsNullOrWhiteSpace(fileName))
        return Result.Failure("Url must no be null or whitespace");

      var processStartInfo = new ProcessStartInfo {FileName = "xdg-open", Arguments = fileName};
      var process = Process.Start(processStartInfo);
      return process?.HasExited ?? true 
        ? Result.Failure("Could not start Browser") 
        : Result.Success();
    }

    public Result<string> SaveFile(string directoryPath, string fileName, byte[] fileContent) {
      if (!Directory.Exists(directoryPath))
        Directory.CreateDirectory(directoryPath);

      var filePath = Path.Join(directoryPath, fileName);
      if (File.Exists(filePath))
        return Result.Failure<string>("The file already exists");

      try {
        File.WriteAllBytes(filePath, fileContent);
      } catch(Exception exc) {
        return Result.Failure<string>($"Could not save File, because {exc.Message}");
      }

      return Result.Success(filePath);
    }

    public string GetWellKnownPath(WellKnownLocations wellKnownLocation) {
      switch (wellKnownLocation) {
        case WellKnownLocations.TempDirectory:
          return "/tmp/";
        case WellKnownLocations.UserConfigDirectory:
          return "~/.config/pr0cessor/";
        default:
          throw new ArgumentOutOfRangeException(nameof(wellKnownLocation), wellKnownLocation, null);
      }
    }
  }
}
