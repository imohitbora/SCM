using Domain;
using System.Collections.Generic;

namespace SCM.Console
{
    public static class OrderFactory
    {
        public static Order GetOrder()
        {
            return new Order
            {
                LineItems = new List<LineItem>
                {
                    new LineItem
                    {
                        Id = 1,
                        Item = new Item
                        {
                            Id = 1,
                            Price = 50,
                            SKUId = 'A'
                        },
                        OrderedQty = 5,                        
                    }
                }
            };
        }
    }
}
