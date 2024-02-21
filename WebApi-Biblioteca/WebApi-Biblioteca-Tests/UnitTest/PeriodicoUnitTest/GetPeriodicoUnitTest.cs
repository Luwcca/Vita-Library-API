using FluentAssertions;
using Microsoft.AspNetCore.Mvc;
using WebApi_Biblioteca.Controllers;
using WebApi_Biblioteca.Data.Dtos.PeriodicoDtos;

namespace WebApi_Biblioteca_Tests.UnitTest.PeriodicoUnitTest;

public class GetPeriodicoUnitTest : IClassFixture<PeriodicoUnitTestController>
{
    private readonly PeriodicoController _controller;

    public GetPeriodicoUnitTest(PeriodicoUnitTestController controller)
    {
        _controller = new PeriodicoController(controller.context, controller.mapper); 
    }

    [Fact]
    public void GetPeriodicoById_OKResult()
    {
        var periodicoId = 4;
        var data = _controller.GetPeriodicosByID(periodicoId);

        data.Result.Should().BeOfType<OkObjectResult>()
             .Which.StatusCode.Should().Be(200);

    }

    [Fact]
    public void GetPeriodicoById_NotFound_Result()
    {
        var periodicoId = 999;
        var data = _controller.GetPeriodicosByID(periodicoId);

        data.Result.Should().BeOfType<NotFoundObjectResult>()
            .Which.StatusCode.Should().Be(404);

    }

    [Fact]
    public void GetPeriodicoById_BadRequest_Result()
    {
        var periodicoId = 0;
        var data = _controller.GetPeriodicosByID(periodicoId);

        data.Result.Should().BeOfType<BadRequestObjectResult>()
               .Which.StatusCode.Should().Be(400);

    }

    [Fact]
    public void GetPeriodico_LivroDtoList_Result()
    {
        var data = _controller.GetPeriodicos();

        data.Result.Should().BeOfType<OkObjectResult>()
             .Which.Value.Should().BeAssignableTo<IEnumerable<ReadPeriodicoDto>>();
    }
}
