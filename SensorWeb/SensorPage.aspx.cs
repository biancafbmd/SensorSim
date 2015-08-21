using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Web.Services;
using System.Text;
using System.IO;
using System.Timers;

using Microsoft.ServiceBus.Messaging;
using Microsoft.ServiceBus;


namespace SensorWeb
{
    public partial class WebForm2 : System.Web.UI.Page
    {
        //static System.Timers.Timer EventHubTimer;
        EventHubClient client;
        private List<ConnectSensor> sensors;
        static Random rand;
        private int[] min;
        private int[] max;

        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                Global.EventHubPars.EHname = Request.Form["EHName"];
                Global.EventHubPars.ConnectionString = Request.Form["ConnectionString"];
                Global.EventHubPars.DisplayName = Request.Form["DisplayName"];
                Global.EventHubPars.Organization = Request.Form["Organisation"];
                Global.EventHubPars.Location = Request.Form["Location"];
                
            }
            else
            {
            }
            
        }

        protected void StartEH_Click(object sender, EventArgs e)
        {
            if (SendButton.Text.StartsWith("Start"))
            {
                Global.ifStart = true;
                SendButton.Text = "Sending to Event Hub";
                SendButton.Enabled = false;

                //set Event Hub Client
                MessagingFactory factory = MessagingFactory.CreateFromConnectionString(Global.EventHubPars.ConnectionString + ";TransportType=Amqp");
                client = factory.CreateEventHubClient(Global.EventHubPars.EHname);

                //initialise sensors
                sensors = new List<ConnectSensor> {
                    new ConnectSensor("5eb6aaff-02de-40e9-a5e6-547f4b456360", sensortype1.Value, sensorunit1.Value)
                };

                SetSensorAttributes();

                //set min/max ranges
                min = new int[] {
                    Convert.ToInt32(minrange1.Value)
                };

                max = new int[]
                {
                    Convert.ToInt32(maxrange1.Value)
                };


                //initialise random int generator
                rand = new Random();

                //set Timer using the user-defined value
                double seconds = Convert.ToDouble(datafreq.Value) * 1000;
                Global.EventHubTimer = new System.Timers.Timer();
                SetTimer(Global.EventHubTimer, seconds);
            }
            /* Stop version of the button not working as expected 
            else if (SendButton.Text.StartsWith("Stop"))
            {
                SendButton.Text = "Start Event Hub";

                try
                {
                    Global.EventHubTimer.Enabled = false;
                    Global.EventHubTimer.Close();
                }
                catch (NullReferenceException nullRef)
                {
                    System.Diagnostics.Debug.WriteLine(nullRef.Message);
                }
                
            }  */               

        }

        //whent the Timer ticks send data to Event Hub
        private void ATimer_Elapsed(object sender, ElapsedEventArgs e)
        {
            EventData data;
            string message;

            for (int i = 0; i < sensors.Count; i++)
            {
                sensors[i].timecreated = DateTime.UtcNow.ToString("o");
                sensors[i].value = rand.Next(min[i], max[i]);
                message = sensors[i].ToJson();

                data = new EventData(Encoding.UTF8.GetBytes(message));
                client.Send(data);
            }
        }

        //Sets the timer to send data to Azure Event Hub periodically
        private void SetTimer(System.Timers.Timer timer, double value)
        {
            timer.Interval = value;
            timer.Elapsed += ATimer_Elapsed;
            timer.Enabled = true;
        }

        private void SetSensorAttributes()
        {
            foreach(ConnectSensor sensor in sensors)
            {
                sensor.displayname = Global.EventHubPars.DisplayName;
                sensor.location = Global.EventHubPars.Location;
                sensor.organization = Global.EventHubPars.Organization;
            }
        }
    }
}