using FluentAssertions;
using Microsoft.AspNetCore.Mvc;
using WebApi_Biblioteca.Controllers;
using WebApi_Biblioteca.Data.Dtos.EmprestimoDtos;

namespace WebApi_Biblioteca_Tests.UnitTest.EmprestimoUnitTest;

public class GetEmprestimoUnitTest : IClassFixture<EmprestimoUnitTestController>
{
    private readonly EmprestimoController _controller;

    public GetEmprestimoUnitTest(EmprestimoUnitTestController controller)
    {
        _controller = new EmprestimoController(controller.context, controller.mapper);
    }

    [Fact]
    public void GetFuncionario_FuncionarioDtoList_Result()
    {
        var data = _controller.GetEmprestimos();

        data.Result.Should().BeOfType<OkObjectResult>()
             .Which.Value.Should().BeAssignableTo<IEnumerable<GetItemEmprestimosDto>>();
    }
}