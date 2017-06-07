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
            
            motorcycleToString.AppendFormat("The motorcycle has licence type {0} and engine capacity of {1} CCM", this.m_LicenceType, this.m_EngineCapacity);
            motorcycleToString.Append(base.ToString());

            return motorcycleToString.ToString();
        }
    }
}
