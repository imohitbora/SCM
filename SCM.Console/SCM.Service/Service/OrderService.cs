using Domain;
using SCM.Service.IService;
using System.Collections.Generic;

namespace SCM.Service.Service
{
    public class OrderService : IOrderService
    {
        private readonly IEnumerable<IPromotionService> _promotions;

        public OrderService(IEnumerable<IPromotionService> promotions)
        {
            _promotions = promotions;
        }

        public void PlaceOrder(Order order)
        {
           
        }
    }
}
