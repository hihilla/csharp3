
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

    }
}
