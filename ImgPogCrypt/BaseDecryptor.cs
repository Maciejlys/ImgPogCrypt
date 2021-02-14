using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using ImgPogCrypt.lib;
using ImgPogCrypt.model;

namespace ImgPogCrypt
{
    public class BaseDecryptor : IDecryptor
    {
        public string Decrypt(List<RgbDifference> diff)
        {
            string diffs = ConvertRgbDiffListToString(diff);
            return BinaryToString(diffs);
        }

        private string ConvertRgbDiffListToString(List<RgbDifference> rgbDifferences)
        {
            StringBuilder sb = new StringBuilder();
            foreach (RgbDifference rgbDifference in rgbDifferences)
            {
                sb.Append(ConvertRgbDiffToString(rgbDifference));
            }

            return sb.ToString();
        }

        private string ConvertRgbDiffToString(RgbDifference rgbDifference)
        {
            StringBuilder sb = new StringBuilder();
            sb.Append(rgbDifference.R);
            sb.Append(rgbDifference.G);
            sb.Append(rgbDifference.B);
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