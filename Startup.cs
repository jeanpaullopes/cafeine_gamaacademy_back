using Cafeine_DinDin_Backend.Repositories;
using Cafeine_DinDin_Backend.Services;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.HttpsPolicy;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
using Microsoft.OpenApi.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Cafeine_DinDin_Backend
{
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
            services.AddCors(options =>
            {
                options.AddPolicy("Policy1",
                    builder =>
                    {
                        builder.WithOrigins("http://example.com",
                                            "http://www.contoso.com");
                    });

                options.AddPolicy("AnotherPolicy",
                    builder =>
                    {
                        builder.WithOrigins("http://www.contoso.com")
                                            .AllowAnyHeader()
                                            .AllowAnyMethod();
                    });
            });
            services.AddControllers();
            
            services.AddDbContext<ApplicationDBContext>(options =>
                options.UseSqlServer(Configuration.GetConnectionString("ApplicationDBSettings")));
            //services.AddSingleton<CourseRepository>();
            //services.AddSingleton<CourseService>();

            services.AddSwaggerGen(c =>
            {
                c.SwaggerDoc("v1", new OpenApiInfo { Title = "Cafeine_DinDin_Backend", Version = "v1" });
            });

            // aplicação de filtro anti CSRF - Cross-Site Request Forgery
            // não funciona com o swagger 
            //services.AddMvc(options =>
            //{
            //    options.Filters.Add(new AutoValidateAntiforgeryTokenAttribute());
            //});


            services.AddMvc().SetCompatibilityVersion(CompatibilityVersion.Version_2_2);

            services.AddCors(options => {
                options.AddPolicy("CorsPolicy", builder => builder
                .WithOrigins("*")
                .AllowAnyOrigin()
                .AllowAnyMethod()
                .AllowAnyHeader()
                );
            });

        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            //if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
                app.UseSwagger();
                app.UseSwaggerUI(c => c.SwaggerEndpoint("/swagger/v1/swagger.json", "Cafeine_DinDin_Backend v1"));
            }

            app.UseHttpsRedirection();

            app.UseRouting();
            app.UseCors("CorsPolicy");

            app.UseAuthorization();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
            });
            
        }
    }
}
