using pr0gramm.WebApi.Attributes;
using pr0gramm.WebApi.Models.Request;

namespace pr0cessor.Tests.UnitTest.WebApi.Models {
  public class TestApiRequest : BaseApiRequest {

    public const string Parameter1Name = "parameter1";
    [IncludeQueryParameters(Parameter1Name)]
    public string Parameter1 => "Hello";
    
    public const string Parameter2Name = "parameter2";
    [IncludeQueryParameters(Parameter2Name)]
    public string Parameter2 => "World";

    public const string Parameter3Name = "number";
    [IncludeQueryParameters(Parameter3Name)] 
    public int Parameter3 => 42;
    
    public string NotSerializedParameter = "ShouldNotBeSerialized";
    public int ShouldAlsoNotBeSerialized = 666;
    
    public TestApiRequest(string apiScheme, string apiDomain, string apiEndpoint) : base(apiScheme, apiDomain, apiEndpoint) {
    }
  }
}
