using System.IO;
using System.Threading.Tasks;
using CSharpFunctionalExtensions;
using Microsoft.Extensions.DependencyInjection;
using pr0cessor.Implementations;
using pr0gramm.WebApi.Extensions;
using pr0gramm.WebApi.Interfaces;
using pr0gramm.WebApi.Models;
using Shouldly;
using Xunit;

namespace pr0cessor.Tests.IntegrationTest.WebApi {
  public class GetCaptchaTest {
    [Fact]
    public async Task TestRetrievingCaptcha() {
      var impl = new ServiceCollection()
        .AddSingleton<RequestConfiguration>()
        .AddPr0grammWebApi()
        .BuildServiceProvider()
        .GetService<IPr0grammApi>();

      var captchaResult = await impl.GetCaptcha();
      captchaResult.IsSuccess.ShouldBeTrue();
      captchaResult.IsFailure.ShouldBeFalse();
      captchaResult.Value.ShouldNotBeNull();
      captchaResult.Value.Token.ShouldNotBeNull();
      captchaResult.Value.Base64CaptchaImage.ShouldNotBeNull();
    }

    [Fact]
    public async Task TestSaveCaptcha() {
      var impl = new ServiceCollection()
        .AddSingleton<RequestConfiguration>()
        .AddPr0grammWebApi()
        .BuildServiceProvider()
        .GetService<IPr0grammApi>();

      var captchaResult = await impl.GetCaptcha()
        .Bind(c => CaptchaConverter.ConvertToByteArray(c.Base64CaptchaImage));
      
      captchaResult.IsSuccess.ShouldBeTrue();
    }
  }
}
