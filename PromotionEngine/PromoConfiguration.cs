using System;
using System.Collections.Generic;
using System.Text;

namespace PromotionEngine
{
    public class PromoConfiguration
    {
        private Dictionary<string, int> SkuDetails;
        private List<PromotionModel> Promotions;
        private Dictionary<string, int> CartData;

        // Constructor - Initializes the class variables
        public PromoConfiguration(Dictionary<string, int> cartInfo)
        {
            // Add the actual value of SKU.
            SkuDetails = new Dictionary<string, int>();
            SkuDetails.Add("A", 50);
            SkuDetails.Add("B", 30);
            SkuDetails.Add("C", 20);
            SkuDetails.Add("D", 15);

            Promotions = new List<PromotionModel>();

            //Promotion: 3 A's => 130
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

            //Promotion: 2 B's => 45
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

            //Promotion: 1 C & 1 D => 30
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

        // Function to calculate the total value of the SKU in the cart.
        public long CalculateTotal()
        {
            long total = 0;

            try
            {
                // Loop to apply the promotions, if any
                foreach (PromotionModel promo in Promotions)
                {
                    bool applyPromo = true;

                    int promoMultiples = 0;

                    //Loop to verify the promotion & find the least multiple of promotions need to apply.
                    foreach (ItemModel item in promo.Items)
                    {
                        if (CartData.ContainsKey(item.ItemId) && CartData[item.ItemId] >= item.Count)
                            promoMultiples = promoMultiples == 0 || promoMultiples > CartData[item.ItemId] / item.Count ? CartData[item.ItemId] / item.Count : promoMultiples;
                        else
                            applyPromo = false;
                    }
                    if (applyPromo)
                    {
                        //Remove the units from the cart on which the promotion is applied
                        foreach (ItemModel item in promo.Items)
                        {
                            if (CartData.ContainsKey(item.ItemId))
                                CartData[item.ItemId] = CartData[item.ItemId] - (promoMultiples * item.Count);
                        }
                        //Calculate the total cart value after applying the promotion
                        total += Convert.ToInt64(promoMultiples) * Convert.ToInt64(promo.Value);
                    }
                }

                // Calculate cart value for items that doesn't apply promotions
                foreach (KeyValuePair<string, int> keyValue in CartData)
                {
                    total += keyValue.Value > 0 ? Convert.ToInt64(SkuDetails[keyValue.Key]) * Convert.ToInt64(keyValue.Value) : 0;
                }
            }
            catch
            {
                total = -1;
            }

            return total;
        }

    }
}
