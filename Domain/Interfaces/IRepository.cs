using Lab1.Domain.Models;

namespace Lab1.Domain.Interfaces;

/// <summary>
/// Provides data access operations for items and checkout records.
/// </summary>
public interface IRepository
{
    /// <summary>
    /// Saves an item to the repository. Updates existing item if ID matches.
    /// </summary>
    /// <param name="item">The item to save.</param>
    void SaveItem(Item item);

    /// <summary>
    /// Retrieves an item by its unique identifier.
    /// </summary>
    /// <param name="itemId">The unique identifier of the item.</param>
    /// <returns>The item if found; otherwise, null.</returns>
    Item? GetItem(int itemId);

    /// <summary>
    /// Retrieves all items in the repository.
    /// </summary>
    /// <returns>A list of all items.</returns>
    List<Item> AllItems();

    /// <summary>
    /// Saves a checkout record to the repository.
    /// </summary>
    /// <param name="record">The checkout record to save.</param>
    void SaveRecord(CheckoutRecord record);

    /// <summary>
    /// Retrieves the most recent active checkout record for a specific item.
    /// </summary>
    /// <param name="itemId">The unique identifier of the item.</param>
    /// <returns>The active checkout record if found; otherwise, null.</returns>
    CheckoutRecord? GetActiveRecordFor(int itemId);

    /// <summary>
    /// Retrieves all checkout records in the repository.
    /// </summary>
    /// <returns>A list of all checkout records.</returns>
    List<CheckoutRecord> AllRecords();
}