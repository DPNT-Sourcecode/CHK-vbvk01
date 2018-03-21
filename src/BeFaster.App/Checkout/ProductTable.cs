using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BeFaster.App.Checkout.Models;

namespace BeFaster.App.Checkout
{
    public static class ProductTable
    {
        public static Dictionary<string, ProductModel> Products
        {
            get
            {
                if (products == null)
                {
                    products = new Dictionary<string, ProductModel>();

                    products.Add("A", new ProductModel()
                    {
                        Name = "A",
                        Price = 50,
                        SpecialOffers = new List<SpecialOfferModel>() {
                            new SpecialOfferModel() { Count = 5, SpecialPrice = 200 },
                            new SpecialOfferModel() { Count = 3, SpecialPrice = 130 } }
                    });
                    products.Add("B", new ProductModel()
                    {
                        Name = "B",
                        Price = 30,
                        SpecialOffers = new List<SpecialOfferModel>() {
                            new SpecialOfferModel() { BonusBringerProductName = "E", BonusBringerProductNumber = 2 },
                            new SpecialOfferModel() { Count = 2, SpecialPrice = 45 } }
                    });
                    products.Add("C", new ProductModel() { Name = "C", Price = 20, SpecialOffers = null });
                    products.Add("D", new ProductModel() { Name = "D", Price = 15, SpecialOffers = null });
                    products.Add("E", new ProductModel() { Name = "E", Price = 40, SpecialOffers = null });
                    products.Add("F", new ProductModel()
                    {
                        Name = "F",
                        Price = 10,
                        SpecialOffers = new List<SpecialOfferModel>() {
                            new SpecialOfferModel() { BonusBringerProductName = "F", BonusBringerProductNumber = 3 } }
                    });
                    products.Add("G", new ProductModel() { Name = "G", Price = 20, SpecialOffers = null });
                    products.Add("H", new ProductModel()
                    {
                        Name = "H",
                        Price = 10,
                        SpecialOffers = new List<SpecialOfferModel>() {
                            new SpecialOfferModel() { Count = 10, SpecialPrice = 80 },
                            new SpecialOfferModel() { Count = 5, SpecialPrice = 45 } }
                    });
                    products.Add("I", new ProductModel() { Name = "I", Price = 35, SpecialOffers = null });
                    products.Add("J", new ProductModel() { Name = "J", Price = 60, SpecialOffers = null });
                    products.Add("K", new ProductModel()
                    {
                        Name = "K",
                        Price = 70,
                        SpecialOffers = new List<SpecialOfferModel>() {
                            new SpecialOfferModel() { Count = 2, SpecialPrice = 120 } }
                    });
                    products.Add("L", new ProductModel() { Name = "L", Price = 90, SpecialOffers = null });
                    products.Add("M", new ProductModel()
                    {
                        Name = "M",
                        Price = 15,
                        SpecialOffers = new List<SpecialOfferModel>() {
                            new SpecialOfferModel() { BonusBringerProductName = "N", BonusBringerProductNumber = 3 } }
                    });
                    products.Add("N", new ProductModel() { Name = "N", Price = 40, SpecialOffers = null });
                    products.Add("O", new ProductModel() { Name = "O", Price = 10, SpecialOffers = null });
                    products.Add("P", new ProductModel()
                    {
                        Name = "P",
                        Price = 50,
                        SpecialOffers = new List<SpecialOfferModel>() {
                            new SpecialOfferModel() { Count = 5, SpecialPrice = 200 } }
                    });
                    products.Add("Q", new ProductModel()
                    {
                        Name = "Q",
                        Price = 30,
                        SpecialOffers = new List<SpecialOfferModel>() {
                            new SpecialOfferModel() { BonusBringerProductName = "R", BonusBringerProductNumber = 3 },
                            new SpecialOfferModel() { Count = 3, SpecialPrice = 80 } }
                    });
                    products.Add("R", new ProductModel() { Name = "R", Price = 50, SpecialOffers = null });
                    products.Add("S", new ProductModel() { Name = "S", Price = 20, SpecialOffers = null });
                    products.Add("T", new ProductModel() { Name = "T", Price = 20, SpecialOffers = null });
                    products.Add("U", new ProductModel()
                    {
                        Name = "U",
                        Price = 40,
                        SpecialOffers = new List<SpecialOfferModel>() {
                            new SpecialOfferModel() { BonusBringerProductName = "U", BonusBringerProductNumber = 4 } }
                    });
                    products.Add("V", new ProductModel()
                    {
                        Name = "V",
                        Price = 50,
                        SpecialOffers = new List<SpecialOfferModel>() {
                            new SpecialOfferModel() { Count = 3, SpecialPrice = 130 },
                            new SpecialOfferModel() { Count = 2, SpecialPrice = 90 } }
                    });
                    products.Add("W", new ProductModel() { Name = "W", Price = 20, SpecialOffers = null });
                    products.Add("X", new ProductModel() { Name = "X", Price = 17, SpecialOffers = null });
                    products.Add("Y", new ProductModel() { Name = "Y", Price = 20, SpecialOffers = null });
                    products.Add("Z", new ProductModel() { Name = "Z", Price = 21, SpecialOffers = null });
                }

                return products;
            }
        }

        private static Dictionary<string, ProductModel> products;

        public static List<GroupDiscount> GroupDiscounts
        {
            get
            {
                if (groupDiscounts == null)
                {
                    groupDiscounts = new List<GroupDiscount>();

                    groupDiscounts.Add(new GroupDiscount() { Participants = new List<string>() { "Z", "Y", "S", "T", "X" }, Price = 45, Count = 3 });
                }

                return groupDiscounts;
            }
        }
        private static List<GroupDiscount> groupDiscounts;
    }
}
