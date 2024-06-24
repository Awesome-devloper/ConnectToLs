using com.lightstreamer.client;

namespace BlazorApp1.BleazorLightSteramer
{
    public class SystemOutClientListener : ClientListener
    {
        private LightstreamerClient client;

        private bool resub = true;

        public SystemOutClientListener(LightstreamerClient client)
        {
            this.client = client;
        }

        public void onListenEnd()
        {
        }

        public void onListenStart()
        {
        }

        public void onPropertyChange(string property)
        {
            Console.WriteLine("Property " + property + " changed: ");
            if (this.client != null)
            {
                if (property.Equals("serverInstanceAddress"))
                {
                    Console.WriteLine(this.client.connectionDetails.ServerAddress);
                }
                if (property.Equals("sessionId"))
                {
                    Console.WriteLine(this.client.connectionDetails.SessionId);
                }

            }
        }

        public void onServerError(int errorCode, string errorMessage)
        {
            Console.WriteLine("Server Error - " + errorMessage + " - " + errorCode);
        }

        public void onStatusChange(string status)
        {
            Console.WriteLine(" >>>>>>>>>>>>>>>>>> " + status + " - ");

            if ((status.StartsWith("CONNECTED:WS") || status.StartsWith("CONNECTED:HT")) && (resub))
            {
                //if (QuickStart.quick_mode == 1)
                //{
                //    QuickStart.SubscribeChat();
                //}
                //else if (QuickStart.quick_mode == 2)
                //{
                //    QuickStart.SubscribeCommand();
                //}
                //else if (QuickStart.quick_mode == 0)
                //{
                //    QuickStart.SubscribeStocks();
                //}
                resub = false;
            }
        }
    }
}
