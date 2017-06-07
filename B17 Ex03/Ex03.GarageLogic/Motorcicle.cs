using System;
using System.Text;

namespace Ex03.GarageLogic
{
    class Motorcicle : Vehicle
    {
        private e_LicenceType m_LicenceType;
        private int m_EngineCapacity;

        enum e_LicenceType
        {
            A,
            AB,
            A2,
            B1
        };

        public override string ToString()
        {
            StringBuilder motorcycleToString = new StringBuilder();
            motorcycleToString.Append("Motorcycle\n");
            
            motorcycleToString.AppendFormat("Licence type :{0}\nEngine capacity: {1} CCM\n", this.m_LicenceType, this.m_EngineCapacity);
            motorcycleToString.Append(base.ToString());

            return motorcycleToString.ToString();
        }
    }
}
