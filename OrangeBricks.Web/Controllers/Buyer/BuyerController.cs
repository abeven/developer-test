using Microsoft.AspNet.Identity;
using OrangeBricks.Web.Attributes;
using OrangeBricks.Web.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace OrangeBricks.Web.Controllers.Buyer
{

    [OrangeBricksAuthorize(Roles = "Buyer")]
    public class BuyerController : Controller
    {
        private readonly IOrangeBricksContext _context;

        public BuyerController(IOrangeBricksContext context)
        {
            _context = context;
        }
        
        public ActionResult MyProperties()
        {
            var builder = new Builders.BuyerPropertiesViewModelBuilder(_context);
            var viewModel = builder.Build(User.Identity.GetUserId());
            return View(viewModel);
        }
    }
}