
using System;
using System.Collections.Generic;
using System.Text;

namespace Ex03.GarageLogic
{
    public abstract class Vehicle
    {
        protected string m_ModelName;
        protected string m_LicenceNumber;
        protected eEnergyType m_EnergyType;//
        protected Nullable<eFuelType> m_FuelType;//
        protected float m_CurrentEnergyLevel;
        protected float m_MaximalEnergyLevel;//
        protected List<Wheel> m_Wheels;// Max air pressure + num wheels
        // information for garage
        protected string m_OwnerName;
        protected string m_OwnerPhoneNumber;
        protected eVehicleState m_VehicleState = eVehicleState.RepairInProgress;

        private static readonly string sr_ModelNameKey = "Model Name";
        private static readonly string sr_LicenceNumberKey = "Licence Number";
        private static readonly string sr_CurrentEnergyLevelKey = "Current Energy Level";
        private static readonly string sr_OwnerNameKey = "Owner Name";
        private static readonly string sr_OwnerPhoneNumberKey = "Owners Phone Number";
        private static readonly string sr_WheelsAirPressureKey = "Wheels current air pressure";
        private static readonly string sr_WheelsManufacturerKey = "Wheels Manufacturer";

        public Dictionary<string, string> VehicleInput()
        {
            Dictionary<string, string> inputNeeded = new Dictionary<string, string>();

            inputNeeded.Add(sr_ModelNameKey, null);
            inputNeeded.Add(sr_LicenceNumberKey, null);
            inputNeeded.Add(sr_CurrentEnergyLevelKey, null);
            inputNeeded.Add(sr_OwnerNameKey, null);
            inputNeeded.Add(sr_OwnerPhoneNumberKey, null);
            inputNeeded.Add(sr_WheelsAirPressureKey, null);
            inputNeeded.Add(sr_WheelsManufacturerKey, null);

            return inputNeeded;
        }

        public abstract Dictionary<string, string> NeededInputs();

        public Dictionary<string, string> InputForExistingVehicle()
        {
            Dictionary<string, string> inputNeeded = new Dictionary<string, string>();

            inputNeeded.Add(sr_CurrentEnergyLevelKey, null);
            inputNeeded.Add(sr_WheelsAirPressureKey, null);

            return inputNeeded;
        }

        public void ParseExsitcingVehicleInput(Dictionary<string, string> i_VehicleInput){
			string tempStringBeforeParsing;
			float curEnergyLevel;
            string airPressures;

			if (!((i_VehicleInput.TryGetValue(sr_CurrentEnergyLevelKey, out tempStringBeforeParsing)) &&
				  (float.TryParse(tempStringBeforeParsing, out curEnergyLevel))))
			{
				throw new FormatException("No Current Energy Level");
			}

			if (!i_VehicleInput.TryGetValue(sr_WheelsAirPressureKey, out airPressures))
			{
				throw new FormatException("No Wheels air pressure");
			}

            this.m_CurrentEnergyLevel = curEnergyLevel;
            parseWheelAirPressure(airPressures);
        }

        public void ParseVehicleInput(Dictionary<string, string> i_VehicleInput)
        {
            string modelName;
            string licenceNumber;
            string tempStringBeforeParsing;
            float curEnergyLevel;
            string ownerName;
            string ownerPhoneNumber;
            string airPressures;
            string wheelsManufacturers;

            if (!i_VehicleInput.TryGetValue(sr_ModelNameKey, out modelName))
            {
                throw new FormatException("No Model Name");
            }

            if (!i_VehicleInput.TryGetValue(sr_LicenceNumberKey, out licenceNumber))
            {
                throw new FormatException("No Licence Number");
            }

            if (!((i_VehicleInput.TryGetValue(sr_CurrentEnergyLevelKey, out tempStringBeforeParsing)) &&
                  (float.TryParse(tempStringBeforeParsing, out curEnergyLevel))))
            {
                throw new FormatException("No Current Energy Level");
            }

            if (!i_VehicleInput.TryGetValue(sr_OwnerNameKey, out ownerName))
            {
                throw new FormatException("No Owner Name");
            }

            if (!i_VehicleInput.TryGetValue(sr_OwnerPhoneNumberKey, out ownerPhoneNumber))
            {
                throw new FormatException("No Owner Phone Number");
            }

            if (!i_VehicleInput.TryGetValue(sr_WheelsAirPressureKey, out airPressures))
            {
                throw new FormatException("No Wheels air pressure");
            }

            if (!i_VehicleInput.TryGetValue(sr_WheelsManufacturerKey, out wheelsManufacturers))
            {
                throw new FormatException("No Wheels manufacturers");
            }

            this.m_ModelName = modelName;
            this.m_LicenceNumber = licenceNumber;
            this.m_CurrentEnergyLevel = curEnergyLevel;
            this.m_OwnerName = ownerName;
            this.m_OwnerPhoneNumber = ownerPhoneNumber;
            parseWheelAirPressure(airPressures);
            parseWheelManufacturers(wheelsManufacturers);
        }

        private void parseWheelAirPressure(string i_AirPressures)
        {
            string[] airPressures = i_AirPressures.Split(',');

            if (airPressures.Length == 1)
            {
                parseWheelOneAirPressure(i_AirPressures);
                return;
            }

            if (airPressures.Length != this.m_Wheels.Count)
            {
                string exceptionMsg = string.Format("Not Enough arguments. There are {0} wheels, and {1} arguments",
                                                    this.m_Wheels.Count, airPressures.Length);
                throw new ArgumentException(exceptionMsg);
            }

            for (int i = 0; i < airPressures.Length; i++)
            {
                float wheelAirPressure;
                if (!float.TryParse(airPressures[i], out wheelAirPressure))
                {
                    throw new FormatException("Air Pressure must be a float");
                }

                this.m_Wheels[i].CurrentAirPressure = wheelAirPressure;
            }
        }

