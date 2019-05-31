using System;
using System.Collections.Generic;
using System.Text;

namespace FrameworkDesign.ClassLibrary
{
    public interface IOperationNormalPrices
    {
        double GetPrices(Order order);
        double GetVipPrices(Order order);
    }
}
