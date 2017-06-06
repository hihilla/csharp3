using System;

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

        public override void AddEnergy(float i_EnergyToAdd, e_FuelType? i_EnergyType = default(e_FuelType?), e_FuelType i_FuelType = e_FuelType.none)
        {
            throw new NotImplementedException();
        }
    }
}
