using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace CarRentingSystem.Areas.Administrator.Controllers
{
    [Area("Administrator")]
    [Route("Administrator/[controller]/[Action]/{id?}")]
    [Authorize(Roles = "Administrator")]
    public class BaseController : Controller
    {
    }
}
