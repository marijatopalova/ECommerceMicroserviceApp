using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using PaymentService.Models;

namespace PaymentService.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PaymentsController : ControllerBase
    {
        // Sample in-memory payments
        private static readonly List<Payment> Payments =
        [
            new Payment { OrderId = 1, Amount = 1999.98M, Status = "Completed" },
            new Payment { OrderId = 2, Amount = 799.99M, Status = "Pending" },
        ];

        [HttpGet("{orderId}")]
        public IActionResult GetPaymentByOrderId(int orderId)
        {
            var payment = Payments.FirstOrDefault(p => p.OrderId == orderId);
            return payment == null ? NotFound() : Ok(payment);
        }

        [HttpPost]
        public IActionResult ProcessPayment([FromBody] Payment payment)
        {
            payment.Status = "Completed";
            Payments.Add(payment);
            return Ok(payment);
        }
    }
}
