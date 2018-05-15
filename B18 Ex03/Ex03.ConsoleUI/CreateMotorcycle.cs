﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using B18_Ex03;

namespace Ex03.ConsoleUI
{
    class CreateMotorcycle
    {
        private Motorcycle m_NewMotorcycle;
        public CreateMotorcycle(Vehicle i_NewVehicle)
        {
            this.m_NewMotorcycle = (Motorcycle)i_NewVehicle;
            Console.Clear();
            assignLicenseType();
            Console.Clear();
            setEngineVolume();
        }

        private void assignLicenseType()
        {
            Console.WriteLine("Please choose  Motorcycle LicenseType: ");
            Console.WriteLine(Messages.getEnumAsString(typeof(Motorcycle.eLicenseType)));
            m_NewMotorcycle.LicenseType = (Motorcycle.eLicenseType)ValidatUserInput.InputIsInRangeOfEnum(typeof(Motorcycle.eLicenseType));
        }

        private void setEngineVolume()
        {
            Console.WriteLine("Please choose the engine volume");
            int engineVolume = ValidatUserInput.ParseInputToInt();
            m_NewMotorcycle.EngineSize = engineVolume;
        }
    }
}