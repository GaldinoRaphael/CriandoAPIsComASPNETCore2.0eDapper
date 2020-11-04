using Microsoft.AspNetCore.Mvc;

namespace RaphaStore.Api.Controllers
{
    public class HomeController : Controller
    {
        [Route("")]
        public string Get()
        {
            return "Hello world";
        }
    }
}