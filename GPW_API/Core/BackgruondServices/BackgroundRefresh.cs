using GPW_API.DataAccess;
using GPW_API.DataAccess.References;
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
                    var context = scope.ServiceProvider.GetRequiredService<GpwContext>();

                    var gpwRefresh = new GpwRefresh(context);
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
