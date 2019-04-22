using Capitalism.Logic.Services;
using Capitalism.SharedKernel;
using Capitalism.Web.Api.Models.Buildings;
using Capitalism.Web.Extensions;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace Capitalism.Web.Api.Controllers.Buildings
{
    [Authorize]
    [ApiController]
    public class TownHallController : ControllerBase
    {
        [HttpGet]
        [Route("api/building/townhall/{id}")]
        public IActionResult Get(string id)
        {
            var player = ObjectFactory.Container.GetInstance<GetPlayerService>().GetByUserId(User.Identity.GetId());
            var townHall = ObjectFactory.Container.GetInstance<GetBuildingService>().GetBuildingByTownIdBuildingId(player.CurrentTown, id);
            var town = ObjectFactory.Container.GetInstance<GetTownService>().GetById(townHall.TownId);

            var model = new TownHallGetModel
            {
                TownName = town.Name,
                Population = town.Population,
                AccountBalance = town.AccountBalance,
                PollutionLevel = town.PollutionLevel
            };
            return Ok(model);
        }
    }
}