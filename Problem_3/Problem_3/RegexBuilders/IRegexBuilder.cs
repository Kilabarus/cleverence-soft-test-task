using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace Problem_3.RegexBuilders
{
    internal interface IRegexBuilder
    {
        public RegexGroupNames GetGroupNames();
        public Regex Build();
    }
}
