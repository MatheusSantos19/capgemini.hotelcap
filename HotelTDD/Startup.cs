using HotelTDD.Domain.Interface;
using HotelTDD.Infra.Context;
using HotelTDD.Repository;
using HotelTDD.Services.ClientService;
using HotelTDD.Services.Interface;
using HotelTDD.Services.Invoice;
using HotelTDD.Services.Occupation;
using HotelTDD.Services.Room;
using HotelTDD.Services.TypeRoom;
using HotelTDD.Services.User;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.IdentityModel.Tokens;
using Microsoft.OpenApi.Models;
using Swashbuckle.AspNetCore.SwaggerUI;
using System.Text;



namespace HotelTDD
{
    public class Startup
    {
        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }



        public IConfiguration Configuration { get; }



        public void ConfigureServices(IServiceCollection services)
        {
            string connectionString = Configuration.GetConnectionString("HotelDB");



            services.AddDbContext<HotelContext>(options =>
                                                      options.UseSqlServer(connectionString));




            services.AddScoped<IRoomService, RoomService>();
            services.AddScoped<ITypeRoomService, TypeRoomService>();
            services.AddScoped<IClientService, ClientService>();
            services.AddScoped<IOccupationService, OccupationService>();
            services.AddScoped<IInvoiceService, InvoiceService>();
            services.AddScoped<IUserService, UserService>();



            services.AddScoped<IRoomRepository, RoomRepository>();
            services.AddScoped<IClientRepository, ClientRepository>();
            services.AddScoped<ITypeRoomRepository, TypeRoomRepository>();
            services.AddScoped<IOccupationRepository, OccupationRepository>();
            services.AddScoped<IUserRepository, UserRepository>();



            services.AddControllers();



            services.AddSwaggerGen(swagger =>
            {
                swagger.SwaggerDoc("v1", new OpenApiInfo
                {
                    Version = "v1",
                    Title = "Servirtual - Auth.API V1",
                    Description = "Auth.API V1",
                    Contact = new OpenApiContact()
                    {
                        Name = "Roh",
                        Email = "roh@servirtual.com.br",
                        Url = new System.Uri("http://www.servirtual.com.br")
                    }
                });



                swagger.AddSecurityDefinition("Bearer", new OpenApiSecurityScheme
                {
                    Name = "Authorization",
                    Type = SecuritySchemeType.Http,
                    Scheme = "Bearer",
                    In = ParameterLocation.Header,
                    Description = "JWT Authorization header using the Bearer scheme. Example: \"Authorization: Bearer {token}\"",
                });



                swagger.AddSecurityRequirement(new OpenApiSecurityRequirement
                {
                    {
                          new OpenApiSecurityScheme
                            {
                                Reference = new OpenApiReference
                                {
                                    Type = ReferenceType.SecurityScheme,
                                    Id = "Bearer"
                                }
                            },
                            new string[] {}
                    }
                });



                //swagger.OperationFilter<ExamplesOperationFilter>();
            });



            var key = Encoding.ASCII.GetBytes("fedaf7d8863b48e197b9287d492b708e");



            services.AddAuthentication(x =>
            {
                x.DefaultAuthenticateScheme = JwtBearerDefaults.AuthenticationScheme;
                x.DefaultChallengeScheme = JwtBearerDefaults.AuthenticationScheme;
            })
            .AddJwtBearer(x =>
            {
                x.RequireHttpsMetadata = false;
                x.SaveToken = true;
                x.TokenValidationParameters = new TokenValidationParameters
                {
                    ValidateIssuerSigningKey = true,
                    IssuerSigningKey = new SymmetricSecurityKey(key),
                    ValidateIssuer = false,
                    ValidateAudience = false
                };
            });
        }



        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }



            app.UseHttpsRedirection();



            app.UseSwagger();



            app.UseSwaggerUI(c =>
            {
                c.SwaggerEndpoint($"/swagger/v1/swagger.json", "Auth.API V1");
                c.DocumentTitle = "Auth API";
                c.DocExpansion(DocExpansion.None);
            });



            app.UseAuthentication();



            app.UseRouting();



            app.UseAuthorization();



            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
            });
        }
    }
}
