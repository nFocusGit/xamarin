using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PetOwnerTool_01
{
    public static class IntExtension
    {
        public static int MultiplyValue(this int value)
        {
            return value*1000;
        }
    }
}
