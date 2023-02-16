using System;
using System.Linq;
using System.IO;
using System.Text;
using System.Diagnostics;

namespace WksProsit5
{
    class Program
    {
        public static string XOR(string data, string key)
        {
            int dataLen = data.Length;
            int keyLen = key.Length;
            char[] output = new char[dataLen];
            for (int i = 0; i < dataLen; ++i)
            {
                output[i] = (char)(data[i] ^ key[i % keyLen]);
            }
            return new string(output);
        }
        static int Main(string[] args)
        {
            var starttime = DateTime.Now;
            string data;
            string outdata;
            try
            {
                using (var reader = new StreamReader(args[0], Encoding.UTF8))
                {
                    data = reader.ReadToEnd();
                }
            }
            catch (Exception)
            {
                return -1;
            }
            if (args.Length > 1)
            {
                outdata = XOR(data, args[1]);
            }
            else if (args.Length > 0)
            {
                string key = "ThisIsATest";
                outdata = XOR(data, key);
            }
            else { return -1; }
            using (var writer = new StreamWriter(args[0]))
            {
                writer.Write(outdata);
            }
            return ((int)DateTime.Now.Subtract(starttime).TotalMilliseconds);
        }
    }
}
