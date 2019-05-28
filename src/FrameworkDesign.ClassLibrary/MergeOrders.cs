using System;
using System.Collections.Generic;
using System.Text;

namespace FrameworkDesign.ClassLibrary
{
    public interface IMergeOrderList<TOrder> where TOrder : Order
    {
    }

    public class MergeOrderList<TOrder> : IMergeOrderList<TOrder> where TOrder : Order
    {
    }

    public class MergeOrders<TOrder> where TOrder : Order
    {
        public IMergeOrderList<TOrder> Merge(TOrder order1, TOrder order2)
        {
            return new MergeOrderList<TOrder>();
        }
    }
}
