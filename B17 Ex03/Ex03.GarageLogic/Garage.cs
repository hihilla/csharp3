
using System;
using System.Collections.Generic;
using System.Text;

namespace Ex03.GarageLogic
{
    class Garage
    {
        private Dictionary<string, Vehicle> m_VehiclesInGarage = new Dictionary<string, Vehicle>();

        public bool InsertNewVehicleToGarage(Vehicle i_Vehicle)
        {
            if (m_VehiclesInGarage.ContainsKey(i_Vehicle.LicenceNumber))
            {
                return false;
            }

            m_VehiclesInGarage.Add(i_Vehicle.LicenceNumber, i_Vehicle);
            return true;
        }

        public string GetLicenceNumbers(Nullable<Vehicle.e_VehicleState> i_StateFilter = null)
        {
            StringBuilder licenceNumbers = new StringBuilder();
            if (i_StateFilter.HasValue)
            {
                foreach (string licence in m_VehiclesInGarage.Keys)
                {
                    Vehicle vehicle;
                    if (m_VehiclesInGarage.TryGetValue(licence, out vehicle))
                    {
                        if (vehicle.VehicleState == i_StateFilter)
                        {
                            licenceNumbers.Append(licence);
                            licenceNumbers.Append("\n");
                        }
                    }
                }
            }
            else
            {
                foreach (string licence in m_VehiclesInGarage.Keys)
                {
                    licenceNumbers.Append(licence);
                    licenceNumbers.Append("\n");
                }
            }

            return licenceNumbers.ToString();
        }

        public void ChangeVehicleState(string i_VehicleLicence, Vehicle.e_VehicleState i_VehicleState)
        {
            Vehicle vehicle;
            if (m_VehiclesInGarage.TryGetValue(i_VehicleLicence, out vehicle))
            {
                vehicle.VehicleState = i_VehicleState;
            }
        }

        public void FillAirInVehicle(string i_VehicleLicence)
        {
            Vehicle vehicle;
            if (m_VehiclesInGarage.TryGetValue(i_VehicleLicence, out vehicle))
            {
                foreach (Weel weel in vehicle.Weels)
                {
                    weel.FillAir(weel.MaxAirPressure);
                }
            }
        }
    }
}
