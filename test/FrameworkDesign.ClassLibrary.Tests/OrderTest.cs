using System;
using FrameworkDesign.ClassLibrary;
using FrameworkDesign.ClassLibrary.OperationPrice;
using Xunit;

namespace FrameworkDesign.ClassLibrary.Tests
{
    [Trait("框架设计", "订单测试")]
    public class OrderTest
    {
        [Fact(DisplayName = "商品价格是否正确-异常测试")]
        public void Order_ItemsPrice_IsCorrect_WithUnExpectedParameters()
        {
            // arrange
            OperationNormalPrices operationNoormalPrices = new OperationNormalPrices();
            Order order = new Order(operationNoormalPrices);
            Items items = new Items();
            items.Add(new Item() { Name = "西瓜", Price = 0.0 });

            // act
            order.Items = items;

            // assert
            Assert.Null(order.Items);
        }

        [Fact(DisplayName = "商品价格是否正确-正常测试")]
        public void Order_ItemsPrice_IsCorrect_WithExpectedParameters()
        {
            // arrange
            OperationNormalPrices operationNoormalPrices = new OperationNormalPrices();
            Order order = new Order(operationNoormalPrices);
            Items items = new Items();
            items.Add(new Item() { Name = "西瓜", Price = 39.99 });

            // act
            order.Items = items;

            // assert
            Assert.NotNull(order.Items);
            Assert.True(order.Items.Count > 0);
        }

        [Fact(DisplayName = "获取订单价格-正常测试")]
        public void Order_GetPrices_WithExpectedParameters()
        {
            // arrange
            double expectedTotalPrice = 10935.99;
            OperationNormalPrices operationNormalPrices = new OperationNormalPrices();
            Order order = new Order(operationNormalPrices);
            Items items = new Items();
            items.Add(new Item() { Code = "Normal_003", Name = "西瓜", Price = 39.99 });
            order.Items = items;

            // act
            order.FilteredItemsCountEvents += (obj) => { };
            var result = order.GetPrices();

            // assert
            Assert.True(result == expectedTotalPrice);
        }

        [Fact(DisplayName = "过滤后的商品数量-正常测试")]
        public void Order_ItemsCountAfterFilter_WithExpectedParameters()
        {
            // arrange
            int expected = 4;
            OperationNormalPrices operationNormalPrices = new OperationNormalPrices();
            Order order = new Order(operationNormalPrices);
            Items items = new Items();
            order.Items = items;

            // act
            int countAfterFilter = -1;
            order.FilteredItemsCountEvents += (obj) => { countAfterFilter = obj; };
            var result = order.GetPrices();

            // assert
            Assert.True(countAfterFilter == expected);
        }
    }
}
