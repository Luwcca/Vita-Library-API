using FluentAssertions;
using Microsoft.AspNetCore.Mvc;
using WebApi_Biblioteca.Controllers;
using WebApi_Biblioteca.Data.Dtos.LivrosDtos;

namespace WebApi_Biblioteca_Tests.UnitTest.LivrosUnitTest;

public class GetLivroUnitTest : IClassFixture<LivrosUnitTestController>
{
    private readonly LivroController _controller;

    public GetLivroUnitTest(LivrosUnitTestController controller)
    {
        _controller = new LivroController(controller.context, controller.mapper);
    }

    [Fact]
    public void GetLivrosById_OKResult()
    {
        var livroId = 45;
        var data = _controller.GetLivrosByID(livroId);

        data.Result.Should().BeOfType<OkObjectResult>()
             .Which.StatusCode.Should().Be(200);

    }

    [Fact]
    public void GetLivrosById_NotFound_Result()
    {
        var livroId = 999;
        var data = _controller.GetLivrosByID(livroId);

        data.Result.Should().BeOfType<NotFoundObjectResult>()
            .Which.StatusCode.Should().Be(404);

    }

    [Fact]
    public void GetLivrosById_BadRequest_Result()
    {
        var livroId = 0;
        var data = _controller.GetLivrosByID(livroId);

        data.Result.Should().BeOfType<BadRequestObjectResult>()
               .Which.StatusCode.Should().Be(400);

    }

    [Fact]
    public void GetLivros_LivroDtoList_Result()
    {
        var data = _controller.GetLivros();

        data.Result.Should().BeOfType<OkObjectResult>()
             .Which.Value.Should().BeAssignableTo<IEnumerable<ReadLivroDto>>();
    }

}