using CommandLine;

namespace pr0cessor.Models.CliArguments {
  [Verb("auth", HelpText = "Permanent authentication of specific user (no need to enter username and password everytime)")]
  public class Auth {
    [Option('u', "username", Required = true, HelpText = "Your username, required for authentication")]
    public string Username { get; set; }

    [Option('p', "password", Required = true, HelpText = "Your password, required for authentication")]
    public string Password { get; set; }
  }
}
