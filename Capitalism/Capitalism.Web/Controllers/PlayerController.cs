using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Capitalism.Web.Extensions;
using Capitalism.Web.Models.PlayerViewModels;
using Capitalism.Logic.Models;

namespace Capitalism.Web.Controllers
{
    [Authorize]
    public class PlayerController : Controller
    {
        public IActionResult Index()
        {
            var userId = User.Identity.GetId();
            return View();
        }

        [HttpGet]
        [Route("player/create")]
        public IActionResult Create()
        {
            var model = new PlayerCreateViewModel();
            return View(model);
        }

        [HttpPost]
        [Route("player/create")]
        public IActionResult Create(PlayerCreateViewModel model)
        {
            if (ModelState.IsValid)
            {
                Player.CreateNewPlayer(User.Identity.GetId(), model.DisplayName);
                return RedirectToAction(nameof(HomeController.Index), "Home");
            }
            return View(model);
        }

    }
}