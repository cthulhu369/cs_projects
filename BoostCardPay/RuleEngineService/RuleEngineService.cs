public class RuleEngineService
{
    private readonly TransactionDbContext _context;

    public RuleEngineService(TransactionDbContext context)
    {
        _context = context;
    }

    public bool ApplyRules(Transaction transaction)
    {
        // Example: Apply rules to the transaction
        return true; // Return true if rules are satisfied
    }
}
