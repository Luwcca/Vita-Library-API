using AutoMapper;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WebApi_Biblioteca.Data;
using WebApi_Biblioteca.Profiles;

namespace WebApi_Biblioteca_Tests;

public class LivrosUnitTestController
{
    public IMapper mapper;

    public  static DbContextOptions<BibliotecaContext> dbContextOptions;

    public static string ConnectionString =
        "Data Source=DESKTOP-7GN0E4U\\SQLEXPRESS;Initial Catalog=Biblioteca;Trusted_Connection=True;TrustServerCertificate=True;Encrypt=False;";


    static LivrosUnitTestController()
    {
        dbContextOptions = new DbContextOptionsBuilder<BibliotecaContext>()
            .UseSqlServer(ConnectionString).Options;
    }

    public LivrosUnitTestController()
    {
        var config = new MapperConfiguration(cfg =>
        {
            cfg.AddProfile(new LivroProfile());
        });
        
        mapper = config.CreateMapper();

        var context = new BibliotecaContext(dbContextOptions);
    }
}
