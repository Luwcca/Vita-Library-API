using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.EntityFrameworkCore;
using Microsoft.IdentityModel.Tokens;
using Microsoft.OpenApi.Models;
using System.Reflection;
using WebApi_Biblioteca.Data;

namespace WebApi_Biblioteca;

public class Program
{
    public static void Main(string[] args)
    {
        var builder = WebApplication.CreateBuilder(args);

        var connectionString = builder.Configuration.GetConnectionString("VitaLibrary");

        // Add services to the container.

        builder.Services.AddDbContext<BibliotecaContext>(opt =>
            opt.UseLazyLoadingProxies().UseSqlServer(connectionString));

        //add Automapper em todo App domain
        builder.Services.AddAutoMapper(AppDomain.CurrentDomain.GetAssemblies());

        //add autenticação jwt bearer
        builder.Services.AddAuthentication(opt =>
        {
            //especifica o esquema de autenticação e o desafio como jwt por padrão
            opt.DefaultAuthenticateScheme = JwtBearerDefaults.AuthenticationScheme;
            opt.DefaultChallengeScheme = JwtBearerDefaults.AuthenticationScheme;
            //especifica as configurações de validação do token
        }).AddJwtBearer(options =>
        {
            options.TokenValidationParameters = new TokenValidationParameters
            {
                ValidateIssuer = true,
                ValidateAudience = true,
                ValidateLifetime = true,
                IssuerSigningKey = new SymmetricSecurityKey(System.Text.Encoding.UTF8.GetBytes(builder.Configuration["Jwt:SecretKey"])),
                ClockSkew = TimeSpan.Zero,
                ValidIssuer = builder.Configuration["Jwt:Issuer"],
                ValidAudience = builder.Configuration["Jwt:Audience"]
            };
        });


        builder.Services.AddControllers();

        // Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
        builder.Services.AddEndpointsApiExplorer();

        builder.Services.AddSwaggerGen(c =>
        {
            //adição de definição Bearer de segurança
            c.AddSecurityDefinition("Bearer", new OpenApiSecurityScheme()
            {
                Name = "Authorization", //cabeçalho do token
                Type = SecuritySchemeType.ApiKey, //tipo de autorização realizada por chave de api
                Scheme = "Bearer", //esquema bearer
                BearerFormat = "JWT",//formato jwt
                In = ParameterLocation.Header,//Indica que o token deve ser atrelado ao header request
                Description = "Autorização utilizando Bearer Jwt. \r\n Escreva Bearer + o token gerado no LogIn"
            });
            //Requisita que as operações da API necessitem do Bearer
            c.AddSecurityRequirement(new OpenApiSecurityRequirement()
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

            //documentação
            c.SwaggerDoc("v1", new OpenApiInfo { Title = "WebApi-Biblioteca", Version = "v1" });
            var xmlFile = $"{Assembly.GetExecutingAssembly().GetName().Name}.xml";
            var xmlPath = Path.Combine(AppContext.BaseDirectory, xmlFile);
            c.IncludeXmlComments(xmlPath);

        });

        var app = builder.Build();

        // Configure the HTTP request pipeline.
        if (app.Environment.IsDevelopment())
        {
            app.UseSwagger();
            app.UseSwaggerUI();
        }

        app.UseHttpsRedirection();

        app.UseAuthentication();
        app.UseAuthorization();


        app.MapControllers();

        app.Run();
    }
}