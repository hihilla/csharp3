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
            while (!int.TryParse(userAnswer, out chosenAction) || !(chosenAction >= 1 && chosenAction <= 7)) 
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
