using System;

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
          return new JsonSessionStorage(filePath);
        default:
          throw new ArgumentException("Unknown StorageType", nameof(storageType));
      }
    }
  }
}
