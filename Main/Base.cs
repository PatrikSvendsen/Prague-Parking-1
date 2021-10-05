using System;
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
    *
    *
    *
    *
    *
    *Fixa ticket system
    *
    *-----MENY
    **Gör menu snyggare
    **Använda try-catch funktion för meny.
    **Få in alla valbara menyer.
    *
    *----MoveVehicle
    *Fungerar.
    *Man kan flytta enskild bil eller MC. Flytta ut en MC från en dubbelparkering samt flytta in en mc till en annan mc.
    *
    *
    *---CollectVehicle
    *Funktion fungerar. Behöver förbättras med try & catch
    */

namespace Main
{

    public class Base
    {
        public static string[] parkingList = new string[100];     //Tilldelade 100 platser för parkeringen.
        //public static string[] parkingList = new string[3];     //Test array

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
                        Console.WriteLine("This is the default in main menu.");
                        break;
                }
                #region RegisterVehicle
                if (menu == 1)          //Registrera fordon
                {

                    /*
                     * Denna undermenu skall registrera ett fordon
                     * 
                     * TODO: dubbla MC kontroller EJ för dubbletter
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
                        case 1:
                        case 2: break;
                        case 3: break;

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
                        bool vPlateCheck = CheckIfDupplicate(vehiclePlate);             // Om kontrollen ger en false tillbaka betyder de att regnumret redan finns.
                        if (spot >= 0 && vPlateCheck == true)
                        {
                            //string NoVType = RemoveTypeOfVehicle(newVPlate, vehiclePlate); // kontrollerar om regnr är mindre än 10 långt.
                            bool checkLengthPlate = CheckPlateLength(vehiclePlate);              // kontrollerar för dubbla regnr.

                            if (checkLengthPlate == true)
                            {
                                parkingList[spot] = newVPlate;
                                Console.WriteLine("Vehicle with license plate: {0} is now parked at P{1} at {2}", newVPlate, spot + 1, now);
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
                                string mcPlate = newmcPlate1 + " | " + newmcPlate2;
                                parkingList[spot] = mcPlate;
                                Console.WriteLine("Vehicle with license plate: {0} is now parked at P{1} at {2}", mcPlate, spot + 1, now);
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
                        else if (checkDuppPlate1 == false || checkDuppPlate2 == false)
                        {
                            if (checkDuppPlate1 == false)
                            {
                                Console.WriteLine("First license plate already exist, please try again, {0}.", mcPlate1);
                                Console.WriteLine("Press a key to return to main menu.");
                                //Console.ReadKey();
                                //continue;
                            }
                            if (checkDuppPlate2 == false)
                            {
                                Console.WriteLine("Second license plate already exist, please try again, {0}.", mcPlate2);
                                Console.WriteLine("Press a key to return to main menu.");
                                //Console.ReadKey();
                                //continue;
                            }
                            Console.ReadKey();
                            continue;
                        }

                    }
                    continue;

                }       // Registrera fordon
                #endregion
                if (menu == 2)
                {
                    /*
                     * Program för att hämta ut fordon.
                     */

                    //Console.Clear(); 
                    Console.WriteLine();
                    Console.Write("Please enter the License plate number: ");
                    string vehiclePlate = Console.ReadLine().ToUpper();
                    int spot = FindVehicleSpotInList(vehiclePlate);                 // Returnerar indexet vart fordonet står
                    string vehicleSpot = FindVehicleParkedOnSpot(vehiclePlate);     // Returnerar hela strängen som innehåller regnr
                    if (spot >= 0)
                    {
                        Console.WriteLine("Vehicle with {0} is currently parked at P{1}.\n", vehiclePlate, spot);
                        Console.WriteLine("\tCollect vehicle?\ty / n");
                        string answer = Console.ReadLine();
                        try
                        {
                            for (int i = 0; i < parkingList.Length; i++)
                            {
                                if (parkingList[i] == null)
                                {

                                }
                                if (parkingList[spot - 1].Contains(" | "))
                                {
                                    //string vehiclePlate2 = FindVehicleParkedOnSpot(vehiclePlate); //Ger tillbaka hela sträng namnet ink båda MC
                                    string[] splitVehiclePlate = vehicleSpot.Split(" | ");             // splitVehiclePlate = array
                                    string mcPlate = TypeOfVehicle(2, vehiclePlate);          // Lägger till MC@ i regnr
                                    int index1 = Array.IndexOf(splitVehiclePlate, mcPlate);    // Finner indexet vart inmatade regnr finns.

                                    if (index1 == 0)
                                    {
                                        parkingList[spot - 1] = splitVehiclePlate[1];
                                        Console.WriteLine("Motorcycle with {0} has now been collected.", mcPlate);
                                        Console.ReadKey();
                                    }
                                    else if (index1 == 1)
                                    {
                                        parkingList[spot - 1] = splitVehiclePlate[0];
                                        Console.WriteLine("Motorcycle with {0} has now been collected.", mcPlate);
                                        Console.ReadKey();
                                    }
                                    break;

                                }
                                if (parkingList[i].Contains("CAR@") || parkingList[i].Contains("MC@"))
                                {
                                    parkingList[spot - 1] = null;
                                    break;
                                }
                            }

                            if (answer == "y")
                            {
                                //string emptySpot = ClearParkingSpot(spot);
                                Console.WriteLine("\nParking spot is now empty");
                                Console.WriteLine("Press a key to return to main menu");
                                Console.ReadKey();
                                continue;
                            }
                            else if (answer == "n")
                            {
                                Console.WriteLine("Press a key to return to main menu");
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

                    Console.WriteLine("\n\tDo you want to move a Car, single MC or two motorcycles?");
                    Console.WriteLine("1) Car");
                    Console.WriteLine("2) 1 motorcycle");
                    Console.WriteLine("3) 2 Motorcycle");

                    int submenu = int.Parse(Console.ReadLine());

                    switch (submenu)
                    {
                        case 1:
                        case 2: break;
                        case 3: break;
                        default:
                            break;
                    }
                    Console.WriteLine("Enter your license plate number: ");
                    string vehiclePlate = Console.ReadLine().ToUpper();

                    int newSpot;
                    int newSpot0;
                    int newSpot1;

                    //string unSplitedPlate = Console.ReadLine().ToUpper();
                    //string vehiclePlate = SplitVehiclePlates(unSplitedPlate);
                    if (submenu == 1 || submenu == 2)                       // Fungerar att flytta enskilda fordon fortfarande
                    {
                        for (int i = 0; i < parkingList.Length; i++)
                        {
                            if (parkingList[i] == null)     // Används för att sätta första värdet på null, så allt inte krashar. Hjälp av Edwin
                            {
                                continue;
                            }
                            if (parkingList[i].Contains(vehiclePlate))
                            {
                                //Console.Clear();
                                Console.WriteLine("Vehicle is currently parked at {0}\n", i + 1);
                                Console.WriteLine("Please enter a new parking spot");
                                newSpot = int.Parse(Console.ReadLine());
                                string movingVehiclePlate = FindVehicleParkedOnSpot(vehiclePlate);

                                if (movingVehiclePlate.Contains("CAR@"))                    // Fungerar att flytta en bil.
                                {
                                    if (parkingList[newSpot - 1] == null)
                                    {
                                        parkingList[newSpot - 1] = parkingList[i];
                                        parkingList[i] = null;
                                        Console.WriteLine("Vehicle with license plate {0} can now be moved to spot {1}", vehiclePlate, newSpot);
                                        Console.ReadKey();
                                        //MainMenu();
                                        break;
                                    }
                                    else if (parkingList[newSpot - 1] != parkingList[i])
                                    {
                                        Console.ForegroundColor = ConsoleColor.Red;
                                        Console.WriteLine();
                                        Console.WriteLine("A vehicle with {0} is already parked on this spot", parkingList[newSpot - 1]);
                                        Console.WriteLine();
                                        Console.ResetColor();
                                        Console.ReadKey();
                                        break;
                                    }
                                }
                                else if (movingVehiclePlate.Contains("MC@"))
                                {
                                    if (parkingList[newSpot - 1] == null)
                                    {
                                        parkingList[newSpot - 1] = parkingList[i];
                                        parkingList[i] = null;
                                        Console.WriteLine("Vehicle with license plate {0} is moved to spot {1}", vehiclePlate, newSpot);
                                        Console.ReadKey();
                                        //MainMenu();
                                        break;
                                    }
                                    //else if (parkingList[newSpot - 1] != parkingList[i])                // Program för att ge röd kod om det står ett fordon på platsen redan.
                                    else if (parkingList[newSpot - 1].Contains("CAR@") == true)                // Program för att ge röd kod om det står ett fordon på platsen redan.
                                    {
                                        Console.ForegroundColor = ConsoleColor.Red;
                                        Console.WriteLine();
                                        Console.WriteLine("A car with {0} is already parked on this spot", parkingList[newSpot - 1]);
                                        Console.WriteLine();
                                        Console.ResetColor();
                                        Console.ReadKey();
                                        break;
                                    }
                                    else if (parkingList[newSpot - 1].Contains(" | ") == true)
                                    {
                                        Console.ForegroundColor = ConsoleColor.Red;
                                        Console.WriteLine();
                                        Console.WriteLine("This parking spot is full. Please choose another spot.");
                                        Console.WriteLine();
                                        Console.ResetColor();
                                        Console.ReadKey();
                                    }
                                    else if (parkingList[newSpot - 1].Contains("MC@") == true)
                                    {
                                        vehiclePlate = TypeOfVehicle(2, vehiclePlate);
                                        string parkedMc = parkingList[newSpot - 1];
                                        string mcPlate0 = parkedMc + " | " + vehiclePlate;
                                        parkingList[newSpot - 1] = mcPlate0;
                                        parkingList[i] = null;
                                        Console.WriteLine("Motorcycle is now parked on spot {0}", newSpot);
                                        Console.ReadKey();
                                        break;


                                    }
                                }
                            }
                        }
                    }
                    else if (submenu == 3)
                    {
                        for (int i = 0; i < parkingList.Length; i++)
                        {
                            if (parkingList[i] == null)
                            {
                                continue;
                            }
                            if (parkingList[i].Contains(vehiclePlate))
                            {
                                /*
                                 * i = aktuell parkeringsplats för fordonet
                                 */

                                //Console.Clear();
                                Console.WriteLine("This vehicle is currently parked at {0}\n", i + 1); // Hittar och listar vart fordonet är parkerat.

                                string vehiclePlate2 = FindVehicleParkedOnSpot(vehiclePlate); //Ger tillbaka hela sträng namnet ink båda MC

                                string[] splitVehiclePlate = vehiclePlate2.Split(" | ");             // splitVehiclePlate = array
                                string mcPlate = TypeOfVehicle(2, vehiclePlate);          // Lägger till MC@ i regnr
                                int index1 = Array.IndexOf(splitVehiclePlate, mcPlate);    // Finner indexet vart inmatade regnr finns. 

                                //Console.WriteLine(mcPlate);                               // Skriver ut regnr med beteckning
                                //Console.WriteLine("This is the index of input vehicle plate: {0}", index1);               //Ska printa index av input REG

                                if (index1 == 0)
                                {
                                    Console.WriteLine("Please enter a new parking spot");
                                    newSpot0 = int.Parse(Console.ReadLine());
                                    //Console.Clear();

                                    if (parkingList[newSpot0 - 1] == null || parkingList[newSpot0 - 1].Contains("MC@") == true)  //TODO: Fungerar. Den kollar om platsen är tom eller om en MC står där.
                                    {
                                        if (parkingList[newSpot0 - 1] == null)
                                        {
                                            parkingList[newSpot0 - 1] = splitVehiclePlate[0];
                                            string mcPlate1 = splitVehiclePlate[1];
                                            parkingList[i] = splitVehiclePlate[1];
                                            Console.WriteLine("Vehicle with license plate {0} is moved to spot {1}", mcPlate, newSpot0);
                                            Console.WriteLine("and motorcycle with {0} is standing on parking spot {1}", mcPlate1, i + 1);
                                            Console.ReadKey();
                                            //MainMenu();
                                            break;
                                        }
                                        else if (parkingList[newSpot0 - 1].Contains("MC@"))
                                        {

                                            string mcPlate2 = parkingList[newSpot0 - 1];
                                            //Console.WriteLine(mcPlate2);
                                            string newMcPlate = mcPlate2 + " | " + mcPlate;
                                            string mcPlate1 = splitVehiclePlate[1]; https://discord.com/channels/@me/480669656613650442
                                            parkingList[i] = splitVehiclePlate[1];
                                            parkingList[newSpot0 - 1] = newMcPlate;
                                            Console.WriteLine("Vehicle with license plate {0} is moved to spot {1} and is now standing with {2}", mcPlate, newSpot0, mcPlate2);
                                            Console.WriteLine("and motorcycle with {0} is standing on parking spot {1}", mcPlate1, i + 1);
                                            Console.ReadKey();
                                            break;
                                        }

                                    }
                                    else if (parkingList[newSpot0 - 1].Contains("CAR@"))
                                    {
                                        Console.ForegroundColor = ConsoleColor.Red;
                                        Console.WriteLine();
                                        Console.WriteLine("A vehicle with {0} is already parked on this spot", parkingList[newSpot0 - 1]);
                                        Console.WriteLine();
                                        Console.ResetColor();
                                        Console.ReadKey();
                                        break;
                                    }
                                }
                                else if (index1 == 1)
                                {
                                    Console.WriteLine("Please enter a new parking spot: ");
                                    newSpot1 = int.Parse(Console.ReadLine());
                                    //Console.Clear();
                                    if (parkingList[newSpot1 - 1] == null || parkingList[newSpot1 - 1].Contains("MC@") == true)
                                    {
                                        if (parkingList[newSpot1 - 1] == null)
                                        {
                                            parkingList[newSpot1 - 1] = splitVehiclePlate[1];
                                            string mcPlate0 = splitVehiclePlate[0];
                                            parkingList[i] = splitVehiclePlate[0];
                                            Console.WriteLine("Vehicle with license plate {0} is moved to spot {1}", mcPlate, newSpot1);
                                            Console.WriteLine("and motorcycle with {0} is standing on parking spot {1}", mcPlate0, i + 1);
                                            Console.ReadKey();
                                            break;
                                        }
                                        else if (parkingList[newSpot1 - 1].Contains("MC@"))
                                        {
                                            string mcPlate1 = parkingList[newSpot1 - 1];
                                            //Console.WriteLine(mcPlate2);
                                            string newMcPlate = mcPlate1 + " | " + mcPlate;
                                            string mcPlate0 = splitVehiclePlate[0];
                                            parkingList[i] = splitVehiclePlate[0];
                                            parkingList[newSpot1 - 1] = newMcPlate;
                                            Console.WriteLine("Vehicle with license plate {0} is moved to spot {1} and is now standing with {2}", mcPlate, newSpot1, mcPlate1);
                                            Console.WriteLine("and motorcycle with {0} is standing on parking spot {1}", mcPlate0, i + 1);
                                            Console.ReadKey();
                                            break;
                                        }
                                    }
                                    else if (parkingList[newSpot1 - 1].Contains("CAR@"))
                                    {
                                        Console.ForegroundColor = ConsoleColor.Red;
                                        Console.WriteLine();
                                        Console.WriteLine("A vehicle with {0} is already parked on this spot", parkingList[newSpot1 - 1]);
                                        Console.WriteLine();
                                        Console.ResetColor();
                                        Console.ReadKey();
                                        break;
                                    }
                                }
                            }
                        }
                    }
                }       // Flytta fordon
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

                        if (spot >= 0)
                        {
                            string vehicleSpot = parkingList[spot - 1];
                            Console.WriteLine("\n\t\nVehicle with license plate: {0} is currently parked at P{1}.\n", vehicleSpot, spot);
                            Console.WriteLine("\nPress a key to return to main menu.");
                            Console.ReadKey();
                            continue;
                        }
                        else if (spot < 0)
                        {
                            Console.WriteLine("We cannot find a vehicle with that licenses plate.");
                            Console.WriteLine("\nPress a key to return to main menu.");
                            //Console.WriteLine("Rad 167");
                            Console.ReadKey();
                        }
                        continue;
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

        public static int FindVehicleSpotInList(string vehiclePlate)        // Problem att hitta korrekt SPOT. Returnerar alltid 0.
        {
            /*
             * Metod för att hitta på vilken plats fordonet står på, behöver vehiclePlate och ger ut en parking spot i form av int.
             */
            for (int i = 0; i < parkingList.Length; i++)
            {
                if (parkingList[i] == null)
                {
                    continue;
                }
                if (parkingList.Contains("CAR@" + vehiclePlate) || (parkingList.Contains("MC@" + vehiclePlate) || parkingList[i].Contains(" | ")))
                {
                    if (parkingList[i].Contains("CAR@" + vehiclePlate))
                    {
                        return i + 1;
                    }
                    else if (parkingList[i].Contains("MC@" + vehiclePlate))
                    {
                        return i + 1;
                    }
                }
                //else
                //{

                //}
            }
            return -1;
        }
        public static string FindVehicleParkedOnSpot(string vehiclePlate)        //Fungerar
        {
            //    /*
            //     * Metod för att for-loopa igenom parkeringslistan - returnerar regnr på parkerad bil på specifik plats.
            //     */

            for (int i = 0; i < parkingList.Length; i++)
            {
                if (parkingList[i] == null)
                {
                    continue;
                }
                //if (parkingList.Contains("CAR@" + vehiclePlate) || parkingList.Contains("MC@" + vehiclePlate))
                if (parkingList[i].Contains(vehiclePlate))
                {
                    string returnedPlate = parkingList[i];
                    return returnedPlate;
                }
            }
            return null;
        }
        public static int CheckIfSpotIsEmpty(bool check)        //Fungerar
        {
            /*
             * Metod för att kontrollera om en plats är ledig.
             */

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
            //if (Array.IndexOf(parkingList, "CAR@" + vehiclePlate) >= 0)
            //{
            //    return false;
            //}
            //if (Array.IndexOf(parkingList, "MC@" + vehiclePlate) >= 0)
            //{
            //    return false;
            //}
            for (int i = 0; i < parkingList.Length; i++)
            {
                if (parkingList[i] == null)
                {
                    continue;
                }
                if (parkingList.Contains("CAR@" + vehiclePlate) || (parkingList.Contains("MC@" + vehiclePlate) || parkingList[i].Contains(" | ")))
                {
                    if (parkingList[i].Contains("CAR@" + vehiclePlate))
                    {
                        return false;
                    }
                    else if (parkingList[i].Contains("MC@" + vehiclePlate))
                    {
                        return false;
                    }
                }
            }
            return true;
        }
        public static string ClearParkingSpot(int spot)
        {
            for (int i = 0; i < parkingList.Length; i++)
            {
                if (parkingList[i] == null)
                {
                    continue;
                }
                else
                {
                    parkingList[spot] = null;
                    return null;
                }
            }
            return "";
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

        //public static int SplitArrayFindIndex(string[] vehiclePlate, string inputPlate)  // Behöver 2 argument, hela stringen ink.
        //                                                                               // Båda MC reg och input reg
        //{
        //    //string[] splitVehiclePlate = vehiclePlate.Split(" | ");             // splitVehiclePlate = array
        //    int index = Array.IndexOf(vehiclePlate, inputPlate);
        //    return index;
        //}
        //public static string[] SplitVehiclePlates(string vehiclePlate)        // Returner en string av 2 MCs
        //{
        //    //Program för att splitta en sträng
        //    string[] splitVehiclePlate = vehiclePlate.Split(" | ").ToArray();
        //    return splitVehiclePlate;

        //}
        //public static string MotorcycleVehiclePlate(string splitVPlateArr)
        //{

        //}
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






