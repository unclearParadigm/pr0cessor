using System;
using pr0cessor.Environment.Interfaces;

namespace pr0cessor.Environment.Implementations {
  public static class EnvironmentAbstractionFactory {
    public static IEnvironmentAbstraction Create() {
      switch (System.Environment.OSVersion.Platform) {
        case PlatformID.Unix:
          return new LinuxEnvironmentAbstraction();
        
        case PlatformID.WinCE:
        case PlatformID.Win32NT:
        case PlatformID.Win32Windows:
          // return new WindowsEnvironmentAbstraction();
          return new LinuxEnvironmentAbstraction();

        case PlatformID.Xbox:
          throw new NotSupportedException("This platform is not supported");
          break;
        case PlatformID.MacOSX:
          throw new NotSupportedException("This platform is not (yet) supported");
          break;
        default:
          throw new ArgumentOutOfRangeException();
      }
    }
  }
}
