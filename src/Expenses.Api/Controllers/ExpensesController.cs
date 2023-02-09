using Microsoft.AspNetCore.Mvc;

using Expenses.Core.Dtos;
using Expenses.Core.Interfaces;

namespace Expenses.Api.Controllers;

[ApiController]
[Route("[controller]")]
public class ExpensesController : ControllerBase
{
    private readonly IExpensesService _expensesService;
    public ExpensesController(IExpensesService expensesService)
    {
        _expensesService = expensesService;
    }

    [HttpGet("{id:length(24)}")]
    public async Task<ActionResult<ExpenseDto?>> Get(string id)
    {
        return await _expensesService.GetAsync(id);
    }

    [HttpGet("expenses-all")]
    public async Task<ActionResult<IEnumerable<ExpenseDto>>> GetAll()
    {
        // return Ok(await _expensesMongoRepository.GetAll());
        return Ok();
    }

    [HttpPost]
    public async Task<ActionResult<ExpenseDto>> Post(ExpenseDto expenseDto)
    {
        await _expensesService.InsertAsync(expenseDto);
        return Ok();
    }

    [HttpPut("{id:length(24)}")]
    public async Task<IActionResult> Put(string id, ExpenseDto expenseDto)
    {
        await _expensesService.UpdateAsync(id, expenseDto);

        return NoContent();
    }
}