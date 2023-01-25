using Microsoft.AspNetCore.Mvc;
using System.Collections;

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
        return new List<object>
        {
            new { id = 1, expense = "Internet Bill" },
            new { id = 2, expense = "Car" }
        };
    }
}