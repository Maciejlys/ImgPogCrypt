using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using ImgPogCrypt.lib;
using ImgPogCrypt.model;

namespace ImgPogCrypt
{
    public class BaseEncryptor : IEncryptor
    {
        public List<int> Encrypt(string txt)
        {
            List<int> result = new List<int>();
            foreach (char c in txt.ToCharArray())
            {
                String binary = (Convert.ToString(c, 2).PadLeft(8, '0'));
                binary.ToList().ForEach(c => result.Add(Convert.ToInt32(c) == 49 ? 1 : 0));
            }
            return result;
        }
    }
}