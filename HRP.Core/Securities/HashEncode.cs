using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Text;
using System.Security.Cryptography;
namespace HRP.Core.Securities
{
   public static class HashEncode
    {
        public static string ToGetHashCode(this string password)
        {
            byte[] mainBytes;
            byte[] encodeBytes;

            MD5 md5;
            md5=new MD5CryptoServiceProvider();

            mainBytes = ASCIIEncoding.Default.GetBytes(password);
            encodeBytes = md5.ComputeHash(mainBytes);

            return BitConverter.ToString((encodeBytes));
        }
    }
}
