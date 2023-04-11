using ActionFilterExample.Model;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace ActionFilterExample.Controllers
{

    [ApiController]
    public class LocalizationController : BaseController
    {
        [HttpGet]
        public IActionResult Get()
        {
            return Ok($"LocalizationCode : {LocalizationCode}");
        }
        [HttpPost]
        public IActionResult Post(UpdateLocalizationRequest request)
        {
            return Ok($"LocalizationCode : {request.LocalizationCode}, LocalizationName : {request.Name}");
        }
    }
}
