using Lab1.Domain.Models;

namespace Lab1.Contracts;

/// <summary>
/// Provides catalog operations for browsing library items.
/// </summary>
public interface ICatalog
{
    /// <summary>
    /// Retrieves a list of all items currently available for checkout.
    /// </summary>
    /// <returns>A list of available items.</returns>
    /// <remarks>
    /// Pre-conditions: None
    /// Post-conditions: Returns all items with Status.AVAILABLE
    /// </remarks>
    List<Item> ListAvailable();

    /// <summary>
    /// Retrieves a list of all items currently checked out.
    /// </summary>
    /// <returns>A list of checked out items.</returns>
    /// <remarks>
    /// Pre-conditions: None
    /// Post-conditions: Returns all items with Status.CHECKED_OUT
    /// </remarks>
    List<Item> ListCheckedOut();

    /// <summary>
    /// Retrieves a list of all items in the catalog, regardless of status.
    /// </summary>
    /// <returns>A list of all items.</returns>
    /// <remarks>
    /// Pre-conditions: None
    /// Post-conditions: Returns all items in the catalog
    /// </remarks>
    List<Item> ListAll();
}