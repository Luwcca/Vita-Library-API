using FluentAssertions;
using Microsoft.AspNetCore.Mvc;
using WebApi_Biblioteca.Controllers;
using WebApi_Biblioteca.Data.Dtos.FuncionarioDtos;

namespace WebApi_Biblioteca_Tests.UnitTest.FuncionarioUnitTest;

public class GetFuncionarioUnitTest : IClassFixture<FuncionarioUnitTestController>
{
    private readonly FuncionarioController _controller;

    public GetFuncionarioUnitTest(FuncionarioUnitTestController controller)
    {
        _controller = new FuncionarioController(controller.context, controller.mapper);
    }

    [Fact]
    public void GetFuncionarioById_OKResult()
    {
        var Id = 2;
        var data = _controller.GetFuncionarioByID(Id);

        data.Result.Should().BeOfType<OkObjectResult>()
             .Which.StatusCode.Should().Be(200);

    }

    [Fact]
    public void GetFuncionarioById_NotFound_Result()
    {
        var Id = 999;
        var data = _controller.GetFuncionarioByID(Id);

        data.Result.Should().BeOfType<NotFoundObjectResult>()
            .Which.StatusCode.Should().Be(404);

    }

    [Fact]
    public void GetFuncionarioById_BadRequest_Result()
    {
        var Id = 0;
        var data = _controller.GetFuncionarioByID(Id);

        data.Result.Should().BeOfType<BadRequestObjectResult>()
               .Which.StatusCode.Should().Be(400);

    }

    [Fact]
    public void GetFuncionario_FuncionarioDtoList_Result()
    {
        var data = _controller.GetFuncionario();

        data.Result.Should().BeOfType<OkObjectResult>()
             .Which.Value.Should().BeAssignableTo<IEnumerable<ReadFuncionarioDto>>();
    }

}
