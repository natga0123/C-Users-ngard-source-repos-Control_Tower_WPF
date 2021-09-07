using System;
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
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace Control_Tower_WPF
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>

    public delegate void Flight_Command_Event_Handler<TEventArgs>(object sender, TEventArgs e);

    
    public partial class MainWindow : Window
    {
        private Airplanes_in_the_air_counter FPL_counter = new Airplanes_in_the_air_counter();

        /// <summary>
        /// Main Window GUI initialization
        /// 
        /// </summary>
        public MainWindow()
        {
            InitializeComponent();
            WindowStartupLocation = System.Windows.WindowStartupLocation.CenterScreen;
            Label_Number_of_Flights.Content = "Number of airborne flights: " + FPL_counter.Return_Flight_count().ToString();
        }

        /// <summary>
        /// Handle send button logic
        /// create a new flight window
        /// and subscribe on its events
        /// 
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void Send_Btn_click(object sender, RoutedEventArgs e)
        {
            
            string Flight_Code = this.TextBox_Flight_Code.Text.Trim();
            if (Flight_Code.Length == 0)
            {
                MessageBox.Show("Flight Code should be given");
                return;
            }

            Flight_Log_Entry Log = new Flight_Log_Entry();
            Log.Flight_Code = Flight_Code;
            Log.Status = "Sent to RWY";
            Log.Time = DateTime.Now;

            this.List_View_Flights.Items.Add(Log);
            Flight_window new_flight = new Flight_window(Flight_Code);
            new_flight.Set_Flight_Id(Flight_Code);

            new_flight.Raise_Takeoff_Event += FPL_counter.Count_Takeoff_Event;
            new_flight.Raise_Land_Event += FPL_counter.Count_Land_Event;

            new_flight.Raise_Takeoff_Event += Handle_Takeoff_Event;
            new_flight.Raise_Heading_Event += Handle_Heading_Event;
            new_flight.Raise_Land_Event += Handle_Land_Event;           

            new_flight.Show();
            
        }
        /// <summary>
        /// Take off event handler (subscriber)
        /// updates the log
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void Handle_Takeoff_Event(object sender, TakeOffEventInfo e)
        {
            Flight_Log_Entry Log = new Flight_Log_Entry();
            Log.Flight_Code = e.Flight_Id;
            Log.Status = e.Command_Info;
            Log.Time = e.Time_of_command;

            this.List_View_Flights.Items.Add(Log);
            Label_Number_of_Flights.Content = "Number of airborne flights: " + FPL_counter.Return_Flight_count().ToString();
        }
        /// <summary>
        /// Heading change event handler
        /// updates the log
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void Handle_Heading_Event(object sender, ChangeRouteEventInfo e)
        {
            Flight_Log_Entry Log = new Flight_Log_Entry();
            Log.Flight_Code = e.Flight_Id;
            Log.Status = e.Command_Info;
            Log.Time = e.Time_of_command;

            this.List_View_Flights.Items.Add(Log);
        }
        /// <summary>
        /// Land Event handler
        /// updates the log
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void Handle_Land_Event(object sender, LandEventInfo e)
        {
            Flight_Log_Entry Log = new Flight_Log_Entry();
            Log.Flight_Code = e.Flight_Id;
            Log.Status = e.Command_Info;
            Log.Time = e.Time_of_command;

            this.List_View_Flights.Items.Add(Log);
            Label_Number_of_Flights.Content = "Number of airborne flights: " + FPL_counter.Return_Flight_count().ToString();
        }
        /// <summary>
        /// Text input handler from user via GUI
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void TextBox_TextChanged(object sender, TextChangedEventArgs e)
        {
            int Str_Len = this.TextBox_Flight_Code.Text.Length;
            if (Str_Len > 15)
            {
                MessageBox.Show("Flight Code should not be longer than 15 symbols");
                this.TextBox_Flight_Code.Text = this.TextBox_Flight_Code.Text.Remove(Str_Len - 1);
            }
        }
        /// <summary>
        /// Mouse down handler
        /// removes the help text from the textbox
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void Mouse_down_on_flight_code(object sender, MouseButtonEventArgs e)
        {
            this.TextBox_Flight_Code.Text = "";
        }
        /// <summary>
        /// Textbox focus handler
        /// removes help text from textbox
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void TextBox_Flight_Code_Focus(object sender, RoutedEventArgs e)
        {
            this.TextBox_Flight_Code.Text = "";
        }

        /// <summary>
        /// Handles starting flight
        /// adds a log entry
        /// </summary>
        /// <typeparam name="TEventArgs"></typeparam>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void Flight_Start_Event_Handler<TEventArgs>(object sender, TakeOffEventInfo e)
        {
            this.List_View_Flights.Items.Add(e.Flight_Id);
        }
       
        /// <summary>
        /// On Tower window closing event
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void Window_Tower_Closing(object sender, System.ComponentModel.CancelEventArgs e)
        {
            if (FPL_counter.Return_Flight_count() > 0)
            {
                MessageBox.Show("Kan inte stänga tornet innan alla flygplan har landat.");
                e.Cancel = true;
            }
        }
        /// <summary>
        /// Handles Tower windiw closing
        /// exits application if no flights up in the air
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void Window_Tower_Closed(object sender, EventArgs e)
        {
            System.Windows.Application.Current.Shutdown();
        }
    }
}
