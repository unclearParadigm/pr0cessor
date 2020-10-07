using System.Threading.Tasks;
using CSharpFunctionalExtensions;
using pr0cessor.Environment.Structures;

namespace pr0cessor.Environment.Interfaces {
  public interface IEnvironmentAbstraction {
    Result OpenBrowser(string url);
    Result OpenImageViewer(string fileName);
    Result<string> SaveFile(string directoryPath, string fileName, byte[] fileContent);

    string GetWellKnownPath(WellKnownLocations wellKnownLocation);
  }
}
