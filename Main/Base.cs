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
    *Funkar för enskilda fordon, måste anpassas för flera MC
    */

namespace Main
{

    public class Base
    {

        //public static string[] parkingList = new string[100];     //Tilldelade 100 platser för parkeringen.

        public static string[] parkingList = {"CAR@ABC123", "CAR@ABC321", "CAR@ABC111", "" , "" };     //Test array

        public static void Main(string[] args)
        {
            while (true)
            {
                DateTime now = DateTime.Now;
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

                    case 1: break;
                    case 2: break;
                    case 3: break;
                    case 4: break;
                    case 5: break;

                    default:
                        Console.WriteLine("Felsökning, rad 60");
                        break;
                }
                if (menu == 1)          //Registrera fordon
                {

                    /*
                     * Denna undermenu skall registrera ett fordon
                     */


                    //Console.Clear();
                    Console.WriteLine();
                    Console.WriteLine("Please choose below what type of vehcle you want to register: \t");
                    Console.WriteLine("1) Car");
                    Console.WriteLine("2) 1 MC");
                    Console.WriteLine("3) 2 MC's");

                    int submenu = int.Parse(Console.ReadLine());
                    switch (submenu)

                    {
                        case 1: int input1 = submenu; break;
                        case 2: break;
                        case 3: int input3 = submenu; break;

                        default:
                            Console.WriteLine("If you are here, something bad happened. Press any key to return back.");
                            Console.ReadKey();
                            break;

                    }

                    bool check = false;
                    int spot = CheckIfSpotIsEmpty(check);
                    if (submenu == 1 || submenu == 2)
                    {
                        Console.Write("Please enter the License plate number: ");
                        string vehiclePlate = Console.ReadLine().ToUpper();
                        Console.WriteLine();
                        string newVPlate = TypeOfVehicle(submenu, vehiclePlate);
                        bool vPlateCheck = CheckIfDupplicate(vehiclePlate);
                        if (spot >= 0 && vPlateCheck == true)
                        {
                            //string NoVType = RemoveTypeOfVehicle(newVPlate, vehiclePlate); // kontrollerar om regnr är mindre än 10 långt.
                            bool checkLengthPlate = CheckPlateLength(vehiclePlate);              // kontrollerar för dubbla regnr.

                            if (checkLengthPlate == true)
                            {
                                parkingList[spot] = newVPlate;
                                Console.WriteLine("Your vehicle with license plate: {0} is now parked at P{1} at {2}", newVPlate, spot + 1, now);
                                Console.WriteLine("Press a key to return to main menu.");
                                Console.ReadKey();
                                //MainMenu();
                                continue;
                            }
                            else
                            {
                                Console.WriteLine("You entered a to long license plate.");
                                Console.WriteLine("\n\nPress a key to return to main menu.");
                                Console.ReadKey();
                                continue;
                            }
                        }
                        else if (spot < 0)
                        {
                            Console.WriteLine("There are no empty spots left.");
                            Console.WriteLine("Press a key to return to main menu");
                            Console.ReadKey();
                        }
                        else if (vPlateCheck == false)
                        {
                            Console.WriteLine("This license plate already exist, {0}", vehiclePlate);
                            Console.WriteLine("\n\nPress a key to return to main menu.");
                            Console.ReadKey();
                            continue;
                        }
                    }
                    else if (submenu == 3)
                    {
                        Console.Write("Please enter the License plate number of the first motorcycle: ");
                        string mcPlate1 = Console.ReadLine().ToUpper();
                        Console.Write("Please enter the License plate number of the second motorcycle: ");
                        string mcPlate2 = Console.ReadLine().ToUpper();
                        Console.WriteLine();
                        string newmcPlate1 = TypeOfVehicle(submenu, mcPlate1);
                        string newmcPlate2 = TypeOfVehicle(submenu, mcPlate2);
                        bool checkDuppPlate1 = CheckIfDupplicate(mcPlate1);
                        bool checkDuppPlate2 = CheckIfDupplicate(mcPlate2);

                        if (spot >= 0 && checkDuppPlate1 && checkDuppPlate2 == true)
                        {
                            //string noMcType1 = RemoveTypeOfVehicle(newmcPlate1, mcPlate1); // metod som tar bort typen på regnr.
                            //string noMcType2 = RemoveTypeOfVehicle(newmcPlate2, mcPlate2); // metod som tar bort typen på regnr.
                            bool checkLength1 = CheckPlateLength(mcPlate1);                // kontrollerar om regnr är mindre än 10 långt.
                            bool checkLength2 = CheckPlateLength(mcPlate2);                // kontrollerar om regnr är mindre än 10 långt.

                            if (checkLength1 && checkLength2 == true)
                            {
                                string mcPlate = newmcPlate1 + " " + newmcPlate2;
                                parkingList[spot] = mcPlate;
                                Console.WriteLine("Your vehicle with license plate: {0} is now parked at P{1} at {2}", mcPlate, spot + 1, now);
                                Console.WriteLine("Press a key to return to main menu.");
                                Console.ReadKey();
                                //MainMenu();
                                continue;
                            }
                            else if (checkLength1 == false)
                            {
                                Console.WriteLine("License plate 1 is: {0}", checkLength1);
                                Console.WriteLine("\n\nPress a key to return to main menu.");
                                Console.ReadKey();
                                continue;

                            }
                            else
                            {
                                Console.WriteLine("License plate 2 is: {1}", checkLength2);
                                //Console.WriteLine("You entered a to long license plate.");
                                Console.WriteLine("\n\nPress a key to return to main menu.");
                                Console.ReadKey();
                                continue;
                            }
                        }
                        else if (spot < 0)
                        {
                            Console.WriteLine("There are no empty spots left.");
                            Console.WriteLine("Press a key to return to main menu");
                            Console.ReadKey();
                        }
                        else if (checkDuppPlate1 || checkDuppPlate2 == true)
                        {
                            if (checkDuppPlate1 == false)
                            {
                                Console.WriteLine("First license plate already exist, please try again, {0}.", mcPlate1);
                                Console.WriteLine("Press a key to return to main menu.");
                                Console.ReadKey();
                                continue;
                            }
                            else
                            {
                                Console.WriteLine("Second license plate already exist, please try again, {0}.", mcPlate2);
                                Console.WriteLine("Press a key to return to main menu.");
                                Console.ReadKey();
                                continue;
                            }
                        }

                    }
                    continue;

                }       // Registrera fordon
                if (menu == 2)
                {
                    /*
                     * Program för att hämta ut fordon.
                     */

                    //Console.Clear(); 
                    Console.WriteLine();
                    Console.Write("Please enter the License plate number: ");
                    string vehiclePlate = Console.ReadLine().ToUpper();
                    int spot = FindVehicleSpotInList(vehiclePlate);
                    string vehicleSpot = FindVehicleParkedOnSpot(vehiclePlate);
                    if (spot >= 0)
                    {
                        Console.WriteLine("Your vehicle with license plate: {0} is currently parked at P{1}.\n", vehicleSpot, spot + 1);
                        Console.WriteLine("\tCollect vehicle?\ty / n");
                        string answer = Console.ReadLine();
                        //Console.WriteLine("\nPress a key to return to main menu.");
                        //Console.ReadKey();
                        try
                        {
                            if (answer == "y")
                            {
                                int emptySpot = ClearParkingSpot(spot);
                                Console.WriteLine("Parking spot {0} is now empty", emptySpot + 1);
                                Console.WriteLine("Press a key to return to main menu");
                                //Console.WriteLine("Rad 145");
                                Console.ReadKey();
                                continue;
                            }
                            else if (answer == "n")
                            {
                                Console.WriteLine("Press a key to return to main menu");
                                //Console.WriteLine("Rad 152");
                                Console.ReadKey();
                                break;
                            }
                        }
                        catch (FormatException e)
                        {
                            Console.WriteLine("Something happend", e);
                        }
                        break;
                    }
                    else if (spot < 0)
                    {
                        Console.WriteLine("We cannot find a vehicle with that licenses plate.");
                        Console.WriteLine("\nPress a key to return to main menu.");
                        //Console.WriteLine("Rad 167");
                        Console.ReadKey();
                    }
                }       // Hämta ut fordon
                if (menu == 3)
                {
                    /*
                     * Kod för att flytta på ett fordon från en plats till en annan.
                     */

                    Console.WriteLine("Enter your license plate number: ");
                    string vehiclePlate = Console.ReadLine().ToUpper();

                    int newSpot;

                    //string unSplitedPlate = Console.ReadLine().ToUpper();
                    //string vehiclePlate = SplitVehiclePlates(unSplitedPlate);

                    int spot = FindVehicleSpotInList(vehiclePlate);
                    Console.Clear();
                    Console.WriteLine("Your vehicle is currently parked at {0}\n", spot + 1);
                    Console.WriteLine("Please enter a new parking spot");
                    newSpot = int.Parse(Console.ReadLine());

                    if (parkingList[newSpot - 1] == null)
                    {
                        parkingList[newSpot - 1] = parkingList[spot];
                        parkingList[spot] = null;
                        Console.WriteLine("Your vehicle with license plate {0} is moved to spot {1}", vehiclePlate, newSpot);
                        Console.ReadKey();
                        //MainMenu();
                        continue;
                    }
                    else if (parkingList[newSpot] != parkingList[spot])
                    {
                        Console.ForegroundColor = ConsoleColor.Red;
                        Console.WriteLine();
                        Console.WriteLine("A vehicle with {0} is already parked on this spot", parkingList[newSpot]);
                        Console.WriteLine();
                        Console.ResetColor();
                        Console.ReadKey();
                        continue;
                    }

                    else
                    {
                        Console.WriteLine("Test");
                    }



                }
                if (menu == 4)
                {
                    /*
                     * Visar en visuell bild av hela parkeringen.
                     */

                    Console.Clear();
                    Console.WriteLine("Below is the parking lot with current parked vehicles\n");
                    {
                        ShowParkingList();
                    }
                    Console.WriteLine("\n\nPress a key to return to main menu");
                    Console.ReadKey();

                }       // Visar parkeringen
                if (menu == 5)
                {
                    /*
                     * Denna undermenu skall hitta ett specifikt fordon i arrayen.
                     */
                    try
                    {
                        //Console.Clear(); 
                        Console.WriteLine();
                        Console.Write("Please enter the License plate number: ");
                        string vehiclePlate = Console.ReadLine().ToUpper();
                        int spot = FindVehicleSpotInList(vehiclePlate);
                        string vehicleSpot = FindVehicleParkedOnSpot(vehiclePlate);
                        if (spot >= 0)
                        {
                            Console.WriteLine("\n\t\nYour vehicle with license plate: {0} is currently parked at P{1}.\n", vehicleSpot, spot);
                            Console.WriteLine("\nPress a key to return to main menu.");
                            Console.ReadKey();
                            break;
                        }
                        else if (spot < 0)
                        {
                            Console.WriteLine("We cannot find a vehicle with that licenses plate.");
                            Console.WriteLine("\nPress a key to return to main menu.");
                            //Console.WriteLine("Rad 167");
                            Console.ReadKey();
                        }
                        break;
                    }
                    catch (FormatException e)
                    {
                        Console.WriteLine("Something bad happend", e);
                    }

                }       // Hitta fordon i parkeringen
                continue;
            }
        }



