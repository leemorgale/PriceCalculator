using PriceCalculator.App.DataLayer;
using PriceCalculator.App.Entities.Basket;
using PriceCalculator.App.Entities.SpecialOffers;
using System;
using System.Collections.Generic;
using PriceCalculator.App.Interfaces;

namespace PriceCalculator.App.App
{
    public class BasketCalculator : IBasketCalculator
    {
        private readonly SpecialOffers _specialOffers;
        public BasketCalculator(SpecialOffers specialOffers)
        {
            _specialOffers = specialOffers;
        }

        public ShoppingBasketPrice CalculatePrice(ShoppingBasket shoppingBasket)
        {
            // apply special offers to basket
            var appliedSpecialOffers = new List<SpecialOfferApplied>();
            var discountAmount = 0.0m;
            foreach (var specialOffer in _specialOffers.GetSpecialOfferRules())
            {
                // calculate discount from special offer
                var specialOfferDiscount = GetDiscountedAmount(specialOffer, shoppingBasket);
                if (discountAmount > 0)
                {
                    discountAmount += specialOfferDiscount;
                    appliedSpecialOffers.Add(new SpecialOfferApplied(specialOffer, discountAmount));
                }
            }

            decimal subtotal = shoppingBasket.GetBasketPrice();
            decimal total = subtotal - discountAmount;
            return new ShoppingBasketPrice(subtotal, total, appliedSpecialOffers);
        }

        public decimal GetDiscountedAmount(SpecialOfferRule specialOfferRule, ShoppingBasket shoppingBasket)
        {
            // SpecialOfferRule product not matched basket
            int specialOfferRuleMatchCount = shoppingBasket.GetItemCountById(specialOfferRule.SpecialOfferMatchRule.Product.Id) / specialOfferRule.SpecialOfferMatchRule.MinimumQuantity;
            if (specialOfferRuleMatchCount == 0)
            {
                return 0m;
            }

            // SpecialOfferDiscount product not found in basket
            int discountedItemCount = shoppingBasket.GetItemCountById(specialOfferRule.SpecialOfferDiscountRule.Product.Id);
            if (discountedItemCount == 0)
            {
                return 0m;
            }

            // if there is a maximum limit on discountCount 
            int discountAppliedCount = Math.Min(specialOfferRuleMatchCount, discountedItemCount);
            if (specialOfferRule.SpecialOfferDiscountRule.MaximumQuantity.HasValue)
            {
                discountAppliedCount = discountedItemCount % specialOfferRule.SpecialOfferDiscountRule.MaximumQuantity.Value;
            }

            // calculate the discount based on the basket items
            decimal percentageDiscount = specialOfferRule.SpecialOfferDiscountRule.DiscountPercent / 100;
            return specialOfferRule.SpecialOfferDiscountRule.Product.Price * percentageDiscount * discountAppliedCount;
        }
    }
}
