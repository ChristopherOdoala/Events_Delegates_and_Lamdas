using System;
using System.Collections.Generic;
using System.Text;

namespace Events_delegates_lamdas
{
    //public delegate int WorkPerformedHandler(object sender, WorkPerformedEventArgs e);
    public class Worker
    {
        public event EventHandler<WorkPerformedEventArgs> WorkPerformed;
        public event EventHandler WorkCompleted;
        public void DoWork(int hours, WorkType workType)
        {
            for (int i = 0; i < hours; i++)
            {
                System.Threading.Thread.Sleep(1000);
                OnWorkPerformed(i + 1, workType);
            }
            OnWorkCompleted();
        }

        protected virtual void OnWorkPerformed(int hours, WorkType workType)
        {
            //Method 1
            //if(WorkPerformed != null)
            //{
            //    WorkPerformed(hours, workType);
            //}

            //Method 2
            var del = WorkPerformed as EventHandler<WorkPerformedEventArgs>;
            if(del != null)
            {
                del(this, new WorkPerformedEventArgs(hours, workType));
            }
        }

        protected virtual void OnWorkCompleted()
        {
            //Method 1
            //if(WorkCompleted != null)
            //{
            //    WorkCompleted(this, EventArgs.Empty);
            //}

            //Method 2
            var del = WorkCompleted as EventHandler;
            if (del != null)
            {
                del(this, EventArgs.Empty);
            }
        }
    }
}
