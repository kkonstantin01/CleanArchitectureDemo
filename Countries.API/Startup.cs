using System.Diagnostics.CodeAnalysis;
using System.Reflection;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.OpenApi.Models;
using MediatR;
using MediatR.Extensions.FluentValidation.AspNetCore;
using Countries.Application.UseCases.Countries.Commands;
using Countries.Domain.Repositories;
using Countries.Infrastructure.Persistence;
using Countries.Infrastructure.Repositories;
using Countries.Application.Dtos;
using Countries.Domain.Entities;
using Countries.Application.Converters;

namespace Countries.API
{
    [ExcludeFromCodeCoverage]
    public class Startup
    {
        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        public IConfiguration Configuration { get; }

        // This method gets called by the runtime. Use this method to add services to the container.
        public void ConfigureServices(IServiceCollection services)
        {
            services.AddControllers();

            services.AddDbContext<CountryContext>(
                 options => options.UseInMemoryDatabase("CountryDB"));

            services.AddSwaggerGen(c =>
            {
                c.SwaggerDoc("v1", new OpenApiInfo { Title = "Countries.API", Version = "v1" });
            });

            services.AddMediatR(typeof(CreateCountry).GetTypeInfo().Assembly);

            Assembly assembly = typeof(CreateCountryValidator).Assembly;
            services.AddFluentValidation(new[] { assembly });

            services.AddScoped(typeof(IRepository<>), typeof(Repository<>));
            services.AddTransient<ICountryRepository, CountryRepository>();

            services.AddScoped<ITypeConverter<Country, CountryDto>, CountryDtoConverter>();
            services.AddScoped<ITypeConverter<CountryDto, Country>, CountryConverter>();
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
                app.UseSwagger();
                app.UseSwaggerUI(c => c.SwaggerEndpoint("/swagger/v1/swagger.json", "Countries.API v1"));
            }

            app.UseHttpsRedirection();

            app.UseRouting();

            app.UseAuthorization();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
            });
        }
    }
}
