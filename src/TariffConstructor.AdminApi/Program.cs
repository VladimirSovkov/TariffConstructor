using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Hosting;
using TariffConstructor.Infrastructure.Startup;

namespace TariffConstructor.AdminApi
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var program = new Program<Startup>();

            program.Run(args);
        }
    }
}
