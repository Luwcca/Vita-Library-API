using FluentAssertions;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WebApi_Biblioteca.Controllers;
using WebApi_Biblioteca_Tests.UnitTest.FuncionarioUnitTest;

namespace WebApi_Biblioteca_Tests.UnitTest.FuncionarioUnitTest;

public class DeleteFuncionarioUnitTest : IClassFixture<FuncionarioUnitTestController>
{
    private readonly FuncionarioController _controller;

    public DeleteFuncionarioUnitTest(FuncionarioUnitTestController controller)
    {
        _controller = new FuncionarioController(controller.context, controller.mapper);
    }

    [Fact]
    public void DeleteFuncionario_Ok_Result()
    {
        var id = 3;

        var data = _controller.DeleteFuncionario(id);

        data.Should().BeOfType<OkObjectResult>().Which.StatusCode.Should().Be(200);
    }

    [Fact]
    public void DeleteFuncionario_NotFound_Result()
    {
        var id = 999;

        var data = _controller.DeleteFuncionario(id);

        data.Should().BeOfType<NotFoundObjectResult>().Which.StatusCode.Should().Be(404);
    }

}
