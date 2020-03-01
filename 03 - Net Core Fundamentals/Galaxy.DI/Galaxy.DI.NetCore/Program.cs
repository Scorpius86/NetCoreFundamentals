using Microsoft.Extensions.DependencyInjection;
using System;

namespace Galaxy.DI.NetCore
{
    class Program
    {
        static void Main(string[] args)
        {
            var serviceProvider = new ServiceCollection()
                .AddSingleton<GuidServiceSingleton>()
                .AddTransient<GuidServiceSingleton>()
                .AddScoped<GuidServiceSingleton>()
                .BuildServiceProvider();
        }
    }
}
