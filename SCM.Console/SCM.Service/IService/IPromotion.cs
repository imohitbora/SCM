using Domain;

namespace SCM.Service.IService
{
    public interface IPromotion
    {
        void ApplyPromotion(Order order);

        int Priority { get; }        
    }
}
