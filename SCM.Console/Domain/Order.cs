using System.Collections.Generic;
using System.Linq;

namespace Domain
{
    public class Order
    {
        public IEnumerable<LineItem> LineItems { get; set; }

        public decimal Total
        {
            get
            {
                return LineItems.Sum(x => x.Price);
            }
        }

        public decimal NetAmount
        {
            get
            {
                return LineItems.Sum(x => x.PriceAfterPromotion);
            }
        }
    }
}
