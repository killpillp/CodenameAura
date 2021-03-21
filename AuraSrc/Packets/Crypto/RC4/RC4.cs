﻿using System;
using System.Linq;

namespace PaulModz.Packets.Crypto.RC4
{
    internal class RC4
    {
        internal RC4(byte[] key)
        {
            Key = KSA(key);
        }

        internal RC4(string key)
        {
            Key = KSA(StringToByteArray(key));
        }

        internal byte[] Key { get; set; }

        internal byte i { get; set; }
        internal byte j { get; set; }

        internal byte PRGA()
        {
            var temp = (byte) 0;

            i = (byte) ((i + 1) % 256);
            j = (byte) ((j + Key[i]) % 256);

            temp = Key[i];
            Key[i] = Key[j];
            Key[j] = temp;

            return Key[(Key[i] + Key[j]) % 256];
        }

        internal static byte[] KSA(byte[] key)
        {
            var keyLength = key.Length;
            var S = new byte[256];

            for (var i = 0; i != 256; i++) S[i] = (byte) i;

            var j = (byte) 0;

            for (var i = 0; i != 256; i++)
            {
                j = (byte) ((j + S[i] + key[i % keyLength]) % 256);

                var temp = S[i];
                S[i] = S[j];
                S[j] = temp;
            }
            return S;
        }

        internal static byte[] StringToByteArray(string str)
        {
            var bytes = new byte[str.Length];
            for (var i = 0; i < str.Length; i++) bytes[i] = (byte) str[i];
            return bytes;
        }
    }

    internal class RC4_Core
    {
        internal const string InitialKey = "fhsd6f86f67rt8fw78fw789we78r9789wer6re";
        internal const string InitialNonce = "nonce";
        public static Random Random = new Random();

        internal RC4_Core()
        {
            InitializeCiphers(InitialKey + InitialNonce);
        }

        internal RC4_Core(string key)
        {
            if (key == null)
                throw new ArgumentNullException(nameof(key));

            InitializeCiphers(key);
        }

        internal RC4 Encryptor { get; set; }
        internal RC4 Decryptor { get; set; }

        internal void Encrypt(ref byte[] data)
        {
            if (data == null)
                throw new ArgumentNullException(nameof(data));

            for (var k = 0; k < data.Length; k++)
                data[k] ^= Encryptor.PRGA();
        }

        internal void Decrypt(ref byte[] data)
        {
            if (data == null)
                throw new ArgumentNullException(nameof(data));

            for (var k = 0; k < data.Length; k++)
                data[k] ^= Decryptor.PRGA();
        }

        public void UpdateCiphers(uint clientSeed, byte[] serverNonce)
        {
            if (serverNonce == null)
                throw new ArgumentNullException(nameof(serverNonce));

            var newNonce = ScrambleNonce(clientSeed, serverNonce);
            var key = InitialKey + newNonce;
            InitializeCiphers(key);
        }

        internal void InitializeCiphers(string key)
        {
            Encryptor = new RC4(key);
            Decryptor = new RC4(key);

            for (var k = 0; k < key.Length; k++)
            {
                Encryptor.PRGA();
                Decryptor.PRGA();
            }
        }

        internal static byte[] GenerateNonce()
        {
            var buffer = new byte[Random.Next(15, 25)];
            Random.NextBytes(buffer);
            return buffer;
        }

        internal static string ScrambleNonce(ulong clientSeed, byte[] serverNonce)
        {
            var scrambler = new Scrambler(clientSeed);
            var byte100 = 0;
            for (var i = 0; i < 100; i++)
                byte100 = scrambler.GetByte();
            return serverNonce.Aggregate(string.Empty,
                (current, t) => current + (char) (t ^ (scrambler.GetByte() & byte100)));
        }
    }
}