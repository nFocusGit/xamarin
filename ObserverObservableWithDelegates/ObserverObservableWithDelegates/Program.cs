using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ObserverObservableWithDelegates
{
    class Program
    {
        static void Main(string[] args)
        {
            Observable observable = new Observable();
            Observer observer = new Observer();
            observable.SomethingHappened += observer.HandleEvent;

            observable.DoSomething();

            Console.ReadKey();
        }
    }
}
