using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.HttpsPolicy;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;
using Microsoft.Extensions.Options;
using Swashbuckle.AspNetCore.Swagger;
using Swashbuckle.AspNetCore.SwaggerGen;
using Videoteka.WebAPI.Database;
using Videoteka.WebAPI.Security;
using Videoteka.WebAPI.Services;

namespace Videoteka.WebAPI
{
    public class Startup
    {
        public class BasicAuthDocumentFilter : IDocumentFilter
        {
            public void Apply(SwaggerDocument swaggerDoc, DocumentFilterContext context)
            {
                var securityRequirements = new Dictionary<string, IEnumerable<string>>()
        {
            { "basic", new string[] { } }  // in swagger you specify empty list unless using OAuth2 scopes
        };

                swaggerDoc.Security = new[] { securityRequirements };
            }
        }
        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        public IConfiguration Configuration { get; }

        // This method gets called by the runtime. Use this method to add services to the container.
        public void ConfigureServices(IServiceCollection services)
        {
            services.AddMvc().AddJsonOptions(options => {

                options.SerializerSettings.ReferenceLoopHandling =

                    Newtonsoft.Json.ReferenceLoopHandling.Ignore;

            }).SetCompatibilityVersion(CompatibilityVersion.Version_2_1);
            services.AddAutoMapper();

            // Register the Swagger generator, defining 1 or more Swagger documents
            services.AddSwaggerGen(c =>
            {
                c.SwaggerDoc("v1", new Info { Title = "My API", Version = "v1" });
                c.AddSecurityDefinition("basic", new BasicAuthScheme() { Type = "basic" });
                c.DocumentFilter<BasicAuthDocumentFilter>();
            });

            services.AddAuthentication("BasicAuthentication")
                .AddScheme<AuthenticationSchemeOptions, BasicAuthenticationHandler>("BasicAuthentication", null);

            var connection = @"Server=.;Database=Videoteka2;Trusted_Connection=True;ConnectRetryCount=0";
            services.AddDbContext<VideotekaContext>(options => options.UseSqlServer(connection));



            services.AddScoped<IKorisniciService, KorisniciService>();
            services.AddScoped<IKlijentService, KlijentService>();
            services.AddScoped<ICRUDService<Model.Models.Grad, Model.Requests.GradSearchRequest,Model.Requests.GradUpsertRequest, Model.Requests.GradUpsertRequest>, GradoviService>();
            services.AddScoped<ICRUDService<Model.Models.Zanr, Model.Requests.ZanrSearchRequest,Model.Requests.ZanrUpsertRequest, Model.Requests.ZanrUpsertRequest>, ZanrService>();
            services.AddScoped<ICRUDService<Model.Models.Drzava, Model.Requests.DrzavaSearchRequest, Model.Requests.DrzavaUpsertRequest, Model.Requests.DrzavaUpsertRequest>, DrzaveService>();
            services.AddScoped<ICRUDService<Model.Models.Reziser, Model.Requests.ReziserSearchRequest, Model.Requests.ReziserUpsertRequest, Model.Requests.ReziserUpsertRequest>, ReziseriService>();
            services.AddScoped<IService<Model.Models.Uloge, object>, BaseService<Model.Models.Uloge, object, Database.Uloge>>();
            services.AddScoped<IService<Model.Models.KorisniciUloge, Model.Requests.KorisniciUlogeSearchRequest>, KorisniciUlogeService>();
            services.AddScoped<ICRUDService<Model.Models.Film, Model.Requests.FilmSearchRequest, Model.Requests.FilmUpsertRequest, Model.Requests.FilmUpsertRequest>, FilmService>();
            services.AddScoped<ICRUDService<Model.Models.Poruka, Model.Requests.PorukaSearchRequest, Model.Requests.PorukaUpsertRequest, Model.Requests.PorukaUpsertRequest>, PorukaService>();
            services.AddScoped<ICRUDService<Model.Models.Racun, Model.Requests.RacunSearchRequest, Model.Requests.RacunUpsertRequest, Model.Requests.RacunUpsertRequest>, RacunService>();
            services.AddScoped<ICRUDService<Model.Models.Ocjena, Model.Requests.OcjenaSearchRequest, Model.Requests.OcjenaUpsertRequest, Model.Requests.OcjenaUpsertRequest>, OcjenaService>();
            services.AddScoped<ICRUDService<Model.Models.RezervacijaFilma, Model.Requests.RezervacijaFilmaSearchRequest, Model.Requests.RezervacijaFilmaUpsertRequest, Model.Requests.RezervacijaFilmaUpsertRequest>, RezervacijaFilmovaService>();


        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IHostingEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }
            else
            {
                app.UseHsts();
            }


            app.UseSwagger();

            app.UseSwaggerUI(c =>
            {
                c.SwaggerEndpoint("/swagger/v1/swagger.json", "My API V1");
            });

            app.UseAuthentication();

            //app.UseHttpsRedirection();

            app.UseMvc();

        }
    }
}
