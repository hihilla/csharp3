
namespace Ex03.GarageLogic
{
    abstract class ElectricVehicle : Vehicle
    {
        float m_RemainingRunningTimeInHours;
        float m_MaxRunningTimeInHours;

        public void ChargeBattery(float i_HoursToAddToBattery)
        {
            // מקבלת שעות להוסיף למצבר, מוסיפה כל עוד לא עובר את המקס
        }
    }
}
