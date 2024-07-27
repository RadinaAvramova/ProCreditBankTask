using Microsoft.AspNetCore.Mvc;
using ProCreditBankZadacha.Services;

namespace ProCreditBankZadacha.Controllers
{
    [ApiController]
    [Route("api/mt799")]
    public class SwiftMT799Controller : ControllerBase
    {
        private readonly SwiftMT799Parser _swiftMT799Parser;
        private readonly ApplicationDbContext _dbContext;

        public SwiftMT799Controller(SwiftMT799Parser swiftMT799Parser, ApplicationDbContext dbContext)
        {
            _swiftMT799Parser = swiftMT799Parser;
            _dbContext = dbContext;
        }

        [HttpPost]
        [Route("process")]
        public IActionResult ProcessMT799Message([FromBody] string message)
        {
            try
            {
                
                SwiftMT799Parser.SwiftMT799Message parsedMessage = _swiftMT799Parser.ParseMT799(message);

               
                var parsedEntity = new ParsedSwiftMT799Message
                {
                    Field1 = parsedMessage.Field1,
                    Field2 = parsedMessage.Field2,
                    
                };

                _dbContext.ParsedMessages.Add(parsedEntity);
                _dbContext.SaveChanges();

                return Ok("Message processed successfully!");
            }
            catch (Exception ex)
            {
               
                return StatusCode(500, "Error processing the message.");
            }
        }
    }
}

