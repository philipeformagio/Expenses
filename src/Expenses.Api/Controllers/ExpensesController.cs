using Microsoft.AspNetCore.Mvc;

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
}