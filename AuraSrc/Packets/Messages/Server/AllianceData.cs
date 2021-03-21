using System;
using System.Collections.Generic;
using PaulModz.Core.Settings;
using PaulModz.Utilities;

namespace PaulModz.Packets.Messages.Server
{
    internal class AllianceData
    {
        internal static byte[] Payload()
        {
            var players = 1;
            var AllianceData = new List<byte>();
            AllianceData.AddInt(0);
            AllianceData.AddInt(1);
            AllianceData.AddString(Constants.OwnHomeData.StartingClanName);
            AllianceData.AddScid(16, 23); //insigna
            AllianceData.Add(3); //byte
            AllianceData.AddVInt(players); //nr membri
            AllianceData.AddVInt(1000); //scor
            AllianceData.AddVInt(666); //scor1
            AllianceData.Add(1);
            AllianceData.Add(1);
            AllianceData.AddVInt(145);
            AllianceData.AddVInt(1);
            AllianceData.AddVInt(1000); //donation/week
            AllianceData.AddVInt(-1661);
            AllianceData.Add(1);
            AllianceData.Add(1);
            AllianceData.Add(0);
            AllianceData.AddScid(57, 120); //Romania
            AllianceData.Add(0);

            AllianceData.AddString(Constants.AllianceData.Description);
            AllianceData.AddVInt(players); //nr playeri clan

            var random = new Random();
            for (byte zero = 0; zero < players; zero++)
            {
                var _ID = random.Next(0, 999999);
                AllianceData.AddLong(_ID);
                AllianceData.AddString(Constants.OwnHomeData.StartingClanName + " - " + zero);
                AllianceData.AddScid(54, 11); //arena
                AllianceData.AddVInt(3); //rol
                AllianceData.AddVInt(random.Next(1, 13)); //nivel
                AllianceData.AddVInt(random.Next(1000, 6600));
                AllianceData.AddVInt(random.Next(1, 1000));
                AllianceData.AddVInt(100);
                AllianceData.AddVInt(zero); //rank curent
                AllianceData.AddVInt(zero); //rank anterior
                AllianceData.AddVInt(100); //coroane
                AllianceData.AddVInt(1);
                AllianceData.AddVInt(1);
                AllianceData.AddVInt(1);
                AllianceData.AddVInt(1);
                AllianceData.AddVInt(1); //00 7F 9C DA B0 08 24 04
                AllianceData.AddLong(_ID);
            }
            AllianceData.Add(1);
            AllianceData.Add(1);
            AllianceData.AddVInt(1);
            AllianceData.AddVInt(1);
            AllianceData.AddInt(1);
            AllianceData.AddInt(1);
            AllianceData.AddVInt(1);
            AllianceData.Add(1);
            AllianceData.Add(1);
            return AllianceData.ToArray();
        }
    }
}