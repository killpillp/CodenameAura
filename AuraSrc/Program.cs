using System.Diagnostics;
using System.Drawing;
using Colorful;
using PaulModz.Core;
using PaulModz.Core.Network;
using PaulModz.Core.Settings;

namespace PaulModz
{
    internal class Program
    {
        internal static Stopwatch elpst = new Stopwatch();

        private static void Main(string[] args)
        {
            Console.Write(@"
           ██████╗░░█████╗░██╗░░░██╗██╗░░░░░███╗░░░███╗░█████╗░██████╗░███████
           ██╔══██╗██╔══██╗██║░░░██║██║░░░░░████╗░████║██╔══██╗██╔══██╗╚════██║
           ██████╔╝███████║██║░░░██║██║░░░░░██╔████╔██║██║░░██║██║░░██║░░███╔═╝ 
           ██╔═══╝░██╔══██║██║░░░██║██║░░░░░██║╚██╔╝██║██║░░██║██║░░██║██╔══╝░░
           ██║░░░░░██║░░██║╚██████╔╝███████╗██║░╚═╝░██║╚█████╔╝██████╔╝███████╗ 
           ╚═╝░░░░░╚═╝░░╚═╝░╚═════╝░╚══════╝╚═╝░░░░░╚═╝░╚════╝░╚═════╝░╚══════╝ v." +
                          Constants.ServerConfig.AppVersion, Color.Orange);
            Console.WriteLine();

            elpst.Reset();

            elpst.Start();

            Logger.Log($"Se pregateste...", Logger.DefCon.INFO);

            AsynchronousSocketListener.StartListening();

            Console.ReadKey(true);
        }
    }
}