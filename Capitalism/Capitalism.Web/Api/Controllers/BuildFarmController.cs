using Capitalism.Logic.Models.Buildings;
using Capitalism.Logic.Services;
using Capitalism.Logic.Types;
using Capitalism.SharedKernel;
using Capitalism.Web.Api.Models;
using Capitalism.Web.Extensions;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace Capitalism.Web.Api.Controllers
{
    [Authorize]
    [ApiController]
    public class BuildFarmController : ControllerBase
    {
        [HttpPost]
        [Route("api/build/farm")]
        public IActionResult Post([FromBody] BuildFarmPostModel model)
        {
            var player = ObjectFactory.Container.GetInstance<GetPlayerService>().GetByUserId(User.Identity.GetId());
            var building = ObjectFactory.Container.GetInstance<GetBuildingService>().GetBuildingByTownIdBuildingId(player.CurrentTown, model.BuildingId);

            var results = ActionResults.Empty;
            if (building is EmptyLand)
            {
                var farm = new Farm(
                    building.Id, 
                    building.TownId, 
                    building.XCoordinate, 
                    building.YCoordinate, 
                    player.DisplayName + "'s Farm", 
                    ((EmptyLand)building).OwnerId, 
                    ((EmptyLand)building).IsForSale, 
                    ((EmptyLand)building).Price, 
                    ((EmptyLand)building).ModifiedDate, 
                    ((EmptyLand)building).CreatedDate);
                results = farm.Build((EmptyLand)building, player);
            }
            else
                results = ActionResults.Failed("You can only build new buildings on empty land.");

            return Ok(results);
        }
    }
}
