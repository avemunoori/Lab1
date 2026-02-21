using Lab1;
using Lab1.Contracts;
using Lab1.Domain.Models;
using Lab1.Domain.Enums;
using Lab1.Services;

namespace Lab1;

class Program
{
    private static IRepository _repository = null!;
    private static IClock _clock = null!;
    private static IPolicy _policy = null!;
    private static INotifier _notifier = null!;
    private static ICheckoutService _checkoutService = null!;
    private static ICatalog _catalog = null!;
    static void Main(string[] args)
    {
        Initialize();
        while (true)
        {
            Greet();
            var choice = Console.ReadLine();
            if (choice == "0") break;
            Choice(choice);
            Console.WriteLine("\nPress ENTER to continue...");
            Console.ReadLine();
        }
    }
    
    private static void Initialize()
    {
        _repository = new Repository();
        _clock = new Clock();
        _policy = new Policy(_clock);
        _notifier = new Notifier();
        _checkoutService = new CheckoutService(_repository, _policy, _clock, _notifier);
        _catalog = _checkoutService.GetCatalog();
    }

    public static void Greet()
    {
        Console.WriteLine("Welcome to the Equipment Checkout System!\n" +
                          "Choose an option:\n" +
                          "1) Add items to inventory\n" +
                          "2) List available items\n" +
                          "3) List unavailable items\n" +
                          "4) Check out item\n" +
                          "5) Return item\n" +
                          "6) Show due soon (next 24h)\n" +
                          "7) Show overdue items\n" +
                          "8) Search items (optional)\n" +
                          "9) Mark item LOST\n" +
                          "0) Exit");
    }

    public static void Choice(string? choice)
    {
        switch (choice)
        {
            case "1":
                AddItem();
                break;
            case "2":
                ListAvailable();
                break;
            case "3":
                ListUnavailable();
                break;
            case "4":
                CheckoutItem();
                break;
            case "5":
                ReturnItem();
                break;
            case "6":
                ListDueSoon();
                break;
            case "7":
                ListOverdue();
                break;
            case "8":
                Search();
                break;
            case "9":
                MarkLost();
                break;
            default:
                Console.WriteLine("Invalid choice.");
                break;
        }
    }

    public static void AddItem()
    {
        Console.WriteLine("\nEnter item ID: ");
        if (!int.TryParse(Console.ReadLine(), out var id))
        {
            Console.WriteLine("Invalid ID.");
            return;
        }
       
        Console.WriteLine("\nEnter item name: ");
        var name = Console.ReadLine() ?? "";
        
        Console.WriteLine("\nEnter item category: ");
        Console.WriteLine("Valid categories:");
        foreach (var value in Enum.GetNames(typeof(Category)))
        {
            Console.WriteLine(value);
        }
        if (!Enum.TryParse<Category>(Console.ReadLine(), true, out var category))
        {
            Console.WriteLine("Invalid category.");
            return;
        }
        
        Console.WriteLine("\nValid conditions:");
        foreach (var value in Enum.GetNames(typeof(Condition)))
        {
            Console.WriteLine(value);
        }
        if (!Enum.TryParse<Condition>(Console.ReadLine(), true, out var condition))
        {
            Console.WriteLine("Invalid condition.");
            return;
        }
        
        try
        {
            var item = new Item(id, name, category, condition);
            _repository.SaveItem(item);
            Console.WriteLine("\nItem added successfully.");
        }
        catch (Exception ex)
        {
            Console.WriteLine(ex.Message);
        }
    }

    public static void ListAvailable()
    {
        foreach (var item in _catalog.ListAvailable())
        {
            Console.WriteLine($"{item.Id} | {item.Name} | {item.Category} | {item.Condition}");
        }
    }

    public static void ListUnavailable()
    {
        if (_catalog.ListCheckedOut().Count == 0 && _catalog.ListLost().Count == 0)
        {
            Console.WriteLine("No items found.");
            return;
        }
        foreach (var item in _catalog.ListCheckedOut())
        {
            Console.WriteLine($"{item.Id} | {item.Name} | {item.Category} | {item.Condition}");
        }

        foreach (var item in _catalog.ListLost())
        {
            Console.WriteLine($"{item.Id} | {item.Name} | {item.Category} | {item.Condition}");
        }
    }

    public static void CheckoutItem()
    {
        Console.WriteLine("Checkout Item:");
        Console.WriteLine("Item ID:");
        if (!int.TryParse(Console.ReadLine(), out var itemId))
        {
            Console.WriteLine("Invalid ID.");
            return;
        }

        Console.WriteLine("Your ID:");
        if (!int.TryParse(Console.ReadLine(), out var borrowerId))
        {
            Console.WriteLine("Invalid ID.");
            return;
        }
        Console.WriteLine("Your name:");
        var name = Console.ReadLine() ?? "";
        Console.WriteLine("Your email: ");
        var email = Console.ReadLine() ?? "";
        
        var borrower = new Borrower(borrowerId, name, email);
        var dueDate = _clock.Today().AddDays(7);
        try
        {
            var receipt = _checkoutService.Checkout(itemId, borrower, dueDate);
            receipt.Checkout();
        }
        catch (Exception ex)
        {
            Console.WriteLine(ex.Message);
        }
    }

    public static void ReturnItem()
    {
        Console.WriteLine("Return item");
        Console.WriteLine("Item ID:");
        if (!int.TryParse(Console.ReadLine(), out var itemId))
        {
            Console.WriteLine("Invalid ID.");
        }
        
        try
        {
            var receipt = _checkoutService.Return(itemId);
            receipt.Return();
        }
        catch (Exception ex)
        {
            Console.WriteLine(ex.Message);
        }
    }

    public static void ListDueSoon()
    {
        Console.WriteLine("Due soon (next 24h)");
        _checkoutService.NotifyDueSoon(TimeSpan.FromHours(24));
    }

    public static void ListOverdue()
    {
        Console.WriteLine("Overdue");
        _checkoutService.NotifyOverdue();
    }

    public static void Search()
    {
        Console.WriteLine("Search Items");
        Console.WriteLine("Query");
        var input = Console.ReadLine();
        foreach (var item in _catalog.ListAvailable())
        {
            if (item.Name.ToLower() == input.ToLower())
            {
                Console.WriteLine($"{item.Id} | {item.Name} | {item.Condition}");
            }
        }
    }

    public static void MarkLost()
    {
        Console.WriteLine("Mark Item lost");
        Console.WriteLine("Item ID:");
        if (!int.TryParse(Console.ReadLine(), out var itemId))
        {
            Console.WriteLine("Invalid ID.");
            return;
        }
        _checkoutService.MarkLost(itemId);
        Console.WriteLine("Item has been marked lost");
    }
}