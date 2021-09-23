using System;
using System.Collections.Generic;
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
    *Använda while-loop för menu så att den loopar tillbaka efter en metod blivit kallad.
    *Använda switch-case i frågorna?
    *Göra classer av metoderna/parkeringen så att man kan använda den vartsomhelst. Samt en start-class.
    *Använda .Contains funktion, finns övningar sen tidigare där detta blev täckt.
    *Implementera DateTime.Now för att få fram tid.
    *Fixa ticket system
    *
    *-----MENY
    **Gör menu snyggare
    **Använda try-catch funktion för meny.
    **Få in alla valbara menyer.
    *
    *-----LIST
    *Gör en fix så att endast text kommer upp om hur många platser som är tomma inte alla 100 på en gång.
    *Måste även kunna identifiera vad för typ av fordon som står placerat på platsen.
    *Går att använda "friviliga parametrar" från demo 07 Metoder för att kunna göra en visuell bild av parkeringen.
    */

namespace Main
{

    public class Base
    {


        public static string[] parkingList = new string[101];     //Tilldelade 100 platser för parkeringen.

        public static void Main(string[] args)
        {
            while (true)
            {
                MainMenu();
            }

        }

        public static void MainMenu()            //TODO: MENY   
        {
            Console.Clear();
            Console.WriteLine("Welcome! This program is made for registering and collecting cars at a parking lot.\n");
            Console.WriteLine("1) Register vehicle");
            Console.WriteLine("2) Collect vehicle");
            Console.WriteLine("3) Move vehicle");
            Console.WriteLine("4) Show parkinglist");
            //Console.WriteLine("5) Register Vehicle");
            Console.WriteLine("7) Exit FUNGERAR EJ");
            Console.Write("\r\nSelect an option: ");

            int menu = int.Parse(Console.ReadLine());
            switch (menu)                       //switchen för menu.
            {
                case 1: TypeOfVehicle(); break;
                case 2: CollectVehichle(); break;
                case 3: MoveVehicle(); break;
                case 4: ShowParkingList(); break;
                //case 5: RegisterVehicle(); break;

                default:
                    Console.WriteLine("Felsökning, rad 60");
                    break;
            }
            MainMenu();
        }
        public static void TypeOfVehicle()
        {
            Console.Clear(); Console.WriteLine();
            Console.WriteLine("Please choose below what type of vehcle you want to register: "); Console.WriteLine();
            Console.WriteLine("1) Car");
            Console.WriteLine("2) MC");
            Console.WriteLine("3) Return to main menu"); Console.WriteLine();

            int submenu = int.Parse(Console.ReadLine());
            switch (submenu)
            {
                case 1: Console.WriteLine("Rad 88"); RegisterCar(); break;
                case 2: Console.WriteLine("Rad 89"); RegisterMC(); break;
                //case 3: Console.WriteLine("Rad 90"); MainMenu(); break;

                default:
                    Console.WriteLine("Rad 93");
                    Console.ReadKey();
                    //MainMenu();
                    break;
            }
            //MainMenu();
        }
        public static void RegisterCar()       //TODO: Snygga till koden
        {
            Console.Clear();
            Console.WriteLine();
            Console.Write("Please enter the License plate number: ");
            string vehiclePlate = Console.ReadLine().ToUpper();
            Console.WriteLine();
            DateTime now = DateTime.Now;

            //CheckLicensePlate(vehiclePlate);
            //if (n < 0) //parkingList.Contains(vehiclePlate)
            //{
            //    Search(vehiclePlate);

            //MainMenu();
            if (parkingList.Contains(vehiclePlate))
            {
                Console.WriteLine();
                Console.WriteLine("Your vehicle is already parked");
                Console.ReadKey();
                //MainMenu();
            }
            else if (vehiclePlate.Length <= 10)
            {
                for (int i = 1; i < parkingList.Length; i++)
                {
                    if (parkingList[i] == null)
                    {
                        parkingList[i] = vehiclePlate;
                        Console.WriteLine("Your car with license plate: {0} is parked at P{1} at {2}", vehiclePlate, i, now);
                        break;
                    }

                    

                }
                Console.WriteLine("\n\nPress a key to return to main menu");
                Console.ReadKey();
                MainMenu();
            }
            else
            {
                Console.WriteLine("You entered a wrong value");
                Console.WriteLine("\n\nPress a key to try again ");
                Console.ReadKey();
                RegisterCar();
            }
        }
        public static void RegisterMC()
        {
            Console.Clear();
            Console.WriteLine();
            Console.Write("Please enter the License plate number: ");
            string carPlate = Console.ReadLine().ToUpper();
            Console.WriteLine();
            DateTime now = DateTime.Now;
            if (parkingList.Contains(carPlate))
            {
                Console.WriteLine();
                Console.WriteLine("Your motorcycle is already parked");
                Console.ReadKey();
                //MainMenu();
            }
            else if (carPlate.Length <= 10)
            {
                for (int i = 0; i < parkingList.Length; i++)
                {
                    if (parkingList[i] == null)
                    {
                        parkingList[i] = carPlate;
                        Console.WriteLine("Your motorcycle with license plate: {0} is parked at spot {1} at {2}", carPlate, i + 1, now);
                        break;
                    }
                }
                Console.WriteLine("\n\nPress a key to return to main menu");
                Console.ReadKey();
                //MainMenu();
            }
            else
            {
                Console.WriteLine("You have entered a to long lisence plate number");
                Console.WriteLine("\n\nPress a key to try again ");
                Console.ReadKey();
                RegisterMC();
            }
        }      //TODO: Måste göras om

