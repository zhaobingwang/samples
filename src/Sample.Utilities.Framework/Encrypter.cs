using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;

namespace Sample.Utilities.Framework
{
    public static class Encrypter
    {
        /// <summary>
        /// MD5加密
        /// </summary>
        /// <param name="str">需要加密的字符串</param>
        /// <param name="encoding">字符的编码</param>
        /// <returns></returns>
        public static string MD5Encrypt(string str, Encoding encoding)
        {
            if (string.IsNullOrEmpty(str))
            {
                return null;
            }
            MD5CryptoServiceProvider md5Hasher = new MD5CryptoServiceProvider();
            byte[] data = md5Hasher.ComputeHash(encoding.GetBytes(str));
            StringBuilder sBuilder = new StringBuilder();
            for (int i = 0; i < data.Length; i++)
            {
                sBuilder.Append(data[i].ToString("x2"));
            }
            return sBuilder.ToString();
        }
    }
}
