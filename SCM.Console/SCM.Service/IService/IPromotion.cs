using Domain;

namespace SCM.Service.IService
{
    public interface IPromotion
    {
        void ApplyPromotion(Order items);

        int Priority { get; }        
    }
}
