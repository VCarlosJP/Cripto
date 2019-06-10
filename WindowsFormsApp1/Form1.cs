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

namespace WindowsFormsApp1
{
    public partial class Form1 : Form
    {
        string ClavePublica;

        public Form1()
        {
            InitializeComponent();
            
        }

        private void button1_Click(object sender, EventArgs e)
        {
            var culero = new RSAKey();
            var Items = culero.RSAKeys();
            label2.Text = Items.Item1;
            label5.Text = Items.Item1;

            label4.Text = Items.Item2;
            label6.Text = Items.Item2;
        }

        private void button2_Click(object sender, EventArgs e)
        {
            var culero = new RSAKey();
            var Items = culero.RSAKeys();

            ClavePublica = Items.Item1;
            label2.Text = Items.Item1;
            label5.Text = Items.Item1;

            label4.Text = Items.Item2;
            label6.Text = Items.Item2;
        }

        private void button3_Click(object sender, EventArgs e)
        {
            using (XmlWriter writer = XmlWriter.Create("C:\\Users\\Vills\\Desktop\\cp_esclavo.xml"))
            {
                writer.WriteElementString("clavepublica", ClavePublica);
                writer.Flush();
            }
        }

        string pathToFile = "";
        string publicKey = "";

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
                    publicKey = elemList[i].InnerXml;
                }

                label9.Text = publicKey;


            }
        }

        private void button5_Click(object sender, EventArgs e)
        {
            TDESKeys TripleDesKeys = new TDESKeys();
            TripleDesKeys.TDES_Keys();
        }

    }
}
