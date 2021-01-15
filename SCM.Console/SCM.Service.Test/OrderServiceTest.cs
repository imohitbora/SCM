﻿using Domain;
using Moq;
using SCM.Service.IService;
using SCM.Service.Service;
using System.Collections.Generic;
using System.Linq;
using Xunit;

namespace SCM.Service.Test
{
    public class OrderServiceTest
    {
        private readonly Mock<IPromotion> _promotionAMock;
        private readonly Mock<IPromotion> _promotionBMock;
        private readonly Mock<IPromotion> _promotionCMock;
        private readonly IOrderService _orderService;

        public OrderServiceTest()
        {
            _promotionAMock = new Mock<IPromotion>();
            _promotionBMock = new Mock<IPromotion>();
            _promotionCMock = new Mock<IPromotion>();

            IEnumerable<IPromotion> promotions = new List<IPromotion>
            {
                _promotionAMock.Object,
                _promotionBMock.Object,
                _promotionCMock.Object
            };

            _orderService = new OrderService(promotions);
        }

        [Fact]
        public void Test_ApplyPromotion_Scenario1()
        {
            //Arrange
            Order order = GetOrderForScenario1();
            SetupPromotionA();
            SetupPromotionB();
            SetupPromotionCD();

            //Act
            _orderService.ApplyPromotion(order);

            //Assert
            Assert.Equal(100, order.NetAmount);
        }

        private void SetupPromotionA()
        {
            _promotionAMock.Setup(x => x.ApplyPromotion(It.IsAny<Order>())).Callback<Order>((o) =>
            {
                var item = o.LineItems.FirstOrDefault(x => x.Item.SKUId == 'A');

                while (item != null && item.OrderedQty - item.PromotionAppliedQty >= 3)
                {
                    item.PromotionAppliedQty += 3;
                    item.PromotionAmount = 20;
                }
            });
        }

        private void SetupPromotionB()
        {
            _promotionBMock.Setup(x => x.ApplyPromotion(It.IsAny<Order>())).Callback<Order>((o) =>
            {
                var item = o.LineItems.FirstOrDefault(x => x.Item.SKUId == 'B');

                while (item != null && item.OrderedQty - item.PromotionAppliedQty >= 2)
                {
                    item.PromotionAppliedQty += 2;
                    item.PromotionAmount += 15;
                }
            });
        }

        private void SetupPromotionCD()
        {
            _promotionCMock.Setup(x => x.ApplyPromotion(It.IsAny<Order>())).Callback<Order>((o) =>
            {
                var itemC = o.LineItems.FirstOrDefault(x => x.Item.SKUId == 'C');
                var itemD = o.LineItems.FirstOrDefault(x => x.Item.SKUId == 'D');

                while (itemC != null && itemD != null && (itemC.OrderedQty - itemC.PromotionAppliedQty >= 1 &&
                itemD.OrderedQty - itemD.PromotionAppliedQty >= 1))
                {
                    itemC.PromotionAppliedQty += 1;
                    itemD.PromotionAppliedQty += 1;

                    // Store promotion amount in any of item or can be stored in equal half in both products.
                    itemC.PromotionAmount = 5;
                }
            });
        }


        private Order GetOrderForScenario1()
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
