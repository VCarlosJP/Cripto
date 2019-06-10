using System;
using System.Security.Cryptography;
using System.Text;
using System.Xml;

class RSAKey
{


    public Tuple<string, string> RSAKeys()
    {

        string finalPublicKey = null;
        string finalPrivateKey = null;

        UnicodeEncoding ByteConverter = new UnicodeEncoding();
        RSACryptoServiceProvider RSA = new RSACryptoServiceProvider();
        RSACryptoServiceProvider RSA1 = new RSACryptoServiceProvider();



        var publicKey = RSA.ToXmlString(false);
        
        
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





    return new Tuple<string, string>("LlavePublica", "Llave Privada");

    }

}


