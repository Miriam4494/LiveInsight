

//using LiveFeedback.Core.Interfaces.IRepositories;
//using LiveFeedback.Core.Interfaces.IServices;
//using LiveFeedback.Data;
//using LiveFeedback.Data.Repositories;
//using LiveFeedback.Services.Services;
//using Microsoft.EntityFrameworkCore;


//namespace LiveFeedback.API
//{
//    public class Program
//    {
//        public static void Main(string[] args)
//        {
//            var builder = WebApplication.CreateBuilder(args);

//            builder.Services.AddScoped(typeof(IRepository<>), typeof(Repository<>));

//            builder.Services.AddScoped<IUserRepository, UserRepository>();
//            builder.Services.AddScoped<IRoleRepository, RoleRepository>();
//            builder.Services.AddScoped<IPermissionRepository, PermissionRepository>();
//            builder.Services.AddScoped<IQuestionRepository, QuestionRepository>();
//            builder.Services.AddScoped<IMyImageRepository, MyImageRepository>();
//            builder.Services.AddScoped<IFeedbackRepository, FeedbackRepository>();

//            builder.Services.AddScoped<IUserService, UserService>();
//            builder.Services.AddScoped<IRoleService, RoleService>();
//            builder.Services.AddScoped<IPermissionService, PermissionService>();
//            builder.Services.AddScoped<IQuestionService, QuestionService>();
//            builder.Services.AddScoped<IMyImageService, MyImageService>();
//            builder.Services.AddScoped<IFeedbackService, FeedbackService>();

//            builder.Services.AddControllers();
//       //     builder.Services.AddDbContext<DataContext>(options =>
//       //options.UseSqlServer(builder.Configuration.GetConnectionString("DefaultConnection")));

//            builder.Services.AddDbContext<DataContext>();




//            // Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
//            builder.Services.AddEndpointsApiExplorer();
//            builder.Services.AddSwaggerGen();


//            // Configure the HTTP request pipeline.
//            var app = builder.Build();
//            if (app.Environment.IsDevelopment())
//            {
//                app.UseSwagger();
//                app.UseSwaggerUI();


//            }
//            builder.Services.AddCors();


//            app.UseHttpsRedirection();

//            app.UseAuthorization();


//            app.MapControllers();

//            app.Run();
//        }
//    }
//}
using LiveFeedback.Core;
using LiveFeedback.Core.Interfaces.IRepositories;
using LiveFeedback.Core.Interfaces.IServices;
using LiveFeedback.Data;
using LiveFeedback.Data.Repositories;
using LiveFeedback.Services.Services;
using AutoMapper;
using Microsoft.AspNetCore.Authentication.JwtBearer;



//using LiveFeedback.Services.Services.LiveFeedback.Services.Services;
using Microsoft.EntityFrameworkCore;
using Microsoft.IdentityModel.Tokens;
using System.Text;
using Microsoft.OpenApi.Models;
//using LiveFeedback.Service.Services;

namespace LiveFeedback.API
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);

            builder.Services.AddScoped(typeof(IRepository<>), typeof(Repository<>));

            builder.Services.AddScoped<IUserRepository, UserRepository>();
            builder.Services.AddScoped<IRoleRepository, RoleRepository>();
            builder.Services.AddScoped<IPermissionRepository, PermissionRepository>();
            builder.Services.AddScoped<IQuestionRepository, QuestionRepository>();
            builder.Services.AddScoped<IMyImageRepository, MyImageRepository>();
            builder.Services.AddScoped<IFeedbackRepository, FeedbackRepository>();

            builder.Services.AddScoped<IUserService, UserService>();
            builder.Services.AddScoped<IRoleService, RoleService>();
            builder.Services.AddScoped<IPermissionService, PermissionService>();
            builder.Services.AddScoped<IQuestionService, QuestionService>();
            builder.Services.AddScoped<IMyImageService, MyImageService>();
            builder.Services.AddScoped<IFeedbackService, FeedbackService>();
            builder.Services.AddSingleton<JwtService>();

            builder.Services.AddControllers();

            builder.Services.AddAutoMapper(typeof(MappingProfile), typeof(MappingProfilePostModel));

            // התחברות למסד הנתונים
            builder.Services.AddDbContext<DataContext>();

            // הגדרת Swagger
            builder.Services.AddEndpointsApiExplorer();
            // builder.Services.AddSwaggerGen();
            builder.Services.AddSwaggerGen(options =>
            {
                options.AddSecurityDefinition("Bearer", new OpenApiSecurityScheme
                {
                    Scheme = "Bearer",
                    BearerFormat = "JWT",
                    In = ParameterLocation.Header,
                    Name = "Authorization",
                    Description = "Bearer Authentication with JWT Token",
                    Type = SecuritySchemeType.Http
                });
                options.AddSecurityRequirement(new OpenApiSecurityRequirement
    {
        {
            new OpenApiSecurityScheme
            {
                Reference = new OpenApiReference
                {
                    Id = "Bearer",
                    Type = ReferenceType.SecurityScheme
                }
            },
            new List<string>()
        }
    });
            });

            // הגדרת CORS: מדיניות שמאפשרת לכל מקור לשלוח בקשות
            builder.Services.AddCors(options =>
            {
                options.AddPolicy("AllowAll", policy =>
                {
                    policy.AllowAnyOrigin().AllowAnyMethod().AllowAnyHeader();
                });
            });
            //JWT***

            builder.Services.AddAuthentication(JwtBearerDefaults.AuthenticationScheme)
.AddJwtBearer(options =>
{
options.TokenValidationParameters = new TokenValidationParameters
{
ValidateIssuer = true,
ValidateAudience = true,
ValidateLifetime = true,
ValidateIssuerSigningKey = true,
ValidIssuer = builder.Configuration["Jwt:Issuer"],
ValidAudience = builder.Configuration["Jwt:Audience"],
IssuerSigningKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(builder.Configuration["Jwt:Key"]))
};
});
            //builder.Services.AddAuthentication("Bearer")
            //.AddJwtBearer(options =>
            //{
            //    options.TokenValidationParameters = new TokenValidationParameters
            //    {
            //        ValidateIssuer = true,
            //        ValidateAudience = true,
            //        ValidateLifetime = true,
            //        ValidateIssuerSigningKey = true,
            //        ValidIssuer = builder.Configuration["Jwt:Issuer"],
            //        ValidAudience = builder.Configuration["Jwt:Audience"],
            //        IssuerSigningKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(builder.Configuration["Jwt:Key"]))
            //    };
            //});

            builder.Services.AddAuthorization();


            //***

            var app = builder.Build();
            app.UseCors();

            if (app.Environment.IsDevelopment())
            {
                app.UseSwagger();
                app.UseSwaggerUI();
            }





            // הפעלת CORS
            app.UseCors("AllowAllOrigins");





            app.UseHttpsRedirection();
            app.UseAuthentication(); // לפני Authorization

            app.UseAuthorization();


            app.MapControllers();

            app.Run();
        }
    }
}

