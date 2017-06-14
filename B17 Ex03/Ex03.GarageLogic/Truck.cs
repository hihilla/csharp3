
using System;
using System.Collections.Generic;
using System.Text;

namespace Ex03.GarageLogic
{
    public class Truck : Vehicle
    {
        private bool m_IsCarryingHazardousMaterials;
        private float m_MaxCarryingWeight;

        private static readonly string sr_HazardMaterialKey = "Hazardous Materials <Y/N>";
        private static readonly string sr_MaxCarryWeightKey = "Maximum Carrying Weight";

        public Truck(eEnergyType i_EnergyType, eFuelType? i_FuelType, float i_MaximalEnergyLevel, float i_MaxAirPressure, int i_NumOfWheels) 
            : base(i_EnergyType, i_FuelType, i_MaximalEnergyLevel, i_MaxAirPressure, i_NumOfWheels)
        {
        }

        public override string ToString()
        {
            StringBuilder truckToString = new StringBuilder();
            truckToString.Append("Truck\n");

            if (m_IsCarryingHazardousMaterials)
            {
                truckToString.Append("This truck carries hazardous materials\n");
            }
            else
            {
                truckToString.Append("This truck doesn't carry any hazardous materials\n");
            }

            truckToString.AppendFormat("Maximux carrying weight: {0}\n", m_MaxCarryingWeight);
            truckToString.Append(base.ToString());

            return truckToString.ToString();
        }

        public override Dictionary<string, string> NeededInputs()
        {
            Dictionary<string, string> neededInput = new Dictionary<string, string>();
            neededInput.Add(sr_HazardMaterialKey, null);
            neededInput.Add(sr_MaxCarryWeightKey, null);

            return neededInput;
        }

        public override void ParseNeededInput(Dictionary<string, string> i_InputToParse)
        {
            string hazMaterialsInput;
            string maxCarryWInput;
            int maxCarryWeight = -1;

            if (!((i_InputToParse.TryGetValue(sr_MaxCarryWeightKey, out maxCarryWInput)) &&
                  (int.TryParse(maxCarryWInput, out maxCarryWeight))))
			{
				throw new FormatException("No Max Carrying Weight");
			}

            if (maxCarryWeight < 0) {
                throw new ArgumentException("Max Carrying Weight must be positive");
            }

            if (!i_InputToParse.TryGetValue(sr_HazardMaterialKey, out hazMaterialsInput))
			{
				throw new FormatException("No Hazardous Materials");
			}

            switch (hazMaterialsInput.ToUpper())
            {
                case "Y":
                    this.m_IsCarryingHazardousMaterials = true;
                    break;
				case "N":
                    this.m_IsCarryingHazardousMaterials = false;
					break;
                default:
                    throw new ArgumentException("Invalid answer for hazardous materials");
            }

            this.m_MaxCarryingWeight = maxCarryWeight;
        }
    }
}
