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
        private UsertInterface m_UsertInterface;
        private string m_LicensePlate;
        private VehicleFactory.eVehicleTypes m_VehcileType;
        private Vehicle m_CreatedVhicle;
        private bool m_VehicleIsAllReadyInTheGarage = false;

        public AddVehicle(UsertInterface i_UserInterface)
        {
            this.m_UsertInterface = i_UserInterface;
            Console.Clear();
            Console.WriteLine("You have chosen to add a new vehicle");

            getVehicleTypeAndCreateVhicle();
            Console.Clear();
            getLicensePlateNumber();
            Console.Clear();
            addVehicleToGarage();

            if (!m_VehicleIsAllReadyInTheGarage)
            {
                Console.Clear();
                getCarModle();
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

                if (m_VehcileType.Equals(VehicleFactory.eVehicleTypes.ElectricCar) || m_VehcileType.Equals(VehicleFactory.eVehicleTypes.GasCar))
                {
                    CreateCar createCar = new CreateCar(m_CreatedVhicle);
                }
                else if (m_VehcileType.Equals(VehicleFactory.eVehicleTypes.ElectricMotorcycle) || m_VehcileType.Equals(VehicleFactory.eVehicleTypes.GasMotorcycle))
                {
                    CreateMotorcycle createMotorcycle = new CreateMotorcycle(m_CreatedVhicle);
                }
                else
                {
                    CreateTruck createTruck = new CreateTruck(m_CreatedVhicle);

                }

                Console.Clear();
                Console.WriteLine("Vehicle added to garage");
                Messages.PressAnyKeyToContinue();
            }
        }


        private void getLicensePlateNumber()
        {
            Console.WriteLine(Messages.k_EnterLicenseNumberMessage);
            string licenseNumber = ValidatUserInput.ValidateInputInNotEmpty();
            this.m_LicensePlate = licenseNumber;
            m_CreatedVhicle.LicenseNumber = m_LicensePlate;
        }

        private void getVehicleTypeAndCreateVhicle()
        {
            Console.WriteLine("Please choose one of the following vehicle types:");
            VehicleFactory.eVehicleTypes usersVehicleTypeChoise = (VehicleFactory.eVehicleTypes)ValidatUserInput.InputIsInRangeOfEnum(typeof(VehicleFactory.eVehicleTypes));
            m_VehcileType = usersVehicleTypeChoise;
            m_CreatedVhicle = VehicleFactory.CreateVehicle(usersVehicleTypeChoise);
        }

        private void getCarModle()
        {
            Console.WriteLine("Please enter the vehicle model name");
            string carModleName = ValidatUserInput.ValidateInputInNotEmpty();
            m_CreatedVhicle.ModelName = carModleName;
        }

        private void setEnergyPercentage()
        {
            m_CreatedVhicle.SetEnergyPercentge();
        }

        private void addWheelsManufacturer()
        {
            Console.WriteLine("Please enter Wheels Manufacturer name");
            string ManufacturerOfWheels = ValidatUserInput.ValidateInputInNotEmpty();

            foreach (Wheel wheel in m_CreatedVhicle.Wheels)
            {
                wheel.Manufacturer = ManufacturerOfWheels;
            }
        }

        private void setWheelsCurrentAirPressure()
        {
            Console.WriteLine("Please enter the current air pressure of the wheels");
            float currentAirPressure = ValidatUserInput.ParseInputToFloat();
            try
            {
                foreach (Wheel wheel in m_CreatedVhicle.Wheels)
                {
                    wheel.PumpAir(currentAirPressure);
                }
            }
            catch (Exception exeption)
            {
                Console.Clear();
                Console.WriteLine(exeption.Message);
                Console.WriteLine("Please try again");
                setWheelsCurrentAirPressure();
            }
        }

        private void getUsersName()
        {
            Console.WriteLine("Please tell us your name");
            string OwnersName = ValidatUserInput.ValidateInputInNotEmpty();
            m_CreatedVhicle.OwnerName = OwnersName;
        }

        private void getUsersPhoneNumber()
        {
            Console.WriteLine("Please tell us your phone number");
            string OwnersPhoneNumber = ValidatUserInput.ValidateInputInNotEmpty();
            m_CreatedVhicle.OwnerPhoneNumber = OwnersPhoneNumber;
        }

        private void setCurrentAmountOfEnergy()
        {
            if (m_CreatedVhicle.EnergySource.EnergyType.Equals(EnergySource.eEnergyTypes.Gas))
            {
                Console.WriteLine("Please enter current amount of fuel in liters");
            }
            else
            {
                Console.WriteLine("Please enter remaining time of engine operation in hours");
            }

            float amountOfEnergy = ValidatUserInput.ParseInputToFloat();

            try
            {
                m_CreatedVhicle.EnergySource.FillEnergy(amountOfEnergy);
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
                m_UsertInterface.Garage.AddVehicleToGarage(m_CreatedVhicle);
            }

            catch (Exception exeption)
            {
                m_VehicleIsAllReadyInTheGarage = true;
                Console.Clear();
                Console.WriteLine(exeption.Message);
                Messages.PressAnyKeyToContinue();
            }
        }
    }

}
