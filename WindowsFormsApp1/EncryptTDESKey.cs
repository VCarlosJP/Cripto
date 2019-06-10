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
        public static List<byte[]> RSAEncrypt(List<byte[]> TripleDESKeys, RSAParameters RSAKeyInfo, bool DoOAEPPadding)
        {
            try
            {

                RSACryptoServiceProvider RSA = new RSACryptoServiceProvider();

                var array = new List<byte[]>();

                    for (var i=0; i<=3; i++) {
                        RSA.ImportParameters(RSAKeyInfo);
                        array.Add(RSA.Encrypt(TripleDESKeys[i], DoOAEPPadding));
                    Console.WriteLine(array[i]);
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
