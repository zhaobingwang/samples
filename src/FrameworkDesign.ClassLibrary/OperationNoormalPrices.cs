using System;
using System.Collections.Generic;
using System.Text;

namespace FrameworkDesign.ClassLibrary
{
    public class OperationNoormalPrices : IOperationNormalPrices
    {
        public double GetPrices(Order order)
        {
            var noamalItemList = order.Items.GetNormalItems();
            double result = 0.0;
            foreach (var item in noamalItemList)
            {
                result += item.Price;   // 普通商品直接相加
            }

            var vipItemList = order.Items.GetVIPItems();
            foreach (var item in vipItemList)
            {
                result += item.Price + 20;    // VIP商品统一下调了20元，所以都需要加上
            }
            return result;
        }

        public double GetVipPrices(Order order)
        {
            double result = 0.0;
            var vipItemList = order.Items.GetVIPItems();
            foreach (var item in vipItemList)
            {
                result += item.Price + 20;    // VIP商品统一下调了20元，所以都需要加上
            }
            return result;
        }
    }
}
