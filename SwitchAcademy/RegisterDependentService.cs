using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.AspNetCore.Mvc.ViewFeatures;
using Microsoft.EntityFrameworkCore;
using Microsoft.IdentityModel.Tokens;
using Microsoft.OpenApi.Models;
using SwitchAcademy.Persistence.GenericRepository;
using SwitchAcademy.Persistence.Models;
using SwitchAcademy.Services.Implementations;
using SwitchAcademy.Services.Interfaces;
using System.Text;

namespace SwitchAcademy
{
    public static class RegisterDependentService
    {
        public static WebApplicationBuilder RegisterServices(this WebApplicationBuilder builder)
        {

            builder.Services.AddDbContext<DataContext>(x => x.UseSqlServer(builder.Configuration.GetConnectionString("DefaultConnection")
                , context =>
                {
                    context.EnableRetryOnFailure(5, TimeSpan.FromSeconds(10), null);
                }));

            builder.Services.AddHttpContextAccessor();
            builder.Services.AddControllers();
            builder.Services.AddMvc();
            builder.Services.AddScoped(typeof(IEntityFrameworkRepository<>), typeof(EntityFrameworkRepository<>));
            builder.Services.AddScoped<IAuthService, AuthService>();
            builder.Services.AddScoped<ITokenService, TokenService>();
            builder.Services.AddScoped<ITrainingTrackService, TrainingTrackService>();
            builder.Services.AddScoped<IUserService, UserService>();
            builder.Services.AddScoped<IEmailService, EmailService>();
            builder.Services.AddAutoMapper(typeof(Program).Assembly);
            // builder.Services.AddIdentityServices();
            //builder.Services.AddControllersWithViews()
            //     .AddNewtonsoftJson(options =>
            //     options.SerializerSettings.ReferenceLoopHandling = Newtonsoft.Json.ReferenceLoopHandling.Ignore
            // );

            builder.Services.AddControllers().AddNewtonsoftJson(options =>
               options.SerializerSettings.ReferenceLoopHandling = Newtonsoft.Json.ReferenceLoopHandling.Ignore
           );
            IConfiguration configuration = builder.Configuration;
            builder.Services.AddAuthentication(JwtBearerDefaults.AuthenticationScheme)
               .AddJwtBearer(options =>
               {
                   options.TokenValidationParameters = new TokenValidationParameters
                   {
                       ValidateIssuerSigningKey = true,
                       IssuerSigningKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(configuration["TokenKey"])),
                       ValidateIssuer = false,
                       ValidateAudience = false
                   };
               });

            builder.Services.AddSwaggerGen(c =>
            {
                c.SwaggerDoc("v1", new OpenApiInfo { Title = "SwitchAcademyAPI", Version = "v1" });

                var security = new Dictionary<string, IEnumerable<string>>
                {
                    {"", new string[] { }},
                };
                c.AddSecurityDefinition("Bearer", new OpenApiSecurityScheme
                {
                    Description = "JWT Authorization header using the Bearer scheme. Example: \"Authorization: Bearer {token}\"",
                    Name = "Authorization",
                    In = ParameterLocation.Header,
                    Type = SecuritySchemeType.ApiKey
                });
                c.AddSecurityRequirement(new OpenApiSecurityRequirement() {
                    {
                        new OpenApiSecurityScheme
                        {
                            Reference = new OpenApiReference
                            {
                                Type = ReferenceType.SecurityScheme,
                                Id = "Bearer"
                            },
                            Name = "Bearer",
                            In = ParameterLocation.Header,

                        },
                        new List<string>()
                    }
                });
                //var xmlFile = $"{Assembly.GetExecutingAssembly().GetName().Name}.xml";
                //var xmlPath = Path.Combine(AppContext.BaseDirectory, xmlFile);
                //c.IncludeXmlComments(xmlPath);
            });
            //builder.Services.AddSwaggerExamplesFromAssemblies(typeof(Program).Assembly);
            builder.Services.AddMemoryCache();
            builder.Services.AddCors();

            return builder;
        }
    }
}
