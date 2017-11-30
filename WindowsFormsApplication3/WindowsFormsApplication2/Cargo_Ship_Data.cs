using System;


namespace WindowsFormsApplication2
{
    public delegate string Ship_Data();

    class Cargo_Ship_Data : Dimensions
    {
        protected int Capacity;

        public string Dry_Cargo()
        {
            Length = 226;
            Width = 24;
            Height = 35;
            Capacity = 30000;
            return (";  Длина: " + Length + "м, Ширина: " + Width + "м, Высота: " + Height + "м, Грузоподъёмность: " + Capacity + "т,");

        }

        public string Tanker()
        {
            Length = 414;
            Width = 63;
            Height = 59;
            Capacity = 553662;
            return (";  Длина: " + Length + "м, Ширина: " + Width + "м, Высота: " + Height + "м, Грузоподъёмность: " + Capacity + "т,");

        }

        public string Container()
        {
            Length = 320;
            Width = 33;
            Height = 26;
            Capacity = 65000;
            return (";  Длина: " + Length + "м, Ширина: " + Width + "м, Высота: " + Height + "м, Грузоподъёмность: " + Capacity + "т,");

        }

    }
}
