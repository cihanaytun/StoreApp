using Microsoft.AspNetCore.Builder;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.OpenApi.Models;

namespace storeAPI.Extensions
{
    public static class SwaggerServiceExtensions
    {
        public static IServiceCollection AddSwaggerDocumantation (this IServiceCollection services)
        {
            services.AddSwaggerGen(c =>
            {
                c.SwaggerDoc("v1", new OpenApiInfo { 
                    Title = "storeAPI",
                    Version = "v1" ,
                    //add
                    Description = "This Application Prefare For Store App ",
                    Contact = new OpenApiContact
                    {
                        Name ="Cihan",
                        Email ="cihan_aytun@hotmail.com",          
                    }
                    
                });

                //add
                var securtiySchema = new OpenApiSecurityScheme
                {
                    Description = "JWT Auth Bearer Scheme",
                    Name = "Authorization",
                    In = ParameterLocation.Header,
                    Type = SecuritySchemeType.Http,
                    Scheme = "bearer",
                    Reference = new OpenApiReference
                    {
                        Type = ReferenceType.SecurityScheme,
                        Id = "Bearer"
                    }
                };
                c.AddSecurityDefinition("Bearer", securtiySchema);


                var securityRequirment = new OpenApiSecurityRequirement { { securtiySchema, new[] { "Bearer" } } };
                c.AddSecurityRequirement(securityRequirment);
            });

            return services;
        }


        public static IApplicationBuilder UseSwaggerDocumantion(this IApplicationBuilder app)
        {
            app.UseSwagger();
            app.UseSwaggerUI(c => 
                c.SwaggerEndpoint("/swagger/v1/swagger.json", "storeAPI v1")
                );

            return app;
        }
    }
}
