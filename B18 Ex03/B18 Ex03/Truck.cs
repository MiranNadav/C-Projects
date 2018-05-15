using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace B18_Ex03
{
    public abstract class Truck : Vehicle
    {
        private bool m_IsCarryingDangerousMaterials;
        private float m_MaxAllowedWeight;
        private const int k_NumberOfWheels = 12;
        private const int k_MaximumWheelPressure = 28;

        public Truck ()
        {
            this.m_IsCarryingDangerousMaterials = false;
            this.m_MaxAllowedWeight = 0;
            base.Wheels = new List<Wheel>(k_NumberOfWheels);
            for (int i = 0; i < k_NumberOfWheels; i++)
            {
                base.Wheels.Add(new Wheel(k_MaximumWheelPressure));
            }

        }

        public bool IsCarryingDangerousMaterials
        {
            get
            {
                return this.m_IsCarryingDangerousMaterials;
            }
            set
            {
                this.m_IsCarryingDangerousMaterials = value;
            }
        }

        public float MaxAllowedWeight
        {
            get
            {
                return this.m_MaxAllowedWeight;
            }
            set
            {
                this.m_MaxAllowedWeight = value;
            }
        }
    }
}
