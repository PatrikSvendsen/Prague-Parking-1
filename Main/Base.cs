using System;

/* Program som skall kunna ta emot kunder och registrera deras fordon (Bil/MC) samt hämta ut.
 * Krav på vad systemet skall klara av
    ● Systemet skall kunna ta emot ett fordon och tala om vilken parkeringsplats den får.
    ● Manuellt flytta ett fordon från en plats till en annan.
    ● Ta bort fordon vid uthämtning.
    ● Söka efter fordon.
    ● Kunden önskar en textbaserad meny

    **TODO
    *Få in alla valbara menyer.
    *Fixa listor för alla parkeringsplatser
    *Använda try-catch funktion för meny.
    *Använda while-loop för menu så att den loopar tillbaka efter en metod blivit kallad.
    *Gör menu snyggare
    *Här bör man kunna lägga till alternativ om att flytta en befintlig kund samt söka efter fordon
    *Använda switch-case i frågorna?
    *Göra classer av metoderna/parkeringen så att man kan använda den vartsomhelst. Samt en start-class.
    *Använda .Contains funktion, finns övningar sen tidigare där detta blev täckt.
    */

namespace Main
{
    class Base
    {

        public string[] parkingLot = new string[100];     //Tilldelade 100 platser för parkeringen.

        public static void Main(string[] args)
        {
            MainMenu();
        }

        public static void MainMenu()               //Text för meny
        {
            Console.Clear();
            Console.WriteLine("Welcome! This program is made for registering and collecting cars at a parking lot.\n");
            Console.WriteLine("1) Register new customer");
            Console.WriteLine("2) Collect vehicle");
            Console.WriteLine("3) Adjust customer");
            Console.WriteLine("4) Exit");
            Console.Write("\r\nSelect an option: ");
            //Console.WriteLine("XX) Show parkinglist");

            //int menuInput = int.Parse(Console.ReadLine());

            //if (menuInput >= 1 && menuInput <= 5)
            //{

            int menu = int.Parse(Console.ReadLine());
            switch (menu)                       //switchen för menu.
            {
                case 1: NewCustomer(); break;
                case 2: CollectVehichle(); break;
                case 3: MoveVehicle(); break;
                case 4: ShowParkingList(); break;

                default:
                    Console.WriteLine("Felsökning, rad 60");
                    MainMenu();
                    break;
            }
        }
        public static void NewCustomer()
        {
            Console.WriteLine("Rad 64");
            MainMenu();
        }

        public static void CollectVehichle()
        {
        }

        public static void MoveVehicle()
        {
        }

        public static void ShowParkingList()
        {

        }


    }
}










