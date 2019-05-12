using System;
using System.Collections.Generic;
using System.Text;

namespace FrameworkDesign.ClassLibrary
{
    public class Item
    {
        public string Code { get; set; }
        public string Name { get; set; }
        public virtual double Price { get; set; }
    }

    public class VipItem : Item
    {
        //private double price;
        //public override double Price
        //{
        //    get { return price; }
        //    set { price = value; }
        //}
        public override double Price { get => base.Price; set => base.Price = value; }
    }
}
