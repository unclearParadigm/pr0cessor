using System.Collections.Generic;
using CSharpFunctionalExtensions;

namespace pr0cessor.Localization.Extensions {
  public static class DictionaryExtensions {
    public static Maybe<string> GetValue(this IDictionary<string, string> dictionary, string key) {
      return dictionary.ContainsKey(key) ? Maybe<string>.From(dictionary[key]) : Maybe<string>.None;
    }
  }
}
