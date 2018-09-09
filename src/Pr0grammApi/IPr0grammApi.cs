using System;
using System.Threading.Tasks;
using System.Collections.Generic;

using CommandLine;
using CSharpFunctionalExtensions;

using Pr0cessor.Models.Pr0grammApi;
using Pr0cessor.Models.Pr0grammApi.Requests;
using Pr0cessor.Models.Pr0grammApi.Responses;

namespace Pr0cessor.Pr0grammApi {
  public interface IPr0grammApi : IDisposable {
    void AuthWithExistingSession(Session session);
    Task<Result<Session, string>> AuthAsync(string username, string password);
    Task<Result<IEnumerable<FavoriteItem>, string>> GetFavoritesAsync(string targetUser);
  }
}
