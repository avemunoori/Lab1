using Lab1.Contracts;
using Lab1.Domain.Models;

public class Repository : IRepository
{
    private readonly List<Item> _items;
    private readonly List<CheckoutRecord> _records;

    public Repository()
    {
        _items = new List<Item>();
        _records = new List<CheckoutRecord>();
    }
    
    public void SaveItem(Item item)
    {
        if (item == null) throw new ArgumentNullException(nameof(item));
        
        var existing = _items.FirstOrDefault(x => x.Id == item.Id);

        if (existing == null)
        {
            _items.Add(item);
        }
        else
        {
            _items.Remove(existing);
            _items.Add(item);
        }
    }

    public Item? GetItem(int itemId)
    {
        return _items.SingleOrDefault(x => x.Id == itemId);
    }

    public IReadOnlyList<Item> AllItems()
    {
        return _items;
    }

    public void SaveRecord(CheckoutRecord record)
    {
        if (record == null) throw new ArgumentNullException(nameof(record));
        _records.Add(record);
    }

    public CheckoutRecord? GetActiveRecordFor(int itemId)
    {
        return _records
            .Where(r => r.Item.Id == itemId)
            .OrderByDescending(r => r.CheckoutDate)
            .FirstOrDefault();
    }

    public IReadOnlyList<CheckoutRecord> AllRecords()
    {
        return _records;
    }
}