using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ExpenseTrackerApi.Domain.Entities;

[Table("Expenses")]
public class Expense
{
    public int Id { get; set; }

    public int CategoryId { get; set; }
    public Category Category { get; set; } = null!;

    public required DateTime Date { get; set; }

    [Length(0, 200)]
    public string? Description { get; set; }

}
