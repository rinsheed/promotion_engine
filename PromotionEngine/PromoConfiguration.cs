using System;
using System.Collections.Generic;
using System.Text;

namespace PromotionEngine
{
    public class PromoConfiguration
    {
        private Dictionary<string, int> SkuDetails;
        private Dictionary<string, int> CartData;
        private List<PromotionModel> Promotions;

        // Constructor - Initializes the class variables
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

        public int CalculateTotal()
        {
            int total = 0;

            foreach (KeyValuePair<string, int> keyValue in CartData)
            {
                total += keyValue.Value > 0 ? SkuDetails[keyValue.Key] * keyValue.Value : 0;
            }

            return total;
        }

    }
}
