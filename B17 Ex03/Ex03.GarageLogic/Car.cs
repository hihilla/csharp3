namespace Ex03.GarageLogic
{
    using System;
    using System.Text;

    public class Car : Vehicle
    {
        private readonly int r_MaxNumOfDoors = 5;
        private readonly int r_MinNumOfDoors = 2;
        private e_Color m_carColor;
        private int m_numberOfDoors; // {2, 3, 4, 5}       

        public Car(
            e_EnergyType i_EnergyType,
            Nullable<e_FuelType> i_FuelType,
            float i_MaximalEnergyLevel,float i_MaxAirPressure, int i_NumOfWheels,
            int i_NumOfDoors)
            : base(i_EnergyType, i_FuelType, i_MaximalEnergyLevel,
                    i_MaxAirPressure, i_NumOfWheels)
        {
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
