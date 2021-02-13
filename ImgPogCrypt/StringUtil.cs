using System.Collections.Generic;
using System.Text;

namespace ImgPogCrypt
{
    public class StringUtil
    {
        public static string[] SplitStringToSet(string s)
        {
            List<string> list = new List<string>();
            StringBuilder temp = new StringBuilder();
            for (int i = 0; i < s.Length; i++)
            {
                temp.Append(s[i]);
                if (temp.Length == 3)
                {
                    list.Add(temp.ToString());
                    temp.Clear();
                }
            }

            if (temp.Length != 0)
            {
                while (temp.Length < 3)
                {
                    temp.Append('0');
                }

                list.Add(temp.ToString());
            }

            return list.ToArray();
        }
    }
}