namespace Expenses.Core.Entites;

public class Expense
{
    public Expense(string name, decimal price)
    {
        Name = name;
        Price = price;
    }

    public string? Id { get; set; }
    public string? Name { get; set; }
    public decimal Price { get; set; }
    public string? DayOfWeek { get; set; }
    public bool Recurrent { get; set; }
    public DateTime DueDate { get; set; }
    public DateTime CreatedAt { get; set; }
    public DateTime? UpdatedAt { get; set; }

    public bool IsValid() => !String.IsNullOrWhiteSpace(Name) && 
                             Price != 0 &&
                             DueDate != null;

    public void CreateEntityToSave()
    {
        CreatedAt = DateTime.Now;
        DayOfWeek = DateTime.Today.DayOfWeek.ToString();
    }
}