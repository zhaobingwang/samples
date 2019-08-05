using Microsoft.AspNetCore.Mvc.ActionConstraints;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Sample.NetCore.Web
{
    public class CountrySpecificAttribute : Attribute, IActionConstraint
    {
        private readonly string _countryCode;
        public CountrySpecificAttribute(string countryCode)
        {
            _countryCode = countryCode;
        }
        public int Order
        {
            get
            {
                return 0;
            }
        }
        public bool Accept(ActionConstraintContext context)
        {
            return string.Equals(
                context.RouteContext.RouteData.Values["country"].ToString(),
                _countryCode,
                StringComparison.OrdinalIgnoreCase);
        }
    }
}
