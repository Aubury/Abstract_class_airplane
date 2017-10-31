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
       public virtual int Max_Hieght_Fly { get; set; }
        private int _altitudeIncrement;
        static  AirPlane()
        {
            MinAltitudeAuto = 2000;
            MaxAltitudeAuto = 10000;
       
        }
        public AirPlane(int capacity, float consuption, int altitudeIncrement)
        {
            Altitude = 0;
            AutoPilotOn = false;
            Capacity = capacity;
            Consumption = consuption;
            _altitudeIncrement = altitudeIncrement;
            Max_Hieght_Fly = 11000;
        }

        public int Climb(int increment)
        {
            if (Altitude + increment > Max_Hieght_Fly)
            {
                throw new Exception($"it's too high!");
            }

            return Altitude += increment;

        }

        public int Down(int increment)
        {
            if (Altitude - increment < 0)
            {
                throw new Exception($"Warning! The plane can be crash.");
            }
            return Altitude -= increment;
        }
        public int Forsage(int increment)
        {
            if (increment * 2 > MaxAltitudeAuto) AutoPilotOn = false;
            return Altitude = increment * 2;

        }
        public abstract void Switch();
      
        public void SetAltitude(int targetAlitude)
        {
            try
            {

                do
                {
                    Climb(_altitudeIncrement);
                    if (Altitude > MinAltitudeAuto) AutoPilotOn = true;
                    if (Altitude > MaxAltitudeAuto) AutoPilotOn = false;

                    Console.WriteLine("Altitude = {0}, Autopilot = {1}", Altitude, AutoPilotOn);
                }
                while (Altitude <= targetAlitude);
            }
            catch (Exception ex)
            {
                Console.WriteLine("----------------------------------------");
                Console.WriteLine($"Warning! Taget altitude = {targetAlitude} "+ ex.Message);
                Altitude = Max_Hieght_Fly;
            }
            Console.WriteLine("----------------------------------------");
            try
            {

                do
                {
                    Down(_altitudeIncrement);
                    if (Altitude < MinAltitudeAuto) AutoPilotOn = false;
                    Console.WriteLine("Altitude = {0}, Autopilot = {1}", Altitude, AutoPilotOn);
                }
                while (Altitude != 0);
            }
            catch (Exception e)
            {
                Console.WriteLine("----------------------------------------");
                Console.WriteLine(e.Message);
                Altitude = 0;
                Console.WriteLine("Altitude = {0}, Autopilot = {1}", Altitude, AutoPilotOn);
            }

        }
    }
}



