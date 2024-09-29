using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace IUCULTURE.front.Controllers
{

   
    public class HomeController : Controller
    {
        [AllowAnonymous]
        public IActionResult Index()
        {
            return View();
        }


        [Authorize(Roles = "ExpertAdmin")]
        public string ExpertAdminPage()
        {
            return "Expert Admin Page";
        }

        [Authorize(Roles = "SeniorAdmin")]
        public string SeniorAdminPage()
        {
            return "Senior Admin Page";
        }

        [Authorize(Roles = "JuniorAdmin")]
        public string JuniorAdminPage()
        {
            return "Junior Admin Page";
        }



   
    }


    
}