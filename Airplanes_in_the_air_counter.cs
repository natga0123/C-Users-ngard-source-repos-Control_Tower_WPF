using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Control_Tower_WPF
{
    class Airplanes_in_the_air_counter
    {
        private int N_started = 0;

        public void Add_start()
        {
            N_started++;
        }
        
        public void Subtract_start()
        {
            N_started--;
        }        

        /// <summary>
        /// Take off event handler (subscriber)
        /// updates the log
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        public void Count_Takeoff_Event(object sender, TakeOffEventInfo e)
        {
            Add_start();
        }

        /// <summary>
        /// Land Event handler
        /// updates the log
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        public void Count_Land_Event(object sender, LandEventInfo e)
        {
            Subtract_start();
        }

        public int Return_Flight_count()
        {
            return N_started;
        }
    }
}
