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
            services.AddTransient<GetTodayWordsBase>();
            IServiceProvider provider = services.BuildServiceProvider();
            var myservice = provider.GetService<GetTodayWordsBase>();
            myservice.Do();
        }
    }
}
