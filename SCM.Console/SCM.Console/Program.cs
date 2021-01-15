using Domain;
using Ninject;
using SCM.Service.IService;
using SCM.Service.Service;

namespace SCM.ConsoleApp
{
    public class Program
    {
        private static IKernel kernel;
        private static IOrderService _orderService;

        public static void Main(string[] args)
        {
            RegisterDependency();

            _orderService = kernel.Get<IOrderService>();
            Order order = OrderFactory.GetOrder();
            _orderService.ApplyPromotion(order);
        }

        private static void RegisterDependency()
        {
            kernel = new StandardKernel();
            kernel.Bind<IPromotion>().To<PromotionA>();
            kernel.Bind<IPromotion>().To<PromotionCandD>();
            kernel.Bind<IPromotion>().To<PromotionB>();


            kernel.Bind<IOrderService>().To<OrderService>();
        }
    }
}
