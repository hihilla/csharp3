
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
            if (i_AirToAdd <= 0)
            {
                throw new ValueOutOfRangeException("Too little air");
            }
            float newAirPressure = i_AirToAdd + m_CurrentAirPressure;
            if (newAirPressure > m_MaxAirPressure)
            {
                throw new ValueOutOfRangeException("Too much air");
            }
            else
            {
                m_CurrentAirPressure = newAirPressure;
            }
        }
    }
}
