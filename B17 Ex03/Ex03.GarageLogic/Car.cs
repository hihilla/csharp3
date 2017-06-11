namespace Ex03.GarageLogic
{
    using System;
    using System.Text;

    public class Car : Vehicle
    {
        private readonly int r_MaxNumOfDoors;
        private readonly int r_MinNumOfDoors;
        private e_Color m_carColor;
        private int m_numberOfDoors; // {2, 3, 4, 5}

        public Car(
            string i_ModelName,
            string i_LicenceNumber,
            e_EnergyType i_EnergyType,
            Nullable<e_FuelType> i_FuelType,
            float i_CurrentEnergyLevel,
            float i_MaximalEnergyLevel,
            string i_OwnerName,
            string i_OwnerPhoneNumber,
            string[] i_ManufacturerName, float[] i_CurrentAirPressure, float i_MaxAirPressure, int i_NumOfWheels,
            e_Color i_CarColor,
            int i_NumOfDoors)
            : base(i_ModelName, i_LicenceNumber, i_EnergyType, i_FuelType, i_CurrentEnergyLevel, i_MaximalEnergyLevel,
                    i_OwnerName, i_OwnerPhoneNumber, i_ManufacturerName, i_CurrentAirPressure, i_MaxAirPressure, i_NumOfWheels)
        {
            if (i_NumOfDoors < r_MinNumOfDoors || i_CurrentEnergyLevel > r_MaxNumOfDoors)
            {
                throw new ValueOutOfRangeException(r_MinNumOfDoors, r_MaxNumOfDoors, i_NumOfDoors);
            }

            this.m_carColor = i_CarColor;
            this.m_numberOfDoors = i_NumOfDoors;
        }

        public enum e_Color
        {
            Yellow,
            White,
            Black,
            Blue
        }

        public override string ToString()
        {
            StringBuilder carToString = new StringBuilder();
            carToString.AppendFormat("{0} Car\n", this.EnergyType);
            carToString.AppendFormat("The car has {0} doors\nColor: {1}", this.m_numberOfDoors, this.m_carColor);
            carToString.Append(base.ToString());

            return null;
        }
    }
}
