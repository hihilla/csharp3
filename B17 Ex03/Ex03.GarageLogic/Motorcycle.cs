using System;
using System.Collections.Generic;
using System.Text;

namespace Ex03.GarageLogic
{
    public class Motorcycle : Vehicle
    {
        private eLicenceType m_LicenceType;
        private int m_EngineCapacity;

        private static readonly string sr_LicenceTypeKey = "Licence Type <A, AB, A2, B1>";
        private static readonly string sr_EngineCapacityKey = "Engine Capacity (CCM)";

        public Motorcycle(eEnergyType i_EnergyType, 
                          Nullable<eFuelType> i_FuelType, 
                          float i_MaximalEnergyLevel, 
                          float i_MaxAirPressure, 
                          int i_NumOfWheels, 
                          eVehicleType i_VehicleType) 
            : base(i_EnergyType, i_FuelType, i_MaximalEnergyLevel, i_MaxAirPressure, i_NumOfWheels, i_VehicleType)
        {
        }

        public enum eLicenceType
        {
            A,
            AB,
            A2,
            B1
        }

        public override string ToString()
        {
            StringBuilder motorcycleToString = new StringBuilder();
            motorcycleToString.AppendFormat("{0} Motorcycle\n", this.EnergyType);

            motorcycleToString.AppendFormat("Licence type :{0}\nEngine capacity: {1} CCM", this.m_LicenceType, this.m_EngineCapacity);
            motorcycleToString.Append(base.ToString());

            return motorcycleToString.ToString();
        }

        public override Dictionary<string, string> NeededInputs()
        {
            Dictionary<string, string> neededInputs = new Dictionary<string, string>();
            neededInputs.Add(sr_LicenceTypeKey, null);
            neededInputs.Add(sr_EngineCapacityKey, null);

            return neededInputs;
        }

        public override void ParseNeededInput(Dictionary<string, string> i_InputToParse)
        {
            string licenceType;
            string engineCapacityInput;
            int engineCapacityCCM = -1;

            if (!i_InputToParse.TryGetValue(sr_LicenceTypeKey, out licenceType))
			{
				throw new FormatException("No Licence Type");
			}

            if (!((i_InputToParse.TryGetValue(sr_EngineCapacityKey, out engineCapacityInput)) && 
                  (int.TryParse(engineCapacityInput, out engineCapacityCCM))))
			{
				throw new FormatException("No Engine Capacity");
			}

            if (engineCapacityCCM < 0) {
                throw new ArgumentException("Engine capacity must be positive");
            }

            switch (licenceType)
            {
                case "A":
                    this.m_LicenceType = eLicenceType.A;
                    break;
				case "AB":
					this.m_LicenceType = eLicenceType.AB;
					break;
				case "A2":
					this.m_LicenceType = eLicenceType.A2;
					break;
				case "B1":
                    this.m_LicenceType = eLicenceType.B1;
					break;
                default:
                    throw new ArgumentException("Invalid licence type");
            }

            this.m_EngineCapacity = engineCapacityCCM;
        }
    }
}
