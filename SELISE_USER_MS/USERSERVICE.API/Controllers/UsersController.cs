using Microsoft.AspNetCore.Mvc;

namespace USERSERVICE.API.Controllers
{
    public class UsersController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
