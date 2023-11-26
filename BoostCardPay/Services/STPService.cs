using Microsoft.EntityFrameworkCore;
using System;
using System.Linq;

public class STPService
{
    private readonly TransactionDbContext _context;

    public STPService(DbContextOptions<TransactionDbContext> context)
    {
        _context = new TransactionDbContext();
    }

        public STPService()
    {
        _context = new TransactionDbContext();
        _context.Database.EnsureCreated();
    }

    public STPService(TransactionDbContext context) {
        _context = context;
    }

    public bool ProcessTransaction(Transaction transaction)
    {
        try
        {   Console.WriteLine("Processing transaction");
            Console.WriteLine("transaction contents:");
            Console.WriteLine(transaction.printTransaction());
            // Simplified logic for processing a transaction
            _context.Database.EnsureCreated();
            _context.Transactions.Add(transaction);
            _context.SaveChanges();
            _context.Database.CloseConnection();

            return true; // Transaction processed successfully
        }
        catch (DbUpdateException ex)
        {   Console.WriteLine("DbUpdateException");
            // Handle exceptions related to database updates (e.g., unique constraint violations)
            Console.WriteLine(ex.ToString());
            // Log the exception or perform any other error handling as needed
            return false; // Indicate that the transaction failed
        }
        catch (Exception ex)
        {   Console.WriteLine("generic Exception");
            Console.WriteLine(ex.ToString());
            // Handle other exceptions that may occur
            // Log the exception or perform any other error handling as needed
            return false; // Indicate that the transaction failed
        }
    }

    public string readTable(string tableName) {
        try
        {
            _context.Database.EnsureCreated();

            // Use raw SQL to query the table by name
            var query = $"SELECT * FROM {tableName}";
            var result = _context.Transactions.FromSqlRaw(query).ToList();
            Console.WriteLine("inside readTable");
            Console.WriteLine(result.ToString());
            _context.Database.CloseConnection();

            if (result.Any())
            {
                // Process the result as needed, e.g., convert it to a string
                return string.Join("\n", result.Select(r => r.ToString()));
            }
            else
            {
                // Handle the case where the table is empty or doesn't exist
                return "No records found in the table or table doesn't exist.";
            }
        }
        catch (Exception ex)
        {
            Console.WriteLine(ex.ToString());
            return "Error";
        }
    }

}