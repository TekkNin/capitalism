using Capitalism.Logic.Services;
using Capitalism.SharedKernel;
using Capitalism.Web.Extensions;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace Capitalism.Web.Controllers
{
    [Authorize]
    public class BuildingController : Controller
    {
        [Route("/play/building/{id}")]
        public IActionResult Index(string id)
        {
            var player = ObjectFactory.Container.GetInstance<GetPlayerService>().GetByUserId(User.Identity.GetId());
            var building = ObjectFactory.Container.GetInstance<GetBuildingService>().GetBuildingByTownIdBuildingId(player.CurrentTown, id);

            return View(building);
        }
    }
}