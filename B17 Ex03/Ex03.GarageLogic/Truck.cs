
using System;

namespace Ex03.GarageLogic
{
    class Truck : Vehicle
    {
        bool m_IsCarryingHazardousMaterials;
        float m_MaxCarryingWeight;

        public override void AddEnergy()
        {
            throw new NotImplementedException();
        }
    }
}
