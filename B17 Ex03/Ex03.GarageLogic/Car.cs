
using System;
using System.Text;

namespace Ex03.GarageLogic
{
    class Car : Vehicle
    {
        private e_Color m_CarColor;
        private int m_NumberOfDoors; // {2, 3, 4, 5}

        enum e_Color
        {
            Yellow,
            White,
            Black,
            Blue
        };

        public override string ToString()
        {
            StringBuilder carToString = new StringBuilder();
            carToString.Append("Car\n");
            carToString.AppendFormat("The car has {0} doors\nColor: {1}", this.m_NumberOfDoors, this.m_CarColor);
            carToString.Append(base.ToString());

            return null;
        }
    }
}
