namespace Domain.Models;

public class Borrower
{
    public int Id { get; init; }
    public string Name { get; set; } = string.Empty;
    public string Email { get; set; } = string.Empty;
}