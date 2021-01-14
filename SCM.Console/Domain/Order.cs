using System.Collections.Generic;

namespace Domain
{
    public class Order
    {
        public ICollection<LineItem> Items { get; set; }

        public int Total { get; set; }
    }
}
