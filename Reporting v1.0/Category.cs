using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Reporting_v1._0
{
    public class Category
    {
        string _content;
        public Category(string content) 
        {
            _content = content;
        }

        public string GetContent() { return _content; }

    }
}
