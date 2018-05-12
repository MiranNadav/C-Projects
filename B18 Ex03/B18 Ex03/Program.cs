using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace B18_Ex03
{
    class Program
    {
        static void Main(string[] args)
        {
            Electric electric = new Electric(0, 3.2F);
            List<Wheel> Wheels = new List<Wheel>();
            for (int i = 0; i < 4; i++)
            {
                Wheel wheel = new Wheel("Yamaha", 32);
                Wheels.Add(wheel);
            }

            ElectricCar Car1 = new ElectricCar("Mazda", "111", Wheels, electric, "Black", 4);
            //Console.WriteLine(Car1.ToString());
            //Console.ReadLine();
        }
    }
}
