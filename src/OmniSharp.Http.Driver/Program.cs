using System;
using OmniSharp.Services;

namespace OmniSharp.Http.Driver
{
    internal class Program
    {
        static int Main(string[] args) => HostHelpers.Start(() =>
        {
            var application = new HttpCommandLineApplication();
            application.OnExecute(() =>
            {
                var environment = application.CreateEnvironment();
                Configuration.ZeroBasedIndices = application.ZeroBasedIndices;

                var writer = new SharedTextWriter(Console.Out);

                var host = new Host(environment, writer, application.Plugin, application.Port, application.Interface);
                host.Start();

                return 0;
            });

            return application.Execute(args);
        });

    }
}
