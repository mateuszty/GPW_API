using GPW_API.Core.Repositories;
using GPW_API.DataAccess;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using System;
using System.Threading;
using System.Threading.Tasks;

namespace GPW_API.Core.BackgroundServices
{
    public class BackgroundRefresh : BackgroundService
    {
        private readonly IServiceScopeFactory _scopeFactory;
        public BackgroundRefresh(IServiceScopeFactory scopeFactory)
        {
            _scopeFactory = scopeFactory;
        }
        protected override async Task ExecuteAsync(CancellationToken stoppingToken)
        {
            while (!stoppingToken.IsCancellationRequested)
            {
                using (var scope = _scopeFactory.CreateScope())
                {
                    var repository = scope.ServiceProvider.GetRequiredService<IGpwRepository>();

                    var gpwRefresh = new GpwRefresh(repository);
                    gpwRefresh.GpwRefreshing();
                }


                GC.Collect();

                Random random = new Random();
                int randomNumber = random.Next(0, 12000);

                await Task.Delay(1800000 + randomNumber, stoppingToken);
            }

        }
    }
}
