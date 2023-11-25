public class Rule
{
    public int Id { get; set; }
    public string? Type { get; set; } // e.g., "TransactionLimit"
    public string? Parameters { get; set; } // JSON string to store various parameters
}
