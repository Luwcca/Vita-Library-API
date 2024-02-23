using FluentAssertions;
using Microsoft.AspNetCore.Mvc;
using WebApi_Biblioteca.Controllers;

namespace WebApi_Biblioteca_Tests.UnitTest.PeriodicoUnitTest;

public class DeletePeriodicoUnitTest : IClassFixture<PeriodicoUnitTestController>
{
    private readonly PeriodicoController _controller;

    public DeletePeriodicoUnitTest(PeriodicoUnitTestController controller)
    {
        _controller = new PeriodicoController(controller.context, controller.mapper);
    }

    [Fact]
    public void DeletePeriodico_Ok_Result()
    {
        var id = 7;

        var data = _controller.DeletePeriodico(id);

        data.Should().BeOfType<OkObjectResult>().Which.StatusCode.Should().Be(200);
    }

    [Fact]
    public void DeletePeriodico_NotFound_Result()
    {
        var id = 999;

        var data = _controller.DeletePeriodico(id);

        data.Should().BeOfType<NotFoundObjectResult>().Which.StatusCode.Should().Be(404);
    }
}

