using AutoMapper;
using Microsoft.EntityFrameworkCore;
using WebApi_Biblioteca.Data;
using WebApi_Biblioteca.Profiles;

namespace WebApi_Biblioteca_Tests.UnitTest.EditoraUnitTest;

public class EditoraUnitTestController
{
    public IMapper mapper;

    public BibliotecaContext context;

    public static DbContextOptions<BibliotecaContext> dbContextOptions;

    public static string ConnectionString =
        "Data Source=DESKTOP-7GN0E4U\\SQLEXPRESS;Initial Catalog=Biblioteca;Trusted_Connection=True;TrustServerCertificate=True;Encrypt=False;";


    static EditoraUnitTestController()
    {
        dbContextOptions = new DbContextOptionsBuilder<BibliotecaContext>()
            .UseSqlServer(ConnectionString).Options;
    }

    public EditoraUnitTestController()
    {
        var config = new MapperConfiguration(cfg =>
        {
            cfg.AddProfile(new EditoraProfile());
        });

        mapper = config.CreateMapper();

        context = new BibliotecaContext(dbContextOptions);
    }
}
