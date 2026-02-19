using Lab1.Domain.Models;

namespace Lab1.Contracts;

/// <summary>
/// Main service interface for library checkout and return operations.
/// Orchestrates interactions between catalog, repository, policy, and notification systems.
/// </summary>
public interface ICheckoutService
{
    /// <summary>
    /// Checks out an item to a borrower with a specified due date.
    /// </summary>
    /// <param name="itemId">The unique identifier of the item to check out.</param>
    /// <param name="borrower">The borrower checking out the item.</param>
    /// <param name="dueDate">The date by which the item should be returned.</param>
    /// <returns>A receipt confirming the checkout transaction.</returns>
    /// <exception cref="ArgumentException">Thrown when itemId does not exist.</exception>
    /// <exception cref="ArgumentNullException">Thrown when borrower is null.</exception>
    /// <exception cref="InvalidOperationException">Thrown when item is not available or borrower is not eligible.</exception>
    /// <remarks>
    /// Pre-conditions:
    /// - Item must exist in the repository
    /// - Item status must be AVAILABLE
    /// - Borrower must not be null
    /// - Borrower must meet policy eligibility requirements
    /// 
    /// Post-conditions:
    /// - Item status changed to CHECKED_OUT
    /// - CheckoutRecord created and saved
    /// - Receipt generated with transaction details
    /// </remarks>
    Receipt Checkout(int itemId, Borrower borrower, DateTime dueDate);

    /// <summary>
    /// Returns an item that was previously checked out.
    /// </summary>
    /// <param name="itemId">The unique identifier of the item to return.</param>
    /// <returns>A receipt confirming the return transaction, or null if item was not checked out.</returns>
    /// <exception cref="ArgumentException">Thrown when itemId does not exist.</exception>
    /// <remarks>
    /// Pre-conditions:
    /// - Item must exist in the repository
    /// 
    /// Post-conditions:
    /// - If item was checked out: Item status changed to AVAILABLE, receipt generated
    /// - If item was not checked out: Returns null
    /// </remarks>
    Receipt? Return(int itemId);

    /// <summary>
    /// Marks an item as lost in the system.
    /// </summary>
    /// <param name="itemId">The unique identifier of the item to mark as lost.</param>
    /// <exception cref="ArgumentException">Thrown when itemId does not exist.</exception>
    /// <remarks>
    /// Pre-conditions: Item must exist in the repository
    /// Post-conditions: Item status changed to LOST
    /// </remarks>
    void MarkLost(int itemId);

    /// <summary>
    /// Retrieves all active loans for a specific borrower.
    /// </summary>
    /// <param name="borrower">The borrower whose active loans to retrieve.</param>
    /// <returns>A list of active checkout records for the borrower.</returns>
    /// <exception cref="ArgumentNullException">Thrown when borrower is null.</exception>
    /// <remarks>
    /// Pre-conditions: Borrower must not be null
    /// Post-conditions: Returns all checkout records where items are still CHECKED_OUT
    /// </remarks>
    List<CheckoutRecord> ListActiveLoans(Borrower borrower);

    /// <summary>
    /// Finds all checkout records with due dates within a specified time window.
    /// </summary>
    /// <param name="window">The time window to search (e.g., next 7 days).</param>
    /// <returns>A list of checkout records due within the time window.</returns>
    /// <remarks>
    /// Pre-conditions: None
    /// Post-conditions: Returns a variable that contains a list of all records that are due soon
    /// </remarks>
    List<CheckoutRecord> FindDueSoon(TimeSpan window);

    /// <summary>
    /// Prints out a list of all the items that are due soon.
    /// </summary>
    /// <param name="window">The time window to search (e.g., next 7 days).</param>
    /// Pre-conditions: None
    /// Post-conditions: Prints each CheckoutRecord that is due soon to the console
    void NotifyDueSoon(TimeSpan window);
    
    /// <summary>
    /// Finds all checkout records that are currently overdue.
    /// </summary>
    /// <returns>A list of overdue checkout records.</returns>
    /// <remarks>
    /// Pre-conditions: None
    /// Post-conditions: Returns a variable that contains a list of all records that are overdue
    /// </remarks>
    List<CheckoutRecord> FindOverdue();
    
    /// <summary>
    /// Prints out a list of all the items that are overdue.
    /// </summary>
    /// Pre-conditions: None
    /// Post-conditions: Prints each CheckoutRecord that are overdue to the console
    void NotifyOverdue();
}