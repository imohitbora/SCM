using Moq;
using SCM.Service.IService;
using Xunit;

namespace SCM.Service.Test
{
    public class OrderServiceTest
    {
        private readonly Mock<IPromotion> _promotionMock;

        public OrderServiceTest()
        {
            _promotionMock = new Mock<IPromotion>();
        }

        [Fact]
        public void Test()
        {

        }
    }
}
