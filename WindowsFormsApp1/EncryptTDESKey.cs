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
                Form1 HexToBytes = new Form1();

                
                    for (var i=0; i<4; i++) {
                    var bytes = HexToBytes.convertir(TripleDESKeys[i]);
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
