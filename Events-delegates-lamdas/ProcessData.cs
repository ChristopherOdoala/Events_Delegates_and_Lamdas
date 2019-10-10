using System;
using System.Collections.Generic;
using System.Text;

namespace Events_delegates_lamdas
{
    public class ProcessData
    {
        public void Process(int x, int y, BizRulesDelegate del)
        {
            var result = del(x, y);
            Console.WriteLine(result);
        }

        public void ProcessAction(int x, int y, Action<int,int> action)
        {
            action(x, y);
            Console.WriteLine("Action has been called");
        }
    }
}
