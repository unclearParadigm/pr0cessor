using System.Collections;
using System.Collections.Generic;
using System.Threading.Tasks;
using CSharpFunctionalExtensions;
using pr0gramm.Domain;
using pr0gramm.Domain.Structures;

namespace pr0gramm.WebApi.Interfaces {
  public interface IPr0grammApi {
    Task<Result<Captcha>> GetCaptcha();
    Task<Result> LogoutAsync(Session session);
    Task<Result<Maybe<Session>>> LoginAsync(Session session);
    Task<Result<Maybe<Session>>> LoginAsync(Authentication authentication);


    Task<Result<Maybe<Post>>> FindPostById(long postId);
    Task<Result<Maybe<User>>> FindUserByNameAsync(string username);

    Task<Result<Maybe<IEnumerable<Post>>>> GetUploadsForUserAsync(string username, IEnumerable<PostCategoryType> categoryTypes);
    Task<Result<Maybe<IEnumerable<Post>>>> GetPostCollectionForUserAsync(string username, string collectionName, IEnumerable<PostCategoryType> categoryTypes);
  }
}
