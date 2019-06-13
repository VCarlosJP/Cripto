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

    public Tuple<RSAParameters, RSAParameters> RSAKeys()
    {



        UnicodeEncoding ByteConverter = new UnicodeEncoding();
        RSACryptoServiceProvider RSA = new RSACryptoServiceProvider(512);
        RSACryptoServiceProvider RSA1 = new RSACryptoServiceProvider();
        


        //var publicKey = RSA.ToXmlString(false);
        //RSAParameters publicKey = RSA.ExportParameters(false);
        

    //var EncodedString = Convert.ToBase64String(Encoding.UTF8.GetBytes(publicKey));

        //Console.WriteLine(publicKey.tr);



        //XmlDocument publicKeyXML = new XmlDocument();
        //        publicKeyXML.LoadXml(publicKey);

        //        XmlNodeList elemList = publicKeyXML.GetElementsByTagName("Modulus");
        //        for (int i = 0; i < elemList.Count; i++)
        //        {
        //            finalPublicKey = elemList[i].InnerXml;
        //        }


        string privateKey = RSA.ToXmlString(true);

               

               

    //XmlDocument privateKeyXML = new XmlDocument();
    //privateKeyXML.LoadXml(privateKey);

    //XmlNodeList elemList1 = privateKeyXML.GetElementsByTagName("Modulus");
    //for (int i = 0; i < elemList1.Count; i++)
    //{
    //    finalPrivateKey = elemList1[i].InnerXml;
    //}





    return new Tuple<RSAParameters, RSAParameters>(RSA.ExportParameters(false), RSA.ExportParameters(true));

    }

}


