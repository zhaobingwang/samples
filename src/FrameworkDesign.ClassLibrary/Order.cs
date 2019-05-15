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
            this.Filter(item =>
            {
                if (item.Price <= 0)
                {
                    return true;
                }
                return false;
            });
            return this.OperationPrices.GetPrices(this);
        }

        private Action<int> filteredItemsCountEvents;
        public event Action<int> FilteredItemsCountEvents
        {
            add
            {
                filteredItemsCountEvents = value;
            }
            remove
            {
                if (filteredItemsCountEvents != null)
                    filteredItemsCountEvents -= value;
            }
        }

        public List<Item> Filter(Func<Item, bool> filter)
        {
            var result = from item in Items where filter(item) select item;
            result.ToList().ForEach(item =>
            {
                Items.Remove(item);
            });
            this.filteredItemsCountEvents(Items.Count);    // 触发过滤后的事件
            return result.DefaultIfEmpty().ToList();
        }
    }
}
