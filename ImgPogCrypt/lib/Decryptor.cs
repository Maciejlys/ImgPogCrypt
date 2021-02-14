using System.Collections.Generic;
using ImgPogCrypt.model;

namespace ImgPogCrypt.lib
{
    public interface IDecryptor
    {
        public string Decrypt(List<int> diff);
    }
}