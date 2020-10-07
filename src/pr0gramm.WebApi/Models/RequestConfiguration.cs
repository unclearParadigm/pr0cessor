using System;
using System.Net;
using CSharpFunctionalExtensions;

namespace pr0gramm.WebApi.Models {
  public class RequestConfiguration {
    public TimeSpan Timeout { get; set; } = TimeSpan.FromSeconds(30);
    public Maybe<IWebProxy> Proxy { get; set; } = Maybe<IWebProxy>.None;
    
    
  }
}