        //public static void RegisterVehicle(string vehiclePlate)
        //{
        //    if (vehiclePlate.Length <= 10)
        //    {
        //        for (int i = 0; i < parkingList.Length; i++)
        //        {
        //            if (parkingList[i] == null)
        //            {
        //                parkingList[i] = vehiclePlate;
        //                Console.WriteLine("Your car with license plate: {0} is parked at P{1}", vehiclePlate, i + 1);

        //            }
        //        }
        //    }
        //}

        //public static void CheckLicensePlate(string vehiclePlate)
        //{
        //    if (parkingList.Contains(vehiclePlate))
        //    {
        //        Console.WriteLine("Car is already parked");
        //    }
        //    else
        //    {
        //        RegisterVehicle(vehiclePlate);
        //    }
        //}
        public static void CollectVehichle()
        {


            //Console.Write("Please enter the license plate your wish to collect: ");
            //foreach (var licensePlate in parkingList)
            //{
            //    ShowParkingList();
            //}

            Console.WriteLine("\n");
            Console.WriteLine("Please enter what parking spot or license number you wish to collect: ");

            //Console.WriteLine("Rad 197");

            //Console.WriteLine("\nVehicle with {0} has now been collected at {1}", vehiclePlate, now);
            ////Console.WriteLine("Rad 199");
            //break;
            Console.WriteLine("\n\nPress a key to return to main menu");
            Console.ReadKey();
            //MainMenu();
        }
        public static void MoveVehicle()
        {
            try
            {
                Console.WriteLine("Enter your license plate number: ");

                {
                    string vehiclePlate = Console.ReadLine().ToUpper();
                    int newSpot;

                    for (int i = 1; i < parkingList.Length; i++)
                    {
                        if (parkingList[i].Contains(vehiclePlate))
                        {
                            Console.Clear();
                            //Console.WriteLine(i);
                            Console.WriteLine("Please enter a new parking spot");
                            newSpot = int.Parse(Console.ReadLine());

                            if (parkingList[newSpot] == null)
                            {
                                parkingList[newSpot] = parkingList[i];
                                parkingList[i] = null;
                                //Console.WriteLine("Your vehicle with license plate {0} is moved to spot {1}", parkingList[newSpot], newSpot);
                                Console.WriteLine("Your vehicle with license plate {0} is moved to spot {1}", vehiclePlate, newSpot);
                                Console.ReadKey();
                                break;
                            }
                            else if (parkingList[newSpot] == parkingList[i])
                            {
                                Console.ForegroundColor = ConsoleColor.Red;
                                Console.WriteLine();
                                Console.WriteLine("Vehicle with registration plate: " + parkingList[i] + " is already parked here...");
                                Console.WriteLine();
                                Console.ResetColor();
                                break;
                            }
                        }
                        else
                        {
                            Console.WriteLine("Something went wrong. This license plate does not exist.");
                        }
                    }
                }
            }
            catch (FormatException e)
            {
                Console.WriteLine("Something went wrong, line 310: {0}", e);
            }

            //MainMenu();
        }       //TODO: Fungerar. Måste dock sorteras upp i mindre metoder

        public static void FindVehicle() { }
        public static void ShowParkingList()
        {
            Console.Clear();
            Console.WriteLine("Below is the parking lot with current parked vehicles\n");
            //try
            {
                int column = 6;
                int rows = 1;

                for (int i = 1; i < parkingList.Length; i++)
                {
                    if (rows >= column && rows % column == 0)
                    {
                        Console.WriteLine();
                        rows = 1;
                    }

                    if (parkingList[i] == null)
                    {
                        Console.Write(i + ": Empty \t");
                        rows++;
                    }

                    else
                    {
                        Console.Write(i + ": " + parkingList[i] + "\t");
                        rows++;

                    }
                }
                Console.WriteLine("\n\nPress a key to try again ");
                Console.ReadKey();
                //MainMenu();
            }
            //catch (FormatException e)
            //{4

            //    Console.WriteLine();
            //    Console.WriteLine("STOP!");
            //}
        }

        //public static void ThrowError(FormatException e)
        //{
        //    Console.WriteLine("Something went wrong with moving your vehicle", e);
        //    Console.WriteLine();
        //}
        //public static string ReturnMainMenu()
        //{
        //    try
        //    {
        //        Console.WriteLine("\n");
        //        Console.WriteLine("Press a key to key to return to main mennu");
        //        Console.ReadKey();
        //        Console.WriteLine("\n");

        //    }
        //    catch (FormatException e)
        //    {
        //        Console.WriteLine("Something went wrong, please try again", e);
        //        Console.WriteLine();
        //    }
        //    return MainMenu();
        //}

        //public static int Search(string vehiclePlate)
        //{
        //    for (int i = 0; i < parkingList.Length; i++)
        //    {
        //        if (parkingList[i].Contains(vehiclePlate))
        //        {
        //            return i;
        //        }
        //    }
        //    return -1;
        //}
    }
}











