using CSharpFunctionalExtensions;
using pr0gramm.Domain;

namespace pr0cessor.Persistence.Interfaces {
  public interface IPr0cessorPersistenceManager {
    Result Set(Session session);
    Result<Maybe<Session>> Get();
  }
}
