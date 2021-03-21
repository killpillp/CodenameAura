using System.Collections.Generic;
using PaulModz.Utilities;

namespace PaulModz.Packets.Messages.Server
{
    internal class InBoxData
    {
        internal static byte[] Payload()
        {
            var Data = new List<byte>();
            Data.AddInt(5); //Message count

            Data.AddString(
                "https://56f230c6d142ad8a925f-b174a1d8fb2cf6907e1c742c46071d76.ssl.cf2.rackcdn.com/inbox/ClashRoyale_logo_small.png");
            Data.AddString("<c4>Welcome to PaulModz Server</c>!"); //titlu
            Data.AddString("Official PaulModz Emulator"); //descriere
            Data.AddString("Our website"); //nume buton
            Data.AddString("http://paulmodz.com/"); //buton link
            Data.AddString(""); //Unk
            Data.AddString(""); //Unk
            Data.AddString(""); //Unk

            // Data.AddString(
            ///     "https://56f230c6d142ad8a925f-b174a1d8fb2cf6907e1c742c46071d76.ssl.cf2.rackcdn.com/inbox/ClashRoyale_logo_small.png");
            // Data.AddString("<c4>Test</c>!"); //titlu
            //Data.AddString("AnotherTest!"); //descriere
            //Data.AddString("Test_Button!"); //nume buton
            //Data.AddString(""); //link buton
            //Data.AddString(""); //Unk
            //Data.AddString(""); //Unk
            //Data.AddString(""); //Unk

            //Data.AddString(
            //     "https://56f230c6d142ad8a925f-b174a1d8fb2cf6907e1c742c46071d76.ssl.cf2.rackcdn.com/inbox/ClashRoyale_logo_small.png");
            // Data.AddString("<c4>Test</c>!"); //titlu
            // Data.AddString("AnotherTest!"); //descriere
            // Data.AddString("Test_Button!"); //nume buton
            // Data.AddString(""); //link buton
            // Data.AddString(""); //Unk
            // Data.AddString(""); //Unk
            // Data.AddString(""); //Unk


            //  Data.AddString(
            //      "https://56f230c6d142ad8a925f-b174a1d8fb2cf6907e1c742c46071d76.ssl.cf2.rackcdn.com/inbox/ClashRoyale_logo_small.png");
            //  Data.AddString("<c4>Test</c>!"); //titlu
            //  Data.AddString("AnotherTest!"); //descriere
            //  Data.AddString("Test_Button!"); //nume buton
            //  Data.AddString(""); //link buton
            //  Data.AddString(""); //Unk
            //  Data.AddString(""); //Unk
            //  Data.AddString(""); //Unk


            // Data.AddString(
            //   "https://56f230c6d142ad8a925f-b174a1d8fb2cf6907e1c742c46071d76.ssl.cf2.rackcdn.com/inbox/ClashRoyale_logo_small.png");
            // Data.AddString("<c4>Test</c>!"); //titlu
            // Data.AddString("AnotherTest!"); //descriere
            //  Data.AddString("Test_Button!"); //nume buton
            /// Data.AddString(""); //link buton
            // Data.AddString(""); //Unk
            // Data.AddString(""); //Unk
            // Data.AddString(""); //Unk

            return Data.ToArray();
        }
    }
}