using BankingSystem.JsonOperations;
using BankingSystem.Models;
using Microsoft.AspNetCore.Mvc;
using System.Text.Json;

namespace BankingSystem.Controllers;

[ApiController]
[Route("[controller]")]
public class PaymentsController(IConfiguration configuration) : ControllerBase
{
    private readonly IConfiguration configuration = configuration;
    private static int _id = 1;

    // Assumes the banking system has already authenticate our company
    // Our company's IBAN, name, etc. is already known by the banking system

    [HttpPost("pay")]
    public IActionResult Pay([FromBody] OutgoingPaymentRequest payment)
    {
        string json = System.IO.File.ReadAllText(configuration.GetValue<string>("paymentFile"));

        if (string.IsNullOrWhiteSpace(json))
            json = "[]";

        ICollection<OutgoingPaymentRequest> payments = JsonSerializer.Deserialize<List<OutgoingPaymentRequest>>(json)!;

        foreach (var item in payments)
        {
            item.Id = _id++;
            item.Date = DateTime.Now;
        }

        JsonFile.Add(payments, payment);

        return Ok();
    }

    [HttpPost("by-description")]
    public IActionResult GetByDescription([FromBody] string description)  // for security reasons the description added to body
    {
        using var streamReader = new StreamReader(configuration.GetValue<string>("paymentFile"));
        string json = streamReader.ReadToEnd();

        if (string.IsNullOrWhiteSpace(json) || json == "[]")
            return NotFound();

        var payments = JsonSerializer.Deserialize<List<OutgoingPaymentRequest>>(json)?
            .Where(p => p.Description == description);

        return (payments?.Any() == true) ? Ok(payments) : NotFound();
        // since payments could also be null, we need guarentee that the condition equals true        
    }
}
