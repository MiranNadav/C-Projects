using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using B18_Ex03;

namespace Ex03.ConsoleUI
{
    class CreateTruck
    {
        private Truck m_NewTruck;
        public CreateTruck(Vehicle i_NewVehicle)
        {
            this.m_NewTruck = (Truck)i_NewVehicle;
            Console.Clear();
            setIfCarryingDangerousMaterials();
            Console.Clear();
            setMaxCarray();
        }

        private void setIfCarryingDangerousMaterials()
        {
            Console.WriteLine("Please choose whether the truck will carry dangerous materials chose Y to 'Yes' and N to 'No'");
            bool IsCarryingDangerousMaterials = ValidatUserInput.validateYesOrNo();
            m_NewTruck.IsCarryingDangerousMaterials = IsCarryingDangerousMaterials;
        }

        private void setMaxCarray()
        {
            Console.WriteLine("Please choose the truck maximum volume of cargo");
            float maximumVolumeOfCargo = ValidatUserInput.ParseInputToFloat();
            m_NewTruck.MaxAllowedWeight = maximumVolumeOfCargo;
        }
    }
}
