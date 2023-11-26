using Castle.Components.DictionaryAdapter.Xml;
using Microsoft.EntityFrameworkCore;

public class STPService
{
    private readonly ApplicationDbContext _context;

    public STPService()
    {
        _context = new ApplicationDbContext();
    }
    public STPService(ApplicationDbContext context)
    {   // what context?
        // what is the purpose of this constructor?
        // what is the purpose of the context parameter?
        _context = context;
    }

    public bool ProcessTransaction(Transaction transaction)
    {
        try
        {
            // Simplified logic for processing a transaction
            _context.Database.EnsureCreated();

            _context.Transactions.Add(transaction);
            _context.SaveChanges();

            return true; // Transaction processed successfully
        }
        catch (DbUpdateException ex)
        {
            // Handle exceptions related to database updates (e.g., unique constraint violations)
            // Log the exception or perform any other error handling as needed
            return false; // Indicate that the transaction failed
        }
        catch (Exception ex)
        {   
            Console.WriteLine(ex.ToString());
            // Handle other exceptions that may occur
            // Log the exception or perform any other error handling as needed
            return false; // Indicate that the transaction failed
        }
    }


}
