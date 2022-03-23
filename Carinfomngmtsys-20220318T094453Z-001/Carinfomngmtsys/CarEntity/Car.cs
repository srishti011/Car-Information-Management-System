using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CarEntity
{
    public class Car
    {
        public int Id { get; set; }
        public string ManufacturerName { get; set; }
        public string Model { get; set; }
        public string Type { get; set; }
        public string Engine { get; set; }
        public double BHP { get; set; }
        public string Transmission { get; set; }
        public int Mileage { get; set; }
        public int Seat { get; set; }
        public string AirBagDetails { get; set; }
        public int BootSpace { get; set; }
        public int Price { get; set; }
        public override string ToString()
        {

            return "____________________________________________________________________________"
                +"\nCar ID: "+Id.ToString() +  "\nModel: " + Model + "\nManufacturer Name: " + ManufacturerName + 
                "\nCar Type: " + Type + "\nCar Engine: " + Engine + "\nBHP value " + BHP.ToString() + 
                "\nTransmission Type: " + Transmission + "\nMileage: " + Mileage.ToString() + "\nTotal No.Of.Seats: "
                + Seat + "\nContains Air Bag: " + AirBagDetails.ToString() + "\nBoot Space " + BootSpace.ToString() +
                "\nCost : " + Price.ToString();
        }
    }
   
}
