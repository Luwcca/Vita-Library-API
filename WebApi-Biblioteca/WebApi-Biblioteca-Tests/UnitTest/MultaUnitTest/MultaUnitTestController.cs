using Microsoft.EntityFrameworkCore;
using WebApi_Biblioteca.Data;

namespace WebApi_Biblioteca_Tests.UnitTest.MultaUnitTest;

public class MultaUnitTestController
{

    public BibliotecaContext context;

    public static DbContextOptions<BibliotecaContext> dbContextOptions;

    public static string ConnectionString =
        "Data Source=DESKTOP-7GN0E4U\\SQLEXPRESS;Initial Catalog=Biblioteca;Trusted_Connection=True;TrustServerCertificate=True;Encrypt=False;";


    static MultaUnitTestController()
    {
        dbContextOptions = new DbContextOptionsBuilder<BibliotecaContext>()
            .UseSqlServer(ConnectionString).Options;
    }

    public MultaUnitTestController()
    {

        context = new BibliotecaContext(dbContextOptions);
    }
}
