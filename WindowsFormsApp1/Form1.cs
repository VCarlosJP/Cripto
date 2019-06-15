using System;
using System.Collections.Generic;
using System.Linq;
using System.Windows.Forms;
using System.Security.Cryptography;
using System.Xml;
using System.IO;
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

        List<byte[]> TDESKeysDecryptedContainer = new List<byte[]>();

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
            //InputsMaestro
            valorClavePublica.Text = "<Valor de la Clave>";
            valorClavePrivada.Text = "<Valor de la Clave>";
            importarClavePublicaEsclavo.Text = "<Valor de la Clave Publica Esclavo>";
            claveTDES1.Text = "<Valor de la Clave TDES>";
            claveTDES2.Text = "<Valor de la Clave TDES>";
            claveTDES3.Text = "<Valor de la Clave TDES>";
            claveTDESEncriptada1.Text = "<Valor de la Clave TDES Encriptada>";
            claveTDESEncriptada2.Text = "<Valor de la Clave TDES Encriptada>";
            claveTDESEncriptada3.Text = "<Valor de la Clave TDES Encriptada>";
            textoEncriptadoXML.Text = "<Texto Encriptado del Fichero XML>";
            textoDesencriptado.Text = "<Texto Desencriptado>";
            //Inputs Esclavo
            valorClavePublicaEsclavo.Text = "<Valor de la Clave>";
            valorClavePrivadaEsclavo.Text = "<Valor de la Clave>";
            claveTDESEncriptadaEsclavo1.Text = "<Valor de la Clave TDES Encriptada>";
            claveTDESEncriptadaEsclavo2.Text = "<Valor de la Clave TDES Encriptada>";
            claveTDESEncriptadaEsclavo3.Text = "<Valor de la Clave TDES Encriptada>";
            claveTDESDesencriptada1.Text = "<Valor de la Clave TDES Desencriptada>";
            claveTDESDesencriptada2.Text = "<Valor de la Clave TDES Desencriptada>";
            claveTDESDesencriptada3.Text = "<Valor de la Clave TDES Desencriptada>";
            resultadoTextoEncriptado.Text = "<Resultado de Texto Encriptado>";
        }

        //Generar Claves RSA (VistaMaestro)
        private void button1_Click(object sender, EventArgs e)
        {
            var culero = new RSAKey();
            var Items = culero.get();
            ClavePublica = Items.ExportParameters(false);
            ClavePrivada = Items.ExportParameters(true);
            ClavePublicaString = Items.ToXmlString(false);
            valorClavePublica.Text = ClavePublicaString;
            valorClavePrivada.Text = Items.ToXmlString(true);
            valorClavePublicaEsclavo.Text = ClavePublicaString;
            valorClavePrivadaEsclavo.Text = Items.ToXmlString(true);
        }

        //Generar Claves RSA (VistaEsclavo)
        private void button2_Click(object sender, EventArgs e)
        {
            var culero = new RSAKey();
            var Items = culero.get();
            ClavePublica = Items.ExportParameters(false);
            ClavePrivada = Items.ExportParameters(true);
            ClavePublicaString = Items.ToXmlString(false);
            valorClavePublica.Text = ClavePublicaString;
            valorClavePrivada.Text = Items.ToXmlString(true);
            valorClavePublicaEsclavo.Text = ClavePublicaString;
            valorClavePrivadaEsclavo.Text = Items.ToXmlString(true);
        }

        //Metodo para generar XML con llave RSA Publica
        private void button3_Click(object sender, EventArgs e)
        {
            SaveFileDialog saveFileDialog1 = new SaveFileDialog();
            saveFileDialog1.Filter = "XML files|*.xml";
            saveFileDialog1.Title = "Exportar XML con Claves TDES Encriptadas";
            saveFileDialog1.FileName = "cp_esclavo.xml";
            saveFileDialog1.ShowDialog();

            using (XmlWriter writer = XmlWriter.Create(Path.GetFullPath(saveFileDialog1.FileName)))
            {
                writer.WriteElementString("clavepublica", ClavePublicaString);
                writer.Flush();
            }
        }

        //Metodo para importar clave Publica Esclavo de XML
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

                importarClavePublicaEsclavo.Text = publicKey;
            }
        }

        //Metodo que genera llaves TDES
        private void button5_Click(object sender, EventArgs e)
        {
            TDESKeys TripleDesKeys = new TDESKeys();
            TDESKeys = TripleDesKeys.TDES_Keys();
            IList<byte[]> test = new List<byte[]>();
            for (var i = 0; i < 4; i++)
            {
                test.Add(convertir(TDESKeys[i]));
                TDESKeysDecryptedContainer.Add(test[i]);
            }

            claveTDES1.Text = TDESKeys[0];
            claveTDES2.Text = TDESKeys[1];
            claveTDES3.Text = TDESKeys[2];

        }

        public byte[] convertir(string texto)
        {
            int Num = texto.Length;
            byte[] bytes = new byte[Num / 2];
            for (var x = 0; x < Num; x += 2)
            {
                bytes[x / 2] = Convert.ToByte(texto.Substring(x, 2), 16);
            }
            return bytes;
        }

        //Metodo para encriptar las 3 llaves TDES con RSA y llave esclavo publica
        private void button6_Click(object sender, EventArgs e)
        {
            EncryptTDESKey TDESKeysEncrypted = new EncryptTDESKey();
            EncryptedTDESKeys = TDESKeysEncrypted.RSAEncrypt(TDESKeys, ClavaPublicaParams.ExportParameters(false), true);

            EncryptedTDESKeysHex = new List<string>();
            
            for (var i = 0; i < 4; i++)
            {
                EncryptedTDESKeysHex.Add(BitConverter.ToString(EncryptedTDESKeys[i]).Replace("-",""));
            }

            claveTDESEncriptada1.Text = EncryptedTDESKeysHex[0];
            claveTDESEncriptada2.Text = EncryptedTDESKeysHex[1];
            claveTDESEncriptada3.Text = EncryptedTDESKeysHex[2];


        }


        //Exportar un XML con las claves TDES encriptadas
        private void button7_Click(object sender, EventArgs e)
        {
            SaveFileDialog saveFileDialog1 = new SaveFileDialog();
            saveFileDialog1.Filter = "XML files|*.xml";
            saveFileDialog1.Title = "Exportar XML con Claves TDES Encriptadas";
            saveFileDialog1.FileName = "tdesencriptado.xml";
            saveFileDialog1.ShowDialog();

            new XDocument(
                new XElement("root",
                    new XElement("tdes1", EncryptedTDESKeysHex[0]),
                    new XElement("tdes2", EncryptedTDESKeysHex[1]),
                    new XElement("tdes3", EncryptedTDESKeysHex[2]),
                    new XElement("iv", EncryptedTDESKeysHex[3])
                )
            ).Save(Path.GetFullPath(saveFileDialog1.FileName));
            //.Save("C:\\Users\\Vills\\Desktop\\tdesencriptado.xml");
        }


        //Metodo para recibir las TDES Keys Encriptadas de un fichero XML
        private void button8_Click(object sender, EventArgs e)
        {
            ImportTDESKeysXML TDESKeysEncrypted = new ImportTDESKeysXML();
            TDESKeysEncryptedImported = TDESKeysEncrypted.importTDESKeys();

            claveTDESEncriptadaEsclavo1.Text = BitConverter.ToString(TDESKeysEncryptedImported[0]).Replace("-", "");
            claveTDESEncriptadaEsclavo2.Text = BitConverter.ToString(TDESKeysEncryptedImported[1]).Replace("-", "");
            claveTDESEncriptadaEsclavo3.Text = BitConverter.ToString(TDESKeysEncryptedImported[2]).Replace("-", "");

        }

        //Metodo para Desencriptar Claves TDES
        private void button9_Click(object sender, EventArgs e)
        {
            DecryptTDESKey TDESKeysDecrypted = new DecryptTDESKey();
            TDESKeysDecryptedContainer = TDESKeysDecrypted.RSADecrypt(TDESKeysEncryptedImported, ClavePrivada, true);

            var probar = new List<string>();

            for (var i = 0; i < 4; i++)
            {
                probar.Add(BitConverter.ToString(TDESKeysDecryptedContainer[i]).Replace("-", ""));
            }

            claveTDESDesencriptada1.Text = probar[0];
            claveTDESDesencriptada2.Text = probar[1];
            claveTDESDesencriptada3.Text = probar[2];


        }

        //Encriptar el texto introducido
        private void button10_Click(object sender, EventArgs e)
        {
            string textToEncrypt = textBox1.Text;
            var tdes = TDESKeysDecryptedContainer[0].Concat(TDESKeysDecryptedContainer[1]).Concat(TDESKeysDecryptedContainer[2]).ToArray();
            var iv = TDESKeysDecryptedContainer[3];

            TDESEncrypter TDES = new TDESEncrypter();
            textEncryptedTDES = TDES.EncryptTextToMemory(textToEncrypt, tdes, iv);

            resultadoTextoEncriptado.Text = BitConverter.ToString(textEncryptedTDES).Replace("-", "");

        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {

        }

        //Expotar Mensaje Encriptado a fichero XML
        private void button11_Click_1(object sender, EventArgs e)
        {
            string textEncrypted = BitConverter.ToString(textEncryptedTDES).Replace("-", "");

            SaveFileDialog saveFileDialog1 = new SaveFileDialog();
            saveFileDialog1.Filter = "XML files|*.xml";
            saveFileDialog1.Title = "Exportar Texto Encriptado";
            saveFileDialog1.FileName = "textoencriptado.xml";
            saveFileDialog1.ShowDialog();

            new XDocument(
                new XElement("root",
                    new XElement("textoe", textEncrypted)
                )
            )
            .Save(Path.GetFullPath(saveFileDialog1.FileName));


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

            textoEncriptadoXML.Text = ImportEncryptedText;
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

            textoDesencriptado.Text = a;


        }

    }
}
