using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using B18_Ex03;

namespace Ex03.ConsoleUI
{
    class UserInterface
    {

        private static readonly Garage sr_Garage = new Garage();

        public static void ServeUser()
        {
            //Console.WriteLine(Messages.k_WelcomeUserMessage);
            //Console.WriteLine();
            Console.WriteLine(Messages.k_Menu);
            Messages.eMainMenuOptions userChoise = ValidateUserInputs.ValidateMenuOption();
            insertNewVehicle();
            //while (userChoise == Messages.eMainMenuOptions.Exit)
            //{
            //    switchEnumToMethods(userChoise);
            //}
        }

        //private static void switchEnumToMethods(Messages.eMainMenuOptions i_EMainMenuOptions)
        //{
        //    switch (i_EMainMenuOptions)
        //    {
        //        case eMainMenuOptions.AddNewVehicle:
        //            insertNewVehicleToGarage();
        //            break;
        //        case eMainMenuOptions.ChangeStatus:
        //            changeVehicleStatus();
        //            break;
        //        case eMainMenuOptions.DisplayAllLicensePlates:
        //            displayAllLicensePlates();
        //            break;
        //        case eMainMenuOptions.DisplayLicensePlatesByFilter:
        //            displayLicensePlatesByFilter();
        //            break;
        //        case eMainMenuOptions.DisplayVehicleDetails:
        //            displayVehicleDetails();
        //            break;
        //        case eMainMenuOptions.InflateWheels:
        //            inflateWheels();
        //            break;
        //        case eMainMenuOptions.RechargeElectricEngine:
        //            rechargeElectricEngine();
        //            break;
        //        case eMainMenuOptions.RefuelFuelEngine:
        //            refuelFuelEngine();
        //            break;
        //        case eMainMenuOptions.Exit:
        //            exit();
        //            break;
        //    }
        //}
        public static void insertNewVehicle()
        {
            Console.WriteLine("You have chosen to add a new Vehicle to the garage. Please enter the license number of the new vehicle");
            string licenseNumberOfTheNewVehicle = ValidateUserInputs.ValidateImputIsNotEmpty();
            createAndAddVehicle(licenseNumberOfTheNewVehicle);
            UserInterface.ServeUser();
        }

        private static void createAndAddVehicle(string i_LicenseNumberOfTheNewVehicle)
        {
            Console.WriteLine("Please Choose the type of the new vehicle");
            string enumToString = Messages.getEnumAsString(typeof(VehicleFactory.eVehicleTypes));
            Console.WriteLine(enumToString);
            int vehcileTypeAsInt = ValidateUserInputs.ParseUserInputToInt();
            createNewVehicle(vehcileTypeAsInt, i_LicenseNumberOfTheNewVehicle);
        }

        private static void createNewVehicle(int i_VehcileTypeAsInt, string i_LicenseNumberOfTheNewVehicle)
        {
            Vehicle newVehicle = null;

            try
            {
                newVehicle = VehicleFactory.CreateVehicle(i_VehcileTypeAsInt);
                newVehicle.LicenseNumber = i_LicenseNumberOfTheNewVehicle;
                sr_Garage.AddVehicleToGarage(newVehicle);
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);

                if (ex is ArgumentException)
                {
                    createAndAddVehicle(i_LicenseNumberOfTheNewVehicle);
                }
            }

            Console.Clear();
            Console.WriteLine("Vehicle added to the garage");
            Console.WriteLine();
        }
    }

}

