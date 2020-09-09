using NUnit.Framework;
using PromotionEngine;
using System.Collections.Generic;

namespace PromotionEngineTest
{
    public class Tests
    {
        [SetUp]
        public void Setup()
        {
        }

        [Test]
        public void AcceptanceTest()
        {
            Dictionary<string, int> cartData = new Dictionary<string, int>();

            cartData.Add("A", 1);
            cartData.Add("B", 1);
            cartData.Add("C", 1);
            PromoConfiguration promo = new PromoConfiguration(cartData);
            Assert.IsTrue(promo.CalculateTotal() == 100);

            cartData.Clear();
            cartData.Add("A", 5);
            cartData.Add("B", 5);
            cartData.Add("C", 1);
            promo = new PromoConfiguration(cartData);
            Assert.IsTrue(promo.CalculateTotal() == 370);

            cartData.Clear();
            cartData.Add("A", 3);
            cartData.Add("B", 5);
            cartData.Add("C", 1);
            cartData.Add("D", 1);
            promo = new PromoConfiguration(cartData);
            Assert.IsTrue(promo.CalculateTotal() == 280);
        }
    }
}