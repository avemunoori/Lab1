using Lab1.Domain.Models;

namespace Lab1.Contracts;

/// <summary>
/// Provides data access operations for items and checkout records.
/// </summary>
public interface IRepository
{
    /// <summary>
    /// Saves an item to the repository. Updates existing item if ID matches.
    /// </summary>
    /// <param name="item">The item to save.</param>
    /// <exception cref="ArgumentNullException">Thrown when item is null.</exception>
    /// <remarks>
    /// Pre-conditions: Item must not be null
    /// Post-conditions: Item is persisted in the repository
    /// </remarks>
    void SaveItem(Item item);

    /// <summary>
    /// Retrieves an item by its unique identifier.
    /// </summary>
    /// <param name="itemId">The unique identifier of the item.</param>
    /// <returns>The item if found; otherwise, null.</returns>
    /// <remarks>
    /// Pre-conditions: None
    /// Post-conditions: Returns matching item or null if not found
    /// </remarks>
    Item? GetItem(int itemId);

    /// <summary>
    /// Retrieves all items in the repository.
    /// </summary>
    /// <returns>A list of all items.</returns>
    /// <remarks>
    /// Pre-conditions: None
    /// Post-conditions: Returns all items in the repository
    /// </remarks>
    List<Item> AllItems();

    /// <summary>
    /// Saves a checkout record to the repository.
    /// </summary>
    /// <param name="record">The checkout record to save.</param>
    /// <exception cref="ArgumentNullException">Thrown when record is null.</exception>
    /// <remarks>
    /// Pre-conditions: Record must not be null
    /// Post-conditions: Record is persisted in the repository
    /// </remarks>
    void SaveRecord(CheckoutRecord record);

    /// <summary>
    /// Retrieves the most recent active checkout record for a specific item.
    /// </summary>
    /// <param name="itemId">The unique identifier of the item.</param>
    /// <returns>The active checkout record if found; otherwise, null.</returns>
    /// <remarks>
    /// Pre-conditions: None
    /// Post-conditions: Returns the most recent checkout record for the item or null
    /// </remarks>
    CheckoutRecord? GetActiveRecordFor(int itemId);

    /// <summary>
    /// Retrieves all checkout records in the repository.
    /// </summary>
    /// <returns>A list of all checkout records.</returns>
    /// <remarks>
    /// Pre-conditions: None
    /// Post-conditions: Returns all checkout records in the repository
    /// </remarks>
    List<CheckoutRecord> AllRecords();
}