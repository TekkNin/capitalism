using Capitalism.Logic.Models.Buildings;
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
    public class EmptyLandController : ControllerBase
    {
        [HttpGet]
        [Route("api/building/emptyland/{id}")]
        public IActionResult Get(string id)
        {
            var player = ObjectFactory.Container.GetInstance<GetPlayerService>().GetByUserId(User.Identity.GetId());
            var emptyLand = (EmptyLand)ObjectFactory.Container.GetInstance<GetBuildingService>().GetBuildingByTownIdBuildingId(player.CurrentTown, id);

            var model = new EmptyLandGetModel
            {
                IsForSale = emptyLand.IsForSale,
                IsOwner = emptyLand.OwnerId == player.Id,
                Price = emptyLand.Price
            };
            return Ok(model);
        }
    }
}