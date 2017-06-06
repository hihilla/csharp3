
using System;
using System.Collections.Generic;

namespace Ex03.GarageLogic
{
    abstract class Vehicle
    {
        protected string m_ModelName;
        protected string m_LicenceNumber;
        protected e_EnergyType m_EnergyType; 
        protected Nullable<e_FuelType> m_EnergyType;
        protected float m_CurrentEnergyLevel;
        protected float m_MaximalEnergyLevel;
        protected List<Weel> m_Weels;
        // information for garage
        protected string m_OwnerName;
        protected string m_OwnerPhoneNumber;
        protected e_VehicleState m_VehicleState = e_VehicleState.RepairInProgress;
        
        enum e_EnergyType
        {
            Electric,
            Fuel
        };

        enum e_FuelType
        {
            none,
            Octan95,
            Octan96,
            Octan98,
            Soler
        };

        enum e_VehicleState
        {
            RepairInProgress,
            RepairComplete,
            Paid
        };

        abstract public void AddEnergy(float i_EnergyToAdd, Nullable<e_FuelType> i_EnergyType = null, e_FuelType i_FuelType = e_FuelType.none);
    }
}
