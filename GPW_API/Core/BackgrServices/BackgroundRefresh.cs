using GPW_API.DataAccess;
using Microsoft.Extensions.Hosting;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;

namespace GPW_API.Core.BackgrServices
{
    public class BackgroundRefresh : BackgroundService
    {
        protected override async Task ExecuteAsync(CancellationToken stoppingToken)
        {
            while (!stoppingToken.IsCancellationRequested)
            {
                var gpwRefresh = new GpwRefresh();

                gpwRefresh.GpwRefreshing();

                GC.Collect();

                Random random = new Random();
                int randomNumber = random.Next(0, 12000);

                await Task.Delay(1800000 + randomNumber, stoppingToken);
            }

        }
    }
}
