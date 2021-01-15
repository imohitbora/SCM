using Domain;
using SCM.Service.IService;
using System.Linq;

namespace SCM.Service.Service
{
    public class PromotionA : IPromotion
    {
        public void ApplyPromotion(Order order)
        {
            if (order == null) return;

            LineItem lineItem = order.LineItems.FirstOrDefault(x => x.Item.SKUId == 'A');

            while (true)
            {
                if (!IsApplicable(lineItem))
                {
                    break;
                }

                lineItem.PromotionAppliedQty += 3;
                lineItem.PromotionAmount = 20;
            }
        }

        public bool IsApplicable(LineItem item)
        {
            return item != null && item.OrderedQty - item.PromotionAppliedQty >= 3;
        }

        public int Priority
        {
            get
            {
                return 1;
            }
        }
    }
}
