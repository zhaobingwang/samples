using System;

namespace FrameworkDesign.ClassLibrary.ConsoleApp
{
    class Program
    {
        static void Main(string[] args)
        {
            Order order = new Order(new OperationPrice.OperationNormalPrices())
            {
                Items = new Items()
            };
            order.FilteredItemsCountEvents += Order_FilteredItemsCountEvents;
            order.GetPrices();
        }

        private static void Order_FilteredItemsCountEvents(int itemCount)
        {
            Console.WriteLine($"过滤后还剩下{itemCount}个商品");
        }
    }
}
