using System;
using Lab1.Domain.Enums;
namespace Lab1.Domain.Models;


public class Receipt
{
    public int ItemId { get; }
    public TransactionType Type { get; }
    public DateTime CheckoutDate { get; }
    public DateTime DueDate { get; }

    public Receipt(int itemId, TransactionType type, DateTime dueDate, DateTime checkoutDate)
    {
        ItemId = itemId;
        Type = type;
        DueDate = dueDate;
        CheckoutDate = checkoutDate;
    }

    public override string ToString() =>
        $"Your receipt:\n{CheckoutDate} | Checkout (due {DueDate}) | {ItemId}";
}