        private void parseWheelManufacturers(string i_Manufacturers)
        {
            string[] manufacturers = i_Manufacturers.Split(',');

            if (manufacturers.Length == 1)
            {
                parseWheelOneManufacturer(i_Manufacturers);
                return;
            }

            if (manufacturers.Length != this.m_Wheels.Count)
            {
                string exceptionMsg = string.Format("Number of arguments is not compatible. There are {0} wheels, and {1} arguments",
                                                    this.m_Wheels.Count, manufacturers.Length);
                throw new ArgumentException(exceptionMsg);
            }

            for (int i = 0; i < manufacturers.Length; i++)
            {
                this.m_Wheels[i].ManufacturerName = manufacturers[i];
            }
        }

        private void parseWheelOneManufacturer(string i_Manufacturer)
        {
            for (int i = 0; i < m_Wheels.Count; i++)
            {
                this.m_Wheels[i].ManufacturerName = i_Manufacturer;
            }
        }

        private void parseWheelOneAirPressure(string i_AirPressure)
        {
            for (int i = 0; i < m_Wheels.Count; i++)
            {
                this.m_Wheels[i].ManufacturerName = i_AirPressure;
            }
        }

        public abstract void ParseNeededInput(Dictionary<string, string> i_InputToParse);

        protected Vehicle(eEnergyType i_EnergyType,
                          Nullable<eFuelType> i_FuelType,
                            float i_MaximalEnergyLevel,
                            float i_MaxAirPressure, int i_NumOfWheels)
        {
            this.m_EnergyType = i_EnergyType;
            this.m_FuelType = i_FuelType;
            this.m_MaximalEnergyLevel = i_MaximalEnergyLevel;
            this.m_Wheels = Wheel.GenerateGeneralWheels(i_MaxAirPressure, i_NumOfWheels);
        }

        public List<Wheel> Weels
        {
            get
            {
                return m_Wheels;
            }

        }

        public string LicenceNumber
        {
            get
            {
                return m_LicenceNumber;
            }
        }

        public eEnergyType EnergyType
        {
            get
            {
                return m_EnergyType;
            }
        }

        public Nullable<eFuelType> FuelType
        {
            get
            {
                return m_FuelType;

            }
        }

        public float MaximalEnergyLevel
        {
            get
            {
                return m_MaximalEnergyLevel;
            }
        }

        public float CurrentEnergyLevel
        {
            get
            {
                return m_CurrentEnergyLevel;
            }
        }


        public enum eEnergyType
        {
            Electric,
            Fuel
        };

        public enum eFuelType
        {
            Octan95,
            Octan96,
            Octan98,
            Soler
        };

        public enum eVehicleState
        {
            RepairInProgress,
            RepairComplete,
            Paid
        };

        public eVehicleState VehicleState
        {
            get
            {
                return m_VehicleState;
            }
            set
            {
                m_VehicleState = value;
            }
        }

        public void AddEnergy(float i_EnergyToAdd, eEnergyType i_EnergyType, Nullable<eFuelType> i_FuelType = null)
        {
            if (i_EnergyType != this.m_EnergyType)
            {
                throw new ArgumentException("Wrong Energy Type!");
            }
            if (i_FuelType != this.FuelType)
            {
                throw new ArgumentException("Wrong Fuel Type!");
            }
            float newAmount = m_CurrentEnergyLevel + i_EnergyToAdd;
            if (i_EnergyType == eEnergyType.Electric)
            {
                newAmount = m_CurrentEnergyLevel + convertMinutesToHours(i_EnergyToAdd);
            }
            if ((i_EnergyToAdd < 0) || (newAmount > m_MaximalEnergyLevel))
            {
                float wrongValue = (i_EnergyToAdd < 0) ? i_EnergyToAdd : newAmount;
                throw new ValueOutOfRangeException(0, m_MaximalEnergyLevel, wrongValue);
            }
            this.m_CurrentEnergyLevel = newAmount;
        }

        public override string ToString()
        {
            StringBuilder vehicleString = new StringBuilder();

            vehicleString.Append("Licence number: ");
            vehicleString.Append(m_LicenceNumber);
            vehicleString.Append("\n");

            vehicleString.Append("Model name: ");
            vehicleString.Append(m_ModelName);
            vehicleString.Append("\n");

            vehicleString.Append("Owner's name: ");
            vehicleString.Append(m_OwnerName);
            vehicleString.Append("\n");

            vehicleString.Append("State in garage: ");
            vehicleString.Append(m_VehicleState);
            vehicleString.Append("\n");

            foreach (Wheel wheel in m_Wheels)
            {
                vehicleString.Append(wheel.ToString());
                vehicleString.Append("\n");
            }

            if (this.m_EnergyType == eEnergyType.Fuel)
            {
                vehicleString.Append(this.m_FuelType);
            }

            vehicleString.Append("Energy level is: ");
            vehicleString.Append(this.m_CurrentEnergyLevel / this.m_MaximalEnergyLevel);
            vehicleString.Append("\n");

            return vehicleString.ToString();
        }

        private static float convertMinutesToHours(float i_MinutesToConvert)
        {
            return i_MinutesToConvert / 60;
        }
    }
}
