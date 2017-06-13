using System;
using System.Collections.Generic;
using System.Text;

namespace Ex03.ConsoleUI
{
    class Program
    {
        public static void Main()
        {
            manageGarage();
        }

        private static void manageGarage()
        {
            GarageLogic.Garage garage = new GarageLogic.Garage();
            char exitChar;
            do
            {
                askUserForInstructions(garage);
                Console.WriteLine("Do you want to exit garage? <Y/N>");
            }
            while (char.TryParse(Console.ReadLine(), out exitChar) && (exitChar != 'Y'));
            Console.Write(exitChar);
            Console.ReadLine();
        }

        private static void askUserForInstructions(GarageLogic.Garage i_Garage)
        {
            Console.WriteLine("Hello Garage manager. What would you like to do?");
            Console.WriteLine("Enter 1 to insert new vehicle to garage.");
            Console.WriteLine("Enter 2 to see licence number of vehicles in garage.");
            Console.WriteLine("Enter 3 to change state of vehicle.");
            Console.WriteLine("Enter 4 to fill air in vehicles wheels");
            Console.WriteLine("Enter 5 to fill gas in fuel based vehicle.");
            Console.WriteLine("Enter 6 to fill energy in electric based vehicle.");
            Console.WriteLine("Enter 7 to display full details of a vehicle.");
            string userAnswer = Console.ReadLine();
            int chosenAction;
            while (!int.TryParse(userAnswer, out chosenAction) || !(chosenAction >= 1 && chosenAction <= 7))
            {
                Console.WriteLine("Invalid action. please choose valid action.");
                userAnswer = Console.ReadLine();
            }

            switch (chosenAction)
            {
                case 1:
                    insertNewVehicle(i_Garage);
                    break;
                case 2:
                    printLicenceNumbersOfVehicles(i_Garage);
                    break;
                case 3:
                    changeState(i_Garage);
                    break;
                case 4:
                    fillAirInVehicle(i_Garage);
                    break;
                case 5:
                    fillFuel(i_Garage);
                    break;
                case 6:
                    fillElectricity(i_Garage);
                    break;
                case 7:
                    displayVehicleDetails(i_Garage);
                    break;
            }
        }

        private static void insertNewVehicle(GarageLogic.Garage i_Garage)
        {
            Console.Write("To insert new motorcycle, Enter 1, ");
            Console.Write("To insert new car, Enter 2, ");
            Console.WriteLine("To insert new truck, Enter 3");
            int vehicleOption;
            while (!int.TryParse(Console.ReadLine(), out vehicleOption) || !(vehicleOption >= 1 && vehicleOption <= 3))
            {
                Console.WriteLine("Invalid input. please insert valid input.");
            }

            Console.WriteLine("For fuel based vehicle Enter 1, fot electric Enter 2");
            int engineOption;
            while (!int.TryParse(Console.ReadLine(), out engineOption) || !(engineOption >= 1 && engineOption <= 2))
            {
                Console.WriteLine("Invalid input. please insert valid input.");
            }

            Console.WriteLine("Enter model name: ");
            string modelName = Console.ReadLine();
            Console.WriteLine("Enter licence number: ");
            string licenceNumber = Console.ReadLine();
            Console.WriteLine("Enter owner's name: ");
            string ownerName = Console.ReadLine();
            Console.WriteLine("Enter owner's phone number: ");
            string ownerPhoneNumber = Console.ReadLine();
            Console.WriteLine("Enter current energy level");
            float energyLevel;
            while (!float.TryParse(Console.ReadLine(), out energyLevel) || (energyLevel < 0))
            {
                Console.WriteLine("Invalid input. please enter non negative energy level.");
            }

            Console.WriteLine("Enter manufacturers of wheels for all wheels, seperated buy comma (,). If all Wheels have the same manufacture, enter it <number of wheels> times.");
            string allManufacturers = Console.ReadLine();
            List<string> manufactureList = new List<string>(allManufacturers.Split(','));
            
            Console.WriteLine("Enter current air pressure of wheels for all wheels, seperated buy comma (,). If all Wheels have the same air pressure, enter it <number of wheels> times.");
            string allAirPressurs = Console.ReadLine();
            List<string> airPressureListString = new List<string>(allAirPressurs.Split(','));
            List<float> airPressureList = new List<float>();
            foreach (string element in airPressureListString)
            {
                airPressureList.Add(float.Parse(element));
            }
            GarageLogic.Vehicle newVehicle;
            switch (vehicleOption)
            {
                case 1:
                    newVehicle = newMotorcycle((engineOption == 2), modelName, licenceNumber, energyLevel, ownerName, ownerPhoneNumber, manufactureList.ToArray(), airPressureList.ToArray());
                    i_Garage.InsertNewVehicleToGarage(newVehicle);
                    break;
                case 2:
                    newVehicle = newCar((engineOption == 2), modelName, licenceNumber, energyLevel, ownerName, ownerPhoneNumber, manufactureList.ToArray(), airPressureList.ToArray());
                    i_Garage.InsertNewVehicleToGarage(newVehicle);
                    break;
                case 3:
                    if (engineOption == 2)
                    {
                        throw new ArgumentException("Truck cannot be electric");
                    }
                    newVehicle = newTruck(modelName, licenceNumber, energyLevel, ownerName, ownerPhoneNumber, manufactureList.ToArray(), airPressureList.ToArray());
                    i_Garage.InsertNewVehicleToGarage(newVehicle);
                    break;
            }   
        }

