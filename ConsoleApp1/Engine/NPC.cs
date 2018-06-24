using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Engine
{
    public class NPC:Human_Base
    {
        public NPC(string name, int ws, int bs, int str, int t, int ag, int inte, int per, int wp, int fel, int ifl)
         : base(name, ws, bs, str, t, ag, inte, per, wp, fel, ifl)
        {
            
        }
    }
}
