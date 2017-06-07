
using System;
using System.Text;

namespace Ex03.GarageLogic
{
    class Truck : Vehicle
    {
        bool m_IsCarryingHazardousMaterials;
        float m_MaxCarryingWeight;

        public override string ToString()
        {
            StringBuilder truckToString = new StringBuilder();

            if (m_IsCarryingHazardousMaterials)
            {
                truckToString.Append("This truck carries hazardous materials");
            }
            else
            {
                truckToString.Append("This truck doesn't carry any hazardous materials");
            }

            truckToString.AppendFormat("The truck maximux carrying weight is {0}", m_MaxCarryingWeight);
            truckToString.Append(base.ToString());

            return truckToString.ToString();
        }

    }
}
