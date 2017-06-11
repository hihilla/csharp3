﻿using System;
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
