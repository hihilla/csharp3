
using System;

namespace Ex03.GarageLogic
{
    class Truck : Vehicle
    {
        bool m_IsCarryingHazardousMaterials;
        float m_MaxCarryingWeight;

        public override void AddEnergy(float i_EnergyToAdd, Nullable<e_FuelType> i_EnergyType = null, e_FuelType i_FuelType = e_FuelType.none)
        {
            throw new NotImplementedException();
        }
    }
}
