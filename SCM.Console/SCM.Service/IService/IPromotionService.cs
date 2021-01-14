using Domain;
using System.Collections.Generic;

namespace SCM.Service.IService
{
    public interface IPromotionService
    {
        void ApplyPromotion(ICollection<LineItem> items);
    }
}
