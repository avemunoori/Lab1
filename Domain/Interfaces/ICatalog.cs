using Lab1.Domain.Models;

namespace Lab1.Domain.Interfaces;

/// <summary>
/// Provides catalog operations for browsing library items.
/// </summary>
public interface ICatalog
{
    /// <summary>
    /// Retrieves a list of all items currently available for checkout.
    /// </summary>
    /// <returns>A list of available items.</returns>
    List<Item> ListAvailable();

    /// <summary>
    /// Retrieves a list of all items currently checked out.
    /// </summary>
    /// <returns>A list of checked out items.</returns>
    List<Item> ListCheckedOut();

    /// <summary>
    /// Retrieves a list of all items in the catalog, regardless of status.
    /// </summary>
    /// <returns>A list of all items.</returns>
    List<Item> ListAll();
}