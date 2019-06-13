using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

using System.Security.Cryptography;
using System.Xml;
using System.IO;
using System.Collections;
using System.Xml.Linq;

namespace WindowsFormsApp1
{
    public partial class Form1 : Form
    {
        //Lllave publica para probar
        RSAParameters ClavePublica;
        string ClavePublicaString;
        //Llave Privada
        RSAParameters ClavePrivada;
        //Variable que almacenara las 3 llaves TDES 
        List<string> TDESKeys;

        //Variable que convierte el String PublicKey a RSAParameters
        RSACryptoServiceProvider ClavaPublicaParams = new RSACryptoServiceProvider();

        List<byte[]> TDESKeysEncryptedImported;

        List<byte[]> TDESKeysDecryptedContainer;

        string pathToFile = "";
        string pathToFileTDES = "";
        string publicKey = "";

        //Variable que almacena la ruta del textoencriptado.xml
        string pathToFileImportEncryptedText = "";
        //Variable que almacena el texto encriptado obtenido del fichero xml
        string ImportEncryptedText = "";

        List<byte[]> EncryptedTDESKeys;

        List<string> EncryptedTDESKeysHex;

        //Variable que almacenara el Texto Encriptado por las claves TDES desencriptadas
        byte[] textEncryptedTDES;


        public Form1()
        {
            InitializeComponent();
            
        }

        //Generar Claves RSA (VistaMaestro)
        private void button1_Click(object sender, EventArgs e)
        {
            var culero = new RSAKey();
            var Items = culero.get();
            ClavePublica = Items.ExportParameters(false);
            ClavePrivada = Items.ExportParameters(true);
            ClavePublicaString = Items.ToXmlString(false);
        }

        private void button2_Click(object sender, EventArgs e)
        {
            var culero = new RSAKey();
            var Items = culero.get();
            ClavePublica = Items.ExportParameters(false);
            ClavePrivada = Items.ExportParameters(true);
            ClavePublicaString = Items.ToXmlString(false);

        }

        private void button3_Click(object sender, EventArgs e)
        {
            using (XmlWriter writer = XmlWriter.Create("C:\\Users\\Vills\\Desktop\\cp_esclavo.xml"))
            {
                writer.WriteElementString("clavepublica", ClavePublicaString);
                writer.Flush();
            }
        }

        

        private void button4_Click(object sender, EventArgs e)
        {
            OpenFileDialog theDialog = new OpenFileDialog();
            theDialog.Title = "Clave Pública";
            theDialog.Filter = "XML files|*.xml";
            theDialog.InitialDirectory = @"C:\Users\Vills\Desktop";

            if (theDialog.ShowDialog() == DialogResult.OK)
            {
                pathToFile = theDialog.FileName;
            }

            if (File.Exists(pathToFile))// only executes if the file at pathtofile exists//you need to add the using System.IO reference at the top of te code to use this
            {
                XmlDocument doc = new XmlDocument();
                doc.Load(pathToFile);

                XmlNodeList elemList = doc.GetElementsByTagName("clavepublica");
                for (int i = 0; i < elemList.Count; i++)
                {
                    publicKey = elemList[i].InnerText;
                }
                ClavaPublicaParams.FromXmlString(publicKey);
            }
        }

        //Metodo que genera llaves TDES
        private void button5_Click(object sender, EventArgs e)
        {
            TDESKeys TripleDesKeys = new TDESKeys();
            TDESKeys = TripleDesKeys.TDES_Keys();



            Console.WriteLine("LLaves Originales [0] "+ TDESKeys[0]);
            Console.WriteLine("LLaves Originales [1] " + TDESKeys[1]);
            Console.WriteLine("LLaves Originales [2] " + TDESKeys[2]);
            Console.WriteLine("LLaves Originales [3] " + TDESKeys[3]);
        }

        //Metodo para encriptar las 3 llaves TDES con RSA y llave esclavo publica
        private void button6_Click(object sender, EventArgs e)
        {
            EncryptTDESKey TDESKeysEncrypted = new EncryptTDESKey();
            EncryptedTDESKeys = TDESKeysEncrypted.RSAEncrypt(TDESKeys, ClavaPublicaParams.ExportParameters(false), false);

            EncryptedTDESKeysHex = new List<string>();
            
            for (var i = 0; i < 4; i++)
            {
                EncryptedTDESKeysHex.Add(BitConverter.ToString(EncryptedTDESKeys[i]).Replace("-",""));
            }
            
        }


