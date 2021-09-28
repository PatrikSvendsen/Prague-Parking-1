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
    *
    *----MoveVehicle
    *Går att flytta fordon, står det ett fordon på den platsen kommer felmeddelande.  
    *.TrimEnd funktion kanske?
    *
    *---CollectVehicle
    *Fungerar men måste anpassas så att MC-/CAR-# läggs till - använd funktionen från MoveVehicle.
    */

namespace Main
{

    public class Base
    {


        public static string[] parkingList = new string[100];     //Tilldelade 100 platser för parkeringen.

        public static void Main(string[] args)
        {
            while (true)
            {
                MainMenu();
            }
        }
        public static void MainMenu()
        {
            Console.Clear();
            Console.WriteLine("Welcome! This program is made for registering and collecting cars at a parking lot.\n");
            Console.WriteLine("1) Register vehicle");
            Console.WriteLine("2) Collect vehicle");
            Console.WriteLine("3) Move vehicle");
            Console.WriteLine("4) Show parkinglist");
            Console.WriteLine("5) Find vehicle");
            Console.WriteLine("6) Exit FUNGERAR EJ");
            Console.Write("\r\nSelect an option: ");

            int menu = int.Parse(Console.ReadLine());
            switch (menu)                       //switchen för menu.
            {

                case 1: RegisterVehicle(""); break;
                case 2: CollectVehichle(); break;
                case 3: MoveVehicle(); break;
                case 4: ShowParkingList(); break;
                case 5: int input3 = menu; break;

                default:
                    Console.WriteLine("Felsökning, rad 60");
                    break;
            }

            if (menu == 5)
            {
                //Console.Clear();
                Console.WriteLine("\nPlease enhter your vehicles license plate: ");
                string vehiclePlate = Console.ReadLine().ToUpper();
                //int parkingSpot = FindVehicle(vehiclePlate);
                //public static int FindVehicle(string vehiclePlate)

                if (vehiclePlate.Length <= 10)
                {
                    if (parkingList.Contains(vehiclePlate))
                    {
                        for (int i = 1; i < parkingList.Length; i++)
                        {
                            if (parkingList[i] == vehiclePlate)
                            {
                                //Console.Clear();
                                Console.WriteLine("Your vehicle with {0} is parked at P{1}\n", vehiclePlate, i);
                                Console.WriteLine("\n\nPress a key to try again ");
                                Console.ReadKey();
                            }
                        }
                    }
                    else
                    {
                        Console.WriteLine("You entered a wrong value");
                        Console.WriteLine("\n\nPress a key to return to main menu");

                    }
                }
            }
            if (menu == 6)
            {
                //Console.WriteLine("Please enter a license plate to find: ");
                //string vehiclePlate = Console.ReadLine();
                //int parkingSpot = Search(vehiclePlate);
                //Console.WriteLine("Your parking spot is: " + parkingSpot);
                //Console.WriteLine("\n\nPress a key to return to main menu");
                //break;
            }
        }
        public static void RegisterVehicle(string vehiclePlate) //TODO: Fungerar delvis, måste lösa så duppleter inte skapas. Använd kod från MoveVehicle för att komma igång och hitta parkingsplatser [i]
        {
            DateTime now = DateTime.Now;
            Console.Clear(); Console.WriteLine();
            Console.WriteLine("Please choose below what type of vehcle you want to register: "); Console.WriteLine();
            Console.WriteLine("1) Car");
            Console.WriteLine("2) MC");
            Console.WriteLine("3) Return to main menu"); Console.WriteLine();

            int submenu = int.Parse(Console.ReadLine());
            switch (submenu)

            {
                case 1: int input1 = submenu; break;
                case 2: int input2 = submenu; break;

                default:
                    Console.WriteLine("If you are here, something bad happaned. Press any key to return back.");
                    Console.ReadKey();
                    //MainMenu();
                    break;
            }
            Console.Write("Please enter the License plate number: ");
            vehiclePlate = Console.ReadLine().ToUpper();
            Console.WriteLine();
            string newVPlate = TypeOfVehicle(submenu, vehiclePlate);

            for (int i = 0; i < parkingList.Length; i++)
            {
                if (parkingList[i] == null)
                {
                    if (newVPlate.Length <= 10)
                    {
                        parkingList[i] = newVPlate;
                        Console.WriteLine("Your vehicle with license plate: {0} is now parked at P{1} at {2}", newVPlate, i + 1, now);
                        Console.WriteLine("Press a key to return to main menu.");
                        Console.ReadKey();
                        MainMenu();
                        break;
                    }
                    else
                    {
                        Console.WriteLine("You entered a wrong value");
                        Console.WriteLine("\n\nPress a key to try again ");
                        Console.ReadKey();
                        break;
                    }
                }
                else if (parkingList[i].Contains("CAR@" + vehiclePlate) || parkingList[i].Contains("MC@" + vehiclePlate))
                {
                    Console.ForegroundColor = ConsoleColor.Red;
                    Console.WriteLine("\n\nA vehicle with this license plate: {0} is already parked here.", vehiclePlate);
                    Console.WriteLine("\nPress a key to return to main menu.");
                    Console.ReadKey();
                    Console.ResetColor();
                    MainMenu();

                }
            }

            //Console.WriteLine("\n\nPress a key to return to main menu");
            //Console.ReadKey();
            MainMenu();
        }

