using System;

namespace pr0gramm.WebApi.Attributes {
  public class IncludeQueryParameters : Attribute {
    public readonly string QueryParameterName;

    public IncludeQueryParameters(string queryParameterName) {
      QueryParameterName = queryParameterName;
    }
  }
}
