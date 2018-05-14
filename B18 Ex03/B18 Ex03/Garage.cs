using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace B18_Ex03
{
    public class Garage
    {
        private Dictionary<string, Vehicle> m_GarageVehicles;

        public Garage()
        {
            m_GarageVehicles = new Dictionary<string, Vehicle>();
        }

        public bool IsVehicleInGarage(string i_LicenseNumber)
        {
            if (m_GarageVehicles.ContainsKey(i_LicenseNumber))
            {
                return true;
            }
            return false;
        }

        public void IsVehicleInGarageException(string i_LicenseNumber)
        {
            if (!IsVehicleInGarage(i_LicenseNumber))
            {
                throw new ArgumentException("This Vehicle is not in the garage!");
            }
        }

        public void AddVehicleToGarage(Vehicle i_Vehicle)
        {
            if (IsVehicleInGarage(i_Vehicle.LicenseNumber))
            {
                i_Vehicle.VehicleGarageStatus = Vehicle.eVehicleGarageStatus.InRepair;
                throw new Exception("This vehicle is already in the garage! Vehicle status changed to being fixed");
            }
            m_GarageVehicles.Add(i_Vehicle.LicenseNumber, i_Vehicle);
        }

        public void ChangeVehicleStatus(string i_LicenseNumber, Vehicle.eVehicleGarageStatus i_VehicleStatus)
        {
            if (!IsVehicleInGarage(i_LicenseNumber))
            {
                throw new Exception("This vehicle's status cannot be changed, it's not in the garage!");
            }

            m_GarageVehicles[i_LicenseNumber].VehicleGarageStatus = i_VehicleStatus;
        }

        public void FillAirToMaximum(string i_LicenseNumber)
        {
            if (!IsVehicleInGarage(i_LicenseNumber))
            {
                throw new Exception("This vehicle's Wheels cannot be pumped, it's not in the garage!");
            }

            List<Wheel> currentVehicleWheels = m_GarageVehicles[i_LicenseNumber].Wheels;
            float maxAirPressure = currentVehicleWheels[0].MaximumAirPressure;
            foreach (Wheel wheel in currentVehicleWheels)
            {
                wheel.CurrentAirPressure = maxAirPressure;
            }
        }
]        public List<string> GetLicenseNumberList()
        {
            List<string> licenseNumbers = new List<string>();
            foreach (KeyValuePair<string, Vehicle> vehicle in this.m_GarageVehicles)
            {
                licenseNumbers.Add(vehicle.Key);
            }

            return licenseNumbers;
        }
        public List<string> GetLicenseNumberList(int i_VehicleStatus)
        {
            if (!Enum.IsDefined(typeof(Vehicle.eVehicleGarageStatus), i_VehicleStatus))
            {
                throw new ArgumentException();
            }

            List<string> licenseNumbers = new List<string>();
            Vehicle.eVehicleGarageStatus vehicleStatus = (Vehicle.eVehicleGarageStatus)i_VehicleStatus;
            foreach (KeyValuePair<string, Vehicle> vehicle in this.m_GarageVehicles)
            {
                if (vehicle.Value.VehicleGarageStatus == vehicleStatus)
                {
                    licenseNumbers.Add(vehicle.Key);
                }
            }

            return licenseNumbers;
        }

        public void PumpAirToMaximum(string i_LicenseNumber)
        {
            if (!IsVehicleInGarage(i_LicenseNumber))
            {
                throw new Exception("This vehicle's air cannot be filled, since it's not in the garage!");
            }

            Vehicle vehicle = this.m_GarageVehicles[i_LicenseNumber];
            vehicle.PumpAllWheelsAirToMaximum();
        }

        public void RefuelGasVehicle(string i_LicenseNumber, int i_GasType, float i_AmountOfGasToFill)
        {
            IsVehicleInGarageException(i_LicenseNumber);
            if (!Enum.IsDefined(typeof(Gas.FuelType), i_GasType))
            {
                throw new ArgumentException("Given gas type does not exist!");
            }
            Vehicle vehicle = this.m_GarageVehicles[i_LicenseNumber];
            Gas.FuelType fuelType = (Gas.FuelType)i_GasType;

            if (!(vehicle.EnergySource is Gas))
            {
                throw new Exception("The given car is not working on gas!");
            }

            Gas gasEngine = (Gas)vehicle.EnergySource;
            gasEngine.FillGas(fuelType, i_AmountOfGasToFill);

        }

        public void RechargeElectricVehicle(string i_LicenseNumber, int i_MinutesToRecharge)
        {
            IsVehicleInGarageException(i_LicenseNumber);
            Vehicle vehicle = this.m_GarageVehicles[i_LicenseNumber];
            if (!(vehicle.EnergySource is Electric))
            {
                throw new Exception("The given car is not electric!");
            }

            Electric electricEngine = (Electric)vehicle.EnergySource;
            electricEngine.Charge((float)i_MinutesToRecharge / 60);
        }

        public string GetFullVehicleDetails(string i_LicenseNumber)
        {
            IsVehicleInGarageException(i_LicenseNumber);
            return this.m_GarageVehicles[i_LicenseNumber].ToString();
        }
    }
}
