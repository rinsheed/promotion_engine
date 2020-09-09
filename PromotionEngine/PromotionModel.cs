using System.Collections.Generic;

namespace PromotionEngine
{
    public class PromotionModel
    {
        public List<ItemModel> Items { get; set; }
        public int Value { get; set; }
    }
    public class ItemModel
    {
        public string ItemId { get; set; }
        public int Count { get; set; }
    }
}
