using Lab1.Contracts;
using Lab1.Domain.Enums;
using Lab1.Domain.Models;

namespace Lab1.Services;

public class Catalog : ICatalog
{
    private readonly IRepository _repository;

    public Catalog(IRepository repository)
    {
        _repository = repository;
    }

    public List<Item> ListAvailable()
    {
        return _repository.AllItems()
            .Where(item => item.Status == Status.Available)
            .ToList();
    }

    public List<Item> ListCheckedOut()
    {
        return _repository.AllItems()
            .Where(item => item.Status == Status.CheckedOut)
            .ToList();
    }

    public List<Item> ListAll()
    {
        return _repository.AllItems();
    }
}
