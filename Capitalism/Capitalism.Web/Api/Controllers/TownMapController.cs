using Capitalism.Logic.Services;
using Capitalism.SharedKernel;
using Capitalism.Web.Extensions;
using Microsoft.AspNetCore.Mvc;

namespace Capitalism.Web.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class TownMapController : ControllerBase
    {
        [HttpGet]
        public IActionResult Get()
        {
            var player = ObjectFactory.Container.GetInstance<GetPlayerService>().GetByUserId(User.Identity.GetId());
            var map = ObjectFactory.Container.GetInstance<GetBuildingService>().GetByTownId(player.CurrentTown);

            return Ok(map);
        }
    }
}
