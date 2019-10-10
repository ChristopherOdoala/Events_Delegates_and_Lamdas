using System;

namespace Events_delegates_lamdas
{
    public delegate int BizRulesDelegate(int x, int y);
    class Program
    {
        static void Main(string[] args)
        {
            BizRulesDelegate addDel = (x, y) => x + y;
            BizRulesDelegate multiplyDel = (x, y) => x * y;

            var data = new ProcessData();
            //data.Process(2, 3, multiplyDel);

            Action<int, int> myAction = (x, y) => Console.WriteLine(x + y);
            Action<int, int> myMultiplyAction = (x, y) => Console.WriteLine(x * y);
            data.ProcessAction(2, 3, myAction);

            var worker = new Worker();
            worker.WorkPerformed += (s,e) => Console.WriteLine("Hours Worked : " + e.Hours + " " + e.WorkType); ;
            worker.WorkCompleted += (s,e) => Console.WriteLine("Worker is done");
            worker.DoWork(8, WorkType.GenerateReports);
            
            Console.Read();
        }

        //static void Worker_WorkPerformed(object sender, WorkPerformedEventArgs e)
        //{
        //    Console.WriteLine("Hours Worked : " + e.Hours + " " + e.WorkType);
        //}

        //static void Worker_WorkCompleted(object sender, EventArgs e)
        //{
        //    Console.WriteLine("Worker is done");
        //}

        //static void DoWork(WorkPerformedHandler del)
        //{
        //    del(5, WorkType.GotoMeetings);
        //}

        //static int WorkPerformed1(int hours, WorkType workType)
        //{
        //    Console.WriteLine("WorkPerformed1 called " + hours.ToString());
        //    return hours + 1;
        //}

        //static int WorkPerformed2(int hours, WorkType workType)
        //{
        //    Console.WriteLine("WorkPerformed2 called " + hours.ToString());    
        //    return hours + 2;
        //}

        //static int WorkPerformed3(int hours, WorkType workType)
        //{
        //    Console.WriteLine("WorkPerformed3 called " + hours.ToString());
        //    return hours + 3;
        //}
    }

    public enum WorkType
    {
        GotoMeetings,
        Golf,
        GenerateReports
    }
}