        //Exportar un XML con las claves TDES encriptadas
        private void button7_Click(object sender, EventArgs e)
        {
            new XDocument(
                new XElement("root",
                    new XElement("tdes1", EncryptedTDESKeysHex[0]),
                    new XElement("tdes2", EncryptedTDESKeysHex[1]),
                    new XElement("tdes3", EncryptedTDESKeysHex[2]),
                    new XElement("iv", EncryptedTDESKeysHex[3])
                )
            )
            .Save("C:\\Users\\Vills\\Desktop\\tdesencriptado.xml");
        }


        //Metodo para recibir las TDES Keys Encriptadas de un fichero XML
        private void button8_Click(object sender, EventArgs e)
        {
            ImportTDESKeysXML TDESKeysEncrypted = new ImportTDESKeysXML();
            TDESKeysEncryptedImported = TDESKeysEncrypted.importTDESKeys();
        }

        //Metodo para Desencriptar Claves TDES
        private void button9_Click(object sender, EventArgs e)
        {
            DecryptTDESKey TDESKeysDecrypted = new DecryptTDESKey();
            TDESKeysDecryptedContainer = TDESKeysDecrypted.RSADecrypt(TDESKeysEncryptedImported, ClavePrivada, false);

            var probar = new List<string>();

            for (var i = 0; i < 4; i++)
            {
                probar.Add(BitConverter.ToString(TDESKeysDecryptedContainer[i]).Replace("-", ""));
            }
            Console.WriteLine(probar[0]);
            Console.WriteLine(probar[1]);
            Console.WriteLine(probar[2]);
            Console.WriteLine(probar[3]);

        }

        //Encriptar el texto introducido
        private void button10_Click(object sender, EventArgs e)
        {
            string textToEncrypt = textBox1.Text;
            var tdes = TDESKeysDecryptedContainer[0].Concat(TDESKeysDecryptedContainer[1]).Concat(TDESKeysDecryptedContainer[2]).ToArray();
            var iv = TDESKeysDecryptedContainer[3];

            TDESEncrypter TDES = new TDESEncrypter();
            textEncryptedTDES = TDES.EncryptTextToMemory(textToEncrypt, tdes, iv);
        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {

        }

        //Expotar Mensaje Encriptado a fichero XML
        private void button11_Click_1(object sender, EventArgs e)
        {
            string textEncrypted = BitConverter.ToString(textEncryptedTDES).Replace("-", "");

            new XDocument(
                new XElement("root",
                    new XElement("textoe", textEncrypted)
                )
            )
            .Save("C:\\Users\\Vills\\Desktop\\textoencriptado.xml");
        }

        private void button12_Click(object sender, EventArgs e)
        {
            OpenFileDialog theDialog = new OpenFileDialog();
            theDialog.Title = "Importar Texto Encriptado";
            theDialog.Filter = "XML files|*.xml";
            theDialog.InitialDirectory = @"C:\Users\Vills\Desktop";

            if (theDialog.ShowDialog() == DialogResult.OK)
            {
                pathToFileImportEncryptedText = theDialog.FileName;
            }

            if (File.Exists(pathToFileImportEncryptedText))// only executes if the file at pathtofile exists//you need to add the using System.IO reference at the top of te code to use this
            {
                XmlDocument doc = new XmlDocument();
                doc.Load(pathToFileImportEncryptedText);

                XmlNodeList elemList = doc.GetElementsByTagName("textoe");
                for (int i = 0; i < elemList.Count; i++)
                {
                    ImportEncryptedText = elemList[i].InnerText;
                }
                
            }
        }

        private void button13_Click(object sender, EventArgs e)
        {
            var tdes = TDESKeysDecryptedContainer[0].Concat(TDESKeysDecryptedContainer[1]).Concat(TDESKeysDecryptedContainer[2]).ToArray();
            var iv = TDESKeysDecryptedContainer[3];

            TDESDecrypter TDES = new TDESDecrypter();

            int Num = ImportEncryptedText.Length;
            byte[] bytes = new byte[Num / 2];
            for (var x = 0; x < Num; x += 2)
            {
                bytes[x / 2] = Convert.ToByte(ImportEncryptedText.Substring(x, 2), 16);
            }

           var a= TDES.DecryptTextFromMemory(bytes, tdes, iv);

            Console.WriteLine(a);
        }
    }
}
