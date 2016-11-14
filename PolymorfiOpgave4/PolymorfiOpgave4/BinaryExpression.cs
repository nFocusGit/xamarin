using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PolymorfiOpgave4
{
    public abstract class BinaryExpression : Expression
    {
        protected readonly Expression left;
        protected readonly Expression right;
        public abstract string OperatorSymbol { get; }

        protected BinaryExpression(Expression left, Expression right)
        {
            this.left = left;
            this.right = right;
        }

        public sealed override string ToString()
        {
            return "(" + left.ToString() + " " + OperatorSymbol + " " + right.ToString() + ")";
        }
    }
}
