using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Web;

namespace RainforestBooks.Functions
{
    static public class HashCode
    {
        static public string PassHash(string data)
        {

            SHA1 sha = SHA1.Create();
            byte[] hashdata = sha.ComputeHash(Encoding.Default.GetBytes(data));
            StringBuilder returnValue = new StringBuilder();

            for (int inst = 0; inst < hashdata.Length; inst++)
            {
                returnValue.Append(hashdata[inst].ToString());
            }
            return returnValue.ToString();

        }
    }
}