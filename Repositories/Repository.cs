using Lab1.Contracts;
using Lab1.Domain.Models;

public class Repository : IRepository
{
    public void SaveItem(Item item)
    {
        throw new NotImplementedException();
    }

    public Item? GetItem(int itemId)
    {
        throw new NotImplementedException();
    }

    public List<Item> AllItems()
    {
        throw new NotImplementedException();
    }

    public void SaveRecord(CheckoutRecord record)
    {
        throw new NotImplementedException();
    }

    public CheckoutRecord? GetActiveRecordFor(int itemId)
    {
        throw new NotImplementedException();
    }

    public List<CheckoutRecord> AllRecords()
    {
        throw new NotImplementedException();
    }
}