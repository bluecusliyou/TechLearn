using System;
using System.Security.Cryptography;
using System.Text;

namespace MyEncryption
{
    public class KeyModel
    {
        /// <summary>
        /// 构造函数
        /// </summary>
        /// <param name="publicKey">共有key</param>
        /// <param name="privateKey">私有key</param>
        public KeyModel(string publicKey, string privateKey)
        {
            this.PublicKey = publicKey;
            this.PrivateKey = privateKey;
        }

        /// <summary>
        /// 公有Key---加密key
        /// </summary>
        public string PublicKey { get; set; }

        /// <summary>
        /// 私有Key--可以加密也可以加密
        /// </summary>
        public string PrivateKey { get; set; }
    }
    
    public class RsaEncrypt
    {
        /// <summary>
        /// 获取公钥/私钥
        /// 每次生成的公钥和私钥都不一样
        /// </summary>
        /// <returns>Encrypt   Decrypt</returns>
        public static KeyModel GetKeyPair()
        {
            RSACryptoServiceProvider RSA = new RSACryptoServiceProvider();

            //包括专用参数： 如果为true，则包含公钥和私钥RSA密钥；false，仅包括公众钥匙 
            string publicKey = RSA.ToXmlString(false); //生成的是公开的解密key
            string privateKey = RSA.ToXmlString(true); //生成的是私有的既可以加密也可以解密的key
            return new KeyModel(publicKey, privateKey);
        }

        /// <summary>
        /// RSA加密
        /// </summary>
        /// <param name="content"></param>
        /// <param name="encryptKey">加密key</param>
        /// <returns></returns>
        public static string Encrypt(string content, string encryptKey)
        {
            RSACryptoServiceProvider rsa = new RSACryptoServiceProvider();
            rsa.FromXmlString(encryptKey);
            UnicodeEncoding ByteConverter = new UnicodeEncoding();
            byte[] DataToEncrypt = ByteConverter.GetBytes(content);
            byte[] resultBytes = rsa.Encrypt(DataToEncrypt, false);
            return Convert.ToBase64String(resultBytes);
        }

        /// <summary>
        /// RSA解密
        /// </summary>
        /// <param name="content"></param>
        /// <param name="decryptKey">解密key</param>
        /// <returns></returns>
        public static string Decrypt(string content, string decryptKey)
        {
            byte[] dataToDecrypt = Convert.FromBase64String(content);
            RSACryptoServiceProvider RSA = new RSACryptoServiceProvider();
            RSA.FromXmlString(decryptKey);
            byte[] resultBytes = RSA.Decrypt(dataToDecrypt, false);
            UnicodeEncoding ByteConverter = new UnicodeEncoding();
            return ByteConverter.GetString(resultBytes);
        }

        /// <summary>
        /// 生成签名
        /// </summary>
        /// <param name="content"></param>
        /// <param name="decryptKey"></param>
        /// <returns></returns>
        public static string SignData(string content, string privatekey)
        { 
            byte[] messagebytes = Encoding.UTF8.GetBytes(content);
            RSACryptoServiceProvider oRSA3 = new RSACryptoServiceProvider();
            oRSA3.FromXmlString(privatekey);
            byte[] AOutput = oRSA3.SignData(messagebytes, "SHA1");
            return Convert.ToBase64String(AOutput);
        }
         
        /// <summary>
        /// 验证签名
        /// </summary>
        /// <param name="content">原文</param>
        /// <param name="autograph">签名</param>
        /// <param name="publickey">共有key</param>
        /// <returns></returns>
        public static bool VerifyData(string content, string autograph, string publickey)
        {
            byte[] messagebytes = Encoding.UTF8.GetBytes(content); 
            byte[] messageAutographbytes = Convert.FromBase64String(autograph); 
            RSACryptoServiceProvider RSA = new RSACryptoServiceProvider();
            RSA.FromXmlString(publickey);
            bool bVerify = RSA.VerifyData(messagebytes, "SHA1", messageAutographbytes); 
            return bVerify; 
        }

        /// <summary>
        /// 生成公钥私钥，同时完成加密
        /// </summary>
        /// <param name="content"></param>
        /// <param name="encryptKey">加密key</param>
        /// <param name="decryptKey">解密key</param>
        /// <returns>加密后结果</returns>
        private static string Encrypt(string content, out string publicKey, out string privateKey)
        {
            RSACryptoServiceProvider rsaProvider = new RSACryptoServiceProvider();
            publicKey = rsaProvider.ToXmlString(false);
            privateKey = rsaProvider.ToXmlString(true);

            UnicodeEncoding ByteConverter = new UnicodeEncoding();
            byte[] DataToEncrypt = ByteConverter.GetBytes(content);
            byte[] resultBytes = rsaProvider.Encrypt(DataToEncrypt, false);
            return Convert.ToBase64String(resultBytes);
        }
    }
}
