using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace UserChallengeApiApp.Api
{
    [Route("api")]
    [ApiController]
    public class HomeController : ControllerBase
    {
        [HttpGet]
        public StringMessage Index()
        {
            return new StringMessage(Message: "server is running");
        }

        [HttpGet("ping")]
        public StringMessage Ping()
        {
            return new StringMessage(Message: "pong");
        }
    }
}
