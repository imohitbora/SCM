using Ninject;
using SCM.Service.IService;
using SCM.Service.Service;

namespace SCM.Console
{
    public class Program
    {
        private static IKernel kernel;
        private static IOrderService _orderService;

        static void Main(string[] args)
        {
            RegisterDependency();
            _orderService = kernel.Get<IOrderService>();

            var order = OrderFactory.GetOrder();

            _orderService.ApplyPromotion(order);
        }
        
        private static void RegisterDependency()
        {
            kernel = new StandardKernel();
            kernel.Bind<IPromotion>().To<PromotionA>();
            kernel.Bind<IOrderService>().To<OrderService>();
        }

        
    }
}
