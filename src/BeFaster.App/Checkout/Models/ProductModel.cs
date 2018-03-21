using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BeFaster.App.Checkout.Models
{
    public class ProductModel
    {
        public string Name { get; set; }
        public int Price { get; set; }
        public List<SpecialOfferModel> SpecialOffers { get; set; }
    }

    public class SpecialOfferModel
    {
        public int? Count { get; set; }
        public int? SpecialPrice { get; set; }
        public string BonusBringerProductName { get; set; }
        public int? BonusBringerProductNumber { get; set; }
    }

    public class GroupDiscount
    {
        public List<string> Participants { get; set; }
        public int Price { get; set; }
        public int Count { get; set; }
    }
}
