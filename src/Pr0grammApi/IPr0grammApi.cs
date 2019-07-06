using System;
using System.Threading.Tasks;
using System.Collections.Generic;

using CSharpFunctionalExtensions;

using Pr0cessor.Models.Pr0grammApi;
using Pr0cessor.Models.Pr0grammApi.Responses;

namespace Pr0cessor.Pr0grammApi {
    public interface IPr0grammApi : IDisposable {
    void AuthWithExistingSession(Session session);
    Task<Result<Session, string>> AuthAsync(string username, string password);
    Task<Result<IEnumerable<Item>, string>> GetFavoritesAsync(string targetUser);
    Task<Result<IEnumerable<Item>, string>> GetUploadsAsync(string targetUser);
  }
}
