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
    public class PlayerStatsController : ControllerBase
    {
        [HttpGet]
        public IActionResult Get()
        {
            var player = ObjectFactory.Container.GetInstance<GetPlayerService>().GetByUserId(User.Identity.GetId());
            var model = new PlayerStatsGetModel
            {
                Id  = player.Id,
                Health = player.Health,
                Energy = player.Energy,
                Happiness = player.Happiness,
                Swagger = player.Swagger,
                MoneyOnHand = player.MoneyOnHand
            };
            return Ok(model);
        }

    }
}
