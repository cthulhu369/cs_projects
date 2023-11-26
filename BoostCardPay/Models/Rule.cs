public class Rule
{
    public int Id { get; set; }
    public string? Type { get; set; } // e.g., "TransactionLimit"
    public string? Parameters { get; set; } // JSON string to store various parameters
    public string? Description { get; set; } // e.g., "Maximum number of transactions per day"
    public string? Status { get; set; } // e.g., "Active"
    public int Priority { get; set; } // e.g., 1
    public string? Value { get; set; } // e.g., "10"
    public string? Name { get; set; } // e.g., "TransactionLimit1"
    public string? ErrorMessage { get; set; } // e.g., "Transaction limit exceeded"

    public Rule(string type, string parameters, string description, string status, int priority, string value, string name, string errorMessage)
    {
        Type = type;
        Parameters = parameters;
        Description = description;
        Status = status;
        Priority = priority;
        Value = value;
        Name = name;
        ErrorMessage = errorMessage;
    }
    public Rule()
    {
        Type = "TransactionLimit";
        Parameters = "{'limit': 10}";
        Description = "Maximum number of transactions per day";
        Status = "Active";
        Priority = 1;
        Value = "10";
        Name = "TransactionLimit1";
        ErrorMessage = "Transaction limit exceeded";
    }
}
