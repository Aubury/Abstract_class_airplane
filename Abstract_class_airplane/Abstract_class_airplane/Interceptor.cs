﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Abstract_class_airplane
{
    class Interceptor:AirPlane
    {
        public Interceptor(int capacity, float consuption, int altitudeIncrement) 
            : base(capacity, consuption, altitudeIncrement) { }
        public new int Max_Hieght_Fly = 31500;
        public override int Forsage(int increment)
        {
            if (increment * 2 > MaxAltitudeAuto) AutoPilotOn = false;
            if (increment * 2 > Max_Hieght_Fly) { return Altitude = Max_Hieght_Fly; }
            return Altitude = increment * 2;

        }
        public override void Switch()
        {
            do
            {
                Console.WriteLine();
                Console.WriteLine("Enter parameter: ");
                Console.WriteLine("If you want to lift up the plane, press 'C'");
                Console.WriteLine("If you want to enable forsage, press 'F'");
                Console.WriteLine("If you want to enable autopilot, press 'A'");
                Console.WriteLine();
                string commandName = Console.ReadLine();

                switch (commandName)
                {
                    case "A":
                        Console.WriteLine("Enable, press '1'\nSwitch off, press '0'.");
                        int autopilot = Int32.Parse(Console.ReadLine());

                        if (autopilot == 1 && Altitude > MinAltitudeAuto || autopilot == 1 && Altitude < MaxAltitudeAuto)
                        { AutoPilotOn = true; }

                        if (autopilot == 1 && Altitude < MinAltitudeAuto || autopilot == 1 && Altitude > MaxAltitudeAuto)
                        { Console.WriteLine("Sorry can not enable autopilot"); AutoPilotOn = false; }

                        if (autopilot == 0) { AutoPilotOn = false; }

                        Console.WriteLine("Altitude = {0}, Autopilot = {1}", Altitude, AutoPilotOn);
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
            while (Console.ReadKey().Key != ConsoleKey.Escape);
        }
    }
}
