using System;
using System.Collections.Generic;
using System.Text;

namespace FrameworkDesign.ClassLibrary
{
    public partial class Employee
    {
        public string Name { get; set; }
        public void GetEmployeeFullName()
        {

        }
        partial void GetJob();
    }
}
