
namespace Ex03.GarageLogic
{
    abstract class FuelVehicle : Vehicle
    {
        enum e_FuelType
        {
            Soler,
            Octan95,
            Octan96,
            Octan98
        };

        e_FuelType m_FuelType;
        float m_CurrentFuelLevelLiters;
        float m_MaxFuelLevelLiters;

        public void AddFuel(float m_LitersToAdd)
        {
            // מוסיפה ליטרים כל עוד לא עובר מקס
        }
    }
}
