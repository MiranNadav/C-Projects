using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace B18_Ex03
{
    class Program
    {
        static void Main()
        {
            try
            {
                Vehicle gastruck = VehicleFactory.CreateVehicle(1);
                Garage g = new Garage();
                gastruck.LicenseNumber = "asdfghj";
                g.AddVehicleToGarage(gastruck);

                Console.WriteLine(g.GetFullVehicleDetails(gastruck.LicenseNumber));
            }
            catch (ArgumentException e) 
            {
                Console.WriteLine(e.Message);
            }

            Console.ReadLine();

        }
    }
}
