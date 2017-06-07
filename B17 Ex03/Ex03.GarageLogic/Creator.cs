
namespace Ex03.GarageLogic
{
    internal class Creator
    {
        Garage m_Garage = new Garage();

        public Motorcycle CreateNewRegularMotorcycle(string i_ModelName, string i_LicenceNumber, 
                                                    float i_CurrentEnergyLevel, string i_OwnerName, 
                                                    string i_OwnerPhoneNumber, string i_ManufacturerName,
                                                    Motorcycle.e_LicenceType i_LicenceType, int i_EngineCapacity)
        {
            int numberOfWheels = 2;
            float maxWheelAirPressure = 33;
            Vehicle.e_EnergyType energyType = Vehicle.e_EnergyType.Fuel;
            Vehicle.e_FuelType fuelType = Vehicle.e_FuelType.Octan95;
            float tankSize = 5.5F;
            return new Motorcycle(i_ModelName, i_LicenceNumber, energyType, fuelType,
                          i_CurrentEnergyLevel, tankSize, i_OwnerName, i_OwnerPhoneNumber,
                          i_ManufacturerName, maxWheelAirPressure, numberOfWheels, i_LicenceType,
                          i_EngineCapacity);
        }

        public Motorcycle CreateNewElectricMotorcycle(string i_ModelName, string i_LicenceNumber,
                                                    float i_CurrentEnergyLevel, string i_OwnerName,
                                                    string i_OwnerPhoneNumber, string i_ManufacturerName,
                                                    Motorcycle.e_LicenceType i_LicenceType, int i_EngineCapacity)
        {
            int numberOfWheels = 2;
            float maxWheelAirPressure = 33;
            Vehicle.e_EnergyType energyType = Vehicle.e_EnergyType.Electric;
            Vehicle.e_FuelType fuelType = Vehicle.e_FuelType.none;
            float batteryTime = 2.7F;
            return new Motorcycle(i_ModelName, i_LicenceNumber, energyType, fuelType,
                          i_CurrentEnergyLevel, batteryTime, i_OwnerName, i_OwnerPhoneNumber,
                          i_ManufacturerName, maxWheelAirPressure, numberOfWheels, i_LicenceType,
                          i_EngineCapacity);
        }

        public Car CreateNewRegularCar()
        {
            int numberOfWheels = 4;
            float maxWheelAirPressure = 30;
            Vehicle.e_EnergyType energyType = Vehicle.e_EnergyType.Fuel;
            Vehicle.e_FuelType fuelType = Vehicle.e_FuelType.Octan98;
            float tankSize = 42F;
            return new Car();
        }

        public Car CreateNewElectricCar()
        {
            int numberOfWheels = 4;
            float maxWheelAirPressure = 30;
            Vehicle.e_EnergyType energyType = Vehicle.e_EnergyType.Electric;
            Vehicle.e_FuelType fuelType = Vehicle.e_FuelType.none;
            float batteryTime = 2.5F;
            return new Car();
        }

        public Truck CreateNewTruck()
        {
            int numberOfWheels = 12;
            float maxWheelAirPressure = 32;
            Vehicle.e_EnergyType energyType = Vehicle.e_EnergyType.Fuel;
            Vehicle.e_FuelType fuelType = Vehicle.e_FuelType.Octan96;
            float tankSize = 135F;
            return new Truck();
        }
    }
}
