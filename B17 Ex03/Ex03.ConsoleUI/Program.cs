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
                Console.WriteLine("Invalid action. please coose valid cation.");
                userAnswer = Console.ReadLine();
            }

            switch (chosenAction)
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
                case 6:
                    break;
                case 7:
                    break;
            }
        }

        private void insertNewVehicle()
        {

        }

        private void printLicenceNumbersOfVehicles()
        {

        }

        private void changeState()
        {

        }

        private void fillAirInVehicle()
        {

        }

        private void fillFuel()
        {

        }

        private void fillElectricity()
        {

        }

        private void displayVehicleDetails()
        {

        }
    }
}
