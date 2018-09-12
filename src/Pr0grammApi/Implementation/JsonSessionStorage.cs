using System;
using System.IO;
using System.Text;

using Newtonsoft.Json;
using CSharpFunctionalExtensions;

using Pr0cessor.Models.Pr0grammApi;

namespace Pr0cessor.Pr0grammApi.Implementation {
  public class JsonSessionStorage : ISessionStorage {
    private readonly string StoragePath;
    public JsonSessionStorage(string storagePath) {
      StoragePath = storagePath;
    }

    public bool HasStored() {
      return File.Exists(StoragePath)
        && Get().IsSuccess;
    }

    public Result<Session, string> Get() {
      try {
        using (var fileStream = new StreamReader(StoragePath)) {
          var content = fileStream.ReadToEnd();
          var session = JsonConvert.DeserializeObject<Session>(content);
          return Result.Ok<Session, string>(session);
        }
      } catch (Exception exc) {
        return Result.Fail<Session, string>(exc.Message);
      }
    }

    public Result Set(Session session) {
      try {
        using (var fileStream = new StreamWriter(StoragePath, false, Encoding.UTF8)) {
          var content = JsonConvert.SerializeObject(session);
          fileStream.Write(content);
          return Result.Ok();
        }
      } catch (Exception exc) {
        return Result.Fail(exc.Message);
      }
    }
  }
}
