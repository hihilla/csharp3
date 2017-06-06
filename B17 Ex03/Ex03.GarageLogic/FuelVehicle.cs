
namespace Ex03.GarageLogic
{
    abstract class FuelVehicle : Vehicle
    {
        protected enum e_FuelType
        {
            Soler,
            Octan95,
            Octan96,
            Octan98
        };

        protected e_FuelType m_FuelType;
        protected float m_CurrentFuelLevelLiters;
        protected float m_MaxFuelLevelLiters;

        public void AddFuel(float m_LitersToAdd)
        {
            // מוסיפה ליטרים כל עוד לא עובר מקס
        }
    }
}
