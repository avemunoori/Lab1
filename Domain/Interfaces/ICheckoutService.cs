using Lab1.Domain.Models;

namespace Lab1.Domain.Interfaces;

/// <summary>
/// Main service interface for library checkout and return operations.
/// Orchestrates interactions between catalog, repository, policy, and notification systems.
/// </summary>
public interface ICheckoutService
{
    /// <summary>
    /// Gets the catalog for browsing available items.
    /// </summary>
    /// <returns>The catalog interface for item browsing.</returns>
    ICatalog GetCatalog();

    /// <summary>
    /// Checks out an item to a borrower with a specified due date.
    /// </summary>
    /// <param name="itemId">The unique identifier of the item to check out.</param>
    /// <param name="borrower">The borrower checking out the item.</param>
    /// <param name="dueDate">The date by which the item should be returned.</param>
    /// <returns>A receipt confirming the checkout transaction.</returns>
    Receipt Checkout(int itemId, Borrower borrower, DateTime dueDate);

    /// <summary>
    /// Returns an item that was previously checked out.
    /// </summary>
    /// <param name="itemId">The unique identifier of the item to return.</param>
    /// <returns>A receipt confirming the return transaction, or null if item was not checked out.</returns>
    Receipt? Return(int itemId);

    /// <summary>
    /// Marks an item as lost in the system.
    /// </summary>
    /// <param name="itemId">The unique identifier of the item to mark as lost.</param>
    void MarkLost(int itemId);

    /// <summary>
    /// Retrieves all active loans for a specific borrower.
    /// </summary>
    /// <param name="borrower">The borrower whose active loans to retrieve.</param>
    /// <returns>A list of active checkout records for the borrower.</returns>
    List<CheckoutRecord> ListActiveLoans(Borrower borrower);

    /// <summary>
    /// Finds all checkout records with due dates within a specified time window.
    /// </summary>
    /// <param name="window">The time window to search (e.g., next 7 days).</param>
    /// <returns>A list of checkout records due within the time window.</returns>
    List<CheckoutRecord> FindDueSoon(TimeSpan window);

    /// <summary>
    /// Finds all checkout records that are currently overdue.
    /// </summary>
    /// <returns>A list of overdue checkout records.</returns>
    List<CheckoutRecord> FindOverdue();
}