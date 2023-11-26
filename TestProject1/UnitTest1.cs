using Microsoft.AspNetCore.Mvc;
using Moq;
using Microsoft.Data.Sqlite;
using Microsoft.EntityFrameworkCore;
namespace BoostCardPay.Tests;

public class TransactionControllerTests
{
    [Fact]
    public void ProcessTransaction_ReturnsOk()
    {
        // Arrange
        var stpService = new Mock<STPService>();
        var controller = new TransactionController(stpService.Object);

        // Act
        var result = controller.ProcessTransaction(new Transaction());

        // Assert
        Assert.IsType<OkObjectResult>(result);
        
    }
}

public class STPServiceTests {
    [Fact]
    public void ProcessTransaction_ReturnsTrue()
    {
        // Arrange
        // var context = new Mock<ApplicationDbContext>();
        var context = new DbContextOptionsBuilder<ApplicationDbContext>()
            .UseSqlite("Filename=Transactions.db")
            .Options;
        var service = new STPService(context);

        // Act
        var result = service.ProcessTransaction(new Transaction());

        // Assert
        Assert.True(result);
    }

    [Fact]
    public void readTableTest() {
        // Arrange
        var context = new DbContextOptionsBuilder<ApplicationDbContext>()
            .UseSqlite("Filename=/home/ericp/Coding/cs_projects/BoostCardPay/Transactions.db")
            .Options;
        var service = new STPService(context);

        // Act
        var result = service.readTable("Transactions");
        Console.WriteLine("the result is:");
        Console.WriteLine(result.ToString());
        Console.WriteLine();
        // Assert
        Assert.Equal("Transaction", result);
    }
}
 
 public class ApplicationDbContextTests {
     [Fact]
     public void getConnection_ReturnsDbConnection()
     {
         // Arrange
         var context = new ApplicationDbContext();

         // Act
         var result = context.getConnection();
         Console.WriteLine("the connection is:");
         Console.WriteLine(result);

         // Assert
         Assert.IsType<SqliteConnection>(result);
     }
 }