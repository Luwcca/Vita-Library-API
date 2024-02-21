using FluentAssertions;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WebApi_Biblioteca.Controllers;

namespace WebApi_Biblioteca_Tests.UnitTest.AlunoUnitTest;

public class DeleteAlunoUnitTest : IClassFixture<AlunoUnitTestController>
{
    private readonly AlunoController _controller;

    public DeleteAlunoUnitTest(AlunoUnitTestController controller)
    {
        _controller = new AlunoController(controller.context, controller.mapper);
    }

    [Fact]
    public void DeleteAluno_Ok_Result()
    {
        var id = 7;

        var data = _controller.DeleteAluno(id);

        data.Should().BeOfType<OkObjectResult>().Which.StatusCode.Should().Be(200);
    }

    [Fact]
    public void DeleteAluno_NotFound_Result()
    {
        var id = 999;

        var data = _controller.DeleteAluno(id);

        data.Should().BeOfType<NotFoundObjectResult>().Which.StatusCode.Should().Be(404);
    }

}

