using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Engine.Utilities
{
    public class Utilities
    {
        public int GetTens(int value)
        {
            var valueStr = value.ToString();
            var valueTens = Convert.ToInt32(valueStr[0]);
            return valueTens;
        }
    }
}
