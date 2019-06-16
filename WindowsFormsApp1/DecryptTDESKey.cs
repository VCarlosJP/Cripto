using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;

namespace WindowsFormsApp1
{
    class DecryptTDESKey
    {
        public List<byte[]> RSADecrypt(List<byte[]> DataToDecrypt, RSAParameters RSAKeyInfo, bool DoOAEPPadding)
        {
            try
            {
                RSACryptoServiceProvider RSA = new RSACryptoServiceProvider();

                RSA.ImportParameters(RSAKeyInfo);

                UnicodeEncoding ByteConverter = new UnicodeEncoding();
                var array = new List<byte[]>();

                for (var i=0; i<4; i++) {
                    array.Add(RSA.Decrypt(DataToDecrypt[i], DoOAEPPadding));
                }   
                     
                return array;
            }


            catch (CryptographicException e)
            {
                Console.WriteLine(e.ToString());
                Console.WriteLine("Error");
                return null;
            }

        }






    }
}
