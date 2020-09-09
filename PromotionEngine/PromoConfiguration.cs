using System;
using System.Collections.Generic;
using System.Text;

namespace PromotionEngine
{
    public class PromoConfiguration
    {
        public Dictionary<string, int> SkuDetails;
        public Dictionary<string, int> CartData;
        public List<PromotionModel> Promotions;


        public PromoConfiguration(Dictionary<string, int> cartInfo)
        {
            SkuDetails = new Dictionary<string, int>();
            SkuDetails.Add("A", 50);
            SkuDetails.Add("B", 30);
            SkuDetails.Add("C", 20);
            SkuDetails.Add("D", 15);

            Promotions = new List<PromotionModel>();
            Promotions.Add(new PromotionModel
            {
                Items = new List<ItemModel>
                {
                    new ItemModel
                    {
                        ItemId = "A",
                        Count = 3
                    }
                },
                Value = 130
            });
            Promotions.Add(new PromotionModel
            {
                Items = new List<ItemModel>
                {
                    new ItemModel
                    {
                        ItemId = "B",
                        Count = 2
                    }
                },
                Value = 45
            });
            Promotions.Add(new PromotionModel
            {
                Items = new List<ItemModel>
                {
                    new ItemModel
                    {
                        ItemId = "C",
                        Count = 1
                    },
                    new ItemModel
                    {
                        ItemId = "D",
                        Count = 1
                    }
                },
                Value = 30
            });

            CartData = new Dictionary<string, int>();
            foreach (KeyValuePair<string, int> keyValue in cartInfo)
            {
                if (SkuDetails.ContainsKey(keyValue.Key))
                {
                    CartData.Add(keyValue.Key, keyValue.Value);
                }
            }
        }
    }
}
