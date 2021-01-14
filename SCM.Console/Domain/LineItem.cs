namespace Domain
{
    public class LineItem
    {
        public int Id { get; set; }

        public Item Item { get; set; }

        public int OrderedQty { get; set; }

        public int PromotionQty { get; set; }
    }
}
