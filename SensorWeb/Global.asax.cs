using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Security;
using System.Web.SessionState;
using System.IO;
using System.Text;

using Microsoft.ServiceBus;

using System.Runtime.Serialization.Json;

namespace SensorWeb
{

    public struct EventHubParameters
    {
        public string EHname { get; set; }
        public string ConnectionString { get; set; }
        public string DisplayName { get; set; }
        public string Organisation { get; set; }
        public string Location { get; set; }
    }

    public class ConnectSensor
    {
        public string guid { get; set; }
        public string displayname { get; set; }
        public string organization { get; set; }
        public string location { get; set; }
        public string measurename { get; set; }
        public string unitofmeasure { get; set; }
        public string timecreated { get; set; }
        public double value { get; set; }

        //default constructor
        public ConnectSensor()
        {

        }

        //constructor taking mor arguments
        public ConnectSensor(string guid, string name, string org, string loc, string measure, string unit)
        {
            this.guid = guid;
            this.displayname = name;
            this.organization = org;
            this.location = loc;
            this.measurename = measure;
            this.unitofmeasure = unit;
        }

        //convert Sensor data in Json String to send to Azure Event Hub
        public string ToJson()
        {
            DataContractJsonSerializer ser = new DataContractJsonSerializer(typeof(ConnectSensor));
            MemoryStream ms = new MemoryStream();
            ser.WriteObject(ms, this);
            string json = Encoding.UTF8.GetString(ms.ToArray(), 0, (int)ms.Length);

            return json;
        }
    }

    public partial class Global : System.Web.HttpApplication
    {
        public static EventHubParameters EventHubPars; 

        protected void Application_Start(object sender, EventArgs e)
        {

        }

        protected void Session_Start(object sender, EventArgs e)
        {

        }

        protected void Application_BeginRequest(object sender, EventArgs e)
        {

        }

        protected void Application_AuthenticateRequest(object sender, EventArgs e)
        {

        }

        protected void Application_Error(object sender, EventArgs e)
        {

        }

        protected void Session_End(object sender, EventArgs e)
        {

        }

        protected void Application_End(object sender, EventArgs e)
        {

        }

    }

    
}