        private static GarageLogic.Car newCar(bool i_IsElectric,
            string i_ModelName, string i_LicenseNumber, float i_CurrentEnergyLevel,
            string i_OwnerName, string i_OwnerPhoneNumber,
            string[] i_Manufacturers, float[] i_CurrAirPressure)
        {
            Console.WriteLine("Enter number of doors: ");
            int numberOfDoors;
            while (!int.TryParse(Console.ReadLine(), out numberOfDoors))
            {
                Console.WriteLine("Invalid doors number, insert number between 2 - 5");
            }

            Console.WriteLine("For Yellow car enter 1, for white car enter 2, for black car enter 3, for blue car enter 4");
            int carColor;
            while (!int.TryParse(Console.ReadLine(), out carColor) || !(carColor >= 1 && carColor <= 4))
            {
                Console.WriteLine("Invalid color. please choose valid color (1 - 4");
            }

            GarageLogic.Car.eColor chosenColor = GarageLogic.Car.eColor.Black;
            switch (carColor)
            {
                case 1:
                    chosenColor = GarageLogic.Car.eColor.Yellow;
                    break;
                case 2:
                    chosenColor = GarageLogic.Car.eColor.White;
                    break;
                case 3:
                    break;
                case 4:
                    chosenColor = GarageLogic.Car.eColor.Blue;
                    break;
            }

            return GarageLogic.Creator.CreateNewCar(numberOfDoors, i_IsElectric);
        }

        private static GarageLogic.Motorcycle newMotorcycle(bool i_IsElectric,
            string i_ModelName, string i_LicenseNumber, float i_CurrentEnergyLevel,
            string i_OwnerName, string i_OwnerPhoneNumber,
            string[] i_Manufacturers, float[] i_CurrAirPressure)
        {
            Console.WriteLine("Enter Engine Capacity in CCM");
            int engineCapacity;
            while (!int.TryParse(Console.ReadLine(), out engineCapacity) || engineCapacity < 0)
            {
                Console.WriteLine("Invalid engine capacity, please enter a non negative number");
            }

            Console.WriteLine("For licence type A enter 1, for licence type AB enter 2, for licence type A2 enter 3, for licence type B1 enter 4");
            int userLicenceType;
            while (!int.TryParse(Console.ReadLine(), out userLicenceType) || !(userLicenceType >= 1 && userLicenceType <= 4))
            {
                Console.WriteLine("Invalid color. please choose valid number (1 - 4)");
            }

            GarageLogic.Motorcycle.eLicenceType chosenLicenceType = GarageLogic.Motorcycle.eLicenceType.A;
            switch (userLicenceType)
            {
                case 2:
                    chosenLicenceType = GarageLogic.Motorcycle.eLicenceType.AB;
                    break;
                case 3:
                    chosenLicenceType = GarageLogic.Motorcycle.eLicenceType.A2;
                    break;
                case 4:
                    chosenLicenceType = GarageLogic.Motorcycle.eLicenceType.B1;
                    break;
            }

            return GarageLogic.Creator.CreateNewMotorcycle(i_IsElectric);
        }


        private static GarageLogic.Truck newTruck(string i_ModelName, string i_LicenseNumber, float i_CurrentEnergyLevel,
            string i_OwnerName, string i_OwnerPhoneNumber,
            string[] i_Manufacturers, float[] i_CurrAirPressure)
        {
            Console.WriteLine("If the truck carries Hazardous Materials enter 1, if not enter 0");
            int hazardousMaterials;
            while (!int.TryParse(Console.ReadLine(), out hazardousMaterials) || !(hazardousMaterials == 0 || hazardousMaterials == 1))
            {
                Console.WriteLine("Invalid input, please enter valid input");
            }

            Console.WriteLine("Enter Maximal carrying weight");
            float maxCarryingWeight;
            while (!float.TryParse(Console.ReadLine(), out maxCarryingWeight) || (maxCarryingWeight < 0))
            {
                Console.WriteLine("Invalid input. Please enter a non valid number");
            }

            return GarageLogic.Creator.CreateNewTruck();
        }

