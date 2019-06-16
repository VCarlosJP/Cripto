using System;
using System.Security.Cryptography;
using System.Text;
using System.Xml;

class RSAKey
{
    public RSACryptoServiceProvider get() {
        RSACryptoServiceProvider RSA = new RSACryptoServiceProvider(512);
        RSA.ExportParameters(true);
        RSA.ExportParameters(false);
        return RSA;
    }

    //public Tuple<RSAParameters, RSAParameters> RSAKeys()
    //{
    //    UnicodeEncoding ByteConverter = new UnicodeEncoding();
    //    RSACryptoServiceProvider RSA = new RSACryptoServiceProvider(512);
        
    //    string privateKey = RSA.ToXmlString(true);

    //return new Tuple<RSAParameters, RSAParameters>(RSA.ExportParameters(false), RSA.ExportParameters(true));

    //}

}


