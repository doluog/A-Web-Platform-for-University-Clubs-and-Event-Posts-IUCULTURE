using Microsoft.AspNetCore.Mvc;

namespace IUCULTURE.front.Controllers
{
    public class TeamController : Controller
    {
        public IActionResult List()
        {
            return View();
        }
    }
}
