using Microsoft.AspNetCore.Mvc;

namespace MMT.UI.Site.Areas.Admin.Controllers
{
    [Area("admin")]
    [Route("admin/home")]
    public class HomeController : Controller
    {
        [Route("index")]
        public IActionResult Index()
        {
            return View();
        }
    }
}