using System.Threading.Tasks;

using CSharpFunctionalExtensions;

namespace Pr0cessor.Pr0grammApi.Factories {
  public static class Pr0grammApiFactory {
    public static Task<Result<IPr0grammApi>> Create() {
      var api = new Implementation.Pr0grammApi();
      var apiResult = Result.Ok<IPr0grammApi>(api);
      return Task.FromResult<Result<IPr0grammApi>>(apiResult);
    }

    public static async Task<Result<IPr0grammApi>> Create(string username, string password) {
      // Create with username and password, do not persist session
      var api = new Implementation.Pr0grammApi();
      return (await api.AuthAsync(username, password))
          .OnSuccess(session => Result.Ok<IPr0grammApi>(api));
    }

    public static async Task<Result<IPr0grammApi>> Create(string username, string password, ISessionStorage sessionStorage) {
      if (string.IsNullOrEmpty(username) 
          && string.IsNullOrEmpty(password)
          && sessionStorage.HasStored()) {
        var session = sessionStorage.Get();
        if (session.IsFailure)
          return Result.Fail<IPr0grammApi>(session.Error);

        var api = new Implementation.Pr0grammApi();
        api.AuthWithExistingSession(session.Value);
        return Result.Ok<IPr0grammApi>(api);
      } else {
        // Create with username and password, persist session
        var api = new Implementation.Pr0grammApi();
        return (await api.AuthAsync(username.Trim(), password.Trim()))
            .OnFailure(error => Result.Fail(error))
            .OnSuccess(session => sessionStorage.Set(session))
            .OnSuccess(persist => Result.Ok<IPr0grammApi>(api));
      }
    }

    public static Task<Result<IPr0grammApi>> Create(ISessionStorage sessionStorage) {
      // Create from already existing session
      var api = new Implementation.Pr0grammApi();
      var session = sessionStorage.Get();
      if (session.IsFailure) {
        return Task.FromResult(Result.Fail<IPr0grammApi>(session.Error));
      }

      api.AuthWithExistingSession(session.Value);
      return Task.FromResult(Result.Ok<IPr0grammApi>(api));
    }
  }
}
