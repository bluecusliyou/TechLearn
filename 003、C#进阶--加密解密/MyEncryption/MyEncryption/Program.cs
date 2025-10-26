using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Security.Cryptography;

namespace MyEncryption
{
    class Program
    {
        static void Main(string[] args)
        {
            try
            {
                //三、不可逆加密MD5
                {
                    //Console.WriteLine("MD5加密");
                    //Console.WriteLine(MD5Encrypt.Encrypt("张三"));
                    //Console.WriteLine(MD5Encrypt.Encrypt("张三"));
                    //Console.WriteLine(MD5Encrypt.Encrypt("李四李四李四李四李四李四李四李四李四李四李四"));
                    //Console.WriteLine(MD5Encrypt.Encrypt("李四李四李四李四李四李四李四李四李四李四李四1"));
                    //Console.WriteLine(MD5Encrypt.Encrypt("王五王五王五王五王五王五王五王五王五王五王五王五王五王五王五王五王五王五王五王五王五王五王五王五王五王五王五"));

                    //Console.WriteLine("文件摘要");
                    //Console.WriteLine(MD5Encrypt.AbstractFile(@"D:\NetDemos\Test\测试文件.txt"));
                    //Console.WriteLine(MD5Encrypt.AbstractFile(@"D:\NetDemos\Test\测试文件 - 副本.txt"));
                }

                //四、对称可逆加密Des
                {
                    //Console.WriteLine("DES加密");
                    //string desEn = DesEncrypt.Encrypt("张三");
                    //string desEn1 = DesEncrypt.Encrypt("李四123456");
                    //Console.WriteLine(desEn);
                    //Console.WriteLine(desEn1);
                    //Console.WriteLine("DES解密");
                    //string desDe = DesEncrypt.Decrypt(desEn);                    
                    //string desDe1 = DesEncrypt.Decrypt(desEn1);
                    //Console.WriteLine(desDe);
                    //Console.WriteLine(desDe1);
                }

                //五、非对称可逆加密Rsa
                {
                    //获取公钥和私钥，每次生成的都不一样
                    Console.WriteLine($"生成公钥和私钥");
                    KeyModel encryptDecrypt = RsaEncrypt.GetKeyPair();
                    Console.WriteLine($"私钥：{encryptDecrypt.PrivateKey}");
                    Console.WriteLine($"公钥：{encryptDecrypt.PublicKey}");

                    //私钥加密，私钥解密  私钥能加密的原因是私钥包含公钥
                    Console.WriteLine($"私钥加密，私钥解密");
                    string rsaEn1 = RsaEncrypt.Encrypt("张三", encryptDecrypt.PrivateKey);
                    Console.WriteLine($"密文:{rsaEn1}");
                    Console.WriteLine($"解密：{RsaEncrypt.Decrypt(rsaEn1, encryptDecrypt.PrivateKey)}");

                    //公钥加密，私钥解密
                    Console.WriteLine($"公钥加密，私钥解密");
                    string rsaEn2 = RsaEncrypt.Encrypt("张三", encryptDecrypt.PublicKey);
                    Console.WriteLine($"密文:{rsaEn2}");
                    Console.WriteLine($"解密：{RsaEncrypt.Decrypt(rsaEn2, encryptDecrypt.PrivateKey)}");

                    //生成签名
                    Console.WriteLine($"生成签名");
                    string autograph = RsaEncrypt.SignData("生成签名的原文", encryptDecrypt.PrivateKey);
                    Console.WriteLine($"签名:{autograph}");

                    //验证签名
                    Console.WriteLine($"验证签名");
                    Console.WriteLine($"验证签名:{RsaEncrypt.VerifyData("生成签名的原文", autograph, encryptDecrypt.PublicKey)}");
                    Console.WriteLine($"验证签名原文改动:{RsaEncrypt.VerifyData("生成签名的原文改动", autograph, encryptDecrypt.PublicKey)}");
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
            Console.ReadKey();
        }
    }
}
