using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using B18_Ex03;

namespace Ex03.ConsoleUI
{
    class AddVehicle
    {
        private UserInterface m_UserInterface;
        private string m_LicensePlate;
        private VehicleFactory.eVehicleTypes m_VehcileType;
        private Vehicle m_CreatedVehicle;
        private bool m_VehicleIsAllReadyInTheGarage = false;
        
        public AddVehicle(UserInterface i_UserInterface)
        {
            this.m_UserInterface = i_UserInterface;
            Console.Clear();
            Console.WriteLine("You have chosen to add a new vehicle");

            getVehicleType();
            createVehicleFromFactory();
            Console.Clear();
            getLicensePlateNumber();
            Console.Clear();
            addVehicleToGarage();

            if (!m_VehicleIsAllReadyInTheGarage)
            {
                Console.Clear();
                getCarModel();
                Console.Clear();
                setCurrentAmountOfEnergy();
                Console.Clear();
                setEnergyPercentage();
                Console.Clear();
                addWheelsManufacturer();
                Console.Clear();
                setWheelsCurrentAirPressure();
                Console.Clear();
                getUsersName();
                Console.Clear();
                getUsersPhoneNumber();
                Console.Clear();

                if (m_CreatedVehicle is Car)
                {
                    CreateCar createCar = new CreateCar(m_CreatedVehicle);
                }
                else if (m_CreatedVehicle is Motorcycle)
                {
                    CreateMotorcycle createMotorcycle = new CreateMotorcycle(m_CreatedVehicle);
                }
                else
                {
                    CreateTruck createTruck = new CreateTruck(m_CreatedVehicle);
                }

                Console.Clear();
                Console.WriteLine("Vehicle added to garage");
                Messages.PressAnyKeyToContinue();
            }
        }


        private void getLicensePlateNumber()
        {
            m_LicensePlate = ValidateUserInput.GetLicensePlateFromUser("Please enter the license number of the vehicle you want to add");
            m_CreatedVehicle.LicenseNumber = m_LicensePlate;
        }

        private void getVehicleType()
        {
            Console.WriteLine("Please choose one of the following vehicle types:");
            m_VehcileType = (VehicleFactory.eVehicleTypes)ValidateUserInput.InputIsInRangeOfEnum(typeof(VehicleFactory.eVehicleTypes));
        }

        private void createVehicleFromFactory ()
        {
            m_CreatedVehicle = VehicleFactory.CreateVehicle(m_VehcileType);
        }

        private void getCarModel()
        {
            Console.WriteLine("Please enter the vehicle model name");
            string carModelName = ValidateUserInput.ValidateInputInNotEmpty();
            m_CreatedVehicle.ModelName = carModelName;
        }

        private void setEnergyPercentage()
        {
            m_CreatedVehicle.SetEnergyPercentge();
        }

        private void addWheelsManufacturer()
        {
            Console.WriteLine("Please enter Wheels Manufacturer name");
            string ManufacturerOfWheels = ValidateUserInput.ValidateInputInNotEmpty();

            foreach (Wheel wheel in m_CreatedVehicle.Wheels)
            {
                wheel.Manufacturer = ManufacturerOfWheels;
            }
        }

        private void setWheelsCurrentAirPressure()
        {
            Console.WriteLine("Please enter the current air pressure of the wheels");
            float currentAirPressure = ValidateUserInput.ParseInputToFloat();

            try
            {
                foreach (Wheel wheel in m_CreatedVehicle.Wheels)
                {
                    wheel.PumpAir(currentAirPressure);
                }
            }
            catch (Exception exception)
            {
                Console.Clear();
                Console.WriteLine(exception.Message);
                Console.WriteLine("Please try again");
                setWheelsCurrentAirPressure();
            }
        }

        private void getUsersName()
        {
            Console.WriteLine("Please tell us your name");
            string OwnersName = ValidateUserInput.ValidateInputInNotEmpty();
            m_CreatedVehicle.OwnerName = OwnersName;
        }

        private void getUsersPhoneNumber()
        {
            Console.WriteLine("Please tell us your phone number");
            string OwnersPhoneNumber = ValidateUserInput.ValidateInputInNotEmpty();
            m_CreatedVehicle.OwnerPhoneNumber = OwnersPhoneNumber;
        }

        private void setCurrentAmountOfEnergy()
        {
            //if (m_CreatedVehicle.EnergySource.EnergyType.Equals(EnergySource.eEnergyTypes.Gas))
            if (m_CreatedVehicle.EnergySource is Gas)
            {
                Console.WriteLine("Please enter current amount of fuel in liters");
            }
            else
            {
                Console.WriteLine("Please enter remaining time of engine operation in hours");
            }

            float amountOfEnergy = ValidateUserInput.ParseInputToFloat();

            try
            {
                m_CreatedVehicle.EnergySource.FillEnergy(amountOfEnergy);
            }
            catch (Exception exception)
            {
                Console.Clear();
                Console.WriteLine(exception.Message);
                Console.WriteLine("Please try again");
                setCurrentAmountOfEnergy();
            }
        }

        private void addVehicleToGarage()
        {
            try
            {
                m_UserInterface.Garage.AddVehicleToGarage(m_CreatedVehicle);
            }

            catch (Exception exception)
            {
                m_VehicleIsAllReadyInTheGarage = true;
                Console.Clear();
                Console.WriteLine(exception.Message);
                Messages.PressAnyKeyToContinue();
            }
        }
    }

}
