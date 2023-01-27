using System;

namespace Expenses.Core.Entites;

public class Expense
{
    public Expense(string name, decimal price)
    {
        Name = name;
        Price = price;
    }

    public int Id { get; set; }
    public string Name { get; set; }
    public decimal Price { get; set; }
    public DateTime CreatedAt { get; set; }
    public DateTime UpdatedAt { get; set; }

    public bool IsValid()
    {
        return !String.IsNullOrWhiteSpace(Name) || Price != 0;
    }
}