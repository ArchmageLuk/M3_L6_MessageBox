using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Timers;

namespace M3_L6_MessageBox
{
    internal class MessageBox
    {
        public enum State { Ok, Cancel };
        public State state { get; set; }

        public delegate void Action(State state);
        public event Action WindowClosed;

        public async void Open()
        {
            WindowClosed += WindowState;
            var cts = new CancellationTokenSource();
            var token = cts.Token;
            token.Register(() => Console.WriteLine("123"));

            Console.WriteLine("Window opened");
            var text = Task.Run(async delegate
            {                
                await Task.Delay(3000, token);
                return "User closed the window";
                
            }, token);
            text.Wait();

            Console.WriteLine(text.Result);

            var whatState = new Random().Next(0, 2);

            switch (whatState)
            {
                case 0:
                    WindowClosed(State.Ok);
                    break;
                case 1:
                    WindowClosed(State.Cancel);
                    break;
            }
            

            try
            {
                await Task.Run(() => "Error");
            }
            catch (TaskCanceledException ex)
            {
                Console.WriteLine(ex.Message);
            }
        }

        public void WindowState(State astate)
        {
            state = astate;
        }

    }
}