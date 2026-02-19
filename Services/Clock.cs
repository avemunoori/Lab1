using Lab1.Contracts;
namespace Lab1.Services;

public class Clock : IClock
{
    public DateTime Today() => DateTime.Today;
}