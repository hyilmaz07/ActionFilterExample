using Microsoft.AspNetCore.Mvc;

namespace ActionFilterExample.Controllers
{
    //Önemli : localizationCode buradaki route parametresi küçük harf ile başlamalı L değil l olacak
    [Route("api/{localizationCode}/[controller]")]
    [ApiController]
    public class BaseController : ControllerBase
    {
        public string LocalizationCode { get; set; }
    }
}
