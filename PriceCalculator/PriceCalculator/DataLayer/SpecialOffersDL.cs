using PriceCalculator.App.Entities.SpecialOffers;
using System.Collections.Generic;

namespace PriceCalculator.App.DataLayer
{
    public class SpecialOffersDL
    {
        private List<SpecialOfferRule> _specialOffers;
        public SpecialOffersDL(List<SpecialOfferRule> specialOffers)
        {
            _specialOffers = specialOffers;
        }

        public List<SpecialOfferRule> GetSpecialOfferRules()
        {
            return _specialOffers;
        }
    }
}
