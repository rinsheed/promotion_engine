using NUnit.Framework;
using PromotionEngine;
using System.Collections.Generic;

namespace PromotionEngineTest
{
    public class PromoConfigurationTest
    {
        [SetUp]
        public void Setup()
        {
        }

        [Test]
        public void AcceptanceTest()
        {
            Dictionary<string, int> cartData = new Dictionary<string, int>();

            // If no values added
            PromoConfiguration promo = new PromoConfiguration(cartData);
            Assert.IsTrue(promo.CalculateTotal() == 0);

            // Case 1: A - 1, B - 1, C - 1. Expected result 100.
            cartData.Add("A", 1);
            cartData.Add("B", 1);
            cartData.Add("C", 1);
            promo = new PromoConfiguration(cartData);
            Assert.IsTrue(promo.CalculateTotal() == 100);

            // Case 1: A - 5, B - 5, C - 1. Expected result 370.
            cartData.Clear();
            cartData.Add("A", 5);
            cartData.Add("B", 5);
            cartData.Add("C", 1);
            promo = new PromoConfiguration(cartData);
            Assert.IsTrue(promo.CalculateTotal() == 370);

            // Case 1: A - 5, B - 5, C - 1. Expected result 280.
            cartData.Clear();
            cartData.Add("A", 3);
            cartData.Add("B", 5);
            cartData.Add("C", 1);
            cartData.Add("D", 1);
            promo = new PromoConfiguration(cartData);
            Assert.IsTrue(promo.CalculateTotal() == 280);
        }

        [Test]
        public void RejectionTest()
        {
            Dictionary<string, int> cartData = new Dictionary<string, int>();
            
            // Invalid SKU - 'F'. Expected result 0.
            cartData.Add("F", 1);
            PromoConfiguration promo = new PromoConfiguration(cartData);
            Assert.IsTrue(promo.CalculateTotal() == 0);

            // Invalid & Valid SKU's: F - 1, B - 2, C - 1. Expected result 75.
            cartData.Clear();
            cartData.Add("F", 1);
            cartData.Add("B", 2);
            cartData.Add("C", 1);
            promo = new PromoConfiguration(cartData);
            Assert.IsTrue(promo.CalculateTotal() == 65);

            // Applying max limit of Int32 in 'A'.
            cartData.Clear();
            cartData.Add("A", 2147483647);
            promo = new PromoConfiguration(cartData);
            Assert.IsTrue(promo.CalculateTotal() == 93057624710);

            // Applying max limit of Int32 in 'B'.
            cartData.Clear();
            cartData.Add("B", 2147483647);
            promo = new PromoConfiguration(cartData);
            Assert.IsTrue(promo.CalculateTotal() == 48318382065);

            // Applying max limit of Int32 in 'C' & 'D'.
            cartData.Clear();
            cartData.Add("C", 2147483647);
            cartData.Add("D", 2147483647);
            promo = new PromoConfiguration(cartData);
            Assert.IsTrue(promo.CalculateTotal() == 64424509410);

            // Applying max limit of Int32 in SKU.
            cartData.Clear();
            cartData.Add("A", 2147483647);
            cartData.Add("B", 2147483647);
            cartData.Add("C", 2147483647);
            cartData.Add("D", 2147483647);
            promo = new PromoConfiguration(cartData);
            Assert.IsTrue(promo.CalculateTotal() == 205800516185);
        }
    }
}