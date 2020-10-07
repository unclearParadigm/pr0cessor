using System.Collections.Generic;
using System.Threading.Tasks;
using CSharpFunctionalExtensions;
using pr0gramm.Domain;
using pr0gramm.Domain.Structures;
using pr0gramm.WebApi.Interfaces;
using pr0gramm.WebApi.Models;
using pr0gramm.WebApi.Models.Request;
using pr0gramm.WebApi.Models.Response;

namespace pr0gramm.WebApi.Implementations {
  public class Pr0grammApi : IPr0grammApi {
    private readonly IPr0grammHttpClient _httpClient;
    private readonly RequestConfiguration _requestConfiguration;

    public Pr0grammApi(IPr0grammHttpClient httpClient, RequestConfiguration requestConfiguration) {
      _httpClient = httpClient;
      _requestConfiguration = requestConfiguration;
    }
    
    public Task<Result<Captcha>> GetCaptcha() {
      return _httpClient
        .GetAsync<CaptchaRequest, CaptchaResponse>(new CaptchaRequest(), _requestConfiguration)
        .Map(d => new Captcha { Token = d.Token, Base64CaptchaImage = d.Captcha });
    }

    public Task<Result> LogoutAsync(Session session) {
      throw new System.NotImplementedException();
    }

    public Task<Result<Maybe<Session>>> LoginAsync(Session session) {
      throw new System.NotImplementedException();
    }

    public Task<Result<Maybe<Session>>> LoginAsync(Authentication authentication) {
      throw new System.NotImplementedException();
    }

    public Task<Result<Maybe<Post>>> FindPostById(long postId) {
      throw new System.NotImplementedException();
    }

    public Task<Result<Maybe<User>>> FindUserByNameAsync(string username) {
      throw new System.NotImplementedException();
    }

    public Task<Result<Maybe<IEnumerable<Post>>>> GetUploadsForUserAsync(string username, IEnumerable<PostCategoryType> categoryTypes) {
      throw new System.NotImplementedException();
    }

    public Task<Result<Maybe<IEnumerable<Post>>>> GetPostCollectionForUserAsync(string username, string collectionName, IEnumerable<PostCategoryType> categoryTypes) {
      throw new System.NotImplementedException();
    }
  }
}
