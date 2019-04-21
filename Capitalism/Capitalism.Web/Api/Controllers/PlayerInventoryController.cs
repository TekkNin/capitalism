using System.Collections.Generic;
using System.Linq;
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
    public class PlayerInventoryController : ControllerBase
    {
        [HttpGet]
        public IActionResult Get()
        {
            var player = ObjectFactory.Container.GetInstance<GetPlayerService>().GetByUserId(User.Identity.GetId());
            var model = new List<PlayerInventoryListItemModel>();
            model = player.Inventory.Items.Where(item => item.Quantity > 0).Select(item => new PlayerInventoryListItemModel
            {
                ItemType = item.ItemType.ToString(),
                Name = item.ItemType.Name,
                Quantity = item.Quantity
            }).ToList();
            return Ok(model);
        }
    }
}
