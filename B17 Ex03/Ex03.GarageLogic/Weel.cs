
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
            float newAirPressure = i_AirToAdd + m_CurrentAirPressure;
            if ((i_AirToAdd <= 0) || (newAirPressure > m_MaxAirPressure))
            {
                throw new ValueOutOfRangeException(0, m_MaxAirPressure, i_AirToAdd);
            }
            else
            {
                m_CurrentAirPressure = newAirPressure;
            }
        }
    }
}
