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

        public AddVehicle(UsertInterface i_UserInterface)
        {
            Console.Clear();
            Console.WriteLine("You have chosen to add a new vehicle");
            this.m_UsertInterface = i_UserInterface;
            getLicensePlateNumber();
            getVehicleTypeAndCreateVhicle();
            m_CreatedVhicle.LicenseNumber = m_LicensePlate;
            getCarModle();
            m_CreatedVhicle.EnergyPercentge = 100f;
            addWheelsManufacturer();
            getUsersName();
            getUsersPhoneNumber();

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

            addVehicleToGarage();
        }


        private void getLicensePlateNumber()
        {
            Console.WriteLine(Messages.k_EnterLicenseNumberMessage);
            string licenseNumber = ValidatUserInput.ValidateInputInNotEmpty();
            this.m_LicensePlate = licenseNumber;
        }

        private void getVehicleTypeAndCreateVhicle()
        {
            Console.WriteLine("Please chose one of the following vehicle types:");
            Console.WriteLine(Messages.getEnumAsString(typeof(VehicleFactory.eVehicleTypes)));
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

        private void addWheelsManufacturer()
        {
            Console.WriteLine("Please enter Wheels Manufacturer name");
            string ManufacturerOfWheels = ValidatUserInput.ValidateInputInNotEmpty();

            foreach (Wheel wheel in m_CreatedVhicle.Wheels)
            {
                wheel.Manufacturer = ManufacturerOfWheels;
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

        private void addVehicleToGarage()
        {
            try
            {
                m_UsertInterface.Garage.AddVehicleToGarage(m_CreatedVhicle);
                Console.WriteLine("Vehicle added to garage");
                Messages.PressAnyKeyToContinue();
            }

            catch (Exception exeption)
            {
                Console.WriteLine(exeption.Message);
                Messages.PressAnyKeyToContinue();
            }
        }
    }

}
