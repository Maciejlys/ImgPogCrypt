using System;
using System.Collections.Generic;
using System.Text;
using ImgPogCrypt.lib;

namespace ImgPogCrypt
{
    public class BaseDecryptor : IDecryptor
    {
        public string Decrypt(List<int> diff)
        {
            return BinaryToString(JoinAllRgbDiffs(diff));
        }

        private string JoinAllRgbDiffs(List<int> diff)
        {
            StringBuilder sb = new StringBuilder();
            diff.ForEach(x=> sb.Append(x));
            return sb.ToString();
        }

        public static string BinaryToString(string data)
        {
            List<Byte> byteList = new List<Byte>();
        
            for (int i = 0; i < data.Length; i += 8)
            {
                byteList.Add(Convert.ToByte(data.Substring(i, 8), 2));
            }
            return Encoding.ASCII.GetString(byteList.ToArray());
        }
    }
}