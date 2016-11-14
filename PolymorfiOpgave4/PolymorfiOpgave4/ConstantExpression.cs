using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PolymorfiOpgave4
{
    public sealed class ConstantExpression : Expression
    {
        private readonly double value;

        public ConstantExpression(double value)
        {
            this.value = value;
        }

        public override double Evaluate()
        {
            return value;
        }

        public override string ToString()
        {
            return value.ToString();
        }
    }
}
