using Capitalism.Logic.Models.Buildings;
using Capitalism.Logic.Services;
using Capitalism.SharedKernel;
using Capitalism.Web.Extensions;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace Capitalism.Web.Controllers
{
    [Authorize]
    public class TestController : Controller
    {
        public IActionResult Mine()
        {
            var player = ObjectFactory.Container.GetInstance<GetPlayerService>().GetByUserId(User.Identity.GetId());
            var mine = new Mine();
            mine.Work(player);

            return Ok();
        }

        public IActionResult Forest()
        {
            var player = ObjectFactory.Container.GetInstance<GetPlayerService>().GetByUserId(User.Identity.GetId());
            var forest = new Forest();
            forest.Work(player);

            return Ok();
        }
    }
}