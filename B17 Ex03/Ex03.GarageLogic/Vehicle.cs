
using System;
using System.Collections.Generic;
using System.Text;

namespace Ex03.GarageLogic
{
    internal abstract class Vehicle
    {
        protected string m_ModelName;
        protected string m_LicenceNumber;
        protected Nullable<e_EnergyType> m_EnergyType;
        protected e_FuelType m_FuelType;
        protected float m_CurrentEnergyLevel;
        protected float m_MaximalEnergyLevel;
        protected List<Wheel> m_Wheels;
        // information for garage
        protected string m_OwnerName;
        protected string m_OwnerPhoneNumber;
        protected e_VehicleState m_VehicleState = e_VehicleState.RepairInProgress;
        
        public enum e_EnergyType
        {
            Electric,
            Fuel
        };

        public enum e_FuelType
        {
            none,
            Octan95,
            Octan96,
            Octan98,
            Soler
        };

        public enum e_VehicleState
        {
            RepairInProgress,
            RepairComplete,
            Paid
        };

        public e_VehicleState VehicleState
        {
            get
            {
                return m_VehicleState;
            }
            set
            {
                m_VehicleState = value;
            }
        }

        public List<Wheel> Weels
        {
            get
            {
                return m_Wheels;
            }

        }

        public string LicenceNumber
        {
            get
            {
                return m_LicenceNumber;
            }
        }

        public Nullable<e_EnergyType> EnergyType
        {
            get
            {
                return m_EnergyType;
            }
        }

        public e_FuelType FuelType
        {
            get
            {
                return m_FuelType;

            }
        }

        public float MaximalEnergyLevel
        {
            get
            {
                return m_MaximalEnergyLevel;
            }
        }

        public float CurrentEnergyLevel
        {
            get
            {
                return m_CurrentEnergyLevel;
            }
        }

        protected Vehicle(string i_ModelName, string i_LicenceNumber, e_EnergyType i_EnergyType, e_FuelType i_FuelType,
                            float i_CurrentEnergyLevel, float i_MaximalEnergyLevel, string i_OwnerName, string i_OwnerPhoneNumber,
                            string i_ManufacturerName, float i_MaxAirPressure, int i_NumOfWheels)
        {
            this.m_ModelName = i_ModelName;
            this.m_LicenceNumber = i_LicenceNumber;
            this.m_EnergyType = i_EnergyType;
            this.m_FuelType = i_FuelType;
            this.m_CurrentEnergyLevel = i_CurrentEnergyLevel;
            this.m_MaximalEnergyLevel = i_MaximalEnergyLevel;
            this.m_OwnerName = i_OwnerName;
            this.m_OwnerPhoneNumber = i_OwnerPhoneNumber;
            this.m_Wheels = Wheel.GenerateWheels(i_ManufacturerName, i_MaxAirPressure, i_NumOfWheels);
        }

        public void AddEnergy(float i_EnergyToAdd, Nullable<e_EnergyType> i_EnergyType = null, e_FuelType i_FuelType = e_FuelType.none)
        {
            if (i_EnergyType != this.m_EnergyType)
            {
                throw new ArgumentException("Wrong Energy Type!");
            }
            if (i_FuelType != this.FuelType)
            {
                throw new ArgumentException("Wrong Fuel Type!");
            }
            float newAmount = m_CurrentEnergyLevel + i_EnergyToAdd;
            if ((i_EnergyToAdd < 0) || (newAmount > m_MaximalEnergyLevel))
            {
                float wrongValue = (i_EnergyToAdd < 0) ? i_EnergyToAdd : newAmount;
                throw new ValueOutOfRangeException(0, m_MaximalEnergyLevel, wrongValue);
            }
            this.m_CurrentEnergyLevel = newAmount;
        }

        public override string ToString()
        {
            StringBuilder vehicleString = new StringBuilder();

            vehicleString.Append("Licence number: ");
            vehicleString.Append(m_LicenceNumber);
            vehicleString.Append("\n");

            vehicleString.Append("Model name: ");
            vehicleString.Append(m_ModelName);
            vehicleString.Append("\n");

            vehicleString.Append("Owner's name: ");
            vehicleString.Append(m_OwnerName);
            vehicleString.Append("\n");

            vehicleString.Append("State in garage: ");
            vehicleString.Append(m_VehicleState);
            vehicleString.Append("\n");

            foreach (Wheel wheel in m_Wheels)
            {
                vehicleString.Append(wheel.ToString());
                vehicleString.Append("\n");
            }

            if (this.m_EnergyType == e_EnergyType.Fuel)
            {
                vehicleString.Append(this.m_FuelType);
            }

            vehicleString.Append("Energy level is: ");
            vehicleString.Append(this.m_CurrentEnergyLevel / this.m_MaximalEnergyLevel);
            vehicleString.Append("\n");

            return vehicleString.ToString();
        }
    }
}
