using System;
using System.IO;
using System.Net;
using System.Net.Sockets;
using System.Text;
using System.Threading;
using PaulModz.Core.Settings;
using PaulModz.Packets;
using PaulModz.Packets.Crypto.RC4;

namespace PaulModz.Core.Network
{
    // stateobj pentru citirea asincronă a datelor clientului
    public class StateObject
    {
        // Dimensiune buffer la primire.
        public const int BufferSize = 4096;

        // Primire buffer.
        public byte[] buffer = new byte[BufferSize];

        // sir de date primite.
        public StringBuilder sb = new StringBuilder();

        // Client  socket.
        public Socket workSocket;
    }

    public class AsynchronousSocketListener
    {
        // Thread signal.
        public static ManualResetEvent allDone = new ManualResetEvent(false);

        public static void StartListening()
        {
            // buffer de date pt primire
            var bytes = new byte[1024];

            // Stabilire punct final local pentru socket.
            // nume dns al calculatorului
            // "host.paulmodz.com".
            var ipHostInfo = Dns.Resolve(Dns.GetHostName());
            var ipAddress = ipHostInfo.AddressList[0];
            var localEndPoint = new IPEndPoint(ipAddress, 9339);

            // Creați un socket TCP/IP.
            var listener = new Socket(AddressFamily.InterNetwork,
                SocketType.Stream, ProtocolType.Tcp);

            // daca merge e bine, daca nu bag polaaa
            try
            {
                listener.Bind(localEndPoint);
                listener.Listen(100);
                Program.elpst.Stop();
                Logger.Log($"Severul s-a deschis la {listener.LocalEndPoint} in {Program.elpst.ElapsedMilliseconds}ms!",
                    Logger.DefCon.INFO);
                while (true)
                {
                    
                    allDone.Reset();

                   

                    listener.BeginAccept(
                        AcceptCallback,
                        listener);

                    
                    allDone.WaitOne();
                    Message.RC4 = new RC4_Core();
                    Logger.Log($"S-a conectat cineva la server!", Logger.DefCon.INFO);
                    Constants.LoginFailed.fingerprintVersion = File.ReadAllLines("F:\\Nginx\\html\\ClashRoyale\\Patchs\\VERSION")[1];
                    Logger.Log($"Am incarcat cu succes patchul({Constants.LoginFailed.fingerprintVersion})",Logger.DefCon.INFO);
                    Constants.LoginFailed.FingerPrint = File.ReadAllText($"F:\\Nginx\\html\\ClashRoyale\\Patchs\\{Constants.LoginFailed.fingerprintVersion}\\fingerprint.json");
                    Logger.Log($"Am incarcat cu succes fingerprintu (F:\\Nginx\\html\\ClashRoyale\\Patchs\\{ Constants.LoginFailed.fingerprintVersion}\\fingerprint.json)", Logger.DefCon.INFO);
                    Constants.ServerConfig.ConnectedUsers++;
                }
            }
            catch (Exception e)
            {
                Console.WriteLine(e.ToString());
            }

            Console.WriteLine("\nPress ENTER to continue...");
            Console.Read();
        }

        public static void AcceptCallback(IAsyncResult ar)
        {
           // semnaleaza instanta sa continue
            allDone.Set();

            // ia socketu care mentine clientu
            var listener = (Socket) ar.AsyncState;
            var handler = listener.EndAccept(ar);

            // creaza state obj
            var state = new StateObject();
            state.workSocket = handler;
            state.buffer = new byte[9999];
            handler.BeginReceive(state.buffer, 0, StateObject.BufferSize, 0,
                ReadCallback, state);
        }

        public static void ReadCallback(IAsyncResult ar)
        {
            var state = (StateObject) ar.AsyncState;
            var handler = state.workSocket;

            try
            {
                var bytesRead = handler.EndReceive(ar);

                if (bytesRead > 0)
                    if (handler.Connected)
                    {
                        new Message(handler, state.buffer);
                        state.buffer = new byte[9999];
                        handler.BeginReceive(state.buffer, 0, StateObject.BufferSize, 0,
                            ReadCallback, state);
                    }
                    else
                    {
                        Logger.Log($"Clientul {handler.RemoteEndPoint} s-a deconectat de pe server!",
                            Logger.DefCon.WARN);
                    }
                else
                    Logger.Log($"Clientul {handler.RemoteEndPoint} s-a deconectat de la server!", Logger.DefCon.WARN);
            }
            catch (Exception e)
            {
                Logger.Log("Am atentionat clientul ca nu putem prelua date de conectare : " + e.Message,
                    Logger.DefCon.ERROR);
            }
        }

        private static void Send(Socket handler, byte[] packet)
        {
            handler.BeginSend(packet, 0, packet.Length, 0,
                SendCallback, handler);
        }

        private static void SendCallback(IAsyncResult ar)
        {
            try
            {
                
                var handler = (Socket) ar.AsyncState;

                
                var bytesSent = handler.EndSend(ar);
                Console.WriteLine("Am trimis {0} bytes catre client.", bytesSent);

                handler.Shutdown(SocketShutdown.Both);
                handler.Close();
            }
            catch (Exception e)
            {
                Console.WriteLine(e.ToString());
            }
        }
    }
}