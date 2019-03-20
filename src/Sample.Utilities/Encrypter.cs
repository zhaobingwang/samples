using System;
using System.Collections.Generic;
using System.IO;
using System.Security.Cryptography;
using System.Text;

namespace Sample.Utilities
{
    public class Encrypter
    {
        #region DES
        public static string DESEncrypt2Hex(string source, string secretKey)
        {
            if (secretKey.Length < 8)
                throw new Exception("secret key length less than 8");
            secretKey = secretKey.Substring(0, 8);

            byte[] data = Encoding.UTF8.GetBytes(source);
            byte[] key = Encoding.UTF8.GetBytes(secretKey);

            DESCryptoServiceProvider provider = new DESCryptoServiceProvider();
            provider.Mode = CipherMode.ECB;
            provider.Padding = PaddingMode.PKCS7;

            ICryptoTransform transform = provider.CreateEncryptor(key, key);
            CryptoStreamMode mode = CryptoStreamMode.Write;

            MemoryStream memStream = new MemoryStream();
            CryptoStream cryptoStream = new CryptoStream(memStream, transform, mode);
            cryptoStream.Write(data, 0, data.Length);
            cryptoStream.FlushFinalBlock();

            byte[] encryptedMessageBytes = new byte[memStream.Length];
            memStream.Position = 0;
            memStream.Read(encryptedMessageBytes, 0, encryptedMessageBytes.Length);

            var arr = memStream.ToArray();
            StringBuilder sb = new StringBuilder();
            foreach (var item in arr)
            {
                sb.Append(item.ToString("X2"));
            }
            return sb.ToString();
        }
        #endregion

        #region private function
        /// <summary>
        /// 将十六进制字符串转为byte数组
        /// </summary>
        /// <param name="hexStr">16进制字符串</param>
        /// <returns></returns>
        private static byte[] ConvertHexString2ByteArray(string hexStr)
        {
            hexStr = hexStr.Replace(" ", "");
            byte[] buffer = new byte[hexStr.Length / 2];
            for (int i = 0; i < hexStr.Length; i += 2)
            {
                buffer[i / 2] = (byte)Convert.ToByte(hexStr.Substring(i, 2), 16);
            }
            return buffer;
        }
        #endregion
    }
}
