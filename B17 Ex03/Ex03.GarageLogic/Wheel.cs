using System.Text;
using System.Collections.Generic;

namespace Ex03.GarageLogic
{
    class Wheel
    {
        private string m_ManufacturerName;
        private float m_CurrentAirPressure;
        private float m_MaxAirPressure;
        
        public string ManufacturerName
        {
            get
            {
                return m_ManufacturerName;
            }
        }

        public float MaxAirPressure
        {
            get
            {
                return m_MaxAirPressure;
            }
        }

        public float CurrentAirPressure
        {
            get
            {
                return m_CurrentAirPressure;
            }
        }

        public Wheel(string i_ManufacturerName, float i_MaxAirPressure)
        {
            // creating a new filled wheel
            this.m_ManufacturerName = i_ManufacturerName;
            this.m_CurrentAirPressure = i_MaxAirPressure;
            this.m_MaxAirPressure = i_MaxAirPressure;
        }

        public void FillAir(float i_AirToAdd)
        {
            float newAirPressure = i_AirToAdd + m_CurrentAirPressure;
            if ((i_AirToAdd <= 0) || (newAirPressure > m_MaxAirPressure))
            {
                float wrongValue = (i_AirToAdd < 0) ? i_AirToAdd : newAirPressure;
                throw new ValueOutOfRangeException(0, m_MaxAirPressure, wrongValue);
            }
            else
            {
                m_CurrentAirPressure = newAirPressure;
            }
        }

        public static List<Wheel> GenerateWheels(string i_ManufacturerName, float i_MaxAirPressure, int i_NumberOfWeels)
        {
            List<Wheel> weels = new List<Wheel>();
            for (int i = 0; i < i_NumberOfWeels; i++)
            {
                weels.Add(new Wheel(i_ManufacturerName, i_MaxAirPressure));
            }
            return weels;
        }

        public override string ToString()
        {
            StringBuilder wheelString = new StringBuilder();

            wheelString.AppendFormat("Wheel Manufacturer: {0}, Current wheel pressure: {1}, Maximal wheel pressure {2}",
                this.ManufacturerName, this.CurrentAirPressure, this.m_MaxAirPressure);

            return wheelString.ToString();
        }
    }
}
