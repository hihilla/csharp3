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
    }
}
