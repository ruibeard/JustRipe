﻿using System;
using System.IO;
using System.Linq;
using System.Security.Cryptography;
using System.Text;

namespace JustRipe.Utils
{
   public class EncryptPassword
   {

      /// <summary>
      /// fields used for encryption password
      /// </summary>
      private const String strPermutation = "neverstoplearning";
      private const Int32 bytePermutation1 = 0x19;
      private const Int32 bytePermutation2 = 0x59;
      private const Int32 bytePermutation3 = 0x17;
      private const Int32 bytePermutation4 = 0x41;

      public static string Encrypt(string strData)
      {
         return Convert.ToBase64String(Encrypt(Encoding.UTF8.GetBytes(strData)));
         // reference https://msdn.microsoft.com/en-us/library/ds4kkd55(v=vs.110).aspx
      }


      // encrypt
      private static byte[] Encrypt(byte[] strData)
      {
         PasswordDeriveBytes passbytes =
         new PasswordDeriveBytes(strPermutation,
         new byte[] { bytePermutation1, bytePermutation2, bytePermutation3, bytePermutation4 });

         MemoryStream memstream = new MemoryStream();
         Aes aes = new AesManaged();
         aes.Key = passbytes.GetBytes(aes.KeySize / 8);
         aes.IV = passbytes.GetBytes(aes.BlockSize / 8);

         CryptoStream cryptostream = new CryptoStream(memstream,
         aes.CreateEncryptor(), CryptoStreamMode.Write);
         cryptostream.Write(strData, 0, strData.Length);
         cryptostream.Close();
         return memstream.ToArray();
      }

   }

}
