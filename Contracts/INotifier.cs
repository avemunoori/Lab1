using Lab1.Domain.Models;
namespace Lab1.Contracts;

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
    /// <exception cref="ArgumentNullException">Thrown when borrower or record is null.</exception>
    /// <remarks>
    /// Pre-conditions:
    /// - Borrower must not be null
    /// - Record must not be null
    /// - Record should have a due date approaching soon
    /// 
    /// Post-conditions: Notification sent to borrower via configured channel
    /// </remarks>
    void DueSoon(Borrower borrower, CheckoutRecord record);

    /// <summary>
    /// Notifies a borrower that an item is overdue.
    /// </summary>
    /// <param name="borrower">The borrower to notify.</param>
    /// <param name="record">The checkout record with overdue information.</param>
    /// <exception cref="ArgumentNullException">Thrown when borrower or record is null.</exception>
    /// <remarks>
    /// Pre-conditions:
    /// - Borrower must not be null
    /// - Record must not be null
    /// - Record due date must be in the past
    /// 
    /// Post-conditions: Overdue notification sent to borrower via configured channel
    /// </remarks>
    void Overdue(Borrower borrower, CheckoutRecord record);
}