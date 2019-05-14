using System;
using FrameworkDesign.ClassLibrary;
using Xunit;

namespace FrameworkDesign.ClassLibrary.Tests
{
    [Trait("框架设计", "订单测试")]
    public class OrderTest
    {
        [Fact(DisplayName = "商品价格是否正确-异常测试")]
        public void Order_ItemsPrice_IsCorrect_WithExpectedParameters()
        {
            // arrange
            OperationNoormalPrices operationNoormalPrices = new OperationNoormalPrices();
            Order order = new Order(operationNoormalPrices);
            Items items = new Items();
            items.Add(new Item() { Name = "西瓜", Price = 0.0 });

            // act
            order.Items = items;

            // assert
            Assert.Null(order.Items);
        }

        [Fact(DisplayName = "商品价格是否正确-正常测试")]
        public void Order_ItemsPrice_IsCorrect_WithUnExpectedParameters()
        {
            // arrange
            OperationNoormalPrices operationNoormalPrices = new OperationNoormalPrices();
            Order order = new Order(operationNoormalPrices);
            Items items = new Items();
            items.Add(new Item() { Name = "西瓜", Price = 39.99 });

            // act
            order.Items = items;

            // assert
            Assert.NotNull(order.Items);
            Assert.True(order.Items.Count > 0);
        }
    }
}
