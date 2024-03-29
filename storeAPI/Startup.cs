using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.FileProviders;
using StackExchange.Redis;
using storeAPI.Extensions;
using storeAPI.Helpers;
using storeAPI.Middleware;
using storeInfrastructure.Data;
using storeInfrastructure.Identity;
using System.IO;

namespace storeAPI
{
    public class Startup
    {
        //added
        private readonly IConfiguration _configuration;
        public Startup(IConfiguration configuration)
        {
            _configuration = configuration;
        }


        // This method gets called by the runtime. Use this method to add services to the container.
        public void ConfigureServices(IServiceCollection services)
        {

            //Add
            //services.AddScoped<IProductRepository, ProductRepository>();
            //services.AddScoped(typeof(IGenericRepository<>), (typeof(GenericRepository<>)));
            services.AddAutoMapper(typeof(MappingProfiles));

            services.AddControllers();

            //MySql 
            var connectionString = _configuration.GetConnectionString("DefaultConnection");
            services.AddDbContext<StoreContext>(options => options.UseMySql(connectionString, ServerVersion.AutoDetect(connectionString)));

            //IdentityDbContext
            var identityConnectionString = _configuration.GetConnectionString("IdentityConnection");
            services.AddDbContext<AppIdentityDbContext>(options => options.UseMySql(identityConnectionString, ServerVersion.AutoDetect(identityConnectionString)));


            //add rediss
            services.AddSingleton<IConnectionMultiplexer>(c =>
            {
                var configuration = ConfigurationOptions.Parse(_configuration.GetConnectionString("Redis"), true);
                configuration.AbortOnConnectFail = false;
                return ConnectionMultiplexer.Connect(configuration);
            });

            // get application services extensions
            services.AddApplicationServices();

            services.AddIdentityServices(_configuration);

            /*services.AddSwaggerGen(c =>
            {
                c.SwaggerDoc("v1", new OpenApiInfo { Title = "storeAPI", Version = "v1" });
            });*/
            // get swager services extensions
            services.AddSwaggerDocumantation();

            //add
            /*services.Configure<ApiBehaviorOptions>(options =>
            {
                options.InvalidModelStateResponseFactory = ActionContext =>
                {
                    var errors = ActionContext.ModelState
                        .Where(e => e.Value.Errors.Count > 0)
                        .SelectMany(x => x.Value.Errors)
                        .Select(x => x.ErrorMessage).ToArray();

                    var errorResponse = new ApiValidationErrorResponse
                    {
                        Errors = errors
                    };

                    return new BadRequestObjectResult(errorResponse);
                };
            });*/


            //Cors
            services.AddCors(options =>
            {
                options.AddPolicy("CorsDevPolicy", builder =>
                {
                    builder.AllowAnyOrigin()
                            .AllowAnyMethod()
                            .AllowAnyHeader();
                });
            });

        }


        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {   
            
            // for the errors
            app.UseMiddleware<ExceptionMiddleware>();

            // we took it out of the function
            //app.UseSwagger();
            //app.UseSwaggerUI(c => c.SwaggerEndpoint("/swagger/v1/swagger.json", "storeAPI v1"));

            // get swager services extensions
            app.UseSwaggerDocumantion(); 

            /*if (env.IsDevelopment())
            {
                //app.UseDeveloperExceptionPage();
                app.UseSwagger();
                app.UseSwaggerUI(c => c.SwaggerEndpoint("/swagger/v1/swagger.json", "storeAPI v1"));
            }*/

            //add for errors
            app.UseStatusCodePagesWithReExecute("/errors/{0}");

            app.UseHttpsRedirection();
            app.UseRouting();


 
            //add for images 
            //before that cors policy must be defined because static files need to cors policy
            app.UseStaticFiles();

            app.UseStaticFiles(new StaticFileOptions
            {
                FileProvider = new PhysicalFileProvider(
                    Path.Combine(Directory.GetCurrentDirectory(),"Content")),
                RequestPath = "/content"
            });

            //cors
            app.UseCors("CorsDevPolicy");

            app.UseAuthentication();
            app.UseAuthorization();
            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
                endpoints.MapFallbackToController("Index", "Fallback");
            });
        }
    }
}