        //MainMenu();
        public static string TypeOfVehicle(int input, string vehiclePlate)  //Fungerar
        {
            /*
             * Metod för att ange beteckning av fordon som registreras via input. Int väljer typ av fordon och vehiclePlate är regnr.
             */

            if (input == 1)
            {
                vehiclePlate = "CAR@" + vehiclePlate;       //Ex. CAR@AAA111
                return vehiclePlate;
            }
            else if (input == 2 || input == 3)
            {
                vehiclePlate = "MC@" + vehiclePlate;        //Ex. MC@AAA111
                return vehiclePlate;
            }
            return vehiclePlate;
        }

        public static bool CheckPlateLength(string vehiclePlate)
        {
            /*
             * Metod som kontrollerar längded på regnr.
             */
            //bool check;
            if (vehiclePlate.Length <= 10)
            {
                //check = true;
                return true;
            }
            else
            {
                return false;
            }
        }
        public static string RemoveTypeOfVehicle(string vehiclePlate, string newVPlate)
        {
            /*
             * Metod som tar bort beteckningen av ett fordon. Man måste ha in 2 strängar. 1 innan beteckning och en med beteckning
             */

            if (vehiclePlate.Contains("CAR@"))
            {
                int pos = vehiclePlate.IndexOf(newVPlate);
                if (pos >= 0)
                {
                    string removedType = vehiclePlate.Remove(0, pos);
                    //Console.WriteLine(removedType);
                    return removedType;
                }
            }
            else if (vehiclePlate.Contains("MC@"))
            {
                int pos = vehiclePlate.IndexOf(newVPlate);
                if (pos >= 0)
                {
                    string removedType = vehiclePlate.Remove(0, pos);
                    //Console.WriteLine(removedType);
                    return removedType;
                }
            }
            return newVPlate;
        } //Fungerar

