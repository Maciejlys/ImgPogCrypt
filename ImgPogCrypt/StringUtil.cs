using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ImgPogCrypt
{
    public class StringUtil
    {
        public static string[] SplitStringBySize(string s, int size = 3)
        {
            if (size <= 0) throw new ArgumentException();
            List<string> list = new List<string>();
            StringBuilder temp = new StringBuilder();
            for (int i = 0; i < s.Length; i++)
            {
                temp.Append(s[i]);
                if (temp.Length == size)
                {
                    list.Add(temp.ToString());
                    temp.Clear();
                }
            }

            if (temp.Length != 0)
            {
                while (temp.Length < size)
                {
                    temp.Append('0');
                }

                list.Add(temp.ToString());
            }

            return list.ToArray();
        }

        public static string JoinSets(string[] strings)
        {
            return string.Join("", strings);
        }
    }
}