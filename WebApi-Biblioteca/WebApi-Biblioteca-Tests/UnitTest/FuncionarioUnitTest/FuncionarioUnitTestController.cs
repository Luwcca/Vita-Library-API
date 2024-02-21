using AutoMapper;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using WebApi_Biblioteca.Data;
using WebApi_Biblioteca.Profiles;

namespace WebApi_Biblioteca_Tests.UnitTest.FuncionarioUnitTest;

public class FuncionarioUnitTestController
{
    public IMapper mapper;

    public IConfiguration configuration;
   
    public BibliotecaContext context;

    public static DbContextOptions<BibliotecaContext> dbContextOptions;

    public static string ConnectionString =
        "Data Source=DESKTOP-7GN0E4U\\SQLEXPRESS;Initial Catalog=Biblioteca;Trusted_Connection=True;TrustServerCertificate=True;Encrypt=False;";


    static FuncionarioUnitTestController()
    {
        dbContextOptions = new DbContextOptionsBuilder<BibliotecaContext>()
            .UseSqlServer(ConnectionString).Options;
    }

    public FuncionarioUnitTestController()
    {
        

        var config = new MapperConfiguration(cfg =>
        {
            cfg.AddProfile(new FuncionarioProfile());
        });

        mapper = config.CreateMapper();

        context = new BibliotecaContext(dbContextOptions);

    }
}
