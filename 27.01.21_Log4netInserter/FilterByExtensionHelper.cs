using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _27._01._21_Log4netInserter
{
    public class FilterByExtensionHelper
    {
        public FilterByExtensionHelper(bool isToFilter, string theExtension)
        {
            IsToFilter = isToFilter;
            TheExtension = theExtension;
        }

        public bool IsToFilter { get; set; }
        public string TheExtension { get; set; }
    }
}
