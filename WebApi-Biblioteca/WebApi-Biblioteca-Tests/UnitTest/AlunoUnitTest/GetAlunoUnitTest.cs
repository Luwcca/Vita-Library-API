using FluentAssertions;
using Microsoft.AspNetCore.Mvc;
using WebApi_Biblioteca.Controllers;
using WebApi_Biblioteca.Data.Dtos.AlunoDtos;

namespace WebApi_Biblioteca_Tests.UnitTest.AlunoUnitTest;

public class GetAlunoUnitTest : IClassFixture<AlunoUnitTestController>
{
    private readonly AlunoController _controller;

    public GetAlunoUnitTest(AlunoUnitTestController controller)
    {
        _controller = new AlunoController(controller.context, controller.mapper);
    }

    [Fact]
    public void GetAlunoById_OKResult()
    {
        var alunoId = 6;
        var data = _controller.GetAlunoByID(alunoId);

        data.Result.Should().BeOfType<OkObjectResult>()
             .Which.StatusCode.Should().Be(200);

    }

    [Fact]
    public void GetAlunoById_NotFound_Result()
    {
        var alunoId = 999;
        var data = _controller.GetAlunoByID(alunoId);

        data.Result.Should().BeOfType<NotFoundObjectResult>()
            .Which.StatusCode.Should().Be(404);

    }

    [Fact]
    public void GetAlunoById_BadRequest_Result()
    {
        var alunoId = 0;
        var data = _controller.GetAlunoByID(alunoId);

        data.Result.Should().BeOfType<BadRequestObjectResult>()
               .Which.StatusCode.Should().Be(400);

    }

    [Fact]
    public void GetAluno_LivroDtoList_Result()
    {
        var data = _controller.GetAluno();

        data.Result.Should().BeOfType<OkObjectResult>()
             .Which.Value.Should().BeAssignableTo<IEnumerable<ReadAlunoDto>>();
    }
}
