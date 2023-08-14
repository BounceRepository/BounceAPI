using Bounce.Services.Notification.Wallet;
using MassTransit;
using MediatR;
using Microsoft.AspNetCore.Builder;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace Bounce.Services.AppServices
{
    public static class SharedAppServices
    {
        public static void AppServices(this WebApplicationBuilder builder)
        {
            //builder.Services.AddMassTransit(config =>
            //{
            //    config.AddConsumer<WalletMessageConsumer>();

            //    config.UsingInMemory((context, cfg) =>
            //    {
            //        cfg.ConfigureEndpoints(context);
            //    });
            //});


        }

        public static void PipelineServices(this WebApplication app)
        {
           


        }

    }
}
