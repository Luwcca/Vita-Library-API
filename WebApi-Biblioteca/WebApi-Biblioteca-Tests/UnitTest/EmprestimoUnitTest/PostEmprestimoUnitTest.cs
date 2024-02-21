using FluentAssertions;
using Microsoft.AspNetCore.Mvc;
using WebApi_Biblioteca.Controllers;
using WebApi_Biblioteca.Data.Dtos.EmprestimoDtos;

namespace WebApi_Biblioteca_Tests.UnitTest.EmprestimoUnitTest;

public class PostEmprestimoUnitTest : IClassFixture<EmprestimoUnitTestController>
{
    private readonly EmprestimoController _controller;

    public PostEmprestimoUnitTest(EmprestimoUnitTestController controller)
    {
        _controller = new EmprestimoController(controller.context, controller.mapper);
    }

    [Fact]
    public void PostEmprestimo_Ok_Result()
    {
        var dto = new PostEmprestimoDto
        {
            AlunoId = 6,
            FuncionarioId = 1,
            ItemEmprestimo = new PostItemEmprestimoDto
            {
                LivroId = 45
            },
            Hora = DateTime.Now
        };

        var data = _controller.PostEmprestimo(dto);

        var result = data.Result.Should().BeOfType<CreatedAtActionResult>();
        result.Subject.StatusCode.Should().Be(201);

    }

    [Fact]
    public void PostEmprestimo_FuncionarioNotFound_Result()
    {
        var dto = new PostEmprestimoDto
        {
            AlunoId = 6,
            FuncionarioId = 999,
            ItemEmprestimo = new PostItemEmprestimoDto
            {
                LivroId = 45
            },
            Hora = DateTime.Now
        };

        var data = _controller.PostEmprestimo(dto);

        var result = data.Result.Should().BeOfType<NotFoundObjectResult>();
        result.Subject.StatusCode.Should().Be(404);


    }

    [Fact]
    public void PostEmprestimo_AlunoNotFound_Result()
    {
        var dto = new PostEmprestimoDto
        {
            AlunoId = 999,
            FuncionarioId = 1,
            ItemEmprestimo = new PostItemEmprestimoDto
            {
                LivroId = 45
            },
            Hora = DateTime.Now
        };

        var data = _controller.PostEmprestimo(dto);

        var result = data.Result.Should().BeOfType<NotFoundObjectResult>();
        result.Subject.StatusCode.Should().Be(404);

    }

    [Fact]
    public void PostEmprestimo_LivroNotFound_Result()
    {
        var dto = new PostEmprestimoDto
        {
            AlunoId = 6,
            FuncionarioId = 1,
            ItemEmprestimo = new PostItemEmprestimoDto
            {
                LivroId = 999
            },
            Hora = DateTime.Now
        };

        var data = _controller.PostEmprestimo(dto);

        var result = data.Result.Should().BeOfType<NotFoundObjectResult>();
        result.Subject.StatusCode.Should().Be(404);

    }

    [Fact]
    public void PostEmprestimo_PeriodicoNotFound_Result()
    {
        var dto = new PostEmprestimoDto
        {
            AlunoId = 6,
            FuncionarioId = 1,
            ItemEmprestimo = new PostItemEmprestimoDto
            { 
                PeriodicoId = 999
            },
            Hora = DateTime.UtcNow
        };

        var data = _controller.PostEmprestimo(dto);

        var result = data.Result.Should().BeOfType<NotFoundObjectResult>();
        result.Subject.StatusCode.Should().Be(404);


    }

    [Fact]
    public void PostEmprestimo_ItemBadRequest_Result()
    {
        var dto = new PostEmprestimoDto
        {
            AlunoId = 6,
            FuncionarioId = 1,
            ItemEmprestimo =
            {
        
            },
            Hora = DateTime.Now
        };

        var data = _controller.PostEmprestimo(dto);

        var result = data.Result.Should().BeOfType<BadRequestObjectResult>();
        result.Subject.StatusCode.Should().Be(400);


    }


    [Fact]
    public void PostEmprestimo_ItemEmprestadoBadRequest_Result()
    {
        var dto = new PostEmprestimoDto
        {
            AlunoId = 6,
            FuncionarioId = 1,
            ItemEmprestimo = new PostItemEmprestimoDto
            {
                LivroId = 45
            },
            Hora = DateTime.Now
        };

        var data = _controller.PostEmprestimo(dto);

        var result = data.Result.Should().BeOfType<BadRequestObjectResult>();
        result.Subject.StatusCode.Should().Be(400);


    }


    [Fact]
    public void PostEmprestimo_AlunoMultadoBadRequest_Result()
    {
        var dto = new PostEmprestimoDto
        {
            AlunoId = 8,
            FuncionarioId = 1,
            ItemEmprestimo = new PostItemEmprestimoDto
            {
                LivroId = 45
            },
            Hora = DateTime.Now
        };

        var data = _controller.PostEmprestimo(dto);

        var result = data.Result.Should().BeOfType<BadRequestObjectResult>();
        result.Subject.StatusCode.Should().Be(400);


    }
}
