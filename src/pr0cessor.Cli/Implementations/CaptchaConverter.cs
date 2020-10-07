using System;
using CSharpFunctionalExtensions;

namespace pr0cessor.Implementations {
  public static class CaptchaConverter {
    private const string Base64PngImageHeader = "data:image/png;base64,";
    
    public static Result<byte[]> ConvertToByteArray(string base64EncodedImg) {
      if (string.IsNullOrWhiteSpace(base64EncodedImg))
        return Result.Failure<byte[]>("The base64-encoded image must not be null");
     
      if(!base64EncodedImg.StartsWith(Base64PngImageHeader))
        return Result.Failure<byte[]>("The Image does not have a supported header");

      var dataWithoutHeader = base64EncodedImg.Replace(Base64PngImageHeader, "");
      var data = Convert.FromBase64String(dataWithoutHeader);
      return Result.Success(data);
    }
  }
}
