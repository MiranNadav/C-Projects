using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace B18_Ex03
{
    public class VehicleFactory
    {
        public static Vehicle CreateVehicle(int i_VehicleTypeAsInt)
        {
            if (!Enum.IsDefined(typeof(eVehicleTypes), i_VehicleTypeAsInt))
            {
                throw new ArgumentException("The input is not a valid vehicle type");
            }

            eVehicleTypes vehicleType = (eVehicleTypes)i_VehicleTypeAsInt;
            Vehicle createdVehicle;
            switch (vehicleType)
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
            GasTruck,
        }
    }
}
