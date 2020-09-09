using System;
using System.Collections.Generic;

namespace PromotionEngine
{
    class Program
    {
        static void Main(string[] args)
        {
            int countValue = 0;
            short option = 0;
            long result = 0;

            Dictionary<string, int> cartInfo = new Dictionary<string, int>();
            cartInfo.Add("A", 0);
            cartInfo.Add("B", 0);
            cartInfo.Add("C", 0);
            cartInfo.Add("D", 0);

            Dictionary<int, string> unitOptions = new Dictionary<int, string>();
            unitOptions.Add(1, "A");
            unitOptions.Add(2, "B");
            unitOptions.Add(3, "C");
            unitOptions.Add(4, "D");

            Console.WriteLine("**SELECT THE OPTION NO. FOR CORRESPONDING SKU ID**");

            do
            {
                Console.WriteLine("(1) A   (2) B   (3) C   (4) D   (0) CALCULATE CART VALUE");
                if (!Int16.TryParse(Console.ReadLine(), out option) || (option != 0 && !unitOptions.ContainsKey(option)))
                {
                    Console.WriteLine("Please enter a valid option.");
                    option = -1;
                    continue;
                }

                if (option == 0) continue;

                Console.Write("Enter the count of " + unitOptions[option] + ": ");
                if (!Int32.TryParse(Console.ReadLine(), out countValue))
                {
                    Console.WriteLine("Please enter a valid count value.");
                    continue;
                }

                cartInfo[unitOptions[option]] = cartInfo[unitOptions[option]] + countValue;

            } while (option != 0);

            PromoConfiguration promoConfiguration = new PromoConfiguration(cartInfo);

            result = promoConfiguration.CalculateTotal();
            if (result == -1)
                Console.WriteLine("Unexpected error.");
            else
                Console.WriteLine("Total Cart Value: " + result);

        }
    }
}
