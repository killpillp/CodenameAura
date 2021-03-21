﻿using System.Collections.Generic;
using PaulModz.Utilities;
using static PaulModz.Core.Settings.Constants.LoginFailed;

namespace PaulModz.Packets.Messages.Server
{
    internal class LoginFailed
    {
        internal static byte[] Payload(Error errorcode)
        {
            var packet = new List<byte>();
            switch (errorcode)
            {
                case Error.OutDatedContent:
                    packet.Add(7);
                    break;
                case Error.Update:
                    packet.Add(8);
                    break;
                case Error.Redirect:
                    packet.Add(9);
                    break;
                case Error.Maintenance:
                    packet.Add(10);
                    break;
                case Error.Banned:
                    packet.Add(11);
                    break;
                case Error.Locked:
                    packet.Add(13);
                    break;
                default:
                    packet.Add(0);
                    break;
            }
            packet.AddString(FingerPrint);
            packet.AddString(Redirect);
            packet.AddString(null);
            packet.AddString(null);
            packet.Add(0);
            packet.Add(0);
            packet.AddString(null);
            packet.Add(2);
            packet.AddString(AssetsUrl);
            packet.AddString(ContentUrl);

            return packet.ToArray();
        }
    }
}