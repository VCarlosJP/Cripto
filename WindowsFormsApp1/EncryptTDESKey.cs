using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;

namespace WindowsFormsApp1
{
    class EncryptTDESKey
    {
        public List<byte[]> RSAEncrypt(List<string> TripleDESKeys, RSAParameters RSAKeyInfo, bool DoOAEPPadding)
        {
            try
            {

                RSACryptoServiceProvider RSA = new RSACryptoServiceProvider();
                RSA.ImportParameters(RSAKeyInfo);

                UnicodeEncoding ByteConverter = new UnicodeEncoding();

                
                var array = new List<byte[]>();

                
                    for (var i=0; i<4; i++) {
                    int Num = TripleDESKeys[i].Length;
                    byte[] bytes = new byte[Num / 2];
                    for (var x=0; x< Num; x+=2) {
                        bytes[x / 2] = Convert.ToByte(TripleDESKeys[i].Substring(x, 2), 16);
                    }

                    array.Add(RSA.Encrypt(bytes, DoOAEPPadding));


                }


                return array;
            }

            catch (CryptographicException)
            {
                Console.WriteLine("Error al encriptar claves TDES");

                return null;
            }

        }

    }
}
