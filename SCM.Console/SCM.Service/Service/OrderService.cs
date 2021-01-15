using Domain;
using SCM.Service.IService;
using System.Collections.Generic;
using System.Linq;

namespace SCM.Service.Service
{
    public class OrderService : IOrderService
    {
        private readonly IEnumerable<IPromotion> _promotions;

        public OrderService(IEnumerable<IPromotion> promotions)
        {
            _promotions = promotions;
        }

        public void ApplyPromotion(Order order)
        {
            foreach (IPromotion promotion in _promotions.OrderBy(x => x.Priority))
            {
                promotion.ApplyPromotion(order);
            }
        }
    }
}
