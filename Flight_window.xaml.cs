using System;
using System.IO;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;

namespace Control_Tower_WPF
{
    /// <summary>
    /// Interaction logic for Flight_window.xaml
    /// </summary>
    public partial class Flight_window : Window
    {
        private string Flight_Id = "";
        private DateTime Flight_TakeOff = DateTime.Now;
        private DateTime Flight_Land = DateTime.Now;
        private DateTime Heading_Change = DateTime.Now;
        private int Heading = 0;

        private bool Landed = false;

        public event EventHandler<TakeOffEventInfo> Raise_Takeoff_Event;
        public event EventHandler<ChangeRouteEventInfo> Raise_Heading_Event;
        public event EventHandler<LandEventInfo> Raise_Land_Event;

        /// <summary>
        /// Contructor of the flight window class
        /// </summary>
        /// <param name="flight_code"></param>
        public Flight_window(string flight_code)
        {
            InitializeComponent();
            this.Title = "Flight " + flight_code;
            Btn_Land.IsEnabled = false;
            Combo_Headings.IsEnabled = false;

            Combo_Headings.Items.Insert(0, "0 deg");
            Combo_Headings.Items.Insert(1, "30 deg");
            Combo_Headings.Items.Insert(2, "60 deg");
            Combo_Headings.Items.Insert(3, "90 deg");
            Combo_Headings.Items.Insert(4, "120 deg");
            Combo_Headings.Items.Insert(5, "150 deg");
            Combo_Headings.Items.Insert(6, "180 deg");

            Combo_Headings.Items.Insert(7, "210 deg");
            Combo_Headings.Items.Insert(8, "240 deg");
            Combo_Headings.Items.Insert(9, "270 deg");
            Combo_Headings.Items.Insert(10, "300 deg");
            Combo_Headings.Items.Insert(11, "330 deg");

            string _imageDirectory = System.IO.Directory.GetCurrentDirectory() + System.IO.Path.DirectorySeparatorChar + "FPL_bilder";
            Random _random = new Random();
            string[] imagePaths = System.IO.Directory.GetFiles(_imageDirectory, "*.jpg");

            BitmapImage bitmapImage = new BitmapImage(new Uri(imagePaths[_random.Next(imagePaths.Length)]));
            Image_fpl.Source = bitmapImage;

        }
        /// <summary>
        /// Set Id
        /// </summary>
        /// <param name="flight_id"></param>
        public void Set_Flight_Id(string flight_id)
        {
            Flight_Id = flight_id;
        }
    /// <summary>
    /// Set Takeoff time
    /// </summary>
    /// <param name="takeoff_time"></param>
        public void Set_Flight_TakeOff(DateTime takeoff_time)
        {
            Flight_TakeOff = takeoff_time;
        }
        /// <summary>
        /// Set Landing time
        /// </summary>
        /// <param name="land_time"></param>
        public void Set_Flight_Land(DateTime land_time)
        {
            Flight_Land = land_time;
        }
        /// <summary>
        /// Set heading direction
        /// </summary>
        /// <param name="direction"></param>
        public void Set_Heading(int direction)
        {
            Heading = direction;
        }
        /// <summary>
        /// Set heading change time
        /// </summary>
        /// <param name="heading_time"></param>
        public void Set_Heading_Time(DateTime heading_time)
        {
            Heading_Change = heading_time;
        }
        /// <summary>
        /// Flight take off button logic
        /// Updates EventArg for Takeoff Event
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void Btn_Start_Click(object sender, RoutedEventArgs e)
        {
            Set_Flight_TakeOff(DateTime.Now);

            TakeOffEventInfo Take_Off_Info = new TakeOffEventInfo();

            Take_Off_Info.Flight_Id = this.Flight_Id;
            Take_Off_Info.Time_of_command = this.Flight_TakeOff;
            Take_Off_Info.Command_Info = "Started";

            On_Raise_Start_Event(Take_Off_Info);

            this.Btn_Start.IsEnabled = false;
            Btn_Land.IsEnabled = true;
            Combo_Headings.IsEnabled = true;
        }

        protected virtual void On_Raise_Start_Event(TakeOffEventInfo e)
        {
            //MessageBox.Show("Flight " + e.Flight_Id + " " + e.Command_Info + " " + e.Time_of_command);
            
            EventHandler<TakeOffEventInfo> handler = Raise_Takeoff_Event;
            if (handler != null)
            {
                handler(this, e);
            }
        }
        /// <summary>
        /// Flight Land logic
        /// Updates EventArg for Land Event
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void Btn_Land_Click(object sender, RoutedEventArgs e)
        {
            Set_Flight_Land(DateTime.Now);

            LandEventInfo Land_Info = new LandEventInfo();

            Land_Info.Flight_Id = this.Flight_Id;
            Land_Info.Time_of_command = this.Flight_TakeOff;
            Land_Info.Command_Info = "Landed";

            On_Raise_Land_Event(Land_Info);

            Landed = true;
            this.Close();
        }
        protected virtual void On_Raise_Land_Event(LandEventInfo e)
        {
            //MessageBox.Show("Flight " + e.Flight_Id + " " + e.Command_Info + " " + e.Time_of_command);

            EventHandler<LandEventInfo> handler = Raise_Land_Event;
            if (handler != null)
            {
                handler(this, e);
            }
        }
        /// <summary>
        /// Flight Heading change logic
        /// Updates EventArg for HEading change Event
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void Combo_Heading_Sel_Changed(object sender, SelectionChangedEventArgs e)
        {
            int i_heading = Combo_Headings.SelectedIndex;

            if (i_heading < 0)
            {
                return;
            }

            int heading_deg = i_heading * 30;

            Set_Heading_Time(DateTime.Now);

            ChangeRouteEventInfo Heading_Info = new ChangeRouteEventInfo();

            Heading_Info.Flight_Id = this.Flight_Id;
            Heading_Info.Time_of_command = this.Heading_Change;
            Heading_Info.heading = heading_deg;
            Heading_Info.Command_Info = "Changed to " + heading_deg.ToString() + " deg";           

            On_Raise_Heading_Event(Heading_Info);

        }
        protected virtual void On_Raise_Heading_Event(ChangeRouteEventInfo e)
        {
            //MessageBox.Show("Flight " + e.Flight_Id + " " + e.Command_Info + " " + e.Time_of_command);

            EventHandler<ChangeRouteEventInfo> handler = Raise_Heading_Event;
            if (handler != null)
            {
                handler(this, e);
            }
        }
        /// <summary>
        /// Handles logic for window closing
        /// prevents closing if not landed
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void Flight_Window_Closing(object sender, System.ComponentModel.CancelEventArgs e)
        {
            if ((!Landed)&(this.Btn_Start.IsEnabled == false))
            {
                MessageBox.Show("Cannot close flight which has not landed."); 
                e.Cancel = true;
            }
        }
    }
}
