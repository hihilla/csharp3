namespace Ex03.GarageLogic
{
    using System;
    using System.Collections.Generic;
    using System.Text;

    public class Car : Vehicle
    {
        private static readonly int sr_MaxNumOfDoors = 5;
        private static readonly int sr_MinNumOfDoors = 2;
        private eColor m_carColor;
        private int m_numberOfDoors; // {2, 3, 4, 5}   

        private static readonly string sr_CarColorKey = "Car Color";
        private static readonly string sr_NumberOfDoorsKey = "Number of doors";

        public Car(
            eEnergyType i_EnergyType,
            Nullable<eFuelType> i_FuelType,
            float i_MaximalEnergyLevel,float i_MaxAirPressure, int i_NumOfWheels,
            int i_NumOfDoors)
            : base(i_EnergyType, i_FuelType, i_MaximalEnergyLevel,
                    i_MaxAirPressure, i_NumOfWheels)
        {
            this.m_numberOfDoors = i_NumOfDoors;
        }

        public override Dictionary<string, string> NeededInputs()
        {
            Dictionary<string, string> inputNeeded = new Dictionary<string, string>();
            inputNeeded.Add(sr_CarColorKey, null);
            inputNeeded.Add(sr_NumberOfDoorsKey, null);

            return inputNeeded;
        }

        public override void ParseNeededInput(Dictionary<string, string> i_InputToParse)
        {
            string carColor;
            string numOfDoorsInput;
            int numberOfDoors = 0;

            if (!i_InputToParse.TryGetValue(sr_CarColorKey, out carColor)){
                throw new FormatException("No Car Color");
			}
			
            if (!((i_InputToParse.TryGetValue(sr_NumberOfDoorsKey, out numOfDoorsInput)) || 
                  (int.TryParse(numOfDoorsInput, out numberOfDoors))))
			{
				throw new FormatException("No Number of doors");
			}

            if (!(numberOfDoors > 2 && numberOfDoors < 5)) {
                string exceptionMsg = string.Format("Number of doors should be minimun {0} and maximum {1}", 
                                                    sr_MinNumOfDoors, sr_MaxNumOfDoors);
                throw new ArgumentException(exceptionMsg);
            }

            switch (carColor.ToLower())
            {
                case "yellow":
                    this.m_carColor = eColor.Yellow;
                    break;
				case "white":
                    this.m_carColor = eColor.White;
					break;
				case "black":
                    this.m_carColor = eColor.Black;
					break;
				case "blue":
                    this.m_carColor = eColor.Blue;
					break;
                default:
                    throw new ArgumentException("Invalid car color");
            }

            this.m_numberOfDoors = numberOfDoors;
        }

        public enum eColor
        {
            Yellow,
            White,
            Black,
            Blue
        }

        public override string ToString()
        {
            StringBuilder carToString = new StringBuilder();
            carToString.AppendFormat("{0} Car\n", this.EnergyType);
            carToString.AppendFormat("The car has {0} doors\nColor: {1}", this.m_numberOfDoors, this.m_carColor);
            carToString.Append(base.ToString());

            return null;
        }
    }
}
