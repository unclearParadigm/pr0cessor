using System;
using System.IO;

using CSharpFunctionalExtensions;

using Pr0cessor.Pr0grammApi.Implementation;

namespace Pr0cessor.Pr0grammApi.Factories {
  public enum StorageType {
    Json
  }

  public static class SessionStorageFactory {
    public static ISessionStorage Create(StorageType storageType, string filePath) {
      switch (storageType) {
        case StorageType.Json:
          if(!File.Exists(filePath))
            File.Create(filePath).Close();
          return new JsonSessionStorage(filePath);
        default:
          throw new ArgumentException("Unknown StorageType", nameof(storageType));
      }
    }
  }
}
