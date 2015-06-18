using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Text;
using System.IO;
using System.Timers;

using Microsoft.ServiceBus.Messaging;
using Microsoft.ServiceBus;


namespace SensorWeb
{
    public partial class WebForm2 : System.Web.UI.Page
    {
        private static System.Timers.Timer aTimer;
        EventHubClient client;
        List<ConnectSensor> sensors;
        static Random rand;

        string trial;

        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                Global.EventHubPars.EHname = Request.Form["EHName"];
                Global.EventHubPars.ConnectionString = Request.Form["ConnectionString"];
                Global.EventHubPars.DisplayName = Request.Form["DisplayName"];
                Global.EventHubPars.Organisation = Request.Form["Organisation"];
                Global.EventHubPars.Location = Request.Form["Location"];
            }
            else
            {
                
            }
            
        }

        //TODO: check state of the button to device what to initialise or not
        protected void StartEH_Click(object sender, EventArgs e)
        {
            trial = Request.Form["sensortype1"];
            System.Diagnostics.Debug.WriteLine(trial);
            string name = "ehdevices";
            string connectionString = "Endpoint=sb://demoiotconnect-ns.servicebus.windows.net/;SharedAccessKeyName=D1;SharedAccessKey=ATxDT/vwvRHfvIjnILPlQJJeClJ5sUbWAlLSZqqVTgM=";

            //set Event Hub Client
            MessagingFactory factory = MessagingFactory.CreateFromConnectionString(connectionString+ ";TransportType=Amqp");
            client = factory.CreateEventHubClient(name);

            //initialise sensor attributes
            ConnectSensor sensor1 = new ConnectSensor("2298a348-e2f9-4438-ab23-82a3930662ab", Global.EventHubPars.DisplayName, Global.EventHubPars.Organisation, Global.EventHubPars.Location, "temp", "C");

            sensors = new List<ConnectSensor> { sensor1 };

            //initialise random int generator
            rand = new Random();

            //set Timer
            SetTimer(aTimer, 2000);                     

        }

        //whent the Timer ticks send data to Event Hub
        private void ATimer_Elapsed(object sender, ElapsedEventArgs e)
        {
            EventData data;
            string message;

            foreach(ConnectSensor sensor in sensors)
            {
                sensor.timecreated = DateTime.UtcNow.ToString("o");
                sensor.value = rand.Next(22, 25);
                message = sensor.ToJson();

                data = new EventData(Encoding.UTF8.GetBytes(message));
                client.Send(data);
            }
        }

        //Sets the timer to send data to Azure Event Hub periodically
        private void SetTimer(System.Timers.Timer timer, double value)
        {
            timer = new System.Timers.Timer(value);
            timer.Elapsed += ATimer_Elapsed;
            timer.Enabled = true;
        }
    }
}