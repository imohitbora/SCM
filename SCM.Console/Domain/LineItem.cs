namespace Domain
{
    public class LineItem
    {
        public int Id { get; set; }

        public Item Item { get; set; }

        public int OrderedQty { get; set; }

        public int PromotionAppliedQty { get; set; }

        public decimal PromotionAmount { get; set; }

        public decimal Price => OrderedQty * Item.Price;

        public decimal PriceAfterPromotion => OrderedQty * Item.Price - PromotionAmount;
    }
}
