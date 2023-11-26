using Microsoft.AspNetCore.Mvc;
using Moq;
using BoostCardPay;
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

public class STPServiceTests
{
    [Fact]
    public void ProcessTransaction_ReturnsTrue()
    {
        // Arrange
        var context = new Mock<ApplicationDbContext>();
        var service = new STPService(context.Object);

        // Act
        var result = service.ProcessTransaction(new Transaction());

        // Assert
        Assert.True(result);
    }
}
