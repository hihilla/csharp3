
using System.Collections.Generic;

namespace Ex03.GarageLogic
{
    abstract class Vehicle
    {
        string m_ModelName;
        string m_LicenceNumber;
        float m_CurrentEnergyLevel;
        List<Weel> m_Weels;
        // information for garage
        string m_OwnerName;
        string m_OwnerPhoneNumber;
        e_VehicleState m_VehicleState = e_VehicleState.RepairInProgress;

        enum e_VehicleState
        {
            RepairInProgress,
            RepairComplete,
            RepairPaid
        };
    }
}
