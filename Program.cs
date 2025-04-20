using Microsoft.Extensions.Options;
using Microsoft.OpenApi.Models;
using Microsoft.EntityFrameworkCore;
using System.Security.Cryptography.Xml;
using Moves_API_.Models;

namespace Moves_API_
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);

            var connectionString = builder.Configuration.GetConnectionString("DefaultConnection");
            builder.Services.AddDbContext<ApplicationDbContext>(options =>
                options.UseSqlServer(connectionString));    
            // Add services to the container.

            builder.Services.AddControllers();
            // Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
            builder.Services.AddEndpointsApiExplorer();//يسمح باكتشاف الـ Endpoints الموجودة في التطبيق.

            //Enable To Cores
            builder.Services.AddCors();
            builder.Services.AddSwaggerGen(Options =>
            {
                //معلومات إضافية إلى توثيق Swagger(عند فتح Swagger UI، سيتم عرض هذه التفاصيل في التوثيق، مما يسهل فهم كيفية استخدام API.)
                Options.SwaggerDoc("v1", new Microsoft.OpenApi.Models.OpenApiInfo
                {
                    Title = "Moves(API)52",
                    Version = "v1",
                    Description = "My first API for Moves(API)",
                    TermsOfService = new Uri("https://example.com/terms"),//رابط الشروط والأحكام 
                    Contact = new Microsoft.OpenApi.Models.OpenApiContact
                    {
                        Name = "NOUR  SOFT",
                        Email = "L5v8r@example.com",
                        Url = new Uri("https://twitter.com/spdx")
                    },
                    License = new Microsoft.OpenApi.Models.OpenApiLicense //رابط الترخيص (License) الذي يوضح نوع الترخيص المستخدم.
                    {
                        Name = "Use under LICX",
                        Url = new Uri("https://example.com/license")
                    }
                });

                //عند فتح Swagger، سيظهر زر "Authorize" حيث يمكن إدخال JWT Token لتجربة الـ API كأنك مستخدم موثّق.
                Options.AddSecurityDefinition("Bearer", new Microsoft.OpenApi.Models.OpenApiSecurityScheme
                { 
                    Name = "Authorization",// يحدد اسم الهيدر الذي سيتم إرسال التوكن فيه.
                    Type = Microsoft.OpenApi.Models.SecuritySchemeType.Http,
                    Scheme = "bearer",
                    BearerFormat = "JWT",
                    In = Microsoft.OpenApi.Models.ParameterLocation.Header,// يشير إلى أن التوكن سيتم إرساله في رأس الطلب (Header).
                    Description = "JWT Authorization header using the Bearer scheme."
                
                
                });
                //بعد هذا التعديل، عندما تحاول تنفيذ أي طلب في Swagger UI، سيطلب منك إدخال JWT Token أولًا، وإلا فلن تتمكن من إرسال الطلبات. هذا يجعل الـ API أكثر أمانًا ويحمي البيانات من الوصول غير المصرح به. 🚀
                //هذا التعديل يضيف متطلبات الأمان (Security Requirements) إلى Swagger، مما يعني أن كل طلب API محمي بالتوثيق JWT ما لم يكن مسموحًا به بشكل صريح.
                Options.AddSecurityRequirement(new OpenApiSecurityRequirement // يخبر Swagger بأن كل طلب إلى API يتطلب توثيق JWT افتراضيًا.
                    {
                        {
                            new OpenApiSecurityScheme //يحدد نوع الأمان المستخدم في الطلبات.
                            {
                                Reference = new OpenApiReference
                                {
                                    Type = ReferenceType.SecurityScheme,
                                    Id = "Bearer"
                                },
                                Name = "Bearer",
                                In = ParameterLocation.Header
                            },
                            new List<string>()
                        }
                    });
                

            });

            var app = builder.Build();

            // Configure the HTTP request pipeline.
            //تهيئة (Configuration) الـ Middleware
            if (app.Environment.IsDevelopment())
            {
                //إذا كان التطبيق يعمل في بيئة التطوير (Development):
                app.UseSwagger();//يتم تفعيل Swagger(app.UseSwagger()) لإنشاء الوثائق.
                app.UseSwaggerUI();
            }

            app.UseHttpsRedirection();//إجبار استخدام HTTPS بدلاً من HTTP لتحسين الأمان.


            //Enable To Cores
            app.UseCors(c => c.AllowAnyHeader().AllowAnyMethod().AllowAnyOrigin());//Withorigin (url....)بحدد مين الى يتعامل  مع api 
                            //مين الى ياكسس من برا الشبكه 

            app.UseAuthorization();//يضيف Authorization Middleware للتحقق من صلاحيات المستخدم قبل الوصول للـ API.


            app.MapControllers();//يحدد أن جميع الـ API Controllers سيتم استخدامها للتعامل مع الطلبات.

            app.Run();
        }
    }
}
