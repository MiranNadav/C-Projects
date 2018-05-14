using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace B18_Ex03
{
    class Garage
    {
        private Dictionary<string, Vehicle> m_GarageVehicles;

        public Garage ()
        {
            m_GarageVehicles = new Dictionary<string, Vehicle>();
        }

        public bool IsVehicleInGarage (string i_LicenseNumber)
        {
            if (m_GarageVehicles.ContainsKey(i_LicenseNumber))
            {
                return true;
            }
            return false;
        }

        public void AddVehicleToGarage (Vehicle i_Vehicle)
        {
            if (IsVehicleInGarage(i_Vehicle.LicenseNumber))
            {
                i_Vehicle.VehicleGarageStatus = Vehicle.eVehicleGarageStatus.BeingFixed;
                throw new Exception("This vehicle is already in the garage!");
            }
            m_GarageVehicles.Add(i_Vehicle.LicenseNumber, i_Vehicle);
        }

        public void ChangeVehicleStatus (string i_LicenseNumber, Vehicle.eVehicleGarageStatus i_VehicleStatus)
        {
            if (!IsVehicleInGarage(i_LicenseNumber))
            {
                throw new Exception("This vehicle's status cannot be changed, it's not in the garage!");
            }

            m_GarageVehicles[i_LicenseNumber].VehicleGarageStatus = i_VehicleStatus;
        }

        public void FillAirToMaximum (string i_LicenseNumber)
        {
            if (!IsVehicleInGarage(i_LicenseNumber))
            {
                throw new Exception("This vehicle's status cannot be changed, it's not in the garage!");
            }

            List<Wheel> currentVehicleWheels = m_GarageVehicles[i_LicenseNumber].Wheels;
            float maxAirPressure = currentVehicleWheels[0].MaximumAirPressure;
            foreach (Wheel wheel in currentVehicleWheels)
            {
                wheel.CurrentAirPressure = maxAirPressure;
            }
        }

        public List<string> GetLicenseNumberList ()
        {

        }
    }
}
