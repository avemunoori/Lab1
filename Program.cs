using Lab1;
using Lab1.Domain.Models;
using Lab1.Domain.Enums;
using Lab1.Services;

namespace Lab1;

class Program
{
    static void Main(string[] args)
    {
        Console.WriteLine("Hello, World!");

        var repo = new Repository();
        var item = new Item(1, "TestItem", Category.Laptop, Condition.Perfect);
        var item2 = new Item(1, "TestItem2", Category.Laptop, Condition.Perfect);
        repo.SaveItem(item);
        repo.SaveItem(item2);
        
        Console.WriteLine(item.Status);
        item.MarkLost();
        Console.WriteLine(item.Status);
        
        var borrower = new Borrower(1, "TestBorrower", "TestEmail@Email.com");
        Console.WriteLine(borrower.Email);
        borrower.UpdateEmail("NewEmail@Email.com");
        Console.WriteLine(borrower.Email);

        Notifier notifier = new Notifier();
        
    }
}