using System;
using System.Collections.Generic;
using System.Text;

namespace FrameworkDesign.ClassLibrary
{
    public interface IMergeOrderList<in TOrder> where TOrder : Order
    {
    }

    public class MergeOrderList<TOrder> : IMergeOrderList<TOrder> where TOrder : Order
    {
    }

    public class MergeOrders<TOrder> where TOrder : Order
    {
        public IMergeOrderList<TOrder> MergeNormal<TChild>(TOrder order1, TChild order2)
        {
            return new MergeOrderList<TOrder>();
        }
    }
}
