using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Security.Cryptography;

namespace DAReport
{
    public static class Encrypt
    {
        public static string MD5Encrypt(string str)
        {
            MD5 m5 = new MD5CryptoServiceProvider();
            byte[] byte1;
            byte1 = m5.ComputeHash(Encoding.Default.GetBytes(str));
            m5.Clear();
            StringBuilder sBuilder = new StringBuilder();
            for (int i = 0; i < byte1.Length; i++)
            {
                var v = byte1[i].ToString("x");
                if (v.Length == 1)
                    sBuilder.Append("0");

                sBuilder.Append(v);
            }
            return sBuilder.ToString(); 

        }
    }
}
