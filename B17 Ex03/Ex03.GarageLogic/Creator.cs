using System;

namespace Ex03.GarageLogic
{
    public class Creator
    {
        public static Motorcycle CreateNewMotorcycle(bool i_IsElectric)
        {
            int numberOfWheels = 2;
            float maxWheelAirPressure = 33;
            Vehicle.eEnergyType energyType = Vehicle.eEnergyType.Electric;
            Nullable<Vehicle.eFuelType> fuelType = null;

            if (!i_IsElectric)
            {
                energyType = Vehicle.eEnergyType.Fuel;
                fuelType = Vehicle.eFuelType.Octan95;
            }

            float tankSize = i_IsElectric ? 2.7F : 5.5F;

            Vehicle.eVehicleType vehicleType = i_IsElectric ?
                Vehicle.eVehicleType.ElectricMotorcycle
                : Vehicle.eVehicleType.FuelMotorcycle;

            return new Motorcycle(energyType,
                                  fuelType,
                                  tankSize,
                                  maxWheelAirPressure,
                                  numberOfWheels,
                                  vehicleType);
        }

        public static Car CreateNewCar(bool i_IsElectric)
        {
            int numberOfWheels = 4;
            float maxWheelAirPressure = 30;
            Vehicle.eEnergyType energyType = Vehicle.eEnergyType.Electric;
            Nullable<Vehicle.eFuelType> fuelType = null;

            if (!i_IsElectric)
            {
                fuelType = Vehicle.eFuelType.Octan98;
                energyType = Vehicle.eEnergyType.Fuel;
            }

            float maxEnergyLevel = i_IsElectric ? 2.5F : 42F;

            Vehicle.eVehicleType vehicleType = i_IsElectric ?
                Vehicle.eVehicleType.ElectricCar
                : Vehicle.eVehicleType.FuelCar;

            return new Car(energyType,
                           fuelType,
                           maxEnergyLevel,
                           maxWheelAirPressure,
                           numberOfWheels,
                           vehicleType);
        }

        public static Truck CreateNewTruck()
        {
            int numberOfWheels = 12;
            float maxWheelAirPressure = 32;
            Vehicle.eEnergyType energyType = Vehicle.eEnergyType.Fuel;
            Vehicle.eFuelType fuelType = Vehicle.eFuelType.Octan96;
            float tankSize = 135F;
            Vehicle.eVehicleType vehicleType = Vehicle.eVehicleType.Truck;

            return new Truck(energyType,
                             fuelType,
                             tankSize,
                             maxWheelAirPressure,
                             numberOfWheels,
                             vehicleType);
        }
    }
}