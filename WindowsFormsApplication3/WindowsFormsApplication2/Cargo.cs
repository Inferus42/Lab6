using System;
using System.Diagnostics;

namespace WindowsFormsApplication2
{
    class Cargo : Dimensions
    {
          public string Location_Cargo()
        {
            Stopwatch stopWatch = new Stopwatch();
            stopWatch.Start(); stopWatch.Stop();
            return "На борту сухогруза " + Environment.NewLine + "Время выполнени метода " + System.Reflection.MethodBase.GetCurrentMethod().Name + " в миллисекундах: " + stopWatch.Elapsed + " или " + stopWatch.ElapsedTicks + " тактов";
            
        }

    }
}
