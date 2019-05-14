using FrameworkDesign.ClassLibrary.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace FrameworkDesign.ClassLibrary
{
    public class Order
    {
        public OrderStatus Status { get; set; }

        private Items items;
        public Items Items
        {
            get
            {
                return items;
            }
            set
            {
                if (value.Any(item => item.Price <= 0.0))    // 验证商品的价格是否正确
                    return;
                items = value;
            }
        }

        private IOperationNormalPrices OperationPrices;
        public Order(IOperationNormalPrices operationPrices)
        {
            this.OperationPrices = operationPrices;
        }
        public double GetPrices()
        {
            return this.OperationPrices.GetPrices(this);
        }
    }
}
