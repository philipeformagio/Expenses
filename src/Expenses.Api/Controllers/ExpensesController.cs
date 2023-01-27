using Microsoft.AspNetCore.Mvc;
using System.Collections;
using Expenses.Api.Dtos;
using Expenses.Core.Entites;

namespace Expenses.Api.Controllers;

[ApiController]
[Route("[controller]")]
public class ExpensesController : ControllerBase
{
    [HttpGet]
    public async Task<ActionResult<object>> Get()
    {
        return new { id = 1, expense = "Internet Bill" };
    }

    [HttpGet("expenses-all")]
    public async Task<ActionResult<IEnumerable<object>>> GetAll()
    {
        var expense = new Expense("Car", 39.0M);
        var isValid = expense.IsValid();

        return new List<object>
        {
            new { id = 1, expense = "Internet Bill" },
            new { id = 2, expense = "Car" },
            new { expense, isValid}
        };
    }

    [HttpPost]
    public async Task<ActionResult<ExpenseDto>> Post(ExpenseInputDto expenseInputDto)
    {
        var expense = new ExpenseDto()
        {
            Name = expenseInputDto.Name,
            Price = expenseInputDto.Price
        };
        return expense;
    }

    [HttpPut]
    public async Task<ActionResult<ExpenseDto>> Put(ExpenseDto expenseDto)
    {

    }
}