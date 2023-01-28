using Microsoft.AspNetCore.Mvc;
using System.Collections;

using Expenses.Api.Dtos;
using Expenses.Core.Entites;
using Expenses.Core.Interfaces;

namespace Expenses.Api.Controllers;

[ApiController]
[Route("[controller]")]
public class ExpensesController : ControllerBase
{
    private readonly IExpensesMongoRepository _expensesMongoRepository;
    public ExpensesController(IExpensesMongoRepository expensesMongoRepository)
    {
        _expensesMongoRepository = expensesMongoRepository;
    }

    [HttpGet("id:int")]
    public async Task<ActionResult<ExpenseDto>> Get(int id)
    {
        var expense = await _expensesMongoRepository.Get(id);
        return new ExpenseDto()
        {
            Name = expense.Name,
            Price = expense.Price
        };
    }

    [HttpGet("expenses-all")]
    public async Task<ActionResult<IEnumerable<ExpenseDto>>> GetAll()
    {
        return Ok(await _expensesMongoRepository.GetAll());
    }

    [HttpPost]
    public async Task<ActionResult<ExpenseDto>> Post(ExpenseInputDto expenseInputDto)
    {
        return await Task.FromResult(new ExpenseDto()
        {
            Name = expenseInputDto.Name,
            Price = expenseInputDto.Price
        });
    }

    [HttpPut]
    public async Task<ActionResult<ExpenseDto>> Put(ExpenseDto expenseDto)
    {
        return await Task.FromResult(new ExpenseDto()
        {
            Name = expenseDto.Name,
            Price = expenseDto.Price
        });
    }
}