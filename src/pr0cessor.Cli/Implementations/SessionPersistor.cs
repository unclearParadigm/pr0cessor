using System;
using System.IO;
using System.Text;
using CSharpFunctionalExtensions;
using Newtonsoft.Json;
using pr0cessor.Environment.Interfaces;
using pr0cessor.Environment.Structures;
using pr0cessor.Interfaces;
using pr0gramm.Domain;

namespace pr0cessor.Implementations {
  public class SessionPersistor : IFileSystemPersistor<Session> {
    public string FileName => "pr0_session.json";
    private readonly IEnvironmentAbstraction _environmentAbstraction;
    
    public SessionPersistor(IEnvironmentAbstraction environmentAbstraction) {
      _environmentAbstraction = environmentAbstraction;
    }
    
    public Result Store(Session dataToPersist) {
      var targetDirectory = _environmentAbstraction.GetWellKnownPath(WellKnownLocations.UserConfigDirectory);
      var fileContent = Encoding.UTF8.GetBytes(JsonConvert.SerializeObject(dataToPersist));
      return _environmentAbstraction.SaveFile(targetDirectory, FileName, fileContent);
    }

    public Result<Maybe<Session>> Read() {
      var targetDirectory = _environmentAbstraction.GetWellKnownPath(WellKnownLocations.UserConfigDirectory);
      var targetFilePath = Path.Join(targetDirectory, FileName);
      if (!File.Exists(targetFilePath))
        return Result.Success(Maybe<Session>.None);

      try {
        var fileContent = File.ReadAllBytes(targetFilePath);
        var asString = Encoding.UTF8.GetString(fileContent);
        var deserialized = JsonConvert.DeserializeObject<Session>(asString);
        return Result.Success(Maybe<Session>.From(deserialized));
      } catch (Exception exc) {
        return Result.Failure<Maybe<Session>>(exc.Message);
      }
    }
  }
}
