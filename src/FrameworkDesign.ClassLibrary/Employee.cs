using System;
using System.Collections.Generic;
using System.Text;

namespace FrameworkDesign.ClassLibrary
{
    public partial class Employee
    {
        partial void GetJob()
        {
            Console.WriteLine("Partial method.");
        }
    }
}
