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
            return BinaryToString(JoinAllRgbDiffs(diff)).Replace("\0", String.Empty);
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

            while (data.Length % 8 != 0)
            {
                data = data.Remove(data.Length -1);
            }
            
            for (int i = 0; i < data.Length; i += 8)
            {
                byteList.Add(Convert.ToByte(data.Substring(i, 8), 2));
            }
            return Encoding.UTF8.GetString(byteList.ToArray());
        }
    }
}