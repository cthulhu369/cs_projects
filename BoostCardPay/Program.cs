using Microsoft.CodeAnalysis.CSharp.Syntax;
using Microsoft.EntityFrameworkCore;


namespace BoostCardPay {
    class Program {

        static async void Main1(string[] args) {
            try
            {
                Console.WriteLine("Hello World!");
                await using var db = new TransactionDbContext();
                Console.WriteLine("Db path is: " + db.DbPath);
                Console.WriteLine("Querying database...");
                var results = from a in db.Transactions
                            select a;        
                await foreach (var result in results.AsAsyncEnumerable()) {
                    Console.WriteLine(result.printTransaction());
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine("An error occurred: " + ex.ToString());
            }

        }
        static void Main(string[] args) {
            Main1(args);
        }
    

    }
}