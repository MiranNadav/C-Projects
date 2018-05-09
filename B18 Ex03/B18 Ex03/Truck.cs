using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace B18_Ex03
{
    class Truck : Vehicle
    {
        private bool m_IsCarryingDangerousMaterials;
        private float m_MaxAllowedWeight;

        public Truck (bool i_IsCarryingDangerousMaterials, float i_MaxAllowedWeight)
        {
            base()
            this.m_IsCarryingDangerousMaterials = i_IsCarryingDangerousMaterials;
            this.m_MaxAllowedWeight = i_MaxAllowedWeight;
        }
    }
}
