//Преобразовать класс Airplane иерархию классов 
//1)	Base Airplane
//2)	Transport, Passenger, Interceptor
//3)	Конкретные модели
//Принять решение на каком уровне абстракций должен находиться существующий код.Внести соответствующие изменения в существующий код.
//Существующий функционал должен остаться неизменным и быть доступным на уровне конкретной модели.



using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Abstract_class_airplane
{
    class Program
    {
        static void Main(string[] args)
        {
            AirPlane An_225 = new Transport(6+88, 15.9F, 280);
            AirPlane Boeing_747 = new Passenger(149, 10.5F, 220);
            AirPlane Mig_31 = new Interceptor(2, 2.1F, 220);
          

            Console.WriteLine(Airbus_A330.Altitude);
            Airbus_A330.SetAltitude(8000);
            Console.WriteLine("===========================================================================================");
            Airbus_A330.Switch();

            Console.ReadLine();
        }
    }
}
