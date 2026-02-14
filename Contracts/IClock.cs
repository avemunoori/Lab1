namespace Lab1.Contracts;

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
    /// <remarks>
    /// Pre-conditions: None
    /// Post-conditions: Returns current system time or test-configured time
    /// </remarks>
    DateTime Today();
}