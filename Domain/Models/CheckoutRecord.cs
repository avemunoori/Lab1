namespace Lab1.Domain.Models;

public class CheckoutRecord
{
    public Item Item { get; }
    public Borrower Borrower { get; }
    public DateTime CheckoutDate { get; }
    public DateTime DueDate { get; }

    public CheckoutRecord(Item item, Borrower borrower, DateTime dueDate, DateTime checkoutDate)
    {
        if (dueDate <= checkoutDate)
            throw new ArgumentException("Due date must be in the future", nameof(dueDate));
        
        Item = item ?? throw new ArgumentException("Item must exist", nameof(item));
        Borrower = borrower ?? throw new ArgumentException("Borrower must exist", nameof(borrower));
        DueDate = dueDate;
        CheckoutDate = checkoutDate;
    }
}