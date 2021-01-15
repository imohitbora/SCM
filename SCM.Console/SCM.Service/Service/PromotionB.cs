using Domain;
using SCM.Service.IService;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SCM.Service.Service
{
    public class PromotionB : IPromotion
    {
        public int Priority => 1;

        public void ApplyPromotion(Order order)
        {
            if (order == null) return;

            LineItem lineItem = order.LineItems.FirstOrDefault(x => x.Item.SKUId == 'B');

            while (IsApplicable(lineItem))
            {
                lineItem.PromotionAppliedQty += 2;
                lineItem.PromotionAmount = 15;
            }
        }

        private bool IsApplicable(LineItem item)
        {
            return item != null && item.OrderedQty - item.PromotionAppliedQty >= 2;
        }
    }
}