        public static int FindVehicleSpotInList(string vehiclePlate)        // Problem att hitta korrekt SPOT. Returnerar 0 alltid
        {
            /*
             * Metod för att hitta på vilken plats fordonet står på, behöver vehiclePlate och ger ut en parking spot i form av int.
             */
            {
                for (int i = 0; i < parkingList.Length; i++)
                {
                    if (parkingList.Contains("CAR@" + vehiclePlate) || (parkingList.Contains("MC@" + vehiclePlate)))
                    {
                        parkingList[i].Contains(vehiclePlate);
                        return i +1;
                    }
                    else
                    {
                        return -1;
                    }
                }
                
            }
            return -1;

        }
        public static string FindVehicleParkedOnSpot(string vehiclePlate)        //Fungerar
        {
            /*
             * Metod för att for-loopa igenom parkeringslistan - returnerar regnr på parkerad bil på specifik plats.
             */

            for (int i = 0; i < parkingList.Length; i++)
            {
                if (parkingList.Contains("CAR@" + vehiclePlate) || (parkingList.Contains("MC@" + vehiclePlate)))
                {
                    if (parkingList[i].Contains(vehiclePlate))
                    {
                        return parkingList[i];
                    }
                }
            }
            return vehiclePlate;
        }

        public static int CheckIfSpotIsEmpty(bool check)
        {
            check = false;
            for (int i = 0; i < parkingList.Length; i++)
            {
                if (parkingList[i] == null)
                {
                    return i;
                }
            }

            return -1;
        }
        public static bool CheckIfDupplicate(string vehiclePlate)
        {

            if (parkingList.Contains("CAR@" + vehiclePlate) || parkingList.Contains("MC@" + vehiclePlate))
            {
                return false;
            }
            else
            {
                return true;
            }
        }
        public static int ClearParkingSpot(int spot)
        {
            int emptySpot = 0;
            parkingList[emptySpot] = parkingList[spot];
            parkingList[spot] = null;
            return spot;
        }
        public static string MoveVehicle()      //TODO: Går att flytta om registrerade fordon finns men krashar om det inte finns något.
        {
            {
                try
                {
                    Console.WriteLine("Enter your license plate number: ");
                    string vehiclePlate = Console.ReadLine().ToUpper();

                    int newSpot;

                    //string unSplitedPlate = Console.ReadLine().ToUpper();
                    //string vehiclePlate = SplitVehiclePlates(unSplitedPlate);

                    for (int i = 0; i < parkingList.Length; i++)
                    {
                        if (parkingList[i].Contains(vehiclePlate))
                        {
                            Console.Clear();
                            Console.WriteLine("Your vehicle is currently parked at {0}\n", i + 1);
                            Console.WriteLine("Please enter a new parking spot");
                            newSpot = int.Parse(Console.ReadLine());

                            if (parkingList[newSpot - 1] == null)
                            {
                                parkingList[newSpot - 1] = parkingList[i];
                                parkingList[i] = null;
                                Console.WriteLine("Your vehicle with license plate {0} is moved to spot {1}", vehiclePlate, newSpot);
                                Console.ReadKey();
                                //MainMenu();
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
                //MainMenu();
            }
            return "";//TODO: Fungerar. Måste dock sorteras upp i mindre metoder
        }
        public static void ShowParkingList()
        {
            /*
             * Metod för att ta fram arrayen/parkeringsplatsen.
             */
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
            }
        } //Fungerar


        public static string SplitVehiclePlates(string vehiclePlate)
        {
            //Program för att splitta en sträng
            string[] splitVPlate = vehiclePlate.Split(" ");

            foreach (string plate in splitVPlate)
            {
                Console.WriteLine(plate);
                Console.ReadLine();
                return plate;
            }
            return " ";
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
        //public static void MainMenu()
        //{
        //    Console.Clear();
        //    Console.WriteLine("Welcome! This program is made for registering and collecting cars at a parking lot.\n");
        //    Console.WriteLine("1) Register vehicle");
        //    Console.WriteLine("2) Collect vehicle");
        //    Console.WriteLine("3) Move vehicle");
        //    Console.WriteLine("4) Show parkinglist");
        //    Console.WriteLine("5) Find vehicle");
        //    Console.WriteLine("6) Exit FUNGERAR EJ");
        //    Console.Write("\r\nSelect an option: ");

        //    int menu = int.Parse(Console.ReadLine());
        //    switch (menu)                       //switchen för menu.
        //    {

        //        case 1: RegisterVehicle(""); break;
        //        case 2: CollectVehichle(); break;
        //        case 3: MoveVehicle(); break;
        //        //case 4: ShowParkingList(); break;
        //        case 4: int input2 = menu; break;
        //        case 5: int input3 = menu; break;

        //        default:
        //            Console.WriteLine("Felsökning, rad 60");
        //            break;
        //    }
        //    if (menu == 4)
        //    {
        //        Console.Clear();
        //        Console.WriteLine("Below is the parking lot with current parked vehicles\n");
        //        //try
        //        {
        //            int column = 6;
        //            int rows = 1;

        //            for (int i = 0; i < parkingList.Length; i++)
        //            {
        //                if (rows >= column && rows % column == 0)
        //                {
        //                    Console.WriteLine();
        //                    rows = 1;
        //                }

        //                if (parkingList[i] == null)
        //                {
        //                    Console.Write(i + 1 + ": Empty \t");
        //                    rows++;
        //                }

        //                else
        //                {
        //                    Console.Write(i + 1 + ": " + parkingList[i] + "\t");
        //                    rows++;

        //                }
        //            }
        //            Console.WriteLine("\n\nPress a key to try again ");
        //            Console.ReadKey();
        //            MainMenu();
        //        }
        //    }
        //    if (menu == 5)
        //    {
        //        //Console.Clear();
        //        Console.WriteLine("\nPlease enter your licenses plate: ");
        //        string vehiclePlate = Console.ReadLine().ToUpper();
        //        //int parkingSpot = FindVehicle(vehiclePlate);
        //        //public static int FindVehicle(string vehiclePlate)

        //        if (vehiclePlate.Length <= 10)
        //        {
        //            if (parkingList.Contains(vehiclePlate))
        //            {
        //                for (int i = 1; i < parkingList.Length; i++)
        //                {
        //                    if (parkingList[i] == vehiclePlate)
        //                    {
        //                        //Console.Clear();
        //                        Console.WriteLine("Your vehicle with {0} is parked at P{1}\n", vehiclePlate, i);
        //                        Console.WriteLine("\n\nPress a key to try again ");
        //                        Console.ReadKey();
        //                    }
        //                }
        //            }
        //            else
        //            {
        //                Console.WriteLine("You entered a wrong value");
        //                Console.WriteLine("\n\nPress a key to return to main menu");

        //            }
        //        }
        //    }
        //    if (menu == 6)
        //    {

        //    }
        //}
        //public static void RegisterVehicle(string vehiclePlate) //TODO: Dubbletter skapas inte. Dock måste det komma in om arrayen är full så ska feldmeddelande komma upp.
        //{
        //    //DateTime now = DateTime.Now;
        //    //Console.Clear(); Console.WriteLine();
        //    //Console.WriteLine("Please choose below what type of vehcle you want to register: "); Console.WriteLine();
        //    //Console.WriteLine("1) Car");
        //    //Console.WriteLine("2) MC");
        //    //Console.WriteLine("3) Return to main menu"); Console.WriteLine();

        //    //int submenu = int.Parse(Console.ReadLine());
        //    //switch (submenu)

        //    //{
        //    //    case 1: int input1 = submenu; break;
        //    //    case 2: int input2 = submenu; break;

        //    //    default:
        //    //        Console.WriteLine("If you are here, something bad happaned. Press any key to return back.");
        //    //        Console.ReadKey();
        //    //        //MainMenu();
        //    //        break;
        //    //}
        //    //Console.Write("Please enter the License plate number: ");
        //    //vehiclePlate = Console.ReadLine().ToUpper();
        //    //Console.WriteLine();

        //    //string newVPlate = TypeOfVehicle(submenu, vehiclePlate);

        //    //for (int i = 0; i < parkingList.Length; i++)
        //    //{
        //    //    if (parkingList[i] == null)
        //    //    {
        //    //        if (newVPlate.Length <= 10)
        //    //        {
        //    //            parkingList[i] = newVPlate;
        //    //            Console.WriteLine("Your vehicle with license plate: {0} is now parked at P{1} at {2}", newVPlate, i + 1, now);
        //    //            Console.WriteLine("Press a key to return to main menu.");
        //    //            Console.ReadKey();
        //    //            //MainMenu();
        //    //            break;
        //    //        }
        //    //        else
        //    //        {
        //    //            Console.WriteLine("You entered a wrong value");
        //    //            Console.WriteLine("\n\nPress a key to try again ");
        //    //            Console.ReadKey();
        //    //            break;
        //    //        }
        //    //    }
        //    //    else if (parkingList[i].Contains("CAR@" + vehiclePlate) || parkingList[i].Contains("MC@" + vehiclePlate))
        //    //    {
        //    //        Console.ForegroundColor = ConsoleColor.Red;
        //    //        Console.WriteLine("\n\nA vehicle with this license plate: {0} is already parked here.", vehiclePlate);
        //    //        Console.WriteLine("\nPress a key to return to main menu.");
        //    //        Console.ReadKey();
        //    //        Console.ResetColor();
        //    //        break;
        //    //        //MainMenu();

        //    //    }
        //    //}
        //    //Console.WriteLine("\n\nPress a key to return to main menu");
        //    //Console.ReadKey();
        //    //MainMenu();
        //}
    }
}






