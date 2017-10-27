using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Abstract_class_airplane
{
   abstract class AirPlane
    {
        public int Capacity { get; private set; }//Вместимость
        public bool AutoPilotOn { get; set; } //автопилот
        public float Consumption { get; private set; } //расход топлева /// Fuel consumption. kg/km
        public int Altitude { get; set; } //высота над уровнем моря
       public static decimal TicketPrice { get; set; }
        public static int MinAltitudeAuto { get; set; }
        public static int MaxAltitudeAuto { get; set; }
        public static int Max_Hieght_Fly { get; set; }
        private int _altitudeIncrement;
        static  AirPlane()
        {
            MinAltitudeAuto = 2000;
            MaxAltitudeAuto = 10000;
            Max_Hieght_Fly = 11000;

        }
        public AirPlane(int capacity, float consuption, int altitudeIncrement)
        {
            Altitude = 0;
            AutoPilotOn = false;
            Capacity = capacity;
            Consumption = consuption;
            _altitudeIncrement = altitudeIncrement;
        }
       
        public int Climb(int increment)
        {
           if(!AutoPilotOn && Altitude + increment > MinAltitudeAuto && Altitude + increment < MaxAltitudeAuto )
            {
                Console.WriteLine("---------------------------------------");
                Console.WriteLine("Do you want to turn on the autopilot?");
                Console.WriteLine("Enable, press '1'\nSwitch off, press '0'.");
                int autopilot = Int32.Parse(Console.ReadLine());
                Console.WriteLine("---------------------------------------");
                if (autopilot == 1) { AutoPilotOn = true; return Altitude += increment; }
                else { return Altitude += increment; }
            }

            if (AutoPilotOn && Altitude + increment > MaxAltitudeAuto)
            {
                Console.WriteLine("---------------------------------------");
                Console.WriteLine("You need to turn off the autopilot");
                Console.WriteLine("Enable, press '1'\nSwitch off, press '0'.");
                int autopilot = Int32.Parse(Console.ReadLine());
                Console.WriteLine("---------------------------------------");
                if (autopilot == 0) { AutoPilotOn = false; return Altitude += increment; }
                else
                    return Altitude = MaxAltitudeAuto;

            }
            return Altitude += increment;
        }

        public int Down(int increment)
        {

            if (AutoPilotOn)
            {
                if (Altitude - increment > MinAltitudeAuto)
                {
                    return Altitude -= increment;
                }
                if (Altitude < MinAltitudeAuto) return Altitude;
                return Altitude = MinAltitudeAuto;
            }

            if (Altitude - increment < 0) return Altitude = 0;
            return Altitude -= increment;
        }
        public virtual int Forsage(int increment)
        {
            if (increment * 2 > MaxAltitudeAuto) AutoPilotOn = false;
            if (increment * 2 > Max_Hieght_Fly) { return Altitude = Max_Hieght_Fly; }
            return Altitude = increment * 2;

        }
        public virtual void Switch()
        {
            do
            {
                Console.WriteLine();
                Console.WriteLine("Enter parameter: ");
                Console.WriteLine("If you want to lift up the plane, press 'C'");
                Console.WriteLine("If you want to enable forsage, press 'F'");
                Console.WriteLine("If you want to enable autopilot, press 'A'");
                Console.WriteLine();
                try
                {
                    string commandName = Console.ReadLine();

                    if (commandName == "C" || commandName == "F" || commandName == "A")
                    {
                        switch (commandName)
                        {
                            case "A":
                                Console.WriteLine("Enable, press '1'\nSwitch off, press '0'.");
                                int autopilot = Int32.Parse(Console.ReadLine());
                                if (autopilot == 1 || autopilot == 0)
                                {
                                    if (autopilot == 1 && Altitude > MinAltitudeAuto || autopilot == 1 && Altitude < MaxAltitudeAuto)
                                    { AutoPilotOn = true; }

                                    if (autopilot == 1 && Altitude < MinAltitudeAuto || autopilot == 1 && Altitude > MaxAltitudeAuto)
                                    { Console.WriteLine("Sorry can not enable autopilot"); AutoPilotOn = false; }

                                    if (autopilot == 0) { AutoPilotOn = false; }

                                    Console.WriteLine("Altitude = {0}, Autopilot = {1}", Altitude, AutoPilotOn);
                                }
                                else
                                {

                                    throw new Exception("Unacceptable symbol");

                                }
                                break;

                            case "C":
                                Console.WriteLine("Enter altitude settings: ");
                                int height = Int32.Parse(Console.ReadLine());

                                if (height <= Max_Hieght_Fly) { Altitude = height; }

                                if (height > Max_Hieght_Fly)
                                { Console.WriteLine($"Height should not be more than {Max_Hieght_Fly}"); Altitude = Max_Hieght_Fly; }

                                if (Altitude < MinAltitudeAuto || Altitude > MaxAltitudeAuto) AutoPilotOn = false;
                                Console.WriteLine("Altitude = {0}, Autopilot = {1}", Altitude, AutoPilotOn);
                                break;

                            case "F":
                                Forsage(Altitude);
                                if (Altitude < MinAltitudeAuto || Altitude > MaxAltitudeAuto) AutoPilotOn = false;
                                Console.WriteLine("Altitude = {0}, Autopilot = {1}", Altitude, AutoPilotOn);
                                break;
                        }
                    }
                    else
                    {
                        throw new Exception("Unacceptable symbol");
                    }
                }
                catch (Exception e)
                {
                    Console.WriteLine("Error: " + e.Message);
                }

            }
            while (Console.ReadKey().Key != ConsoleKey.Escape);
            while (Console.ReadKey().Key != ConsoleKey.Escape);
        }
        public void SetAltitude(int targetAlitude)
        {
             do
            {
                Climb(_altitudeIncrement);
                Console.WriteLine("Altitude = {0}, Autopilot = {1}", Altitude, AutoPilotOn);
            }
            while (Altitude <= targetAlitude);
            Console.WriteLine("-------------------------------------------");
            do
            {
                Down(_altitudeIncrement);
               Console.WriteLine("Altitude = {0}, Autopilot = {1}", Altitude, AutoPilotOn);
            }
            while (Altitude > 0);

        }
    }

}

