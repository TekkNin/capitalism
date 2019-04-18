using Capitalism.Logic.Models.Buildings;
using Capitalism.Logic.Services;
using Capitalism.Logic.Types;
using Capitalism.SharedKernel;
using Capitalism.Web.Api.Models;
using Capitalism.Web.Extensions;
using Microsoft.AspNetCore.Mvc;

namespace Capitalism.Web.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class WorkController : ControllerBase
    {
        [HttpPost]
        public IActionResult Post([FromBody] WorkPostModel model)
        {
            var workResult = WorkResult.Empty;
            var player = ObjectFactory.Container.GetInstance<GetPlayerService>().GetByUserId(User.Identity.GetId());
            switch (model.BuildingId)
            {
                case "mines":
                    var mine = new Mine();
                    workResult = mine.Work(player);
                    break;
                case "forest":
                    var forest = new Forest();
                    workResult = forest.Work(player);
                    break;
            }


            return Ok(workResult);
        }

    }
}
