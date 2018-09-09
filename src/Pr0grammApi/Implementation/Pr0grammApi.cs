using System;
using System.Net;
using System.Linq;
using System.Net.Http;
using System.Threading;
using System.Threading.Tasks;
using System.Collections.Generic;

using CommandLine;
using Newtonsoft.Json;
using CSharpFunctionalExtensions;

using Pr0cessor.Models.Pr0grammApi;
using Pr0cessor.Models.Pr0grammApi.Requests;
using Pr0cessor.Models.Pr0grammApi.Responses;

namespace Pr0cessor.Pr0grammApi.Implementation {
  public class Pr0grammApi : IPr0grammApi, IDisposable {
    private readonly int _requestTimeout;
    private readonly HttpClient _httpClient;
    private readonly CookieContainer _cookieContainer;
    private readonly HttpClientHandler _httpClientHandler;

    public Pr0grammApi(int requestTimeout = 5000) {
      _requestTimeout = requestTimeout;
      _cookieContainer = new CookieContainer();
      _httpClientHandler = new HttpClientHandler();
      _httpClientHandler.CookieContainer = _cookieContainer;
      _httpClient = new HttpClient(_httpClientHandler, false);
    }

    public void AuthWithExistingSession(Session session) {
      _cookieContainer.Add(session.PPCookie);
      _cookieContainer.Add(session.MECookie);
    }

    public async Task<Result<Session, string>> AuthAsync(string username, string password) {
      var apiUri = new Uri($"{ApiConstants.ApiEndpoint}/user/login");
      var postData = new LoginRequest(username, password).ToFormUrlEncodedContent();
      return (await Post<LoginResponse>(apiUri, postData))
        .OnSuccess(response => {
          return Result.Ok<Session, string>(new Session {
            Login = response,
            Username = username,
            PPCookie = GetCookieByName("pp", new Uri(ApiConstants.ApiEndpoint)),
            MECookie = GetCookieByName("me", new Uri(ApiConstants.ApiEndpoint))
          });
        });
    }

    public async Task<Result<IEnumerable<FavoriteItem>, string>> GetFavoritesAsync(string targetUser) {
      var queryData =
        await new FavsRequest(targetUser, Flags.All)
        .ToFormUrlEncodedContent()
        .ReadAsStringAsync();

      var uri = new Uri($"{ApiConstants.ApiEndpoint}/items/get?{queryData}");
      var response = await Get<FavsResponse>(uri);
      return response
        .OnSuccess(r => response.Value.Favorites);
    }

    private Cookie GetCookieByName(string name, Uri uri) {
      var collection = _cookieContainer.GetCookies(uri).Cast<Cookie>();
      return collection.FirstOrDefault(cookie => cookie.Name == name);
    }

    private async Task<Result<T, string>> Get<T>(Uri uri) {
      try {
        var cts = new CancellationTokenSource(_requestTimeout);

        var response = await _httpClient.GetAsync(uri, cts.Token);
        if (!response.IsSuccessStatusCode)
          return Result.Fail<T, string>($"Whoops! Cannot contact pr0gramm.com (Reason: {response.StatusCode})");

        var responseBody = await response.Content.ReadAsStringAsync();
        var deserialized = JsonConvert.DeserializeObject<T>(responseBody);
        return Result.Ok<T, string>(deserialized);

      } catch (Exception exc) {
        return Result.Fail<T, string>(exc.Message);
      }
    }

    private async Task<Result<T, string>> Post<T>(Uri uri, HttpContent content) {
      try {
        var cts = new CancellationTokenSource(_requestTimeout);

        var response = await _httpClient.PostAsync(uri, content, cts.Token);
        if (!response.IsSuccessStatusCode)
          return Result.Fail<T, string>($"Whoops! Cannot contact pr0gramm.com (Reason: {response.StatusCode})");

        var responseBody = await response.Content.ReadAsStringAsync();
        var deserialized = JsonConvert.DeserializeObject<T>(responseBody);
        return Result.Ok<T, string>(deserialized);

      } catch (Exception exc) {
        return Result.Fail<T, string>(exc.Message);
      }
    }

    public void Dispose() {
      throw new NotImplementedException();
    }
  }
}
