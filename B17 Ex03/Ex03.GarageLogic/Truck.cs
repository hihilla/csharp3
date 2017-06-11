
using System;
using System.Text;

namespace Ex03.GarageLogic
{
    public class Truck : Vehicle
    {
        bool m_IsCarryingHazardousMaterials;
        float m_MaxCarryingWeight;

        public Truck(string i_ModelName, string i_LicenceNumber, e_EnergyType i_EnergyType, e_FuelType i_FuelType,
                    float i_CurrentEnergyLevel, float i_MaximalEnergyLevel, string i_OwnerName, string i_OwnerPhoneNumber,
                    string i_ManufacturerName, float i_MaxAirPressure, int i_NumOfWheels, bool i_IsCarryingHazardousMaterials,
                    float i_MaxCarryingWeight) 
            : base(i_ModelName, i_LicenceNumber, i_EnergyType, i_FuelType, i_CurrentEnergyLevel,
                    i_MaximalEnergyLevel, i_OwnerName, i_OwnerPhoneNumber, i_ManufacturerName, i_MaxAirPressure, i_NumOfWheels)
        {
            this.m_IsCarryingHazardousMaterials = i_IsCarryingHazardousMaterials;
            this.m_MaxCarryingWeight = i_MaxCarryingWeight;
        }

        public override string ToString()
        {
            StringBuilder truckToString = new StringBuilder();
            truckToString.Append("Truck\n");

            if (m_IsCarryingHazardousMaterials)
            {
                truckToString.Append("This truck carries hazardous materials\n");
            }
            else
            {
                truckToString.Append("This truck doesn't carry any hazardous materials\n");
            }

            truckToString.AppendFormat("Maximux carrying weight: {0}\n", m_MaxCarryingWeight);
            truckToString.Append(base.ToString());

            return truckToString.ToString();
        }
    }
}