        //MainMenu();
        public static string TypeOfVehicle(int input, string vehiclePlate)
        {
            if (input == 1)
            {
                vehiclePlate = "CAR@" + vehiclePlate;
                return vehiclePlate;
            }
            else if (input == 2)
            {
                vehiclePlate = "MC@" + vehiclePlate;
                return vehiclePlate;
            }
            return vehiclePlate;
        }
        //TODO: Måste göras om
        public static string CollectVehichle()        //TODO: Fungerar EJ, måste fixas med CAR# / MC - ANVÄND TrimEnd funktion?
        {
            Console.Clear(); Console.WriteLine();
            Console.Write("Please enter the License plate number: ");
            string vehiclePlate = Console.ReadLine().ToUpper();
            //string resultPlate = Array.Find(parkingList, element => element.StartsWith("CAR@", StringComparison.Ordinal));
            //vehiclePlate = resultPlate;
            //Console.WriteLine(resultPlate);

            try
            {

            }


            catch (FormatException e)
            {
                Console.WriteLine("Something went wrong {0}", e);
            }
            return vehiclePlate;
        }
        public static string MoveVehicle()      //TODO: Går att flytta om registrerade fordon finns men krashar om det inte finns något.
        {
            {
                try
                {
                    Console.WriteLine("Enter your license plate number: ");
                    string vehiclePlate = Console.ReadLine().ToUpper();
                    int newSpot;

                    for (int i = 0; i < parkingList.Length; i++)
                    {
                        if (parkingList[i].Contains(vehiclePlate))
                        {
                            Console.Clear();
                            Console.WriteLine("Your car is currently parked at {0}\n", i + 1);
                            Console.WriteLine("Please enter a new parking spot");
                            newSpot = int.Parse(Console.ReadLine());

                            if (parkingList[newSpot -1] == null)
                            {
                                parkingList[newSpot -1] = parkingList[i];
                                parkingList[i] = null;
                                Console.WriteLine("Your vehicle with license plate {0} is moved to spot {1}", vehiclePlate, newSpot);
                                Console.ReadKey();
                                MainMenu();
                                break;
                            }
                            else if (parkingList[newSpot] != parkingList[i])
                            {
                                Console.ForegroundColor = ConsoleColor.Red;
                                Console.WriteLine();
                                Console.WriteLine("A vehicle with {0} is already parked on this spot", parkingList[newSpot]);
                                Console.WriteLine();
                                Console.ResetColor();
                                Console.ReadKey();
                                break;
                            }
                        }
                        else
                        {
                            Console.WriteLine("Test");
                        }
                    }
                }
                catch (FormatException e)
                {
                    Console.WriteLine("Something went wrong", e);
                }
                MainMenu();
            }
            return MoveVehicle();//TODO: Fungerar. Måste dock sorteras upp i mindre metoder
        }
        public static void ShowParkingList()
        {
            Console.Clear();
            Console.WriteLine("Below is the parking lot with current parked vehicles\n");
            //try
            {
                int column = 6;
                int rows = 1;

                for (int i = 0; i < parkingList.Length; i++)
                {
                    if (rows >= column && rows % column == 0)
                    {
                        Console.WriteLine();
                        rows = 1;
                    }

                    if (parkingList[i] == null)
                    {
                        Console.Write(i + 1 + ": Empty \t");
                        rows++;
                    }

                    else
                    {
                        Console.Write(i + 1 + ": " + parkingList[i] + "\t");
                        rows++;

                    }
                }
                Console.WriteLine("\n\nPress a key to try again ");
                Console.ReadKey();
                MainMenu();
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


    }
}












