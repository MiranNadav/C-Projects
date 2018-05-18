using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using B18_Ex03;

namespace ConsoleUI
{
    class AddVehicle
    {
        private UserDisplay m_UserDisplay;

        public AddVehicle ()
        {
            m_UserDisplay = new UserDisplay();
        }
        public Vehicle getVitalDetailsFromUser()
        {
            m_UserDisplay.clearAndDisplayMessage("You have chosen to add a new vehicle");

            Vehicle m_CreatedVehicle = createVehicleFromFactory(getVehicleType());
            m_CreatedVehicle.LicenseNumber = getLicensePlateNumber();
            return m_CreatedVehicle;
        }

        public Vehicle populateVehicleWithDetails(Vehicle vehicle)
        {
            vehicle.ModelName = getCarModel();
            setCurrentAmountOfEnergy(vehicle);
            vehicle.SetEnergyPercentge();
            addWheelsManufacturer(vehicle.Wheels);
            setWheelsCurrentAirPressure(vehicle.Wheels);
            vehicle.OwnerName = getUsersName();
            vehicle.OwnerPhoneNumber = getUsersPhoneNumber();
            vehicle = CreateSpecificTypeOfVehicle(vehicle);

            return vehicle;
        }

        private Vehicle CreateSpecificTypeOfVehicle(Vehicle vehicle)
        {
            if (vehicle is Car)
            {
                vehicle = new CreateCar().populateCarWithDetails(vehicle);
            }
            else if (vehicle is Motorcycle)
            {
                vehicle = new CreateMotorcycle().populateMotorcycleWithDetails(vehicle);
            }
            else
            {
                vehicle = new CreateTruck().populateTruckWithDetails(vehicle);
            }

            return vehicle;
        }

        private string getLicensePlateNumber()
        {
            m_UserDisplay.clearAndDisplayMessage("Please enter the license number of the vehicle you want to add");
            return ValidateUserInput.GetLicensePlateFromUser();
        }

        private VehicleFactory.eVehicleTypes getVehicleType()
        {
            m_UserDisplay.displayMessage("Please choose one of the following vehicle types:");
            return (VehicleFactory.eVehicleTypes)ValidateUserInput.InputIsInRangeOfEnum(typeof(VehicleFactory.eVehicleTypes));
        }

        private Vehicle createVehicleFromFactory(VehicleFactory.eVehicleTypes i_VehcileType)
        {
            return VehicleFactory.CreateVehicle(i_VehcileType);
        }

        private string getCarModel()
        {
            m_UserDisplay.clearAndDisplayMessage("Please enter the vehicle model name");
            string carModelName = ValidateUserInput.ValidateInputInNotEmpty();
            return carModelName;
        }

        private void addWheelsManufacturer(List<Wheel> wheels)
        {
            m_UserDisplay.clearAndDisplayMessage("Please enter Wheels Manufacturer name");
            m_UserDisplay.displayEmpty();
            string ManufacturerOfWheels = ValidateUserInput.ValidateInputInNotEmpty();

            foreach (Wheel wheel in wheels)
            {
                wheel.Manufacturer = ManufacturerOfWheels;
            }
        }

        private void setWheelsCurrentAirPressure(List<Wheel> wheels)
        {
            m_UserDisplay.clearAndDisplayMessage("Please enter the current air pressure of the wheels");
            
            float currentAirPressure = ValidateUserInput.ParseInputToFloat();

            try
            {
                foreach (Wheel wheel in wheels)
                {
                    wheel.PumpAir(currentAirPressure);
                }
            }
            catch (Exception exception)
            {
                m_UserDisplay.displayExceptionMessage(exception);
                setWheelsCurrentAirPressure(wheels);
            }
        }

        private string getUsersName()
        {
            m_UserDisplay.clearAndDisplayMessage("Please tell us your name");
            return ValidateUserInput.ValidateInputInNotEmpty();
        }

        private string getUsersPhoneNumber()
        {
            m_UserDisplay.clearAndDisplayMessage("Please tell us your phone number");
            return ValidateUserInput.ValidateInputInNotEmpty();
        }

        private void setCurrentAmountOfEnergy(Vehicle vehicle)
        {
            if (vehicle.EnergySource is Gas)
            {
                m_UserDisplay.clearAndDisplayMessage("Please enter current amount of fuel in liters");
            }
            else
            {
                m_UserDisplay.clearAndDisplayMessage("Please enter remaining time of engine operation in hours");
            }

            float amountOfEnergy = ValidateUserInput.ParseInputToFloat();

            try
            {
                vehicle.EnergySource.FillEnergy(amountOfEnergy);
            }
            catch (Exception exception)
            {
                m_UserDisplay.displayExceptionMessage(exception);
                setCurrentAmountOfEnergy(vehicle);
            }
        }
    }

}
