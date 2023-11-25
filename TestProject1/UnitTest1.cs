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
