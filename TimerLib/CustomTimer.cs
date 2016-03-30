using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;

namespace TimerLib
{
    public class SampleEventArgs: EventArgs
    {
        public string Text { get; private set; }

        public SampleEventArgs(string s)
        {
            Text = s;
        }
    }

    public class CustomTimer
    {
        public delegate void SendByTimer(object sender, SampleEventArgs eventArgs);

        public event SendByTimer OnTimer;

        public int Time { get; set; } = 1000;

        public void WindUp(string message)
        {
            Thread.Sleep(Time);
            RaiseSampleEvent(message);
        }

        public void WindUp(string message, int countOfTimes)
        {
            if (countOfTimes > 0)
            {
                for (int i = 0; i < countOfTimes; i++)
                {
                    WindUp(message);
                }
            }
        }

        protected virtual void RaiseSampleEvent(string message)
        {
            OnTimer?.Invoke(this, new SampleEventArgs(message));
        }
    }
}
