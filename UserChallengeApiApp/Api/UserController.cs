using Microsoft.AspNetCore.DataProtection.KeyManagement;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Primitives;
using UserChallengeApiApp.Model;

namespace UserChallengeApiApp.Api
{
    // UserController - контроллер для работы с пользователями
    [Route("api/user")]
    [ApiController]
    public class UserController : ControllerBase
    {
        private readonly UserService _userService;

        public UserController(UserService userService)
        {
            _userService = userService;
        }

        [HttpGet] 
        public async Task GetAsync()
        {
            // достать заголовок запроса X-Api-Key
            StringValues xApiKeyHeader = HttpContext.Request.Headers["X-Api-Key"];
            if (xApiKeyHeader.Count < 1)
            {
                // не передан нужный заголовок - 400
                HttpContext.Response.StatusCode = StatusCodes.Status400BadRequest;
                await HttpContext.Response.WriteAsJsonAsync(new ErrorMessage(Type: "EmptyHeader", Message: "X-Api-Key is empty"));
            }
            string headerValue = $"{xApiKeyHeader[0]}";
            try
            {
                UserInfo userInfo = await _userService.GetUserInfoAsync(headerValue);
                // 200
                HttpContext.Response.StatusCode = StatusCodes.Status200OK;
                await HttpContext.Response.WriteAsJsonAsync(userInfo);
            }
            catch (InvalidApiKeyException ex) {
                // 404
                HttpContext.Response.StatusCode = StatusCodes.Status404NotFound;
                await HttpContext.Response.WriteAsJsonAsync(new ErrorMessage(Type: ex.GetType().Name, Message: ex.Message));
            }
        }

        [HttpPost]
        public async Task RegisterAsync(LoginMessage loginMessage)
        {
            try
            {
                string apiKey = await _userService.RegisterUserAsync(loginMessage.Login);
                // 200
                HttpContext.Response.StatusCode = StatusCodes.Status200OK;
                await HttpContext.Response.WriteAsJsonAsync(new {ApiKey= apiKey});
            }
            catch (LoginTakenException ex)
            {
                // 409
                HttpContext.Response.StatusCode = StatusCodes.Status409Conflict;
                await HttpContext.Response.WriteAsJsonAsync(new ErrorMessage(Type: ex.GetType().Name, Message: ex.Message));
            }
            catch (InvalidLoginException ex)
            {
                // 400
                HttpContext.Response.StatusCode = StatusCodes.Status400BadRequest;
                await HttpContext.Response.WriteAsJsonAsync(new ErrorMessage(Type: ex.GetType().Name, Message: ex.Message));
            }
        }
    }
}
