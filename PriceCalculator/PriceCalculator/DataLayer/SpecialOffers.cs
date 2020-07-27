using PriceCalculator.App.Entities.SpecialOffers;
using System;
using System.Collections.Generic;

namespace PriceCalculator.App.DataLayer
{
    public class SpecialOffers
    {
        private List<SpecialOfferRule> _specialOffers;
        public SpecialOffers(List<SpecialOfferRule> specialOffers)
        {
            _specialOffers = specialOffers;
        }

        public List<SpecialOfferRule> GetSpecialOfferRules()
        {
            return _specialOffers;
        }
    }
}
