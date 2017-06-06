
using System.Collections.Generic;

namespace Ex03.GarageLogic
{
    abstract class Vehicle
    {
        string m_ModelName;
        string m_LicenceNumber;
        float m_CurrentEnergyLevel;
        List<Weel> m_Weels;
    }
}
