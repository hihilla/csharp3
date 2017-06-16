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
            bool finishRun;
            do
            {
                askUserForInstructions(garage);
                finishRun = exitGerege();
            }
            while (!finishRun);
        }

        private static bool exitGerege()
        {
            Console.WriteLine("Do you want to exit garage? <Y/N>");
            string userAnswer = Console.ReadLine().ToUpper();

            while (userAnswer != "Y" && userAnswer != "N")
            {
                Console.WriteLine("I don't understand...");
                Console.WriteLine("Do you want to exit garage? <Y/N>");
                userAnswer = Console.ReadLine().ToUpper();
            }

            bool decideToExit = userAnswer == "Y";

            return decideToExit;
        }

        private static void askUserForInstructions(GarageLogic.Garage i_Garage)
        {
            Console.WriteLine("Hello Garage manager. What would you like to do?");
            Console.WriteLine("Enter 1 to insert new vehicle to garage.");
            Console.WriteLine("Enter 2 to see licence number of vehicles in garage.");
            Console.WriteLine("Enter 3 to change state of vehicle.");
            Console.WriteLine("Enter 4 to fill air in vehicles wheels");
            Console.WriteLine("Enter 5 to fill gas in fuel based vehicle.");
            Console.WriteLine("Enter 6 to charge electric based vehicle.");
            Console.WriteLine("Enter 7 to display full details of a vehicle.");
            int chosenAction;

            while (!int.TryParse(Console.ReadLine(), out chosenAction) || !(chosenAction >= 1 && chosenAction <= 7))
            {
                Console.WriteLine("Invalid action. please choose valid action.");
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
            Console.WriteLine("To insert new elecrtic motorcycle, Enter 1, ");
            Console.WriteLine("To insert new fuel-based motorcycle, Enter 2, ");
            Console.WriteLine("To insert new elecrtic car, Enter 3");
            Console.WriteLine("To insert new fuel-based car, Enter 4");
            Console.WriteLine("To insert new truck, Enter 5");

            string managerInput = Console.ReadLine();
            int chosenVehiclel;
            int.TryParse(managerInput, out chosenVehiclel);

            while (chosenVehiclel < 1 || chosenVehiclel > 5)
            {
                Console.WriteLine("Invalid input, please choose valid vehicle <1-5>");
            }

            switch (chosenVehiclel)
            {
                case 1:
                    GarageLogic.Motorcycle electriMotorcyle = newMotorcycle(true, i_Garage);
                    break;
                case 2:
                    GarageLogic.Motorcycle fueledMotorcycle = newMotorcycle(false, i_Garage);
                    break;
                case 3:
                    GarageLogic.Car electricCar = newCar(true, i_Garage);
                    break;
                case 4:
                    GarageLogic.Car fueledCar = newCar(false, i_Garage);
                    break;
                case 5:
                    GarageLogic.Truck truck = newTruck(i_Garage);
                    break;
            }
        }

        private static GarageLogic.Car newCar(bool i_isElectric, GarageLogic.Garage i_Garage)
        {
            GarageLogic.Car car = GarageLogic.Creator.CreateNewCar(i_isElectric);
            setVehiclesMembers(i_Garage, car);

            return car;
            //Dictionary<string, string> vehicleDictionary = car.VehicleInput();
            //Dictionary<string, string> carDictionary = car.NeededInputs();

            //fillDictionary(vehicleDictionary);
            //fillDictionary(carDictionary);

            //car.ParseVehicleInput(vehicleDictionary);
            //car.ParseNeededInput(carDictionary);

            //if (i_Garage.InsertNewVehicleToGarage(car))
            //{
            //    car.VehicleState = GarageLogic.Vehicle.eVehicleState.RepairInProgress;
            //}

            //return car;
        }

        private static GarageLogic.Motorcycle newMotorcycle(bool i_isElectric, GarageLogic.Garage i_Garage)
        {
            GarageLogic.Motorcycle motorcycle = GarageLogic.Creator.CreateNewMotorcycle(i_isElectric);
            setVehiclesMembers(i_Garage, motorcycle);

            return motorcycle;
        }

        private static GarageLogic.Truck newTruck(GarageLogic.Garage i_Garage)
        {
            GarageLogic.Truck truck = GarageLogic.Creator.CreateNewTruck();

            //Dictionary<string, string> vehicleDictionary = truck.VehicleInput();
            //Dictionary<string, string> truckDictionary = truck.NeededInputs();

            //fillDictionary(vehicleDictionary);
            //fillDictionary(truckDictionary);

            //truck.ParseVehicleInput(vehicleDictionary);
            //truck.ParseNeededInput(truckDictionary);

            //if (i_Garage.InsertNewVehicleToGarage(truck))
            //{
            //    truck.VehicleState = GarageLogic.Vehicle.eVehicleState.RepairInProgress;
            //}
            setVehiclesMembers(i_Garage, truck);

            return truck;
        }

		private static void setVehiclesMembers(GarageLogic.Garage i_Garage, GarageLogic.Vehicle i_Vehicle)
		{
			Console.WriteLine("Please insert licence number");
			string licenceNumber = Console.ReadLine();
			i_Vehicle.LicenceNumber = licenceNumber;

			if (i_Garage.InsertNewVehicleToGarage(i_Vehicle))
			{
				Dictionary<string, string> generalVehicleDictionary = i_Vehicle.VehicleInput();
				Dictionary<string, string> typeVehicleDictionary = i_Vehicle.NeededInputs();

				fillDictionary(generalVehicleDictionary);
				fillDictionary(typeVehicleDictionary);

				i_Vehicle.ParseVehicleInput(generalVehicleDictionary);
				i_Vehicle.ParseNeededInput(typeVehicleDictionary);
			}
			else
			{
                Dictionary<string, string> excistingVehicleDictionary = i_Vehicle.InputForExistingVehicle();

				fillDictionary(excistingVehicleDictionary);

				i_Vehicle.ParseExsitcingVehicleInput(excistingVehicleDictionary);

				i_Vehicle.VehicleState = GarageLogic.Vehicle.eVehicleState.RepairInProgress;
			}
		}

        private static void fillDictionary(Dictionary<string, string> i_Dictionary)
        {
            List<string> keys = new List<string>(i_Dictionary.Keys);
            foreach (string key in keys)
            {
                Console.WriteLine(key);
                string userInputValue = Console.ReadLine();
                i_Dictionary[key] = userInputValue;
            }
        }

        private static void printLicenceNumbersOfVehicles(GarageLogic.Garage i_Garage)
        {
            Console.WriteLine("Do you want to print with filter?");
            Console.WriteLine("Press 0 for no filter, 1 for Repair In Progress, 2 for Repair Complete, 3 for Paid");
            int chosenFilter;

            while (!int.TryParse(Console.ReadLine(), out chosenFilter) || !(chosenFilter >= 0 && chosenFilter <= 3))
            {
                Console.WriteLine("Invalid filter. please choose valid filter.");
            }

            switch (chosenFilter)
            {
                case 0:
                    Console.WriteLine(i_Garage.GetLicenceNumbers());
                    break;
                case 1:
                    Console.WriteLine(i_Garage.GetLicenceNumbers(GarageLogic.Vehicle.eVehicleState.RepairInProgress));
                    break;
                case 2:
                    Console.WriteLine(i_Garage.GetLicenceNumbers(GarageLogic.Vehicle.eVehicleState.RepairComplete));
                    break;
                case 3:
                    Console.WriteLine(i_Garage.GetLicenceNumbers(GarageLogic.Vehicle.eVehicleState.Paid));
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
            /*Console.WriteLine("Please enter 1 for Octan95, 2 for Octan96, 3 for Octan98, 4 for Soler.");
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
            }*/

            Console.WriteLine("Please enter amount of fuel to fill in liters");
            float amountToFill;
            bool isElectric = false;

            while (!float.TryParse(Console.ReadLine(), out amountToFill))
            {
                Console.WriteLine("Invalid amount. please insert valid amount.");
            }

            i_Garage.FillEnergyInVehicle(licenceNumber, amountToFill, isElectric);
        }

        private static void fillElectricity(GarageLogic.Garage i_Garage)
        {
            Console.WriteLine("Please enter the vehicle licence number");
            string licenceNumber = Console.ReadLine();
            Console.WriteLine("Please enter amount of energy to fill in minutes");
            float amountToFill;
            bool isElectric = true;

            while (!float.TryParse(Console.ReadLine(), out amountToFill))
            {
                Console.WriteLine("Invalid amount. please insert valid amount.");
            }

            i_Garage.FillEnergyInVehicle(licenceNumber, amountToFill, isElectric);
        }

        private static void displayVehicleDetails(GarageLogic.Garage i_Garage)
        {
            Console.WriteLine("Please enter the vehicle licence number");
            string licenceNumber = Console.ReadLine();
            Console.WriteLine(i_Garage.DisplayVehicleDetails(licenceNumber));
        }
    }
}