        private static void printLicenceNumbersOfVehicles(GarageLogic.Garage i_Garage)
        {
            Console.WriteLine("Do you want to print with filter?");
            Console.WriteLine("Press 0 for no filter, 1 for Repair In Progress, 2 for Repair Complete, 3 for Paid");
            string userAnswer = Console.ReadLine();
            int chosenFilter;
            while (!int.TryParse(userAnswer, out chosenFilter) || !(chosenFilter >= 0 && chosenFilter <= 3))
            {
                Console.WriteLine("Invalid filter. please choose valid filter.");
            }

            switch (chosenFilter)
            {
                case 0:////returns string, print the motherfucker
                    i_Garage.GetLicenceNumbers();
                    break;
                case 1:
                    i_Garage.GetLicenceNumbers(GarageLogic.Vehicle.eVehicleState.RepairInProgress);
                    break;
                case 2:
                    i_Garage.GetLicenceNumbers(GarageLogic.Vehicle.eVehicleState.RepairComplete);
                    break;
                case 3:
                    i_Garage.GetLicenceNumbers(GarageLogic.Vehicle.eVehicleState.Paid);
                    break;
            }
        }

        private static void changeState(GarageLogic.Garage i_Garage)
        {
            Console.WriteLine("Please enter the vehicle licence number");
            string licenceNumber = Console.ReadLine();
            Console.WriteLine("Please enter 1 for Repair In Progress, 2 for Repair Complete, 3 for Paid.");
            int chosenState;
            while (!int.TryParse(Console.ReadLine(), out chosenState) || !(chosenState >= 1 && chosenState <= 3))
            {
                Console.WriteLine("Invalid state. please choose valid state.");
            }

            GarageLogic.Vehicle.eVehicleState vehicleState = GarageLogic.Vehicle.eVehicleState.RepairInProgress;
            switch (chosenState)
            {
                case 1:
                    vehicleState = GarageLogic.Vehicle.eVehicleState.RepairInProgress;
                    break;
                case 2:
                    vehicleState = GarageLogic.Vehicle.eVehicleState.RepairComplete;
                    break;
                case 3:
                    vehicleState = GarageLogic.Vehicle.eVehicleState.Paid;
                    break;
            }

            i_Garage.ChangeVehicleState(licenceNumber, vehicleState);
        }

        private static void fillAirInVehicle(GarageLogic.Garage i_Garage)
        {
            Console.WriteLine("Please enter the vehicle licence number");
            string licenceNumber = Console.ReadLine();
            i_Garage.FillAirInVehicle(licenceNumber);
        }

        private static void fillFuel(GarageLogic.Garage i_Garage)
        {
            Console.WriteLine("Please enter the vehicle licence number");
            string licenceNumber = Console.ReadLine();
            Console.WriteLine("Please enter 1 for Octan95, 2 for Octan96, 3 for Octan98, 4 for Soler.");
            int fuelType;
            while (!int.TryParse(Console.ReadLine(), out fuelType) || !(fuelType >= 1 && fuelType <= 4))
            {
                Console.WriteLine("Invalid fuel type. please choose valid fuel type.");
            }

            GarageLogic.Vehicle.eFuelType chosenFuel = GarageLogic.Vehicle.eFuelType.Octan95;
            switch (fuelType)
            {
                case 1:
                    chosenFuel = GarageLogic.Vehicle.eFuelType.Octan95;
                    break;
                case 2:
                    chosenFuel = GarageLogic.Vehicle.eFuelType.Octan96;
                    break;
                case 3:
                    chosenFuel = GarageLogic.Vehicle.eFuelType.Octan98;
                    break;
                case 4:
                    chosenFuel = GarageLogic.Vehicle.eFuelType.Soler;
                    break;
            }

            Console.WriteLine("Please enter amount of fuel to fill in liters");
            float amountToFill;
            while (!float.TryParse(Console.ReadLine(), out amountToFill))
            {
                Console.WriteLine("Invalid amount. please insert valid amount.");
            }

            i_Garage.FillEnergyInVehicle(licenceNumber, chosenFuel, amountToFill);
        }

        private static void fillElectricity(GarageLogic.Garage i_Garage)
        {
            Console.WriteLine("Please enter the vehicle licence number");
            string licenceNumber = Console.ReadLine();
            Console.WriteLine("Please enter amount of energy to fill in minutes");
            float amountToFill;
            while (!float.TryParse(Console.ReadLine(), out amountToFill))
            {
                Console.WriteLine("Invalid amount. please insert valid amount.");
            }

            i_Garage.FillEnergyInVehicle(licenceNumber, null, amountToFill);
        }

        private static void displayVehicleDetails(GarageLogic.Garage i_Garage)
        {
            Console.WriteLine("Please enter the vehicle licence number");
            string licenceNumber = Console.ReadLine();
            Console.WriteLine(i_Garage.DisplayVehicleDetails(licenceNumber));
        }
    }
}
