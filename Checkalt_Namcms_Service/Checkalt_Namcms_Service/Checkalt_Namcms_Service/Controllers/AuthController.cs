using Checkalt_Namcms_Service.Services.IServices;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Checkalt_Namcms_Service.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AuthController : ControllerBase
    {
        public readonly IAuthService _Servc;
        public AuthController(IAuthService Servc)
        {
            _Servc = Servc;
        }

        [HttpGet]
        [Route("getaccesstoken")]
        public async Task<IActionResult> GetAccesstoken()
        {
            try
            {
                var token = await _Servc.GetAccesstoken();
                return Ok(token);
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex);
                throw;
            }
        }
    }
}
