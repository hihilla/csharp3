
using System;
using System.Collections.Generic;
using System.Text;

namespace Ex03.GarageLogic
{
    public class Garage
    {
        private Dictionary<string, Vehicle> m_VehiclesInGarage = new Dictionary<string, Vehicle>();

        public bool InsertNewVehicleToGarage(Vehicle i_Vehicle)
        {
            bool successfulInsertion = true;
            if (m_VehiclesInGarage.ContainsKey(i_Vehicle.LicenceNumber))
            {
                successfulInsertion = false;
            }
            else
            {
                m_VehiclesInGarage.Add(i_Vehicle.LicenceNumber, i_Vehicle);
            }

            return successfulInsertion;
        }


        public string GetLicenceNumbers(Nullable<Vehicle.eVehicleState> i_StateFilter = null)
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

        public string DisplayVehicleDetails(string i_VehicleLicence)
        {
            Vehicle vehicle;
            if (m_VehiclesInGarage.TryGetValue(i_VehicleLicence, out vehicle))
            {
                return vehicle.ToString();
            }
            else
            {
                throw new ArgumentException(string.Format("Vehicle with licence number {0} does not exsist", i_VehicleLicence));
            }
        }

        public void ChangeVehicleState(string i_VehicleLicence, Vehicle.eVehicleState i_VehicleState)
        {
            Vehicle vehicle;
            if (m_VehiclesInGarage.TryGetValue(i_VehicleLicence, out vehicle))
            {
                vehicle.VehicleState = i_VehicleState;
            }
            else
            {
                throw new ArgumentException(string.Format("Vehicle with licence number {0} does not exsist", i_VehicleLicence));
            }
        }

        public void FillEnergyInVehicle(string i_VehicleLicence, float i_AmountToFill, bool i_IsElectric)
        {
            Vehicle vehicle;
            if (m_VehiclesInGarage.TryGetValue(i_VehicleLicence, out vehicle))
            {
                if (!compatibaleEnergyType(vehicle, i_IsElectric)) {
                    string energyType = i_IsElectric ? "Electricity" : "Fuel";
                    throw new ArgumentException(string.Format("Vehicle is {0} but trying to fill with {1}", 
                                                              vehicle.EnergyType, energyType));
                }
                vehicle.AddEnergy(i_AmountToFill, vehicle.EnergyType);
            }
            else
            {
                throw new ArgumentException(string.Format("Vehicle with licence number {0} does not exsist", i_VehicleLicence));
            }
        }

        private bool compatibaleEnergyType(Vehicle i_Vehicle, bool i_IsElectric) {
            bool compatible = i_Vehicle.EnergyType == Vehicle.eEnergyType.Electric && i_IsElectric;

            return compatible;
        }

        public void FillAirInVehicle(string i_VehicleLicence)
        {
            Vehicle vehicle;
            if (m_VehiclesInGarage.TryGetValue(i_VehicleLicence, out vehicle))
            {
                foreach (Wheel weel in vehicle.Weels)
                {
                    float airToFill = weel.MaxAirPressure - weel.CurrentAirPressure;
                    if (airToFill > 0)
                    {
                        weel.FillAir(airToFill);
                    }
                }
            }
            else
            {
                throw new ArgumentException(string.Format("Vehicle with licence number {0} does not exsist", i_VehicleLicence));
            }
        }
        
    }
}
