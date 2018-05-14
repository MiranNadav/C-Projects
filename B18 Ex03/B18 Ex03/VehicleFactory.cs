using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace B18_Ex03
{
    class VehicleFactory
    {
        public static Vehicle CreateVehicle(eVehicleTypes i_VehicleType )
        {
            Vehicle createdVehicle;
            switch (i_VehicleType)
            {
                case eVehicleTypes.GasMotorcycle:
                    createdVehicle = new GasMotorcycle();
                    break;
                case eVehicleTypes.ElectricMotorcycle:
                    createdVehicle = new ElectricMotorcycle();
                    break;
                case eVehicleTypes.GasCar:
                    createdVehicle = new GasCar();
                    break;
                case eVehicleTypes.ElectricCar:
                    createdVehicle = new ElectricCar();
                    break;
                case eVehicleTypes.GasTruck:
                    createdVehicle = new GasTruck();
                    break;
                default:
                    throw new Exception("This kind of vehicle is not supported in the garage");

            }
            return createdVehicle;
        }

        public enum eVehicleTypes
        {
            GasMotorcycle,
            ElectricMotorcycle,
            GasCar,
            ElectricCar,
            GasTruck
        }
    }
}
