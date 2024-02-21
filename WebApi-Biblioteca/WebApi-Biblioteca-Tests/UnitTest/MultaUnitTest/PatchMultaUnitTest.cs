using FluentAssertions;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WebApi_Biblioteca.Controllers;

namespace WebApi_Biblioteca_Tests.UnitTest.MultaUnitTest;

public class PatchMultaUnitTest : IClassFixture<MultaUnitTestController>
{
    private readonly MultasController _controller;

    public PatchMultaUnitTest(MultaUnitTestController controller)
    {
        _controller = new MultasController(controller.context);    
    }

    [Fact]
    public void PatchGerarMulta_Ok_Result()
    {
        var alunoId = 8;
        var multa = 10;

        var data = _controller.GerarMulta(alunoId, multa);

        data.Should().BeOfType<OkObjectResult>().Which.StatusCode.Should().Be(200);
    }

    [Fact]
    public void PatchGerarMulta_NotFound_Result()
    {
        var alunoId = 999;
        var multa = 10;

        var data = _controller.GerarMulta(alunoId, multa);

        data.Should().BeOfType<NotFoundObjectResult>().Which.StatusCode.Should().Be(404);
    }

    [Fact]
    public void PatchPagarMulta_Ok_Result()
    {
        var alunoId = 8;
        var multa = 10;

        var data = _controller.PagarMulta(alunoId, multa);

        data.Should().BeOfType<OkObjectResult>().Which.StatusCode.Should().Be(200);
    }

    [Fact]
    public void PatchPagarMulta_NotFound_Result()
    {
        var alunoId = 999;
        var multa = 10;

        var data = _controller.GerarMulta(alunoId, multa);

        data.Should().BeOfType<NotFoundObjectResult>().Which.StatusCode.Should().Be(404);
    }
}
