
using System;
using System.Text;

namespace Ex03.GarageLogic
{
    class Car : Vehicle
    {
        private e_Color m_CarColor;
        private int m_NumberOfDoors; // {2, 3, 4, 5}

        public enum e_Color
        {
            Yellow,
            White,
            Black,
            Blue
        };

        public override string ToString()
        {
            StringBuilder carToString = new StringBuilder();
            carToString.AppendFormat("{0} Car\n", this.EnergyType);
            carToString.AppendFormat("The car has {0} doors\nColor: {1}", this.m_NumberOfDoors, this.m_CarColor);
            carToString.Append(base.ToString());

            return null;
        }

        public Car(string i_ModelName, string i_LicenceNumber, e_EnergyType i_EnergyType, e_FuelType i_FuelType,
            float i_CurrentEnergyLevel, float i_MaximalEnergyLevel, string i_OwnerName, string i_OwnerPhoneNumber,
            string i_ManufacturerName, float i_MaxAirPressure, int i_NumOfWheels, e_Color i_CarColor, int i_NumOfDoors) :
            base(i_ModelName, i_LicenceNumber, i_EnergyType, i_FuelType, i_CurrentEnergyLevel, i_MaximalEnergyLevel,
            i_OwnerName, i_OwnerPhoneNumber, i_ManufacturerName, i_MaxAirPressure, i_NumOfWheels)
        {
            this.m_CarColor = i_CarColor;
            this.m_NumberOfDoors = i_NumOfDoors;
        }
    }
}
