
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
            else
            {
                throw new ArgumentException(string.Format("Vehicle with licence number {0} does not exsist", i_VehicleLicence));
            }
        }

        public void FillAirInVehicle(string i_VehicleLicence)
        {
            Vehicle vehicle;
            if (m_VehiclesInGarage.TryGetValue(i_VehicleLicence, out vehicle))
            {
                foreach (Weel weel in vehicle.Weels)
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

        private void fillEnergyForVehicle(Vehicle i_Vehicle, float i_AmountToFill)
        {
            float newAmount = i_Vehicle.CurrentEnergyLevel + i_AmountToFill;
            if ((i_AmountToFill < 0) || (newAmount > i_Vehicle.MaximalEnergyLevel))
            {
                throw new ArgumentException(string.Format("Vehicle with licence number {0} does not exsist", i_VehicleLicence));
            }
            else
            {
                i_Vehicle.AddEnergy(i_AmountToFill, i_Vehicle.EnergyType, i_Vehicle.FuelType);
            }
        }

        public void FillFuel(string i_VehicleLicence, Vehicle.e_FuelType i_FuelType, float i_AmountToFill)
        {
            Vehicle vehicle;
            if (m_VehiclesInGarage.TryGetValue(i_VehicleLicence, out vehicle))
            {
                if (i_FuelType == Vehicle.e_FuelType.none)
                {
                    throw new ArgumentException("Wrong vahicle Type!");
                }
                if (vehicle.FuelType != i_FuelType)
                {
                    throw new ArgumentException("Wrong Fuel Type!");
                }
                else
                {
                    fillEnergyForVehicle(vehicle, i_AmountToFill);
                }
            }
            else
            {
                throw new ArgumentException(string.Format("Vehicle with licence number {0} does not exsist", i_VehicleLicence));
            }
        }

        public void ChargeEnergy(string i_VehicleLicence, float i_MinutesToCharge)
        {
            Vehicle vehicle;
            if (m_VehiclesInGarage.TryGetValue(i_VehicleLicence, out vehicle))
            {
                fillEnergyForVehicle(vehicle, i_MinutesToCharge);
            }
            else
            {
                throw new ArgumentException(string.Format("Vehicle with licence number {0} does not exsist", i_VehicleLicence));
            }
        }
    }
}
