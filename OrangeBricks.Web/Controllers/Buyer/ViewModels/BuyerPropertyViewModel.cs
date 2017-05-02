using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace OrangeBricks.Web.Controllers.Buyer.ViewModels
{
    public class BuyerPropertiesViewModel
    {
        public List<BuyerPropertyViewModel> Properties { get; set; }
    }

    public class BuyerPropertyViewModel
    {
        public string PropertyType { get; set; }
        public int NumberOfBedrooms { get; set; }
        public string StreetName { get; set; }
        public int PropertyId { get; set; }
        public BuyerOfferViewModel Offer { get; set; }
        public bool HasOffer { get; set; }
    }

    public class BuyerOfferViewModel
    {
        public int Id;
        public int Amount { get; set; }
        public DateTime CreatedAt { get; set; }
        public bool IsPending { get; set; }
        public string Status { get; set; }
    }
    
}