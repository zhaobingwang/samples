using System;
using System.Collections.Generic;
using System.Text;
using Microsoft.AspNetCore.DataProtection;
using Microsoft.Extensions.DependencyInjection;

namespace CodeSnippets.Security
{
    public class DataProtectionSnippets
    {
        public static void Run()
        {
            // add data protection services
            var serviceCollection = new ServiceCollection();
            serviceCollection.AddDataProtection();
            // serviceCollection.AddDataProtection(options => options.ApplicationDiscriminator = "test");
            var services = serviceCollection.BuildServiceProvider();

            // create an instance of MyClass using the service provider
            var instance = ActivatorUtilities.CreateInstance<MyClass>(services);
            instance.RunSample();
        }
        class MyClass
        {
            IDataProtector _protector;

            // the 'provider' parameter is provided by DI
            public MyClass(IDataProtectionProvider provider)
            {
                _protector = provider.CreateProtector("netcore.consoleapp");
            }

            public void RunSample()
            {
                Console.Write("Enter input: ");
                string input = Console.ReadLine();

                // protect the payload
                string protectedPayload = _protector.Protect(input);
                Console.WriteLine($"Protect returned: {protectedPayload}");

                // unprotect the payload
                string unprotectedPayload = _protector.Unprotect(protectedPayload);
                Console.WriteLine($"Unprotect returned: {unprotectedPayload}");
            }
        }
    }
}
