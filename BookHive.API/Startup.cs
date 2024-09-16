using BookHive.DBClient.Contracts;
using BookHive.DBClient.Repositories;
using Microsoft.AspNetCore.StaticFiles;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.FileProviders;

namespace BookHive.API
{
    public class Startup
    {
        private const string AllowAnyOrigins = "AllowAnyOrigin";
        public IConfiguration Configuration { get; }

        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        //This method gets called by the runtime. Use this method to add services to the container.
        public void ConfigureServices(IServiceCollection services)
        {
            services.AddCors(c =>
            {
                c.AddPolicy(AllowAnyOrigins, options => options.AllowAnyOrigin().AllowAnyHeader().AllowAnyMethod());
            });
            services.AddDbContext<EFDbContext>(options => options.UseSqlServer
            (Configuration.GetConnectionString("DefaultConnection")));

            // Configure DBClient dependency injection repositories
            services.AddScoped<ISampleRepository, EFSampleRepository>();
            services.AddScoped<IBookRepository, EFBookRepository>();
            services.AddScoped<IBookCategoryRepository, EFBookCateogaryRepository>();


            services.AddControllers();

            // Addlogging
            services.AddLogging(builder =>
            {
                builder.AddLog4Net();
            });

            // In production, the React files will be served from this directory
            services.AddSpaStaticFiles(configuration =>
            {
                configuration.RootPath = "Root";
            });
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            var provider = new FileExtensionContentTypeProvider();
            provider.Mappings[".res"] = "application/octet-stream";
            provider.Mappings[".pexe"] = "application/x-pnacl";
            provider.Mappings[".nmf"] = "application/octet-stream";
            provider.Mappings[".mem"] = "application/octet-stream";
            provider.Mappings[".wasm"] = "application/wasm";

            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }
            app.UseHttpsRedirection();
            app.UseCors(AllowAnyOrigins);
            app.UseSpaStaticFiles();
            app.UseDefaultFiles();
            app.UseStaticFiles();
            app.UseStaticFiles(new StaticFileOptions
            {
                FileProvider = new PhysicalFileProvider(
                    Path.Combine(Directory.GetCurrentDirectory(), "Root")),
                ContentTypeProvider = provider
            });
            app.UseRouting();
            app.UseAuthorization();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
            });

            app.UseSpa(spa =>
            {
                spa.Options.SourcePath = "Root";
            });
        }
    }
}
