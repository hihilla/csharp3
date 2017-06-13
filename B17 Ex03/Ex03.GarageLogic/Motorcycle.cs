using System;
using System.Collections.Generic;
using System.Text;

namespace Ex03.GarageLogic
{
    public class Motorcycle : Vehicle
    {
        private e_LicenceType m_LicenceType;
        private int m_EngineCapacity;

        private readonly string r_LicenceTypeKey = "Licence Type";
        private readonly string r_EngineCapacityKey = "Engine Capacity (CCM)";

        public Motorcycle(e_EnergyType i_EnergyType, e_FuelType? i_FuelType, float i_MaximalEnergyLevel, float i_MaxAirPressure, int i_NumOfWheels) 
            : base(i_EnergyType, i_FuelType, i_MaximalEnergyLevel, i_MaxAirPressure, i_NumOfWheels)
        {
        }

        //public Motorcycle(e_EnergyType i_EnergyType, Nullable<e_FuelType> i_FuelType, float i_MaximalEnergyLevel,
        //                                       float i_MaxAirPressure, int i_NumOfWheels) 
        //                          : base(i_EnergyType, i_FuelType, i_MaximalEnergyLevel, i_MaxAirPressure, i_NumOfWheels)
        //{
        //}

        public enum e_LicenceType
        {
            A,
            AB,
            A2,
            B1
        }

        public override string ToString()
        {
            StringBuilder motorcycleToString = new StringBuilder();
            motorcycleToString.AppendFormat("{0} Motorcycle\n", this.EnergyType);

            motorcycleToString.AppendFormat("Licence type :{0}\nEngine capacity: {1} CCM\n", this.m_LicenceType, this.m_EngineCapacity);
            motorcycleToString.Append(base.ToString());

            return motorcycleToString.ToString();
        }

        public override Dictionary<string, string> NeededInputs()
        {
            Dictionary<string, string> neededInputs = new Dictionary<string, string>();
            neededInputs.Add(r_LicenceTypeKey, null);
            neededInputs.Add(r_EngineCapacityKey, null);

            return neededInputs;
        }
    }
}
