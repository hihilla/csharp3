using System.Text;
using System.Collections.Generic;


namespace Ex03.GarageLogic
{
    class Weel
    {
        private string m_ManufacturerName;
        private float m_CurrentAirPressure;
        private float m_MaxAirPressure;

        public override string ToString()
        {
            StringBuilder wheelsState = new StringBuilder();

            wheelsState.Append("Air pressure")
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

        public Weel(string i_ManufacturerName, float i_MaxAirPressure)
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
                throw new ValueOutOfRangeException(0, m_MaxAirPressure, i_AirToAdd);
            }
            else
            {
                m_CurrentAirPressure = newAirPressure;
            }
        }

        public static List<Weel> GenerateWeels(string i_ManufacturerName, float i_MaxAirPressure, int i_NumberOfWeels)
        {
            List<Weel> weels = new List<Weel>();
            for (int i = 0; i < i_NumberOfWeels; i++)
            {
                weels.Add(new Weel(i_ManufacturerName, i_MaxAirPressure));
            }
            return weels;
        }
    }
}
