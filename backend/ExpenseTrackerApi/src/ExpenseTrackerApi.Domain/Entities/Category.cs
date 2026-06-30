using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ExpenseTrackerApi.Domain.Entities;

[Table("Categories")]
public class Category
{
    [Key]
    public int Id { get; set; }

    [Length(2, 100)]
    public required string Name { get; set; }

    public ICollection<Expense> Expenses { get; } = [];
}
