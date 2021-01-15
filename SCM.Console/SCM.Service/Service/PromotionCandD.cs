using Domain;
using SCM.Service.IService;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SCM.Service.Service
{
    public class PromotionCandD : IPromotion
    {
        public int Priority => 2;

        public void ApplyPromotion(Order order)
        {
            if (order == null) return;

            LineItem lineItemC = order.LineItems.FirstOrDefault(x => x.Item.SKUId == 'C');
            LineItem lineItemD = order.LineItems.FirstOrDefault(x => x.Item.SKUId == 'D');

            while (true)
            {
                if (!IsApplicable(lineItemC, lineItemD))
                {
                    break;
                }

                lineItemC.PromotionAppliedQty += 1;
                lineItemD.PromotionAppliedQty += 1;

                // Store promotion amount in any of item or can be stored in equal half in both products.
                lineItemC.PromotionAmount = 5;
            }
        }

        private bool IsApplicable(LineItem lineItemC, LineItem lineItemD)
        {
            if (lineItemD == null || lineItemC == null) return false;

            return lineItemC.OrderedQty - lineItemC.PromotionAppliedQty >= 1 &&
                lineItemD.OrderedQty - lineItemD.PromotionAppliedQty >= 1;
        }
    }
}
