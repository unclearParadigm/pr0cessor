using System.Net.Http;
using Microsoft.Extensions.DependencyInjection;
using pr0gramm.WebApi.Extensions;
using pr0gramm.WebApi.Interfaces;
using Shouldly;
using Xunit;

namespace pr0cessor.Tests.UnitTest {
  public class DependencyInjectionTests {
    
    [Fact]
    public void TestServiceCollectionExtensions() {
      var serviceCollection = new ServiceCollection();
      serviceCollection.AddPr0grammWebApi();
      var serviceProvider = serviceCollection.BuildServiceProvider();
      
      serviceProvider.GetService<HttpClient>().ShouldNotBeNull();
      serviceProvider.GetService<IPr0grammHttpClient>().ShouldNotBeNull();
      
    }
  }
}
