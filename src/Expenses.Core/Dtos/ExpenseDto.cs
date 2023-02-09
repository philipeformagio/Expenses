namespace Expenses.Core.Dtos;

public class ExpenseDto
{
    public string? Id { get; set; }
    public string? Name { get; set; }
    public decimal? Price { get; set; }
    public DateTime? DueData { get; set; }
    public bool? Recurrent { get; set; }
}