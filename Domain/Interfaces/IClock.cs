namespace Lab1.Domain.Interfaces;

/// <summary>
/// Provides access to the current date and time.
/// Abstraction allows for testing with fixed dates.
/// </summary>
public interface IClock
{
    /// <summary>
    /// Gets the current date and time.
    /// </summary>
    /// <returns>The current date and time.</returns>
    DateTime Today();
}