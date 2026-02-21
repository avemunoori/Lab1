using Lab1.Contracts;
using Lab1.Domain.Models;
namespace Lab1.Services;

public class Notifier : INotifier
{
    public void DueSoon(Borrower borrower, CheckoutRecord record)
    {
        if (borrower == null) throw new ArgumentNullException(nameof(borrower));
        if (record == null) throw new ArgumentNullException(nameof(record));
        Console.WriteLine(
            $"Item ID: {record.Item.Id} | Borrowed by {borrower.Name} | {borrower.Email} | Due: {record.DueDate}");
    }

    public void Overdue(Borrower borrower, CheckoutRecord record)
    {
        if (borrower == null) throw new ArgumentNullException(nameof(borrower));
        if (record == null) throw new ArgumentNullException(nameof(record));
        Console.WriteLine(
            $"Item ID: {record.Item.Id} | Borrowed by {borrower.Name} | {borrower.Email} | Was Due: {record.DueDate}");
    }
}