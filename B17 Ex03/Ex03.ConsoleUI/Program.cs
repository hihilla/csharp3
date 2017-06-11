using System;
using System.Collections.Generic;
using System.Text;

namespace Ex03.ConsoleUI
{
    class Program
    {
        public static void Main()
        {
            Console.WriteLine("Adar and Hilla rock!");
        }

        private static void askUserForInstructions()
        {
            GarageLogic.Garage garage = new GarageLogic.Garage();
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
            while (!int.TryParse(userAnswer, out chosenAction)) 
            {
                Console.WriteLine("Invalid action. please choose valid action.");
                userAnswer = Console.ReadLine();
            }

            switch (chosenAction)
            {
                case 1:
                    insertNewVehicle(garage);
                    break;
                case 2:
                    printLicenceNumbersOfVehicles(garage);
                    break;
                case 3:
                    changeState(garage);
                    break;
                case 4:
                    fillAirInVehicle(garage);
                    break;
                case 5:
                    fillFuel(garage);
                    break;
                case 6:
                    fillElectricity(garage);
                    break;
                case 7:
                    displayVehicleDetails(garage);
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

            while (!int.TryParse(userChosenVehicle, out vehicleOption) || (1 > vehicleOption || vehicleOption > 5))
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

            Console.WriteLine("Enter the color of the car");
            while (Console.ReadLine() != GarageLogic.Car.e_Color)
        }


        private static void printLicenceNumbersOfVehicles(GarageLogic.Garage i_Garage)
        {

        }

        private static void changeState(GarageLogic.Garage i_Garage)
        {

        }

        private static void fillAirInVehicle(GarageLogic.Garage i_Garage)
        {

        }

        private static void fillFuel(GarageLogic.Garage i_Garage)
        {

        }

        private static void fillElectricity(GarageLogic.Garage i_Garage)
        {

        }

        private static void displayVehicleDetails(GarageLogic.Garage i_Garage)
        {

        }
    }
}
