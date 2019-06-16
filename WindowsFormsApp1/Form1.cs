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
        //Llaves Publicas y Privadas para poder trabajar internamente
        RSAParameters ClavePublica;
        RSAParameters ClavePrivada;
        
        //Esta variable contendra la llave publica en formato string xml
        string ClavePublicaString;

        //Almacena la llave publica cuando esta es importada de un fichero XML
        string publicKey = "";

        //Variable que convierte la variable global 'publickey' a RSAParameters
        RSACryptoServiceProvider ClavaPublicaParams = new RSACryptoServiceProvider();

        //Lista que almacenara las 3 llaves TDES 
        List<string> TDESKeys;

        //Almacena las TDES Keys y el valor IV provenientes del fichero XML
        List<byte[]> TDESKeysEncryptedImported;

        List<byte[]> TDESKeysDecryptedContainer = new List<byte[]>();

        string pathToFile = "";
        
        
        //Variable que almacena el texto encriptado obtenido del fichero xml
        string ImportEncryptedText = "";

        List<byte[]> EncryptedTDESKeys;

        List<string> EncryptedTDESKeysHex;

        //Variable que almacenara el Texto Encriptado por las claves TDES desencriptadas
        byte[] textEncryptedTDES;


        public Form1()
        {
            InitializeComponent();

            //Inicilización de Textos para TextBox

            //InputsMaestro
            valorClavePublica.Text = "<Valor de la Clave>";
            valorClavePrivada.Text = "<Valor de la Clave>";
            importarClavePublicaEsclavo.Text = "<Valor de la Clave Pública Esclavo>";
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


        //******************************************
        //Funcionalidad de Botones Maestro y Esclavo
        //******************************************


        //Generar Claves RSA (VistaMaestro)
        private void button1_Click(object sender, EventArgs e)
        {
            generarLlavesRSA();
        }

        //Generar Claves RSA (VistaEsclavo)
        private void button2_Click(object sender, EventArgs e)
        {
            generarLlavesRSA();
        }

        //Metodo para generar XML con llave RSA Publica
        private void button3_Click(object sender, EventArgs e)
        {
            var type = "clavepublica";
            string fileName = "cp_esclavo.xml";

            exportarFicheroXML(type, ClavePublicaString, fileName);

        }

        //Metodo para importar Llave RSA Publica desde fichero XML
        private void button4_Click(object sender, EventArgs e)
        {
            string type = "clavepublica";
            publicKey = importarFicheroXML(type);

            ClavaPublicaParams.FromXmlString(publicKey);
            importarClavePublicaEsclavo.Text = publicKey;
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

        //Expotar Mensaje Encriptado a fichero XML
        private void button11_Click_1(object sender, EventArgs e)
        {
            string textEncrypted = BitConverter.ToString(textEncryptedTDES).Replace("-", "");
            string type = "textoe";
            string fileName = "textoencriptado.xml";

            exportarFicheroXML(type, textEncrypted, fileName);
        }

        //Importar Texto encriptado desde XML
        private void button12_Click(object sender, EventArgs e)
        {
            string type = "textoe";
            ImportEncryptedText = importarFicheroXML(type);
            textoEncriptadoXML.Text = ImportEncryptedText;
        }

        //Desencriptar Texto
        private void button13_Click(object sender, EventArgs e)
        {
            var tdes = TDESKeysDecryptedContainer[0].Concat(TDESKeysDecryptedContainer[1]).Concat(TDESKeysDecryptedContainer[2]).ToArray();
            var iv = TDESKeysDecryptedContainer[3];

            TDESDecrypter TDES = new TDESDecrypter();

            var TextoDesenciptado= TDES.DecryptTextFromMemory(convertir(ImportEncryptedText), tdes, iv);
            textoDesencriptado.Text = TextoDesenciptado;
        }





        //***********************************************************
        //METODOS que se repiten
        //***********************************************************


        //Generación de Llaves RSA Maestro/Esclavo
        public void generarLlavesRSA() {

            var llaves = new RSAKey();
            var Items = llaves.get();
            ClavePublica = Items.ExportParameters(false);
            ClavePrivada = Items.ExportParameters(true);
            ClavePublicaString = Items.ToXmlString(false);

            valorClavePublica.Text = ClavePublicaString;
            valorClavePrivada.Text = Items.ToXmlString(true);
            valorClavePublicaEsclavo.Text = ClavePublicaString;
            valorClavePrivadaEsclavo.Text = Items.ToXmlString(true);
        }

        //Metodo para importar Fichero XML

        public string importarFicheroXML(string type) {

            OpenFileDialog theDialog = new OpenFileDialog();
            theDialog.Title = "Importal Fichero XML";
            theDialog.Filter = "XML files|*.xml";

            string Container = "";


            if (theDialog.ShowDialog() == DialogResult.OK)
            {
                pathToFile = theDialog.FileName;
            }

            if (File.Exists(pathToFile))
            {
                XmlDocument doc = new XmlDocument();
                doc.Load(pathToFile);
                XmlNodeList elemList = doc.GetElementsByTagName(type);
                for (int i = 0; i < elemList.Count; i++)
                {
                    Container = elemList[i].InnerText;
                }
            }
            return Container;
        }

        //Exportar a Fichero XML
        public void exportarFicheroXML(string type, string textToSave, string fileName) {
            SaveFileDialog saveFileDialog1 = new SaveFileDialog();
            saveFileDialog1.Filter = "XML files|*.xml";
            saveFileDialog1.Title = "Exportar Texto Encriptado";
            saveFileDialog1.FileName = fileName;
            saveFileDialog1.ShowDialog();

            new XDocument(
                new XElement("root",
                    new XElement(type, textToSave)
                )
            )
            .Save(Path.GetFullPath(saveFileDialog1.FileName));
        }


        //Encargado de convertir cadenas Hexadecimales a Bytes
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




}
}
