using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TimerLib;

namespace TestCustomTimer
{
    class Program
    {
        public class Listner1
        {
            public Listner1(CustomTimer timer)
            {
                timer.OnTimer += GetMessage;
            }

            public void GetMessage(object sender, SampleEventArgs e)
            {
                Console.WriteLine("Listner1 " + e.Text);
            }

            public void Unregister(CustomTimer timer)
            {
                timer.OnTimer -= GetMessage;
            }
        }

        public class Listner2
        {
            public Listner2(CustomTimer timer)
            {
                timer.OnTimer += GetMessage;
            }

            private void GetMessage(Object sender, SampleEventArgs e)
            {
                Console.WriteLine("Listner2 " + e.Text);
            }

            public void Unregister(CustomTimer timer)
            {
                timer.OnTimer -= GetMessage;
            }
        }

        static void Main(string[] args)
        {
            CustomTimer timer = new CustomTimer();
            Listner1 listner1 = new Listner1(timer);
            Listner2 listner2 = new Listner2(timer);
            int time, times;

            Console.WriteLine("Enter time in milliseconds");

            while (!int.TryParse(Console.ReadLine(), out time))
            {
                Console.WriteLine("Incorrect info");
            }

            Console.WriteLine("Enter your message");
            string message = Console.ReadLine();

            Console.WriteLine("Enter count of times to write message");
            while (!int.TryParse(Console.ReadLine(), out times))
            {
                Console.WriteLine("Incorrect info");
            }

            if (times > 10)
            {
                Console.WriteLine("I don't want to do it so much times. I will do it only 10 times");
                times = 10;
            }
            
            timer.WindUp(message, times);

            Console.ReadLine();

            Console.WriteLine("Now listner1 unsubscribe from event");
            listner1.Unregister(timer);

            timer.WindUp(message, times);
            Console.ReadLine();
        }
    }
}
