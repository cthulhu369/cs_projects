using Microsoft.AspNetCore.Mvc;

[ApiController]
[Route("[controller]")]
public class TransactionController : ControllerBase
{
    private readonly STPService _stpService;

    public TransactionController(STPService stpService)
    {
        _stpService = stpService;
    }

    [HttpPost]
    public IActionResult ProcessTransaction([FromBody] Transaction transaction)
    {
        var result = _stpService.ProcessTransaction(transaction);
        //var result1 = new OkObjectResult(200);
        return Ok(result); // Simplified response
    }
}
