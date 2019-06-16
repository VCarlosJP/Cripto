using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Xml;

namespace WindowsFormsApp1
{
    class ImportTDESKeysXML
    {
        public List<byte[]> importTDESKeys()
        {

            string pathToFileTDES = "";
            var array = new List<string>();
            var FinalByteArray = new List<byte[]>();

            OpenFileDialog theDialog = new OpenFileDialog();
            theDialog.Title = "Importar Claves TDES";
            theDialog.Filter = "XML files|*.xml";
            theDialog.InitialDirectory = @"C:\Users\Vills\Desktop";

            if (theDialog.ShowDialog() == DialogResult.OK)
            {
                pathToFileTDES = theDialog.FileName;
            }

            if (File.Exists(pathToFileTDES))// only executes if the file at pathtofile exists//you need to add the using System.IO reference at the top of te code to use this
            {
                XmlDocument doc = new XmlDocument();
                doc.Load(pathToFileTDES);
                XmlNodeList tdes1 = doc.GetElementsByTagName("tdes1");
                XmlNodeList tdes2 = doc.GetElementsByTagName("tdes2");
                XmlNodeList tdes3 = doc.GetElementsByTagName("tdes3");
                XmlNodeList IV = doc.GetElementsByTagName("iv");

                array.Add(tdes1[0].InnerText);
                array.Add(tdes2[0].InnerText);
                array.Add(tdes3[0].InnerText);
                array.Add(IV[0].InnerText);

                Form1 HexToBytes = new Form1();

                for (var i = 0; i < 4; i++)
                {
                    var bytes = HexToBytes.convertir(array[i]);
                    FinalByteArray.Add(bytes);
                }

            }
            return FinalByteArray;
        }
    }
}
