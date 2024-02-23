using FluentAssertions;
using Microsoft.AspNetCore.Mvc;
using WebApi_Biblioteca.Controllers;
using WebApi_Biblioteca.Data.Dtos.EmprestimoDtos;

namespace WebApi_Biblioteca_Tests.UnitTest.EmprestimoUnitTest;

public class PatchEmprestimoUnitTest : IClassFixture<EmprestimoUnitTestController>
{
    private readonly EmprestimoController _controller;

    public PatchEmprestimoUnitTest(EmprestimoUnitTestController controller)
    {
        _controller = new EmprestimoController(controller.context, controller.mapper);
    }

    [Fact]
    public void PatchDevolucao_Ok_Result()
    {
        var emprestimoId = 53;

        var dto = new DevolucaoDto
        {
            Devolucao = DateTime.Now
        };

        var data = _controller.PatchDevolucao(emprestimoId, dto);

        var result = data.Result.Should().BeOfType<OkObjectResult>();
        result.Subject.StatusCode.Should().Be(200);
    }

    [Fact]
    public void PatchDevolucao_NotFound_Result()
    {
        var emprestimoId = 999;

        var dto = new DevolucaoDto
        {
            Devolucao = DateTime.Now
        };

        var data = _controller.PatchDevolucao(emprestimoId, dto);

        var result = data.Result.Should().BeOfType<NotFoundObjectResult>();
        result.Subject.StatusCode.Should().Be(404);
    }

    [Fact]
    public void PatchDevolucao_JaRealizada_BadRequest_Result()
    {
        var emprestimoId = 52;

        var dto = new DevolucaoDto
        {
            Devolucao = DateTime.Now
        };

        var data = _controller.PatchDevolucao(emprestimoId, dto);

        var result = data.Result.Should().BeOfType<BadRequestObjectResult>();
        result.Subject.StatusCode.Should().Be(400);
    }

    [Fact]
    public void PatchDevolucao_BadRequest_Result()
    {
        var emprestimoId = 49;

        DevolucaoDto dto = null;

        var data = _controller.PatchDevolucao(emprestimoId, dto);

        var result = data.Result.Should().BeOfType<BadRequestObjectResult>();
        result.Subject.StatusCode.Should().Be(400);
    }
}
