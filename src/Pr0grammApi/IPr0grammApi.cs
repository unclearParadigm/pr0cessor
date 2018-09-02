using System;
using System.Threading.Tasks;
using System.Collections.Generic;

using CommandLine;
using CSharpFunctionalExtensions;

using Pr0cessor.Models.Pr0grammApi;
using Pr0cessor.Models.Pr0grammApi.Requests;
using Pr0cessor.Models.Pr0grammApi.Responses;

namespace Pr0cessor.Pr0grammApi {
  public interface IPr0grammApi {
    Task<Result<Session, string>> LoginAsync(string username, string password);
    Task<Result<IEnumerable<FavoriteItem>, string>> GetFavoritesAsync(string targetUser);
  }
}
