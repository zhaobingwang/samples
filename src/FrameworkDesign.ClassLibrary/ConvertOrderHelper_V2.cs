using System;
using System.Collections.Generic;
using System.Text;

namespace FrameworkDesign.ClassLibrary
{
    public class ConvertOrderHelper_V2 : ConvertOrderHelper
    {
        protected override Item BuildVipItemWithNormal(Item item)
        {
            var vipItem = base.BuildVipItemWithNormal(item);
            vipItem.Price += 10;    // 新版本中的转换需要外加10块钱
            return vipItem;
        }

        protected override bool ValidatorConvertNormalOrder(Order normalOrder)
        {
            if (base.ValidatorConvertNormalOrder(normalOrder))
            {
                if (normalOrder.Status == Enums.OrderStatus.DeActive)  // 新版本中的转换，订单状态必须是2才能满足验证
                {
                    return true;
                }
            }
            return false;
        }
    }
}
