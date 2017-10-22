using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Abstract_class_airplane
{
    class Passenger:AirPlane
    {
        public Passenger(int capacity, float consuption, int altitudeIncrement) : base(capacity, consuption, altitudeIncrement) { }

    }
}
