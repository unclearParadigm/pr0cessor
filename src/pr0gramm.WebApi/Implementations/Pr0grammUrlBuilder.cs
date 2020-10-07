using System;
using System.Linq;
using System.Reflection;
using CSharpFunctionalExtensions;
using pr0gramm.WebApi.Attributes;
using pr0gramm.WebApi.Models.Request;

namespace pr0gramm.WebApi.Implementations {
  public static class Pr0grammUrlBuilder {
    public static Result<string> BuildHttpGetUrl<TRequest>(TRequest request) where TRequest : BaseApiRequest {
      try {
        var queryParameters = request
          .GetType()
          .GetProperties()
          .Where(property => property.GetCustomAttributes(true).OfType<IncludeQueryParameters>().Any())
          .Select(request.MapToQueryParameter)
          .ToList();

        var uriBuilder = new UriBuilder {
          Scheme = (request.ApiScheme ?? "https").ToLowerInvariant(),
          Host = request.ApiDomain,
          Path = request.ApiEndpoint,
          Query = queryParameters.Any() 
            ? $"?{string.Join("&", queryParameters)}" 
            : string.Empty
        };

        return Result.Success(uriBuilder.ToString());
      } catch {
        return Result.Failure<string>("Could not build Uri!");
      }
    }


    private static string MapToQueryParameter<TRequest>(this TRequest request, PropertyInfo propertyInfo) {
      var attribute = propertyInfo
        .GetCustomAttributes(true)
        .OfType<IncludeQueryParameters>()
        .Single();
      
      var unencodedValue = propertyInfo
        .GetValue(request, null)
        .ToString();

      return $"{attribute.QueryParameterName}={Uri.EscapeDataString(unencodedValue)}";
    }
  }
}
