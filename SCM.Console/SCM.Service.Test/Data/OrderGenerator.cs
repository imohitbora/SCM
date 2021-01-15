using Domain;
using System.Collections.Generic;

namespace SCM.Service.Test.Data
{
    public static class OrderGenerator
    {
        public static Order GetOrderForScenario1()
        {
            var lineItemA = GetLineItemA();
            var lineItemC = GetLineItemC();
            var lineItemB = GetLineItemB();

            lineItemA.OrderedQty = 1;
            lineItemB.OrderedQty = 1;
            lineItemC.OrderedQty = 1;

            return new Order
            {
                LineItems = new List<LineItem>
                {
                    lineItemA,
                    lineItemC,
                    lineItemB
                }
            };
        }

        public static Order GetOrderForScenario2()
        {
            var lineItemA = GetLineItemA();
            var lineItemC = GetLineItemC();
            var lineItemB = GetLineItemB();

            lineItemA.OrderedQty = 5;
            lineItemB.OrderedQty = 5;
            lineItemC.OrderedQty = 1;

            return new Order
            {
                LineItems = new List<LineItem>
                {
                    lineItemA,
                    lineItemC,
                    lineItemB
                }
            };
        }

        public static Order GetOrderForScenario3()
        {
            var lineItemA = GetLineItemA();
            var lineItemC = GetLineItemC();
            var lineItemD = GetLineItemD();
            var lineItemB = GetLineItemB();

            lineItemA.OrderedQty = 3;
            lineItemB.OrderedQty = 5;
            lineItemC.OrderedQty = 1;
            lineItemD.OrderedQty = 1;

            return new Order
            {
                LineItems = new List<LineItem>
                {
                    lineItemA,
                    lineItemC,
                    lineItemB,
                    lineItemD
                }
            };
        }

        private static LineItem GetLineItemA()
        {
            return new LineItem
            {
                Id = 1,
                Item = new Item
                {
                    Id = 1,
                    Price = 50,
                    SKUId = 'A'
                },
                OrderedQty = 3,
            };
        }

        private static LineItem GetLineItemC()
        {
            return new LineItem
            {
                Id = 2,
                Item = new Item
                {
                    Id = 2,
                    Price = 20,
                    SKUId = 'C'
                },
                OrderedQty = 1,
            };
        }

        private static LineItem GetLineItemD()
        {
            return new LineItem
            {
                Id = 3,
                Item = new Item
                {
                    Id = 3,
                    Price = 15,
                    SKUId = 'D'
                },
                OrderedQty = 1,
            };
        }

        private static LineItem GetLineItemB()
        {
            return new LineItem
            {
                Id = 4,
                Item = new Item
                {
                    Id = 4,
                    Price = 30,
                    SKUId = 'B'
                },
                OrderedQty = 1,
            };
        }
    }
}
