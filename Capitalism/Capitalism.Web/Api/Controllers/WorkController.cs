using Capitalism.Logic.Models.Interfaces;
using Capitalism.Logic.Services;
using Capitalism.SharedKernel;
using Capitalism.Web.Api.Models;
using Capitalism.Web.Extensions;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace Capitalism.Web.Api.Controllers
{
    [Authorize]
    [Route("api/[controller]")]
    [ApiController]
    public class WorkController : ControllerBase
    {
        [HttpPost]
        public IActionResult Post([FromBody] WorkPostModel model)
        {
            var player = ObjectFactory.Container.GetInstance<GetPlayerService>().GetByUserId(User.Identity.GetId());
            var building = ObjectFactory.Container.GetInstance<GetBuildingService>().GetBuildingByTownIdBuildingId(player.CurrentTown, model.BuildingId);

            var workResult = ((IWorkable)building).Work(player);

            return Ok(workResult);
        }

    }
}
