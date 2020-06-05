using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Text;
using System.Configuration;
using System.IO;
using System.Security.Cryptography;

namespace Coeno.Common.Utility
{
public class Encrypt
{
        /// <summary>
        /// 加密方法1
        /// </summary>
        /// <param name="Source">待加密的串</param>
        /// <returns>经过加密的串</returns>

        public static string Encrypto(string Source)
        {
            byte[] bytIn = UTF8Encoding.UTF8.GetBytes(Source);
            MemoryStream ms = new MemoryStream();
            RijndaelManaged mobjCryptoService = new RijndaelManaged();
            mobjCryptoService.Key = GetLegalKey();
            mobjCryptoService.IV = GetLegalIV();
            ICryptoTransform encrypto = mobjCryptoService.CreateEncryptor();
            CryptoStream cs = new CryptoStream(ms,encrypto,CryptoStreamMode.Write);
            cs.Write(bytIn,0,bytIn.Length);
            cs.FlushFinalBlock();
            ms.Close();
            byte[] bytOut = ms.ToArray();
            return Convert.ToBase64String(bytOut);
        }

        /// <summary>
        /// 获得密钥
        /// </summary>
        /// <returns>密钥</returns>

        private static byte[] GetLegalKey()
        {
            string sTemp = @"Guz(%&hj7x89H$yuBI0456FtmaT5&fvHUFCy76*h%(HilJ$lhj!y6&(*jkP87jH7";

            RijndaelManaged mobjCryptoService = new RijndaelManaged();
            mobjCryptoService.GenerateKey();

            byte[] bytTemp = mobjCryptoService.Key;
            int KeyLength = bytTemp.Length;

            if (sTemp.Length>KeyLength)
            {
                sTemp = sTemp.Substring(0,KeyLength);
            }
            else if (sTemp.Length<KeyLength)
            {
                sTemp = sTemp.PadRight(KeyLength,' ');
            }
            return ASCIIEncoding.ASCII.GetBytes(sTemp);
        }

        /// <summary>
        /// 获得初始向量IV
        /// </summary>
        /// <returns>初试向量IV</returns>
        private static byte[] GetLegalIV()
        {
            string sTemp = @"E4ghj*Ghg7!rNIfb&95GUY86GfghUb#er57HBh(u%g6HJ($jhWk7&!hg4ui%$hjk";

            RijndaelManaged mobjCryptoService = new RijndaelManaged();
            mobjCryptoService.GenerateIV();

            byte[] bytTemp = mobjCryptoService.IV;
            int IVLength = bytTemp.Length;

            if (sTemp.Length>IVLength)
            {
                sTemp = sTemp.Substring(0,IVLength);
            }
            else if (sTemp.Length<IVLength)
            {
                sTemp = sTemp.PadRight(IVLength,' ');
            }
            return ASCIIEncoding.ASCII.GetBytes(sTemp);

        }

        /// <summary>
        /// 解密方法1
        /// </summary>
        /// <param name="Source">待解密的串</param>
        /// <returns>经过解密的串</returns>

        public static string Decrypto(string Source)
        {
            try
            {
                byte[] bytIn = Convert.FromBase64String(Source);
                MemoryStream ms = new MemoryStream(bytIn,0,bytIn.Length);
                RijndaelManaged mobjCryptoService = new RijndaelManaged();
                mobjCryptoService.Key = GetLegalKey();
                mobjCryptoService.IV = GetLegalIV();
                ICryptoTransform encrypto = mobjCryptoService.CreateDecryptor();
                CryptoStream cs = new CryptoStream(ms,encrypto,CryptoStreamMode.Read);
                StreamReader sr = new StreamReader(cs);
                return sr.ReadToEnd();
            }
            catch(Exception ex)
            {
                return "";
            }
        }
    }

}