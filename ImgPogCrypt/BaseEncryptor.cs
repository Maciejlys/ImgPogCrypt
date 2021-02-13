using System;
using System.Text;
using ImgPogCrypt.lib;

namespace ImgPogCrypt
{
    public class BaseEncryptor : IEncryptor
    {
        public string[] StringToByteArray(string txt)
        {
            StringBuilder result = new StringBuilder();
            foreach (char c in txt.ToCharArray())
            {
                result.Append(Convert.ToString(c, 2).PadLeft(8, '0'));
            }

            return StringUtil.SplitStringToSet(result.ToString());
        }
    }
}