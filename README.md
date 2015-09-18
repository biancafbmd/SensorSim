# SensorSim
Sensor Simulation web app which sends data to Azure Event Hub. 
The sensor data you send is randomly generated from the range you specify once the website is running.

You need to specify your Event Hub parameters before you are able to send this data through. Once you start sending
data, there is no way of stopping that through the website. You need to go and stop the website in Microsoft Azure
(if you are running it in the cloud).

**Warning** This web app was created as a demo environment, hence its performance and stability is not guaranteed.
There are some existing bugs which are not fixed at the moment, so it is highly recommended that you stop this website
when you are not experimenting with it. Otherwise, it might send data to Event Hub continously, hence incurring additional
Azure costs.



