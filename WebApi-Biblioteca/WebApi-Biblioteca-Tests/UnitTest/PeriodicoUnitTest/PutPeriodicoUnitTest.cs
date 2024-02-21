using FluentAssertions;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WebApi_Biblioteca.Controllers;
using WebApi_Biblioteca.Data.Dtos.PeriodicoDtos;

namespace WebApi_Biblioteca_Tests.UnitTest.PeriodicoUnitTest;

public class PutPeriodicoUnitTest : IClassFixture<PeriodicoUnitTestController>
{
    private readonly PeriodicoController _controller;

    public PutPeriodicoUnitTest(PeriodicoUnitTestController controller)
    {
        _controller = new PeriodicoController(controller.context, controller.mapper); 
    }

    [Fact]
    public void PutPeriodico_Ok_Result()
    {
        var periodicoid = 4;

        var periodicodto = new UpdatePeriodicoDto
        {
            Nome = "Periodico",
            Assunto = "Teste",
            Tombo = 1234,
            Autor = "Dev",
            Status = true
        };

        var data = _controller.PutPeriodico(periodicoid, periodicodto);

        var result = data.Result.Should().BeOfType<OkObjectResult>();
        result.Subject.StatusCode.Should().Be(200);
    }

    [Fact]
    public void PutPeriodico_NotFound_Result()
    {
        var periodicoid = 999;

        var periodicodto = new UpdatePeriodicoDto
        {
            Nome = "Periodico",
            Assunto = "Teste",
            Tombo = 1234,
            Autor = "Dev",
            Status = true
        };

        var data = _controller.PutPeriodico(periodicoid, periodicodto);

        var result = data.Result.Should().BeOfType<NotFoundObjectResult>();
        result.Subject.StatusCode.Should().Be(404);
    }

    [Fact]
    public void PutPeriodico_BadRequest_Result()
    {
        var periodicoid = 4;

        var periodicodto = new UpdatePeriodicoDto
        {
            Nome = "Periodico",
            Tombo = 1234,
            Autor = "Dev",
            Status = true
        };

        var data = _controller.PutPeriodico(periodicoid, periodicodto);

        var result = data.Result.Should().BeOfType<BadRequestObjectResult>();
        result.Subject.StatusCode.Should().Be(400);
    }
}
