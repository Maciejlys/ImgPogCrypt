using System.Collections.Generic;
using ImgPogCrypt.model;

namespace ImgPogCrypt.lib
{
    public interface IEncryptor
    {
        public List<RgbDifference> Encrypt(string txt);
    }
}