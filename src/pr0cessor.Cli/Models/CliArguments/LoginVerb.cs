using System.Runtime.CompilerServices;
using CommandLine;

namespace pr0cessor.Models.CliArguments {
  [Verb("login", false, HelpText = "LoginVerbDescription", Hidden = false)]
  public class LoginVerb {
      [Option('u', "username", Default = null)]
      public string Username { get; set; }
      [Option('p', "password", Default = null)]
      public string Password { get; set; }

      [Option('m', "me-cookie", Default = null)]
      public string SessionToken { get; set; }
      
      
  }
}
