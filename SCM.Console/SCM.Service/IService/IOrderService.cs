using Domain;

namespace SCM.Service.IService
{
    public interface IOrderService
    {
        void ApplyPromotion(Order order);
    }
}
