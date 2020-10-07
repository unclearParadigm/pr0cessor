using System;
using System.Net.Http;
using System.Threading;
using System.Threading.Tasks;
using CSharpFunctionalExtensions;
using Newtonsoft.Json;
using pr0gramm.WebApi.Interfaces;
using pr0gramm.WebApi.Models;
using pr0gramm.WebApi.Models.Request;
using pr0gramm.WebApi.Models.Response;

namespace pr0gramm.WebApi.Implementations {
  public class Pr0grammHttpClient : IPr0grammHttpClient {
    private readonly HttpClient _httpClient;
    
    public Pr0grammHttpClient(HttpClient httpClient) {
      _httpClient = httpClient;
    }
    
    public async Task<Result<TResponse>> GetAsync<TRequest, TResponse>(TRequest request, RequestConfiguration configuration) where TRequest : BaseApiRequest where TResponse : BaseApiResponse {
      var cts = new CancellationTokenSource(configuration.Timeout);
      try {
        return await Pr0grammUrlBuilder
          .BuildHttpGetUrl(request)
          .Bind(url => FunctionalHttpGetAsync(url, cts.Token))
          .Bind(FunctionalDeserialize<TResponse>);
      } catch(Exception exc) {
        return Result.Failure<TResponse>(exc.Message);
      }
    }

    public async Task<Result<TResponse>> PostFormAsync<TRequest, TResponse>(TRequest request, RequestConfiguration configuration) where TRequest : BaseApiRequest where TResponse : BaseApiResponse {
      var cts = new CancellationTokenSource(configuration.Timeout);
      try {
        return await Pr0grammUrlBuilder.BuildHttpGetUrl(request)
          .Bind(url => FunctionalPostAsync(url, request.AsFormUrlEncoded(), cts.Token))
          .Bind(FunctionalDeserialize<TResponse>);
      } catch (Exception exc) {
        return Result.Failure<TResponse>(exc.Message);
      }
    }

    private async Task<Result<HttpResponseMessage>> FunctionalHttpGetAsync(string url, CancellationToken ct) {
      try {
        var httpResult = await _httpClient.GetAsync(url, ct);
        return Result.Success(httpResult);
      } catch (Exception exc) {
        return Result.Failure<HttpResponseMessage>(exc.Message);
      }
    }
    
    private async Task<Result<HttpResponseMessage>> FunctionalPostAsync(string url, HttpContent content, CancellationToken ct) {
      try {
        var httpResult = await _httpClient.PostAsync(url, content, ct);
        return Result.Success(httpResult);
      } catch (Exception exc) {
        return Result.Failure<HttpResponseMessage>(exc.Message);
      }
    }
    
    private static async Task<Result<TResponse>> FunctionalDeserialize<TResponse>(HttpResponseMessage httpResponseMessage) {
      try {
        var responseContent = await httpResponseMessage.Content.ReadAsStringAsync();
        return JsonConvert.DeserializeObject<TResponse>(responseContent);
      } catch {
        return Result.Failure<TResponse>("gul");
      }
    }
  }
}
