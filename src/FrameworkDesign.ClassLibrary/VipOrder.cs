using System;
using System.Collections.Generic;
using System.Text;

namespace FrameworkDesign.ClassLibrary
{
    public class VipOrder : Order
    {
        public VipOrder(IOperationNormalPrices operationPrices) : base(operationPrices)
        {
        }
    }
}
