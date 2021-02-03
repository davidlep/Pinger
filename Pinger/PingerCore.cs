using System;
using System.Collections.Generic;
using System.IO;
using System.Net.NetworkInformation;
using System.Threading;

namespace Pinger
{
    class PingerCore
    {
        public void Collect()
        {
            Dataset.Init();
            Settings.Init();

            var settings = Settings.Read();

            var pinger = new Ping();
            Record record;

            while (true)
            {
                record = new Record
                { 
                    RoundtripTime = pinger.Send(settings.host).RoundtripTime, 
                    Timestamp = DateTime.Now
                };

                Dataset.Write(record);

                Thread.Sleep(settings.frequencyInSec * 1000);
            }
        }        
    }
}
