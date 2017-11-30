using System;
using System.Windows.Forms;
using System.Threading;

namespace WindowsFormsApplication2
{
    class ThreadClass
    {
        private ProgressBar pb;
        public bool a = false;

        public bool PB1
        {
            get { return a; }
            set { a = value; }
        }

        public void PB(object obj)

        {
            Thread t = Thread.CurrentThread;
            PB1 = t.IsAlive;
            pb = (ProgressBar)obj;
            
            for (int i = 1; i < 101; i++)
             {      
                 if (pb.InvokeRequired)
                 {
                     pb.Invoke(new Action<int>((s) => pb.Value = s), i);
                 }
                 else
                 {
                     pb.Value = i;
                 }

                 System.Threading.Thread.Sleep(100);
             }
             MessageBox.Show("Одна из групп рабочих закочила работу");
            PB1 = !t.IsAlive;
        }
    }
}
