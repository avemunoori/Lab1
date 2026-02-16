using Lab1.Domain.Models;

namespace Lab1.Contracts;

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
    /// <exception cref="ArgumentNullException">Thrown when item or borrower is null.</exception>
    /// <remarks>
    /// Pre-conditions: 
    /// - Item must not be null
    /// - Borrower must not be null
    /// 
    /// Post-conditions: 
    /// - Returns true if item is available and borrower meets policy requirements
    /// - Returns false otherwise
    /// </remarks>
    bool CanCheckout(Item item, Borrower borrower);

    /// <summary>
    /// Normalizes a proposed due date according to library policies.
    /// May adjust for weekends, holidays, or maximum loan periods.
    /// </summary>
    /// <param name="proposedDate">The proposed due date.</param>
    /// <returns>The normalized due date.</returns>
    /// <remarks>
    /// Pre-conditions: proposedDate should be a future date
    /// Post-conditions: Returns an adjusted date conforming to library policies
    /// </remarks>
    DateTime NormalizeDueDate(DateTime proposedDate);
}