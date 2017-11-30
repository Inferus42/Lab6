using System;
using System.Diagnostics;
using System.Threading;

namespace WindowsFormsApplication2
{    
    class Cargo_Ship : Location_Ship
    {        
        public string State(string Type)
        {
            Stopwatch stopWatch = new Stopwatch();
            stopWatch.Start();

            Cargo_Ship_Data d = new Cargo_Ship_Data();
            

            switch (Type)
            {
                case "Сухогруз":

                    Ship_Data data1 = new Ship_Data(d.Dry_Cargo);
                    
                    stopWatch.Stop();

                    return (Type + data1() + " Местоположение:" + Location() + Environment.NewLine + "Время выполнени метода " + System.Reflection.MethodBase.GetCurrentMethod().Name + " в миллисекундах: " + stopWatch.Elapsed + " или " + stopWatch.ElapsedTicks + " тактов");
                        break;
                    
                case "Танкер":

                    Ship_Data data2 = new Ship_Data(d.Tanker);
                    
                    stopWatch.Stop();

                    return (Type + data2() + " Местоположение:" + Location() + Environment.NewLine + "Время выполнени метода " + System.Reflection.MethodBase.GetCurrentMethod().Name + " в миллисекундах: " + stopWatch.Elapsed + " или " + stopWatch.ElapsedTicks + " тактов");
                    break;
                    
                case "Контейнеровоз":
                   Cargo i1 = new Cargo();
                        Console.Write(i1.Location_Cargo());

                    Ship_Data data3 = new Ship_Data(d.Container);
                    
                    stopWatch.Stop();

                    return (Type + data3() + " Местоположение:" + Location() + Environment.NewLine + "Время выполнени метода " + System.Reflection.MethodBase.GetCurrentMethod().Name + " в миллисекундах: " + stopWatch.Elapsed + " или " + stopWatch.ElapsedTicks + " тактов");
                    break;

                default:
                    return("");
                    }
            }
        
        public string Location()
        {
            return "В порту";
        }


    }

}
