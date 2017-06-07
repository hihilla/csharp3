using System;
using System.Text;

namespace Ex03.GarageLogic
{
    internal class Motorcycle : Vehicle
    {
        private e_LicenceType m_LicenceType;
        private int m_EngineCapacity;

        public enum e_LicenceType
        {
            A,
            AB,
            A2,
            B1
        }

        public Motorcycle(string i_ModelName, string i_LicenceNumber, e_EnergyType i_EnergyType, e_FuelType i_FuelType,
                          float i_CurrentEnergyLevel, float i_MaximalEnergyLevel, string i_OwnerName, string i_OwnerPhoneNumber,
                          string i_ManufacturerName, float i_MaxAirPressure, int i_NumOfWheels, e_LicenceType i_LicenceType,
                          int i_EngineCapacity) 
            : base(i_ModelName, i_LicenceNumber, i_EnergyType, i_FuelType, i_CurrentEnergyLevel,
                    i_MaximalEnergyLevel, i_OwnerName, i_OwnerPhoneNumber, i_ManufacturerName, i_MaxAirPressure, i_NumOfWheels)
        {
            this.m_LicenceType = i_LicenceType;
            this.m_EngineCapacity = i_EngineCapacity;
        }

        public override string ToString()
        {
            StringBuilder motorcycleToString = new StringBuilder();
            motorcycleToString.AppendFormat("{0} Motorcycle\n", this.EnergyType);
            
            motorcycleToString.AppendFormat("Licence type :{0}\nEngine capacity: {1} CCM\n", this.m_LicenceType, this.m_EngineCapacity);
            motorcycleToString.Append(base.ToString());

            return motorcycleToString.ToString();
        }
    }
}
