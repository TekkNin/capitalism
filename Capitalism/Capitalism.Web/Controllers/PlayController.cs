using Capitalism.Logic.Services;
using Capitalism.SharedKernel;
using Capitalism.Web.Extensions;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace Capitalism.Web.Controllers
{
    [Authorize]
    public class PlayController : Controller
    {
        public IActionResult Index()
        {
            var player = ObjectFactory.Container.GetInstance<GetPlayerService>().GetByUserId(User.Identity.GetId());
            if (player == null)
                return RedirectToAction(nameof(PlayerController.Create), "player");

            return View();
        }
    }
}