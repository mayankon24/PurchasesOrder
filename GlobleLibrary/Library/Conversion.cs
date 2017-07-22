using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace GlobleLibrary
{
    class Conversion
    {
        static public byte[] StringToByteArray(string str)
        {
            List<byte> lstByte = new List<byte>();

            for (int i = 0; i < str.Length; i++)
            {
                lstByte.Add(Convert.ToByte(str[i]));
            }

            byte[] data = lstByte.ToArray();

            return data;

        }
        static public string CharArrayToString(char[] charArray)
        {
            StringBuilder tempString = new StringBuilder();

            for (int i = 0; i < charArray.Length; i++)
            {
                tempString.Append(charArray[i]);
            }
            return tempString.ToString();
        }
    }
}
