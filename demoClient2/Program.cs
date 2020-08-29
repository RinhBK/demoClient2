using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using uPLibrary.Networking.M2Mqtt;
using uPLibrary.Networking.M2Mqtt.Messages;

namespace demoClient2
{
    class Program
    {
        static void Main(string[] args)
        {
            // create client instance
            MqttClient client = new MqttClient("localhost");

            // register to message received
           // client.MqttMsgPublishReceived += Client_recievedMessage;

            string clientId = Guid.NewGuid().ToString();
            client.Connect(clientId);

            Console.WriteLine("Publisher: MachineData/");

            client.Publish( "MachineData/" ,UnicodeEncoding.UTF8.GetBytes("Turn On Lamb"),MqttMsgBase.QOS_LEVEL_AT_LEAST_ONCE,true);
        

        }

        static void Client_recievedMessage(object sender, MqttMsgPublishEventArgs e)
        {
            //Handle message received
            var message = Encoding.Default.GetString(e.Message);
            Console.WriteLine("Message received: " + message);

        }
    
    }
}
