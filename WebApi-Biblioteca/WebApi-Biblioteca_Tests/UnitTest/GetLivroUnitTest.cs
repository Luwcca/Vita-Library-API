using FluentAssertions;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WebApi_Biblioteca.Controllers;
using WebApi_Biblioteca.Data;

namespace WebApi_Biblioteca_Tests.UnitTest;

public class GetLivroUnitTest : IClassFixture<LivrosUnitTestController>
{
    private readonly LivroController _controller;
    private BibliotecaContext _context;

    public GetLivroUnitTest(LivrosUnitTestController controller, BibliotecaContext context)
    {
        _controller = new LivroController(controller.mapper);
        _context = context;
    }

    [Fact]
    public Task GetLivrosById_OKResult()
    {
        var livroId = 2;
        var data = _controller.GetLivrosByID(livroId);

        var okResult = Assert.IsType<OkObjectResult>(data.ExecuteResultAsync().Should);
        Assert.Equal(200, okResult.StatusCode);

    }


}
