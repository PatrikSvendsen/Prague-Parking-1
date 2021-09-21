﻿using System;
using System.Linq;
//using NewVehicle;

/* Program som skall kunna ta emot kunder och registrera deras fordon (Bil/MC) samt hämta ut.
 * Krav på vad systemet skall klara av
    ● Systemet skall kunna ta emot ett fordon och tala om vilken parkeringsplats den får.
    ● Manuellt flytta ett fordon från en plats till en annan.
    ● Ta bort fordon vid uthämtning.
    ● Söka efter fordon.
    ● Kunden önskar en textbaserad meny

    **TODO:
    *Få in alla valbara menyer.
    *Fixa listor för alla parkeringsplatser
    *Använda try-catch funktion för meny.
    *Använda while-loop för menu så att den loopar tillbaka efter en metod blivit kallad.
    *Gör menu snyggare
    *Här bör man kunna lägga till alternativ om att flytta en befintlig kund samt söka efter fordon
    *Använda switch-case i frågorna?
    *Göra classer av metoderna/parkeringen så att man kan använda den vartsomhelst. Samt en start-class.
    *Använda .Contains funktion, finns övningar sen tidigare där detta blev täckt.
    *Implementera DateTime.Now för att få fram tid.
    *Fixa ticket system
    *
    */

namespace Main
{
    public class Base
    {

        public static string[] parkingList = new string[100];     //Tilldelade 100 platser för parkeringen.

        public static void Main(string[] args)
        {
            MainMenu();
        }

        public static void MainMenu()               //Text för meny
        {
            Console.Clear();
            Console.WriteLine("Welcome! This program is made for registering and collecting cars at a parking lot.\n");
            Console.WriteLine("1) Register vehicle");
            Console.WriteLine("2) Collect vehicle");
            Console.WriteLine("3) Move vehicle");
            Console.WriteLine("4) Show parkinglist");
            Console.WriteLine("5) Exit");
            Console.Write("\r\nSelect an option: ");
            

            //int menuInput = int.Parse(Console.ReadLine());

            //if (menuInput >= 1 && menuInput <= 5)
            //{

            int menu = int.Parse(Console.ReadLine());
            switch (menu)                       //switchen för menu.
            {
                case 1: TypeOfVehicle(); break;
                case 2: CollectVehichle(); break;
                case 3: MoveVehicle(); break;
                case 4: ShowParkingList(); break;

                default:
                    Console.WriteLine("Felsökning, rad 60");
                    MainMenu();
                    break;
            }
        }
        public static void TypeOfVehicle()
        {
            Console.Clear();
            Console.WriteLine();
            Console.WriteLine("Please choose below what type of vehcle you have: ");
            Console.WriteLine();
            Console.WriteLine("1) Car");
            Console.WriteLine("2) MC");
            Console.WriteLine("3) Return to main menu");
            Console.WriteLine();

            int submenu = int.Parse(Console.ReadLine());
            switch (submenu)
            {
                case 1: Console.WriteLine("Rad 78"); RegisterCar(); break;
                case 2: Console.WriteLine("Rad 79"); RegisterMC(); break;
                case 3: Console.WriteLine("Rad 80"); MainMenu(); break;

                default:
                    Console.WriteLine("Nu är fan något fel: Rad 85");
                    break;
            }
            //MainMenu();
        }
        public static void RegisterCar()       //TODO: Snygga till koden - RegisterCar
        {
            Console.Clear();
            Console.WriteLine();
            Console.Write("Please enter the License plate number: ");
            string carPlate = Console.ReadLine().ToUpper();
            Console.WriteLine();
            if (parkingList.Contains(carPlate))
            {
                Console.WriteLine();
                Console.WriteLine("Car is already parked");
                MainMenu();
            }
            else if (carPlate.Length <= 10)
            {
                for (int i = 0; i < parkingList.Length; i++)
                {
                    if (parkingList[i] == null)
                    {
                        parkingList[i] = carPlate;
                        Console.WriteLine("Your car with license plate:{0} is parked at spot {1}", carPlate, i + 1);
                        break;
                    }
                }
                Console.ReadKey();
                MainMenu();

            }
        }
        public static void RegisterMC()
        {
            Console.Clear();
            Console.WriteLine();
            Console.WriteLine("Rad 99");
            Console.WriteLine();
        }
        //public static void Vehicle()
        //{
        //    Console.WriteLine("Please enter the licenseplate number: \n");
        //    //var vehicle = new Vehicle((Console.ReadLine()), Console.ReadLine(), 1);
        //    //Console.WriteLine($"Vehicle with {vehicle.LicensePlate} was given parking spot:  Type of car:{vehicle.TypeOfCar}");
        //}
        public static void CollectVehichle()
        {
        }
        public static void MoveVehicle()
        {
        }

        public static void ShowParkingList() //TODO: Gör en fix så att endast text kommer upp om hur många platser som är tomma inte alla 100 på en gång.
        {
            //Console.WriteLine("Rad 147");
            Console.Clear();
            int counter = 1;
            int emptySpot = 0;
            foreach (var carPlate in parkingList)
            {
                emptySpot++;
                if (carPlate == null)
                {
                    Console.WriteLine("Parkingspot {0} is not used", emptySpot);
                }
                else
                {
                    Console.WriteLine("Parkingspot {0} is taken by {1}", counter, carPlate);
                    counter++;
                }
            }
        }

    }
}









