using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ObserverObservableWithDelegates
{
    class Observable
    {
        public event EventHandler SomethingHappened;

        public void DoSomething()
        {
            EventHandler handler = SomethingHappened;
            if (handler != null)
            {
                handler(this, EventArgs.Empty);
            }
        }
    }
}
