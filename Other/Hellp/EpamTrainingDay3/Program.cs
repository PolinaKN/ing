using System;
using System.Collections.Generic;
using System.Reflection.Emit;
using System.Runtime.InteropServices.ComTypes;
using System.Security.Cryptography.X509Certificates;

namespace EpamTrainingDay3
{
    class Program
    {
        static void Main(string[] args)
        {
            var inspector = new Inspector();
            var drivers = new List<Driver>
            {
                new Driver(50),
                new Driver(90),
                new Driver(65),
                new Driver(75)
            };

            inspector.OverSpeed += inspector.Handler;
            foreach (var driver in drivers)
            {
                inspector.Inspect(driver);
            }
        }
    }
}
