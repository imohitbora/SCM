namespace Domain
{
    public class LineItem
    {
        public int Id { get; set; }

        public Item Item { get; set; }

        public int OrderedQty { get; set; }

        public int PromotionAppliedQty { get; set; }

        public decimal PromountAmount { get; set; }

        public decimal Amount => OrderedQty * Item.Price - PromountAmount;
    }
}
