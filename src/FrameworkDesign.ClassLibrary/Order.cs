using System;
using System.Collections.Generic;
using System.Text;

namespace FrameworkDesign.ClassLibrary
{
    public class Order
    {
        public int Status { get; set; }
        public Items Items { get; set; }

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
