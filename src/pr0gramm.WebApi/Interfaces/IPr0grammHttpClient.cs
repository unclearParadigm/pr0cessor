using System.Threading.Tasks;
using CSharpFunctionalExtensions;
using pr0gramm.WebApi.Models;
using pr0gramm.WebApi.Models.Request;
using pr0gramm.WebApi.Models.Response;

namespace pr0gramm.WebApi.Interfaces {
  public interface IPr0grammHttpClient {
    Task<Result<TResponse>> GetAsync<TRequest, TResponse>(TRequest request, RequestConfiguration configuration) 
      where TRequest : BaseApiRequest where TResponse : BaseApiResponse;
    
    Task<Result<TResponse>> PostFormAsync<TRequest, TResponse>(TRequest request, RequestConfiguration configuration) 
      where TRequest : BaseApiRequest where TResponse : BaseApiResponse;
  }
}
