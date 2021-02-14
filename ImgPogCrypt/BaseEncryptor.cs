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
            return String.Join(
                    String.Empty,
                    Encoding.UTF8
                        .GetBytes(txt)
                        .Select(byt => Convert.ToString(byt, 2).PadLeft(8, '0')))
                        .Select(c => Convert.ToInt32(c) == 49 ? 1 : 0)
                        .ToList();
        }
    }
}