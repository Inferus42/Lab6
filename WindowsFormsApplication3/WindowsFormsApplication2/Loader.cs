using System;
using System.Diagnostics;
namespace WindowsFormsApplication2
{
    class Loader
    {
        private string work = "Приступают к разгрузке сухогруза";

        public string Work
        {
            get
            {
                Stopwatch stopWatch = new Stopwatch();
                stopWatch.Start(); stopWatch.Stop();
                return work + Environment.NewLine + "Время выполнени метода " + System.Reflection.MethodBase.GetCurrentMethod().Name + " в миллисекундах: " + stopWatch.Elapsed + " или " + stopWatch.ElapsedTicks + " тактов";
            }

            set
            {
                Stopwatch stopWatch = new Stopwatch();
                stopWatch.Start(); stopWatch.Stop();
                work = value + Environment.NewLine + "Время выполнени метода " + System.Reflection.MethodBase.GetCurrentMethod().Name + " в миллисекундах: " + stopWatch.Elapsed + " или " + stopWatch.ElapsedTicks + " тактов";
            }
        }
    }
}
