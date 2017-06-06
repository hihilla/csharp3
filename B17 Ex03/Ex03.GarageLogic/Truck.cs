
using System;

namespace Ex03.GarageLogic
{
    class Truck : Vehicle
    {
        bool m_IsCarryingHazardousMaterials;
        float m_MaxCarryingWeight;

        public override void AddEnergy(float i_EnergyToAdd, e_FuelType? i_EnergyType = default(e_FuelType?), e_FuelType i_FuelType = e_FuelType.none)
        {
            throw new NotImplementedException();
        }
    }
}
