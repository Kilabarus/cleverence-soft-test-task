using System.Text.RegularExpressions;

namespace Problem_3.RegexBuilders
{
    internal interface IRegexBuilder
    {
        public RegexGroupNames GetGroupNames();
        public Regex Build();
    }
}
