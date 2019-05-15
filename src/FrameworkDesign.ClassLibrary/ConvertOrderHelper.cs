using System;
using System.Collections.Generic;
using System.Text;

namespace FrameworkDesign.ClassLibrary
{
    public class ConvertOrderHelper
    {
        public virtual Order ConvertVipOrder(Order normalOrder)
        {
            if (!ValidatorConvertNormalOrder(normalOrder))
                return null;

            Order result = new Order(new OperationPrice.OperationNormalPrices())
            {
                Status = normalOrder.Status,
                Items = normalOrder.Items
            };

            normalOrder.Items.ForEach(item =>
            {
                result.Items.Add(BuildVipItemWithNormal(item));
            });

            return result;
        }

        protected virtual bool ValidatorConvertNormalOrder(Order normalOrder)
        {
            if (normalOrder == null || normalOrder.Items == null || normalOrder.Items.Count == 0)
                return false;
            return true;
        }

        protected virtual Item BuildVipItemWithNormal(Item item)
        {
            Item result = new Item()
            {
                Code = item.Code,
                Name = item.Name,
                Price = item.Price - 20    // 会员价要减掉20元
            };
            return result;
        }
    }
}

