using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using static CarRentingSystem.Areas.Administrator.Constants.AdminConstants;

namespace CarRentingSystem.Areas.Administrator.Controllers
{
    [Area(AreaName)]
    [Route("Administrator/[controller]/[Action]/{id?}")]
    [Authorize(Roles = AdminRoleName)]
    public class BaseController : Controller
    {
    }
}
