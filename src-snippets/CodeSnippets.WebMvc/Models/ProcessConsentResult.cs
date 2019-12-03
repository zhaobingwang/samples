using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CodeSnippets.WebMvc.Models
{
    public class ProcessConsentResult
    {
        public string Redirecturl { get; set; }
        public bool IsRedirect => Redirecturl != null;
        public string ValidationError { get; set; }
        public ConsentViewModel ViewModel { get; set; }
    }
}
