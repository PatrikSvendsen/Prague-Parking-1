using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
//using System.Collections.Generic;
using Parkinglist;

namespace NewVehicle
{           
        /*
        * Objekt som skall hantera vilken typ av fordon samt registrera Regnr
        */


    public class Vehicle
    {
        public static int parkingSpotSeed = 100;
        public List<Parkingspot> allParkingSpots = new List<Parkingspot>();

        string[] _type = { "Car", "MC" };

        public string ParkingSpot { get; }
        public string LicensePlate { get; set; }
        public string TypeOfCar { get; }
        

        public Vehicle(string licensePlate, string typeOfCar, int Spot)
        {
            this.LicensePlate = licensePlate;
            this.TypeOfCar = typeOfCar;
            this.ParkingSpot = parkingSpotSeed.ToString();
            parkingSpotSeed++;
            
        }
    }
}
