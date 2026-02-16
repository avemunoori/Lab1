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

    public void MarkAvailable()
    {
       if (Status == Status.Available)
           throw new InvalidOperationException("Item is already marked available");
       Status = Status.Available;
    }
    
    public void MarkCheckedOut()
    {
        Status = Status switch
        {
            Status.CheckedOut => throw new InvalidOperationException("Item is already marked checked out"),
            Status.Lost => throw new InvalidOperationException("Item is marked lost and cannot be checked out"),
            _ => Status.CheckedOut
        };
    }
    
    public void MarkLost()
    {
        if (Status == Status.Lost) 
            throw new InvalidOperationException("Item is already marked lost"); 
        Status = Status.Lost;
    }
}
