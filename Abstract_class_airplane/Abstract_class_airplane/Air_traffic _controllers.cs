﻿
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Abstract_class_airplane
{
   abstract class Air_traffic__controllers
    {
        public int Altitude { get; set; } //высота над уровнем моря
        public bool AutoPilotOn { get; set; } //автопилот
        public static int MinAltitudeAuto { get; set; }
        public static int MaxAltitudeAuto { get; set; }
        public  int Max_Hieght_Fly;//{ get; set; }
        private int _altitudeIncrement;
        public int Forsage(int increment)
        {
            if (increment * 2 > MaxAltitudeAuto) AutoPilotOn = false;
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
                                try
                                {
                                    Console.WriteLine("Enter altitude settings: ");
                                    int height = Int32.Parse(Console.ReadLine());

                                    if (height <= Max_Hieght_Fly) { Altitude = height; }

                                    if (height > Max_Hieght_Fly)

                                    {
                                        throw new Exception($"Height should not be more than {Max_Hieght_Fly}");


                                    }
                                }
                                catch (Exception ex)
                                {
                                    Console.WriteLine(ex.Message);
                                    Altitude = Max_Hieght_Fly;
                                }

                                if (Altitude < MinAltitudeAuto || Altitude > MaxAltitudeAuto) AutoPilotOn = false;
                                Console.WriteLine("Altitude = {0}, Autopilot = {1}", Altitude, AutoPilotOn);
                                break;

                            case "F":
                                try
                                {
                                    Forsage(Altitude);
                                    if (Altitude < MinAltitudeAuto || Altitude > MaxAltitudeAuto) AutoPilotOn = false;
                                    if (Altitude > Max_Hieght_Fly)
                                    {
                                        throw new Exception($"Sorry!Height should not be more than {Max_Hieght_Fly}");
                                    }
                                }
                                catch (Exception exx)
                                {
                                    Console.WriteLine(exx.Message);
                                 
                                }

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
            while (Console.ReadKey().Key != ConsoleKey.Escape) ;
        }
    }
}
