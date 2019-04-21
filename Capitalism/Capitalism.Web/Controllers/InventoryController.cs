using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace Capitalism.Web.Controllers
{
    [Authorize]
    public class InventoryController : Controller
    {
        [Route("play/inventory")]
        public IActionResult Index()
        {
            return View();
        }
    }
}