using Domain.Enums;
namespace Lab1.Domain.Models;

public class Item
{
    public int Id { get; }
    public string Name { get; }
    public Category Category { get; }
    public Condition Condition { get; }
    public Status Status { get; private set; }

    public Item(int id, string name, Category category, Condition condition)
    {
        if (id <= 0)
            throw new ArgumentException("Id must be greater than zero", nameof(id));
        Id = id;
        if (string.IsNullOrWhiteSpace(name))
            throw new ArgumentException("Name cannot be empty", nameof(name));
        Name = name;
        Category = category;
        Condition = condition;
        Status = Status.Available;
    }

    public void UpdateStatus(Status status)
    {
        if (status == Status)
            throw new InvalidOperationException("Status cannot be changed to its current value.");
        Status = status;
    }
}
