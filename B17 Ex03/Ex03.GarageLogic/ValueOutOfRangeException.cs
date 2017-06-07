using System;

namespace Ex03.GarageLogic
{
    internal class ValueOutOfRangeException : Exception
    {
        private float m_MaxValue;
        private float m_MinValue;

        public float MaxValue
        {
            get
            {
                return m_MaxValue;
            }
            set
            {
                m_MaxValue = value;
            }
        }

        public float MinValue
        {
            get
            {
                return m_MinValue;
            }
            set
            {
                m_MinValue = value;
            }
        }

        public ValueOutOfRangeException(float i_MinValue, float i_MaxValue, float i_OutOfBoundValue)
            : base(string.Format("Input {0} is out of bounds: {1} - {2}", i_OutOfBoundValue, i_MinValue, i_MaxValue))
        {
            m_MinValue = i_MinValue;
            m_MaxValue = i_MaxValue;
        }
    }
}
