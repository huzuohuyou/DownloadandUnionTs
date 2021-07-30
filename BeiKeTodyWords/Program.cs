using CommonService.Words;
using Microsoft.Extensions.DependencyInjection;
using System;

namespace BeiKeTodyWords
{
    class Program
    {
        static void Main(string[] args)
        {
            IServiceCollection services = new ServiceCollection();
            services.AddTransient<GetTodayWordsService>();
            IServiceProvider provider = services.BuildServiceProvider();
            var myservice = provider.GetService<GetTodayWordsService>();
            myservice.Do();
        }
    }
}
