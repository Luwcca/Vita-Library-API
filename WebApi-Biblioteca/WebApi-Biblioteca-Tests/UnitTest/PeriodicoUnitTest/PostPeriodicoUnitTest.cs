using FluentAssertions;
using Microsoft.AspNetCore.Mvc;
using WebApi_Biblioteca.Controllers;
using WebApi_Biblioteca.Data.Dtos.PeriodicoDtos;

namespace WebApi_Biblioteca_Tests.UnitTest.PeriodicoUnitTest;

public class PostPeriodicoUnitTest : IClassFixture<PeriodicoUnitTestController>
{
    private readonly PeriodicoController _controller;

    public PostPeriodicoUnitTest(PeriodicoUnitTestController controller)
    {
        _controller = new PeriodicoController(controller.context, controller.mapper);
    }

    [Fact]
    public void PostPeriodico_CreatedAtAction_Result()
    {
        var periodicodto = new CreatePeriodicoDto
        {
            Nome = "Periodico",
            Assunto = "Teste",
            Tombo = 1234,
            Autor = "Dev",
            Status = true
        };

        var data = _controller.PostPeriodico(periodicodto);

        var result = data.Result.Should().BeOfType<CreatedAtActionResult>();
        result.Subject.StatusCode.Should().Be(201);
    }



    [Fact]
    public void PostPeriodico_BadRequest_Result()
    {
        CreatePeriodicoDto periodicodto = null;

        var data = _controller.PostPeriodico(periodicodto);

        var result = data.Result.Should().BeOfType<BadRequestObjectResult>();
        result.Subject.StatusCode.Should().Be(400);
    }
}
