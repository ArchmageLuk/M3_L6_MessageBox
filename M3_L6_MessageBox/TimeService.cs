using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace M3_L6_MessageBox
{
    internal class TimeService
    {
        private static System.Timers.Timer aTimer;
        public void SetTimer()
        {
            aTimer = new System.Timers.Timer(3000);
        }
    }
}
