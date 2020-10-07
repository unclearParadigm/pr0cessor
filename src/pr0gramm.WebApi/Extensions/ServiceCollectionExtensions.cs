using System.Net.Http;
using Microsoft.Extensions.DependencyInjection;
using pr0gramm.WebApi.Implementations;
using pr0gramm.WebApi.Interfaces;

namespace pr0gramm.WebApi.Extensions {
  public static class ServiceCollectionExtensions {
    public static IServiceCollection AddPr0grammWebApi(this IServiceCollection serviceCollection) {
      serviceCollection
        .AddSingleton<HttpClient>()
        .AddSingleton<IPr0grammHttpClient, Pr0grammHttpClient>()
        .AddSingleton<IPr0grammApi, Pr0grammApi>();
      return serviceCollection;
    }
  }
}
