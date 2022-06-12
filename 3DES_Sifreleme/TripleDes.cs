using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Security.Cryptography;
using System.IO;

namespace _3DES_Sifreleme
{
    public class TripleDes
    {

        private TripleDESCryptoServiceProvider des = new TripleDESCryptoServiceProvider();
        public TripleDes(string key)
        {

            des.Key = Encoding.UTF8.GetBytes(key);
            des.Mode = CipherMode.ECB;
            des.Padding = PaddingMode.PKCS7;

        }
        public void Sifrele(string filepath)
        {
            byte[] Bytes = File.ReadAllBytes(filepath);
            byte[] eBytes = des.CreateEncryptor().TransformFinalBlock(Bytes, 0, Bytes.Length);
            File.WriteAllBytes(filepath, eBytes);
        }
        public void SifreCoz(string filepath)
        {

            byte[] Bytes = File.ReadAllBytes(filepath);
            byte[] dBytes = des.CreateDecryptor().TransformFinalBlock(Bytes, 0, Bytes.Length);
            File.WriteAllBytes(filepath, dBytes);



        }





    }

}
