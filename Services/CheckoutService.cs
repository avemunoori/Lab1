using Lab1.Contracts;
using Lab1.Domain.Enums;
using Lab1.Domain.Models;

namespace Lab1.Services;

public class CheckoutService : ICheckoutService
{
    private readonly IRepository _repository;
    private readonly IPolicy _policy;
    private readonly IClock _clock;
    private readonly INotifier _notifier;
    private readonly ICatalog _catalog;

    public CheckoutService(IRepository repository, IPolicy policy, IClock clock, INotifier notifier)
    {
        _repository = repository;
        _policy = policy;
        _clock = clock;
        _notifier = notifier;
        _catalog = new Catalog(_repository);
    }

    public ICatalog GetCatalog()
    {
        return _catalog;
    }

    public Receipt Checkout(int itemId, Borrower borrower, DateTime dueDate)
    {
        var item = _repository.GetItem(itemId);
        if (item == null)
            throw new ArgumentException($"Item {itemId} does not exist.");

        if (!_policy.CanCheckout(item, borrower))
            throw new InvalidOperationException($"Item {itemId} cannot be checked out.");

        var normalizedDueDate = _policy.NormalizeDueDate(dueDate);
        var checkoutDate = _clock.Today();

        item.MarkCheckedOut();
        var record = new CheckoutRecord(item, borrower, normalizedDueDate, checkoutDate);

        _repository.SaveItem(item);
        _repository.SaveRecord(record);

        return new Receipt(itemId, TransactionType.Checkout, normalizedDueDate, checkoutDate);
    }

    public Receipt? Return(int itemId)
    {
        var item = _repository.GetItem(itemId);
        if (item == null)
            throw new ArgumentException($"Item {itemId} does not exist.");

        var activeRecord = _repository.GetActiveRecordFor(itemId);
        if (activeRecord == null || item.Status != Status.CheckedOut)
            return null;

        item.MarkAvailable();
        _repository.SaveItem(item);

        return new Receipt(itemId, TransactionType.Return, activeRecord.DueDate, activeRecord.CheckoutDate);
    }

    public void MarkLost(int itemId)
    {
        var item = _repository.GetItem(itemId);
        if (item == null)
            throw new ArgumentException($"Item {itemId} does not exist.");

        item.MarkLost();
        _repository.SaveItem(item);
    }

    public List<CheckoutRecord> ListActiveLoans(Borrower borrower)
    {
        return _repository.AllRecords()
            .Where(record => record.Borrower.Id == borrower.Id && 
                             record.Item.Status == Status.CheckedOut)
            .ToList();
    }

    public List<CheckoutRecord> FindDueSoon(TimeSpan window)
    {
        var now = _clock.Today();
        var windowEnd = now.Add(window);

        var dueSoonRecords = _repository.AllRecords()
            .Where(record => record.Item.Status == Status.CheckedOut &&
                             record.DueDate >= now &&
                             record.DueDate <= windowEnd)
            .ToList();

        foreach (var record in dueSoonRecords)
        {
            _notifier.DueSoon(record.Borrower, record);
        }

        return dueSoonRecords;
    }

    public List<CheckoutRecord> FindOverdue()
    {
        var now = _clock.Today();

        var overdueRecords = _repository.AllRecords()
            .Where(record => record.Item.Status == Status.CheckedOut &&
                             record.DueDate < now)
            .ToList();

        foreach (var record in overdueRecords)
        {
            _notifier.Overdue(record.Borrower, record);
        }

        return overdueRecords;
    }
}

