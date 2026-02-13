using Lab1.Domain.Models;

namespace Lab1.Domain.Interfaces;

/// <summary>
/// Provides notification services for checkout-related events.
/// </summary>
public interface INotifier
{
    /// <summary>
    /// Notifies a borrower that an item is due soon.
    /// </summary>
    /// <param name="borrower">The borrower to notify.</param>
    /// <param name="record">The checkout record with due date information.</param>
    void DueSoon(Borrower borrower, CheckoutRecord record);

    /// <summary>
    /// Notifies a borrower that an item is overdue.
    /// </summary>
    /// <param name="borrower">The borrower to notify.</param>
    /// <param name="record">The checkout record with overdue information.</param>
    void Overdue(Borrower borrower, CheckoutRecord record);
}