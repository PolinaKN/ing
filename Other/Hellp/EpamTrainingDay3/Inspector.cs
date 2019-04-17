using System;
using System.Collections.Generic;
using System.Text;

namespace EpamTrainingDay3
{
    public class OverSpeedArgs
    {
        public int Speed { get; set; }
    }

    internal class Inspector
    {
        public event EventHandler<OverSpeedArgs> OverSpeed;

        private const int SpeedLimit = 60;

        public void Inspect(Driver d)
        {
            var args = new OverSpeedArgs { Speed = d.CurrentSpeed };
            OverSpeed?.Invoke(this, args);
        }

        public void Handler(object sender, OverSpeedArgs s)
        {
            var del = s.Speed - SpeedLimit;
            if (del > 0 && del <= 10)
            {
                Console.WriteLine("You are stopped for speeding! Fine 100UAH!");
            }
            else if (del > 10 && del <= 20)
            {
                Console.WriteLine("You are stopped for speeding! Fine 200UAH!");
            }
            else if (del > 20)
            {
                Console.WriteLine("You are stopped for speeding! Fine 500UAH!");
            }
            else
            {
                Console.WriteLine("Speed limit isn't over! You are free.");
            }
        }
    }
}
