using System;
using System.Collections.Generic;
using System.Text;
using ImgPogCrypt.lib;
using ImgPogCrypt.model;

namespace ImgPogCrypt
{
    public class BaseEncryptor : IEncryptor
    {
        public List<RgbDifference> Encrypt(string txt)
        {
            List<RgbDifference> result = new List<RgbDifference>();
            StringBuilder sb = new StringBuilder();
            foreach (char c in txt.ToCharArray())
            {
                sb.Append(Convert.ToString(c, 2).PadLeft(8, '0'));
            }
           string[] binaryPairs = StringUtil.SplitStringToSet(sb.ToString());
           foreach (string pair in binaryPairs)
           {
               result.Add(new RgbDifference(pair));
           }
           return result;
        }
    }
}