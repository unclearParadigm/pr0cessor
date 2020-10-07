using System;

namespace pr0cessor.Implementations {
  public static class ConsoleHelper {

    public static string PromptTextInput(string prompt) {
      Console.Write($">_ {prompt}: ");
      var input = Console.ReadLine();
      Console.WriteLine();
      return input;
    }
    
    public static string PromptSecretInput(string prompt) {
      var password = "";
      Console.Write($">_ {prompt}: ");
      ConsoleKeyInfo keyInfo;

      do {
        keyInfo = Console.ReadKey(true);
        if (keyInfo.Key != ConsoleKey.Backspace && keyInfo.Key != ConsoleKey.Enter) {
          password += keyInfo.KeyChar;
          Console.Write("*");
        } else {
          if (keyInfo.Key == ConsoleKey.Backspace && password.Length > 0) {
            password = password.Substring(0, password.Length - 1);
            Console.Write("\b \b");
          }
        }
      }
      while (keyInfo.Key != ConsoleKey.Enter);
      Console.WriteLine();
      return password;
    }
  }
}
