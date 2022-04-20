using EtsErosApi.Data;
using EtsErosApi.Services;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using Xunit;
using Xunit.Abstractions;
using Xunit.DependencyInjection;


namespace EtsErosApi.Test
{
    public class Startup
    {
        public void ConfigureServices(IServiceCollection services)
        {
            services.AddDbContext<DataContext>(opt => opt.UseInMemoryDatabase("Eros_dev"), ServiceLifetime.Transient);

            services.AddScoped<ITreeRepository, TreeRepository>();
            services.AddScoped<ITreeService, TreeService>();
        }
    }
}
