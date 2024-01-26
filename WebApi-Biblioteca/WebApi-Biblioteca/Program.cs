using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using WebApi_Biblioteca.Data;
using WebApi_Biblioteca.Models;

namespace WebApi_Biblioteca;

public class Program
{
    public static void Main(string[] args)
    {
        var builder = WebApplication.CreateBuilder(args);

        var connectionString = builder.Configuration.GetConnectionString("VitaLibrary");

        // Add services to the container.

        builder.Services.AddDbContext<BibliotecaContext>(opt =>
            opt.UseSqlServer(connectionString));

        //add Automapper em todo App domain
        builder.Services.AddAutoMapper(AppDomain.CurrentDomain.GetAssemblies());


        builder.Services.AddControllers();

        // Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
        builder.Services.AddEndpointsApiExplorer();
        builder.Services.AddSwaggerGen();

        var app = builder.Build();

        // Configure the HTTP request pipeline.
        if (app.Environment.IsDevelopment())
        {
            app.UseSwagger();
            app.UseSwaggerUI();
        }

        app.UseHttpsRedirection();

        app.UseAuthorization();


        app.MapControllers();

        app.Run();
    }
}