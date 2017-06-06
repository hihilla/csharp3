
using System;

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

        public override void AddEnergy()
        {
            throw new NotImplementedException();
        }
    }
}
