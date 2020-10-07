using pr0cessor.Tests.UnitTest.WebApi.Models;
using pr0gramm.WebApi.Implementations;
using pr0gramm.WebApi.Models.Request;
using Shouldly;
using Xunit;

namespace pr0cessor.Tests.UnitTest.WebApi {
  public class Pr0grammUrlBuilderTests {
    
    [Fact]
    public void TestUrlBuilderGenerationWithoutQueryParameters() {
      const string schema = "http";
      const string domain = "pr0gramm.com";
      const string endpoint = "/api/endpoint";
      
      var request = new BaseApiRequest(schema, domain, endpoint);
      var urlResult = Pr0grammUrlBuilder.BuildHttpGetUrl(request);
      
      urlResult.IsSuccess.ShouldBeTrue();
      urlResult.Value.ShouldContain(request.ApiDomain);
      urlResult.Value.ShouldContain(request.ApiEndpoint);
      urlResult.Value.ShouldStartWith(request.ApiScheme);
      urlResult.Value.ShouldBe($"{schema}://{domain}{endpoint}");
    }
    
    [Fact]
    public void TestUrlBuilderGenerationWithQueryParameters() {
      const string schema = "http";
      const string domain = "pr0gramm.com";
      const string endpoint = "/api/endpoint";
      
      var request = new TestApiRequest(schema, domain, endpoint);
      var urlResult = Pr0grammUrlBuilder.BuildHttpGetUrl(request);
      
      urlResult.IsSuccess.ShouldBeTrue();
      urlResult.Value.ShouldContain(request.ApiDomain);
      urlResult.Value.ShouldContain(request.ApiEndpoint);
      urlResult.Value.ShouldStartWith(request.ApiScheme);
      urlResult.Value.ShouldStartWith($"{schema}://");
      urlResult.Value.ShouldContain($"{domain}{endpoint}");

      urlResult.Value.ShouldContain(TestApiRequest.Parameter1Name); // parameter1
      urlResult.Value.ShouldContain(TestApiRequest.Parameter2Name); // parameter2
      urlResult.Value.ShouldContain(TestApiRequest.Parameter3Name); // number
      
      urlResult.Value.ShouldContain(request.Parameter1); // Hello
      urlResult.Value.ShouldContain(request.Parameter2); // World
      urlResult.Value.ShouldContain(request.Parameter3.ToString()); // 42
      
      urlResult.Value.ShouldNotContain(request.NotSerializedParameter);
      urlResult.Value.ShouldNotContain(request.ShouldAlsoNotBeSerialized.ToString());
    }
  }
}
