using System;
using System.Threading.Tasks;
using CSharpFunctionalExtensions;
using pr0cessor.Environment.Interfaces;
using pr0cessor.Environment.Structures;
using pr0cessor.Interfaces;
using pr0cessor.Models.CliArguments;
using pr0gramm.Domain;
using pr0gramm.WebApi.Interfaces;

namespace pr0cessor.Implementations.CommandExecutor {
  public class LoginExecutor {
    private readonly IPr0grammApi _pr0grammApi;
    private readonly IEnvironmentAbstraction _envAbstraction;
    private readonly IFileSystemPersistor<Session> _sessionPersistor;

    public LoginExecutor(IPr0grammApi pr0grammApi, IEnvironmentAbstraction envAbstraction, IFileSystemPersistor<Session> sessionPersistor) {
      _pr0grammApi = pr0grammApi;
      _envAbstraction = envAbstraction;
      _sessionPersistor = sessionPersistor;
    }

    public async Task<Result> ExecuteAsync(LoginVerb loginVerb) {
      if (string.IsNullOrWhiteSpace(loginVerb.Username))
        loginVerb.Username = ConsoleHelper.PromptTextInput("Username");
      if (string.IsNullOrWhiteSpace(loginVerb.Password))
        loginVerb.Username = ConsoleHelper.PromptSecretInput("Password");

      var captchaResponseResult = await _pr0grammApi.GetCaptcha();

      var captchaDirectoryPath = _envAbstraction.GetWellKnownPath(WellKnownLocations.TempDirectory);
      var captchaFilename = $"captcha_{DateTimeOffset.UtcNow.ToUnixTimeSeconds()}.png";

      var transformationResult = captchaResponseResult
        .Bind(c => CaptchaConverter.ConvertToByteArray(c.Base64CaptchaImage))
        .Bind(d => _envAbstraction.SaveFile(captchaDirectoryPath, captchaFilename, d))
        // ReSharper disable once ImplicitlyCapturedClosure
        .Bind(f => _envAbstraction.OpenImageViewer(f)
          .OnFailureCompensate(_ => _envAbstraction.OpenBrowser(f))
          .OnFailureCompensate(_ => {
            Console.WriteLine($"Captcha saved, open it here '{f}'");
            return Result.Success();
          }));

      if (transformationResult.IsFailure) return transformationResult;

      var captchaText = ConsoleHelper.PromptTextInput("Captcha");

      return await _pr0grammApi.LoginAsync(new Authentication {
          Username = loginVerb.Username,
          Password = loginVerb.Password,
          CaptchaText = captchaText,
          CaptchaToken = captchaResponseResult.Value.Token
        })
        .Bind(maybeSession => maybeSession.ToResult("Username, Password are wrong, or you are banned."))
        .Bind(session => _sessionPersistor.Store(session));
    }
  }
}
