
namespace Ex03.GarageLogic
{
    class Car : Vehicle
    {
        enum e_CarColor
        {
            Yellow,
            White,
            Black,
            Blue
        };

        e_CarColor m_CarColor;
        int m_NumberOfDoors; //{2, 3, 4, 5}
    }
}
