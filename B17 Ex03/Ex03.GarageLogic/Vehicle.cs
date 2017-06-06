
using System.Collections.Generic;

namespace Ex03.GarageLogic
{
    abstract class Vehicle
    {
        protected string m_ModelName;
        protected string m_LicenceNumber;
        protected float m_CurrentEnergyLevel;
        protected List<Weel> m_Weels;
        // information for garage
        protected string m_OwnerName;
        protected string m_OwnerPhoneNumber;
        protected e_VehicleState m_VehicleState = e_VehicleState.RepairInProgress;

        protected enum e_VehicleState
        {
            RepairInProgress,
            RepairComplete,
            RepairPaid
        };

        protected enum e_CarColor
        {
            Yellow,
            White,
            Black,
            Blue
        };
    }
}
