using CSharpFunctionalExtensions;
using Pr0cessor.Models.Pr0grammApi;

namespace Pr0cessor.Pr0grammApi {
  public interface ISessionStorage {
    bool HasStored();
    Result Set(Session sesison);
    Result<Session, string> Get();
  }
}
