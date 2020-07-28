using Microsoft.VisualStudio.TestTools.UnitTesting;
using NuGet.Frameworks;
using PriceCalculator.App;
using PriceCalculator.App.App;
using PriceCalculator.App.Entities.Basket;
using PriceCalculator.App.Entities.Product;
using PriceCalculator.App.Entities.SpecialOffers;
using PriceCalculator.App.Exceptions;
using PriceCalculator.App.Interfaces;
using System;

namespace PriceCalculator.Test
{
    [TestClass]
    public class SpecialOfferRuleTest
    {
        [TestMethod]
        public void CheckSpecialOfferMatchRule_NullArgumentException()
        {
            try
            {
                SpecialOfferRule specialOfferRule = new SpecialOfferRule(
                    new SpecialOfferMatchRule(null, 1),
                    new SpecialOfferDiscountRule(new Product(1,"dummy",0.2m),1));
                Assert.Fail("This should throw null exception");
            }
            catch (ArgumentNullException ex)
            {
                Assert.IsTrue(ex.ParamName == "product");
            }
        }

        [TestMethod]
        public void CheckSpecialOfferDiscountRule_NullArgumentException()
        {
            try
            {
                SpecialOfferRule specialOfferRule = new SpecialOfferRule(
                    new SpecialOfferMatchRule(new Product(1, "dummy", 0.2m), 1),
                    new SpecialOfferDiscountRule(null, 1));
                Assert.Fail("This should throw null exception");
            }
            catch (ArgumentNullException ex)
            {
                Assert.IsTrue(ex.ParamName == "product");
            }
        }
    }
}
