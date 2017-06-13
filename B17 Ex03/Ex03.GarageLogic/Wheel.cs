﻿using System.Text;
using System.Collections.Generic;
using System;

namespace Ex03.GarageLogic
{
    public class Wheel
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
            set
            {
                m_ManufacturerName = value;
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
            set
            {
                m_CurrentAirPressure = value;    
            }
        }

        public Wheel(float i_MaxAirPressure)
        {
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

        public static List<Wheel> GenerateGeneralWheels(float i_MaxAirPressure, int i_NumberOfWeels)
        {
            List<Wheel> wheels = new List<Wheel>();
            for (int i = 0; i < i_NumberOfWeels; i++)
            {
                wheels.Add(new Wheel(i_MaxAirPressure));
            }
            return wheels;
        }

        //public static List<Wheel> GenerateDifWheels(string[] i_ManufacturerName, float[] i_CurrentAirPressure, float i_MaxAirPressure, int i_NumberOfWeels)
        //{
        //    if (i_ManufacturerName.Length != i_NumberOfWeels ||
        //        i_CurrentAirPressure.Length != i_NumberOfWeels)
        //    {
        //        throw new ArgumentException("Number of inputs inconsisntent");
        //    }
        //    List<Wheel> weels = new List<Wheel>();
        //    for (int i = 0; i < i_NumberOfWeels; i++)
        //    {
        //        if (i_CurrentAirPressure[i] > i_MaxAirPressure)
        //        {
        //            throw new ValueOutOfRangeException(0, i_MaxAirPressure, i_CurrentAirPressure[i]);
        //        }
        //        weels.Add(new Wheel(i_ManufacturerName[i], i_CurrentAirPressure[i], i_MaxAirPressure));
        //    }
        //    return weels;
        //}

        public override string ToString()
        {
            StringBuilder wheelString = new StringBuilder();

            wheelString.AppendFormat("Wheel Manufacturer: {0}, Current wheel pressure: {1}, Maximal wheel pressure {2}",
                this.ManufacturerName, this.CurrentAirPressure, this.m_MaxAirPressure);

            return wheelString.ToString();
        }
    }
}
