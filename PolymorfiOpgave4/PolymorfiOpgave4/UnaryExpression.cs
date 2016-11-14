using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PolymorfiOpgave4
{
    public abstract class UnaryExpression : Expression
    {
        protected readonly Expression expr;
    }
}
