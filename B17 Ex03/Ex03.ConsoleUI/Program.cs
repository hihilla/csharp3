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
                    insertNewVehicle();
                    break;
                case 2:
                    printLicenceNumbersOfVehicles();
                    break;
                case 3:
                    changeState();
                    break;
                case 4:
                    fillAirInVehicle();
                    break;
                case 5:
                    fillFuel();
                    break;
                case 6:
                    fillElectricity();
                    break;
                case 7:
                    displayVehicleDetails();
                    break;
            }
        }

        private static void insertNewVehicle()
        {

        }

        private static void printLicenceNumbersOfVehicles()
        {

        }

        private static void changeState()
        {

        }

        private static void fillAirInVehicle()
        {

        }

        private static void fillFuel()
        {

        }

        private static void fillElectricity()
        {

        }

        private static void displayVehicleDetails()
        {

        }
    }
}
