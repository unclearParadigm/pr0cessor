using System.Threading.Tasks;
using CommandLine;
using Microsoft.Extensions.DependencyInjection;
using pr0cessor.Environment.Implementations;
using pr0cessor.Environment.Interfaces;
using pr0cessor.Implementations;
using pr0cessor.Implementations.CommandExecutor;
using pr0cessor.Interfaces;
using pr0cessor.Models.CliArguments;
using pr0gramm.Domain;
using pr0gramm.WebApi.Extensions;
using pr0gramm.WebApi.Models;

namespace pr0cessor {
  public class Programm {
    public static Task Main(string[] args) {
      var serviceCollection = new ServiceCollection();
      serviceCollection
        .AddPr0grammWebApi()
        .AddSingleton<RequestConfiguration>()
        .AddSingleton(EnvironmentAbstractionFactory.Create())
        .AddSingleton<IFileSystemPersistor<Session>, SessionPersistor>()
        .AddSingleton<LoginExecutor>();

      var serviceProvider = serviceCollection.BuildServiceProvider();
      
      return Parser.Default
        .ParseArguments<LoginVerb>(args)
        .WithParsedAsync<LoginVerb>(
          loginVerb => serviceProvider.GetService<LoginExecutor>().ExecuteAsync(loginVerb));
    }
  }
}
