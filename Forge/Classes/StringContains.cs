using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Forge.Classes
{
    public class StringContains
    {

        public StringContains()
        {
        }

        public string Special(string text)
        {
            if (text.Contains("'"))
            {
                text = text.Replace("'", "''");
                return text;
            }

            return text;
        }
    }
}
