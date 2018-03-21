using BeFaster.App.Checkout.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BeFaster.App.Checkout.Services
{
    public class CheckoutService
    {
        public int ProcessBasket(string basketContents)
        {
            //check for empty basket
            if (string.IsNullOrEmpty(basketContents))
                return 0;

            Dictionary<string, int> products = basketContents.GroupBy(p => p).OrderBy(p => p.Key).ToDictionary(p => p.Key.ToString(), p => p.Count());
            Dictionary<string, int> reversedProducts = basketContents.GroupBy(p => p).OrderByDescending(p => p.Key).ToDictionary(p => p.Key.ToString(), p => p.Count());

            int groupDiscountsValue = ApplyGroupDiscounts(products);

            int productsValue = groupDiscountsValue + GetProductsValue(products);
            int reversedProductsValue = groupDiscountsValue + GetProductsValue(reversedProducts);

            return Math.Min(productsValue, reversedProductsValue);
        }

        private int ApplyGroupDiscounts(Dictionary<string, int> basketProducts)
        {
            int discountsPrice = 0;

            foreach (GroupDiscount disc in ProductTable.GroupDiscounts)
            {
                Dictionary<string, int> basketGroupDiscountProducts = basketProducts.Where(p => disc.Participants.Contains(p.Key)).ToDictionary(p => p.Key, p => p.Value);

                if (basketGroupDiscountProducts == null || basketGroupDiscountProducts.Count == 0)
                    return 0;

                int totalNoDiscountedProdsInBasket = basketGroupDiscountProducts.Sum(p => p.Value);
                int noOfOffers = totalNoDiscountedProdsInBasket / disc.Count;
                int discountedProds = noOfOffers * disc.Count;

                if (noOfOffers == 0)
                    return 0;

                foreach (string participatingProduct in disc.Participants)
                {
                    if (discountedProds == 0)
                        break;

                    if (basketProducts.ContainsKey(participatingProduct))
                        if (discountedProds > basketProducts[participatingProduct])
                        {
                            discountedProds -= basketProducts[participatingProduct];
                            basketProducts[participatingProduct] = 0;
                        }
                        else
                        {
                            basketProducts[participatingProduct] -= discountedProds;
                            discountedProds = 0;
                        }
                }

                discountsPrice += noOfOffers * disc.Price;
            }

            return discountsPrice;
        }

        private int GetProductsValue(Dictionary<string, int> basketProducts)
        {
            int basketValue = 0;

            foreach (KeyValuePair<string, int> prod in basketProducts)
            {
                int prodVal = GetProductValue(prod.Key, prod.Value, basketProducts);

                //check for invalid basket
                if (prodVal == -1)
                {
                    return -1;
                }

                basketValue += prodVal;
            }

            return basketValue;
        }

        private int GetProductValue(string productName, int count, Dictionary<string, int> basketProducts)
        {
            if (string.IsNullOrEmpty(productName) || count == 0)
                return 0;

            //check for invalid basket
            if (!ProductTable.Products.ContainsKey(productName))
                return -1;

            ProductModel product = ProductTable.Products[productName];

            //check for invalid basket
            if (product == null)
                return -1;

            int productValue = 0;
            int productCount = count;

            if (product.SpecialOffers != null && product.SpecialOffers.Count > 0)
            {
                foreach (SpecialOfferModel specialOffer in product.SpecialOffers)
                {
                    //ckeck buy product x get product y promotions
                    if (!string.IsNullOrEmpty(specialOffer.BonusBringerProductName) && specialOffer.BonusBringerProductNumber.HasValue)
                    {
                        if (!basketProducts.ContainsKey(specialOffer.BonusBringerProductName))
                            continue;

                        int bonusBringerProductInBasket = basketProducts[specialOffer.BonusBringerProductName];
                        int discountedProducts = bonusBringerProductInBasket / specialOffer.BonusBringerProductNumber.Value;

                        if (discountedProducts > productCount)
                            return productValue;


                        productCount -= discountedProducts;
                    }

                    //check buy x number products for y sum promotions
                    else if (specialOffer.Count.HasValue && specialOffer.SpecialPrice.HasValue)
                    {
                        int noOfOffers = productCount / specialOffer.Count.Value;

                        if (noOfOffers > 0)
                        {
                            //add special offers value
                            productValue += noOfOffers * specialOffer.SpecialPrice.Value;
                            //subtract special offer items
                            productCount -= noOfOffers * specialOffer.Count.Value;
                        }
                    }
                }
            }

            productValue += productCount * product.Price;

            return productValue;
        }
    }
}
