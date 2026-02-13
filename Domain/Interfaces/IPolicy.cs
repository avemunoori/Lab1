using Lab1.Domain.Models;

namespace Lab1.Domain.Interfaces;

/// <summary>
/// Defines business rules and policies for library checkout operations.
/// </summary>
public interface IPolicy
{
    /// <summary>
    /// Determines whether a borrower is allowed to check out a specific item.
    /// </summary>
    /// <param name="item">The item to check out.</param>
    /// <param name="borrower">The borrower requesting the checkout.</param>
    /// <returns>True if checkout is allowed; otherwise, false.</returns>
    bool CanCheckout(Item item, Borrower borrower);

    /// <summary>
    /// Normalizes a proposed due date according to library policies.
    /// May adjust for weekends, holidays, or maximum loan periods.
    /// </summary>
    /// <param name="proposedDate">The proposed due date.</param>
    /// <returns>The normalized due date.</returns>
    DateTime NormalizeDueDate(DateTime proposedDate);
}