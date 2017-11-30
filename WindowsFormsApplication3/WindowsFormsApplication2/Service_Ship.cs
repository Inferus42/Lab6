using System;
using System.Diagnostics;

namespace WindowsFormsApplication2
{
    class Service_Ship : Dimensions, Location_Ship
    {
        public string Location()
        {
            Stopwatch stopWatch = new Stopwatch();
            stopWatch.Start(); 

            Length = 120;
            Width = 15;
            Height = 17;
            stopWatch.Stop();
            return ("Сервисный корабль;  Длина: " + Length + "м, Ширина: " + Width + "м, Высота: " + Height + "м, Местоположение: " + " Пришвартовывает корабль в порту" + Environment.NewLine + "Время выполнени метода " + System.Reflection.MethodBase.GetCurrentMethod().Name + " в миллисекундах: " + stopWatch.Elapsed+ " или " + stopWatch.ElapsedTicks + " тактов");
        }
    }
}
