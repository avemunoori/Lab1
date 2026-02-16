namespace Lab1.Domain.Models;

public class Borrower
{
    public int Id { get; }
    
    public string Name { get; }

    private string _email = string.Empty;
    public string Email
    {
        get => _email;
        private set
        {
            if (string.IsNullOrWhiteSpace(value))
                throw new ArgumentException("Email cannot be empty.", nameof(value));
            _email = value;
        }
    }

    public Borrower(int id, string name, string email)
    {
        if (id <= 0)
            throw new ArgumentException("Id cannot be less than one.", nameof(id));
        Id = id;
        if (string.IsNullOrWhiteSpace(name))
            throw new ArgumentException("Name cannot be empty.", nameof(name));
        Name = name;
        Email = email;
    }

    public void UpdateEmail(string newEmail)
    {
        Email = newEmail;
    }
}