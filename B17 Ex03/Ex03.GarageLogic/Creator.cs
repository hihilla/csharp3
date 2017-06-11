
using System;

namespace Ex03.GarageLogic
{
    public class Creator
    {
        public static Motorcycle CreateNewMotorcycle(bool i_IsElectric)
        {
            int numberOfWheels = 2;
            float maxWheelAirPressure = 33;
            Vehicle.e_EnergyType energyType = Vehicle.e_EnergyType.Electric;
            Nullable<Vehicle.e_FuelType> fuelType = null;
            if (!i_IsElectric)
            {
                energyType = Vehicle.e_EnergyType.Fuel;
                fuelType = Vehicle.e_FuelType.Octan95;
            }
            float tankSize = i_IsElectric ? 2.7F : 5.5F;
            return new Motorcycle(energyType, fuelType,
                          tankSize,
                          maxWheelAirPressure, numberOfWheels);
        }

        public static Car CreateNewCar(int i_NumOfDoors, bool i_IsElectric)
        {
            int numberOfWheels = 4;
            float maxWheelAirPressure = 30;
            Vehicle.e_EnergyType energyType = Vehicle.e_EnergyType.Electric;
            Nullable<Vehicle.e_FuelType> fuelType = null;
            if (!i_IsElectric)
            {
                fuelType = Vehicle.e_FuelType.Octan98;
                energyType = Vehicle.e_EnergyType.Fuel;
            }
            float maxEnergyLevel = i_IsElectric ? 2.5F : 42F;
            return new Car(energyType, fuelType,
                    maxEnergyLevel,
                   maxWheelAirPressure, numberOfWheels, i_NumOfDoors);
        }

        public static Truck CreateNewTruck()
        {
            int numberOfWheels = 12;
            float maxWheelAirPressure = 32;
            Vehicle.e_EnergyType energyType = Vehicle.e_EnergyType.Fuel;
            Vehicle.e_FuelType fuelType = Vehicle.e_FuelType.Octan96;
            float tankSize = 135F;
            return new Truck(energyType, fuelType,
                  tankSize, 
                    maxWheelAirPressure, numberOfWheels);
        }
    }
}
