using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Threading;
using System.Diagnostics;

namespace baraba
{
    class Timer
    {
        private int Time;
        /// <summary>
        /// Setup Timer.
        /// </summary>
        public Timer(int Time)
        {
            this.Time = Time;
            new Thread(Run).Start();
        }
        /// <summary>
        /// Run Timer-Thread.
        /// </summary>
        private void Run()
        {
            Attack.SetFloodingStatus(true);
            Debug.Print("Timer Started.");
            for (int i = 0; i <= Time; i++ )
            {
                // Wait ...
                Thread.Sleep(1000);
            }
            Attack.SetFloodingStatus(false);
            Debug.Print("Timer Stopped.");
        }
    }
}
