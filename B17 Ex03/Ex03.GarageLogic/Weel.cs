
namespace Ex03.GarageLogic
{
    class Weel
    {
        private string m_ManufacturerName;
        private float m_CurrentAirPressure;
        private float m_MaxAirPressure;

        public float MaxAirPressure
        {
            get
            {
                return m_MaxAirPressure;
            }
        }

        public void FillAir(float i_AirToAdd)
        {
            // מקבלת כמה אוויר להוסיף לגלגל, משנה לחץ אוויר אם הוא לא חורג מהמקס
        }
    }
}
