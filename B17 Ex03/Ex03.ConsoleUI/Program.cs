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
            } while (char.TryParse(Console.ReadLine(), out exitChar) && (exitChar != 'N'));
        }

        private static void askUserForInstructions(GarageLogic.Garage i_Garage)
        {
            Console.WriteLine("Hello Garage manager. What would you like to do?");
            Console.WriteLine("Press 1 to insert new vehicle to garage.");
            Console.WriteLine("Press 2 to see licence number of vehicles in garage.");
            Console.WriteLine("Press 3 to change state of vehicle.");
            Console.WriteLine("Press 4 to fill air in vehicles wheels");
            Console.WriteLine("Press 5 to fill gas in fuel based vehicle.");
            Console.WriteLine("Press 6 to fill energy in electric based vehicle.");
            Console.WriteLine("Press 7 to display full details of a vehicle.");
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
            Console.WriteLine("To insert new fuel-based motorcycle, press 1");
            Console.WriteLine("To insert new electric motorcycle, press 2");
            Console.WriteLine("To insert new fuel-based car, press 3");
            Console.WriteLine("To insert new electric car, press 4");
            Console.WriteLine("To insert new truck, press 5");
            string userChosenVehicle = Console.ReadLine();
            int vehicleOption;

            while (!int.TryParse(userChosenVehicle, out vehicleOption) || !(vehicleOption >= 1 && vehicleOption <= 5))
            {
                Console.WriteLine("Invalid input. please choose valid input.");
                userChosenVehicle = Console.ReadLine();
            }

            Console.WriteLine("Insert model name: ");
            string modelName = Console.ReadLine();
            Console.WriteLine("Insert licence number: ");
            string licenceNumber = Console.ReadLine();
            Console.WriteLine("Insert owner's name: ");
            string ownerName = Console.ReadLine();
            Console.WriteLine("Insert owner's phone number: ");
            string ownerPhoneNumber = Console.ReadLine();

            switch (vehicleOption)
            {
                case 1:
                    
                    break;
                case 2:
                    
                    break;
                case 3:
                    
                    break;
                case 4:
                    
                    break;
                case 5:
                    
                    break;

            }
        }
        
        private static void insertNewFeuledCar(string i_ModelName, string i_LicenseNumber, string i_OwnerName, string i_OwnerPhoneNumber)
        {
            int numberOfWheels = 4;
            float maxAirPressure = 30;

            Console.WriteLine("Enter remain fuel level: ");
            string remainFuel = Console.ReadLine();
            float remainFuelAsNumber;

            while (!float.TryParse(remainFuel, out remainFuelAsNumber) || (remainFuelAsNumber < 0 || remainFuelAsNumber > 42))
            {
                Console.WriteLine("Invalid fuel level, insert number between 0 - 42");
                remainFuel = Console.ReadLine();
            }

            Console.WriteLine("Enter number of doors: ");
            string userNumberOfDoors = Console.ReadLine();
            int numberOfDoors;

            while (!int.TryParse(userNumberOfDoors, out numberOfDoors) || (numberOfDoors < 2 || numberOfDoors > 5))
            {
                Console.WriteLine("Invalid doors number, insert number between 2 - 5");
                userNumberOfDoors = Console.ReadLine();
            }

            Console.WriteLine("For Yellow car enter 1, for white car enter 2, for black car enter 3, for blue car enter 4");
            string userChosenColor = Console.ReadLine();
            int carColor;
            while (!int.TryParse(userChosenColor, out carColor) || (carColor < 1 || carColor > 4))
            {
                Console.WriteLine("Invalid color. please choose valid color (1 - 4");
            }

            GarageLogic.Car.e_Color chosenColor = GarageLogic.Car.e_Color.Black;
            switch (carColor)
            {
                case 1:
                    chosenColor = GarageLogic.Car.e_Color.Yellow;
                    break;
                case 2:
                    chosenColor = GarageLogic.Car.e_Color.White;
                    break;
                case 3:
                    break;
                case 4:
                    chosenColor = GarageLogic.Car.e_Color.Blue;
                    break;
            }

            Console.WriteLine("Insert manufactorors for wheel #1 (and hit enter), #2 (hit enter), #3 (hit enter), #4 (hit enter), with respect to that order: ");
            string[] manufactororsNames = new string[numberOfWheels]; 
            for (int i = 0; i < manufactororsNames.Length; i++)
            {
                manufactororsNames[i] = Console.ReadLine();
            }

            Console.WriteLine("Insert current air pressure in each wheel, hit enter for every wheel");
            string[] userCurrentPressureInWheels = new string[numberOfWheels];
            float[] currentPressureInWheels = new float[4];
            for (int i = 0; i < userCurrentPressureInWheels.Length; i++)
            {
                userCurrentPressureInWheels[i] = Console.ReadLine();
                while (!float.TryParse(userCurrentPressureInWheels[i], out currentPressureInWheels[i]) || (currentPressureInWheels[i] < 0 || currentPressureInWheels[i] > maxAirPressure))
                {
                    Console.WriteLine("Invalid air pressure, insert a number between 0 and 30"); //HARDCODEDDDDDDDDDDDD
                    userCurrentPressureInWheels[i] = Console.ReadLine();
                }

            }


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
                case 0:
                    i_Garage.GetLicenceNumbers();
                    break;
                case 1:
                    i_Garage.GetLicenceNumbers(GarageLogic.Vehicle.e_VehicleState.RepairInProgress);
                    break;
                case 2:
                    i_Garage.GetLicenceNumbers(GarageLogic.Vehicle.e_VehicleState.RepairComplete);
                    break;
                case 3:
                    i_Garage.GetLicenceNumbers(GarageLogic.Vehicle.e_VehicleState.Paid);
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
            GarageLogic.Vehicle.e_VehicleState vehicleState = GarageLogic.Vehicle.e_VehicleState.RepairInProgress;
            switch (chosenState)
            {
                case 1:
                    vehicleState = GarageLogic.Vehicle.e_VehicleState.RepairInProgress;
                    break;
                case 2:
                    vehicleState = GarageLogic.Vehicle.e_VehicleState.RepairComplete;
                    break;
                case 3:
                    vehicleState = GarageLogic.Vehicle.e_VehicleState.Paid;
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
            GarageLogic.Vehicle.e_FuelType chosenFuel = GarageLogic.Vehicle.e_FuelType.Octan95;
            switch (fuelType)
            {
                case 1:
                    chosenFuel = GarageLogic.Vehicle.e_FuelType.Octan95;
                    break;
                case 2:
                    chosenFuel = GarageLogic.Vehicle.e_FuelType.Octan96;
                    break;
                case 3:
                    chosenFuel = GarageLogic.Vehicle.e_FuelType.Octan98;
                    break;
                case 4:
                    chosenFuel = GarageLogic.Vehicle.e_FuelType.Soler;
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
