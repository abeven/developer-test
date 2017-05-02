using OrangeBricks.Web.Controllers.Buyer.ViewModels;
using OrangeBricks.Web.Models;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;

namespace OrangeBricks.Web.Controllers.Buyer.Builders
{
    public class BuyerPropertiesViewModelBuilder
    {
        readonly IOrangeBricksContext _context;

        public BuyerPropertiesViewModelBuilder(IOrangeBricksContext context)
        {
            _context = context;
        }

        public BuyerPropertiesViewModel Build(string userId)
        {
            var offers = _context
                .Offers.Where(c => c.BuyerUserId == userId)
                .Include(c => c.Property);
            
            var list = new List<BuyerPropertyViewModel>();

            foreach(var offer in offers)
            {
                list.Add(new ViewModels.BuyerPropertyViewModel
                {
                     HasOffer = true,
                     NumberOfBedrooms = offer.Property.NumberOfBedrooms,
                     StreetName = offer.Property.StreetName,
                     PropertyId = offer.Property.Id,
                     PropertyType = offer.Property.PropertyType,
                     Offer = new ViewModels.BuyerOfferViewModel
                     {
                          Amount = offer.Amount,
                          CreatedAt = offer.CreatedAt,
                          Id = offer.Id,
                          IsPending = offer.Status == OfferStatus.Pending,
                          Status = offer.Status.ToString()
                     }
                });
            }
            return new ViewModels.BuyerPropertiesViewModel
            {
                Properties = list
            };
            /*
            return new BuyerPropertyViewModel
            {
                HasOffer = offers.Any(),
                Offers = offers.Select(x => new OfferViewModel
                {
                    Id = x.Id,
                    Amount = x.Amount,
                    CreatedAt = x.CreatedAt,
                    IsPending = x.Status == OfferStatus.Pending,
                    Status = x.Status.ToString()
                }),
                PropertyId = property.Id,
                PropertyType = property.PropertyType,
                StreetName = property.StreetName,
                NumberOfBedrooms = property.NumberOfBedrooms
            };*/

            return null;
        }
    }
}