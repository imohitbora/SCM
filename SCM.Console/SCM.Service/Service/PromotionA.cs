using Domain;
using SCM.Service.IService;
using System;
using System.Collections.Generic;

namespace SCM.Service.Service
{
    public class PromotionA : IPromotionService
    {
        public void ApplyPromotion(ICollection<LineItem> items)
        {
            while(IsApplicable(items))
            {

            }
        }

        public bool IsApplicable(ICollection<LineItem> items)
        {
            return false;
        }
    }
}
