using System.Collections.Generic;
using CSharpFunctionalExtensions;
using pr0cessor.Localization.Extensions;

namespace pr0cessor.Localization {
  public class LanguagePack {
    public readonly string LangCode;
    public readonly IDictionary<string, string> Dictionary;
    public readonly Maybe<LanguagePack> FallbackLanguagePack;

    public LanguagePack(string langCode, IDictionary<string, string> dictionary) {
      LangCode = langCode;
      Dictionary = dictionary;
      FallbackLanguagePack = Maybe<LanguagePack>.None;
    }

    public LanguagePack(string langCode, IDictionary<string, string> dictionary, LanguagePack fallbackLangaugePack) {
      LangCode = langCode;
      Dictionary = dictionary;
      FallbackLanguagePack = Maybe<LanguagePack>.From(fallbackLangaugePack);
    }

    public string Username => Get(nameof(Username));
    public string Password => Get(nameof(Password));
    
    private string Get(string key) {
      return FallbackLanguagePack.HasValue
        ? Dictionary.GetValue(key).Unwrap(FallbackLanguagePack.Value.Get(Username))
        : Dictionary.GetValue(key).Unwrap(key);
    }
  }
}
