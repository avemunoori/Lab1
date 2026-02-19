using Lab1.Contracts;
using Lab1.Domain.Models;
using Lab1.Domain.Enums;
namespace Lab1.Services;

public class Policy : IPolicy
{
    private readonly IClock _clock;

    public Policy(IClock clock)
    {
        _clock = clock ?? throw new ArgumentNullException(nameof(clock));
    }

    public bool CanCheckout(Item item, Borrower borrower)
    {
        if (item == null) throw new ArgumentNullException(nameof(item));
        if (borrower == null) throw new ArgumentNullException(nameof(borrower));
        if (item.Status != Status.Available) 
            return false;
        return true;
    }

    public DateTime NormalizeDueDate(DateTime proposedDate)
    {
        var today = _clock.Today();
        
        if (today > proposedDate.Date) throw new ArgumentException("Due date cannot be in the past");
        return proposedDate;
    }
}