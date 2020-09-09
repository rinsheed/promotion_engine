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




        }
    }
}