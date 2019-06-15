namespace WindowsFormsApp1
{
    partial class Form1
    {
        /// <summary>
        /// Variable del diseñador necesaria.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Limpiar los recursos que se estén usando.
        /// </summary>
        /// <param name="disposing">true si los recursos administrados se deben desechar; false en caso contrario.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Código generado por el Diseñador de Windows Forms

        /// <summary>
        /// Método necesario para admitir el Diseñador. No se puede modificar
        /// el contenido de este método con el editor de código.
        /// </summary>
        private void InitializeComponent()
        {
            this.button1 = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.tabControl1 = new System.Windows.Forms.TabControl();
            this.tabPage1 = new System.Windows.Forms.TabPage();
            this.claveTDES3 = new System.Windows.Forms.TextBox();
            this.claveTDES2 = new System.Windows.Forms.TextBox();
            this.claveTDES1 = new System.Windows.Forms.TextBox();
            this.importarClavePublicaEsclavo = new System.Windows.Forms.TextBox();
            this.valorClavePrivada = new System.Windows.Forms.TextBox();
            this.valorClavePublica = new System.Windows.Forms.TextBox();
            this.button13 = new System.Windows.Forms.Button();
            this.button12 = new System.Windows.Forms.Button();
            this.button7 = new System.Windows.Forms.Button();
            this.button6 = new System.Windows.Forms.Button();
            this.button5 = new System.Windows.Forms.Button();
            this.button4 = new System.Windows.Forms.Button();
            this.tabPage2 = new System.Windows.Forms.TabPage();
            this.valorClavePrivadaEsclavo = new System.Windows.Forms.TextBox();
            this.valorClavePublicaEsclavo = new System.Windows.Forms.TextBox();
            this.button11 = new System.Windows.Forms.Button();
            this.textBox1 = new System.Windows.Forms.TextBox();
            this.label12 = new System.Windows.Forms.Label();
            this.button10 = new System.Windows.Forms.Button();
            this.button9 = new System.Windows.Forms.Button();
            this.button8 = new System.Windows.Forms.Button();
            this.button3 = new System.Windows.Forms.Button();
            this.button2 = new System.Windows.Forms.Button();
            this.label7 = new System.Windows.Forms.Label();
            this.label8 = new System.Windows.Forms.Label();
            this.claveTDESEncriptada1 = new System.Windows.Forms.TextBox();
            this.claveTDESEncriptada2 = new System.Windows.Forms.TextBox();
            this.claveTDESEncriptada3 = new System.Windows.Forms.TextBox();
            this.textoEncriptadoXML = new System.Windows.Forms.TextBox();
            this.textoDesencriptado = new System.Windows.Forms.TextBox();
            this.claveTDESEncriptadaEsclavo1 = new System.Windows.Forms.TextBox();
            this.claveTDESEncriptadaEsclavo2 = new System.Windows.Forms.TextBox();
            this.claveTDESEncriptadaEsclavo3 = new System.Windows.Forms.TextBox();
            this.claveTDESDesencriptada1 = new System.Windows.Forms.TextBox();
            this.claveTDESDesencriptada2 = new System.Windows.Forms.TextBox();
            this.claveTDESDesencriptada3 = new System.Windows.Forms.TextBox();
            this.resultadoTextoEncriptado = new System.Windows.Forms.TextBox();
            this.tabControl1.SuspendLayout();
            this.tabPage1.SuspendLayout();
            this.tabPage2.SuspendLayout();
            this.SuspendLayout();
            // 
            // button1
            // 
            this.button1.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.button1.Location = new System.Drawing.Point(6, 6);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(164, 52);
            this.button1.TabIndex = 0;
            this.button1.Text = "Generar Claves RSA ";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(176, 7);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(104, 16);
            this.label1.TabIndex = 1;
            this.label1.Text = "Clave Publica";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.Location = new System.Drawing.Point(176, 40);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(106, 16);
            this.label3.TabIndex = 3;
            this.label3.Text = "Clave Privada";
            // 
            // tabControl1
            // 
            this.tabControl1.Controls.Add(this.tabPage1);
            this.tabControl1.Controls.Add(this.tabPage2);
            this.tabControl1.Location = new System.Drawing.Point(12, 12);
            this.tabControl1.Name = "tabControl1";
            this.tabControl1.SelectedIndex = 0;
            this.tabControl1.Size = new System.Drawing.Size(721, 507);
            this.tabControl1.TabIndex = 5;
            // 
            // tabPage1
            // 
            this.tabPage1.BackColor = System.Drawing.SystemColors.GradientActiveCaption;
            this.tabPage1.Controls.Add(this.textoDesencriptado);
            this.tabPage1.Controls.Add(this.textoEncriptadoXML);
            this.tabPage1.Controls.Add(this.claveTDESEncriptada3);
            this.tabPage1.Controls.Add(this.claveTDESEncriptada2);
            this.tabPage1.Controls.Add(this.claveTDESEncriptada1);
            this.tabPage1.Controls.Add(this.claveTDES3);
            this.tabPage1.Controls.Add(this.claveTDES2);
            this.tabPage1.Controls.Add(this.claveTDES1);
            this.tabPage1.Controls.Add(this.importarClavePublicaEsclavo);
            this.tabPage1.Controls.Add(this.valorClavePrivada);
            this.tabPage1.Controls.Add(this.valorClavePublica);
            this.tabPage1.Controls.Add(this.button13);
            this.tabPage1.Controls.Add(this.button12);
            this.tabPage1.Controls.Add(this.button7);
            this.tabPage1.Controls.Add(this.button6);
            this.tabPage1.Controls.Add(this.button5);
            this.tabPage1.Controls.Add(this.button4);
            this.tabPage1.Controls.Add(this.button1);
            this.tabPage1.Controls.Add(this.label3);
            this.tabPage1.Controls.Add(this.label1);
            this.tabPage1.Location = new System.Drawing.Point(4, 22);
            this.tabPage1.Name = "tabPage1";
            this.tabPage1.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage1.Size = new System.Drawing.Size(713, 481);
            this.tabPage1.TabIndex = 0;
            this.tabPage1.Text = "Maestro";
            // 
            // claveTDES3
            // 
            this.claveTDES3.Location = new System.Drawing.Point(158, 209);
            this.claveTDES3.Name = "claveTDES3";
            this.claveTDES3.Size = new System.Drawing.Size(364, 20);
            this.claveTDES3.TabIndex = 19;
            // 
            // claveTDES2
            // 
            this.claveTDES2.Location = new System.Drawing.Point(158, 183);
            this.claveTDES2.Name = "claveTDES2";
            this.claveTDES2.Size = new System.Drawing.Size(364, 20);
            this.claveTDES2.TabIndex = 18;
            // 
            // claveTDES1
            // 
            this.claveTDES1.Location = new System.Drawing.Point(158, 157);
            this.claveTDES1.Name = "claveTDES1";
            this.claveTDES1.Size = new System.Drawing.Size(364, 20);
            this.claveTDES1.TabIndex = 17;
            // 
            // importarClavePublicaEsclavo
            // 
            this.importarClavePublicaEsclavo.Location = new System.Drawing.Point(312, 97);
            this.importarClavePublicaEsclavo.Name = "importarClavePublicaEsclavo";
            this.importarClavePublicaEsclavo.Size = new System.Drawing.Size(395, 20);
            this.importarClavePublicaEsclavo.TabIndex = 16;
            // 
            // valorClavePrivada
            // 
            this.valorClavePrivada.Location = new System.Drawing.Point(288, 39);
            this.valorClavePrivada.Name = "valorClavePrivada";
            this.valorClavePrivada.Size = new System.Drawing.Size(419, 20);
            this.valorClavePrivada.TabIndex = 15;
            // 
            // valorClavePublica
            // 
            this.valorClavePublica.Location = new System.Drawing.Point(289, 9);
            this.valorClavePublica.Name = "valorClavePublica";
            this.valorClavePublica.Size = new System.Drawing.Size(418, 20);
            this.valorClavePublica.TabIndex = 14;
            // 
            // button13
            // 
            this.button13.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.button13.Location = new System.Drawing.Point(145, 389);
            this.button13.Name = "button13";
            this.button13.Size = new System.Drawing.Size(416, 46);
            this.button13.TabIndex = 13;
            this.button13.Text = "Desencriptar texto con TDES y clave TDES creada";
            this.button13.UseVisualStyleBackColor = true;
            this.button13.Click += new System.EventHandler(this.button13_Click);
            // 
            // button12
            // 
            this.button12.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.button12.Location = new System.Drawing.Point(8, 337);
            this.button12.Name = "button12";
            this.button12.Size = new System.Drawing.Size(225, 46);
            this.button12.TabIndex = 12;
            this.button12.Text = "Importar mensaje de xml";
            this.button12.UseVisualStyleBackColor = true;
            this.button12.Click += new System.EventHandler(this.button12_Click);
            // 
            // button7
            // 
            this.button7.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.button7.Location = new System.Drawing.Point(528, 209);
            this.button7.Name = "button7";
            this.button7.Size = new System.Drawing.Size(179, 72);
            this.button7.TabIndex = 11;
            this.button7.Text = "Exportar xml TDES encriptada\r\n";
            this.button7.UseVisualStyleBackColor = true;
            this.button7.Click += new System.EventHandler(this.button7_Click);
            // 
            // button6
            // 
            this.button6.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.button6.Location = new System.Drawing.Point(8, 246);
            this.button6.Name = "button6";
            this.button6.Size = new System.Drawing.Size(144, 72);
            this.button6.TabIndex = 9;
            this.button6.Text = "Encriptar clave TDES con RSA y clave pública esclavo\r\n";
            this.button6.UseVisualStyleBackColor = true;
            this.button6.Click += new System.EventHandler(this.button6_Click);
            // 
            // button5
            // 
            this.button5.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.button5.Location = new System.Drawing.Point(7, 157);
            this.button5.Name = "button5";
            this.button5.Size = new System.Drawing.Size(145, 72);
            this.button5.TabIndex = 7;
            this.button5.Text = "Generar Clave TDES";
            this.button5.UseVisualStyleBackColor = true;
            this.button5.Click += new System.EventHandler(this.button5_Click);
            // 
            // button4
            // 
            this.button4.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.button4.Location = new System.Drawing.Point(6, 83);
            this.button4.Name = "button4";
            this.button4.Size = new System.Drawing.Size(300, 46);
            this.button4.TabIndex = 5;
            this.button4.Text = "Importar clave pública RSA Esclavo\r\n";
            this.button4.UseVisualStyleBackColor = true;
            this.button4.Click += new System.EventHandler(this.button4_Click);
            // 
            // tabPage2
            // 
            this.tabPage2.BackColor = System.Drawing.SystemColors.AppWorkspace;
            this.tabPage2.Controls.Add(this.resultadoTextoEncriptado);
            this.tabPage2.Controls.Add(this.claveTDESDesencriptada3);
            this.tabPage2.Controls.Add(this.claveTDESDesencriptada2);
            this.tabPage2.Controls.Add(this.claveTDESDesencriptada1);
            this.tabPage2.Controls.Add(this.claveTDESEncriptadaEsclavo3);
            this.tabPage2.Controls.Add(this.claveTDESEncriptadaEsclavo2);
            this.tabPage2.Controls.Add(this.claveTDESEncriptadaEsclavo1);
            this.tabPage2.Controls.Add(this.valorClavePrivadaEsclavo);
            this.tabPage2.Controls.Add(this.valorClavePublicaEsclavo);
            this.tabPage2.Controls.Add(this.button11);
            this.tabPage2.Controls.Add(this.textBox1);
            this.tabPage2.Controls.Add(this.label12);
            this.tabPage2.Controls.Add(this.button10);
            this.tabPage2.Controls.Add(this.button9);
            this.tabPage2.Controls.Add(this.button8);
            this.tabPage2.Controls.Add(this.button3);
            this.tabPage2.Controls.Add(this.button2);
            this.tabPage2.Controls.Add(this.label7);
            this.tabPage2.Controls.Add(this.label8);
            this.tabPage2.Location = new System.Drawing.Point(4, 22);
            this.tabPage2.Name = "tabPage2";
            this.tabPage2.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage2.Size = new System.Drawing.Size(713, 481);
            this.tabPage2.TabIndex = 1;
            this.tabPage2.Text = "Esclavo";
            // 
            // valorClavePrivadaEsclavo
            // 
            this.valorClavePrivadaEsclavo.Location = new System.Drawing.Point(289, 42);
            this.valorClavePrivadaEsclavo.Name = "valorClavePrivadaEsclavo";
            this.valorClavePrivadaEsclavo.Size = new System.Drawing.Size(289, 20);
            this.valorClavePrivadaEsclavo.TabIndex = 18;
            // 
            // valorClavePublicaEsclavo
            // 
            this.valorClavePublicaEsclavo.Location = new System.Drawing.Point(289, 8);
            this.valorClavePublicaEsclavo.Name = "valorClavePublicaEsclavo";
            this.valorClavePublicaEsclavo.Size = new System.Drawing.Size(289, 20);
            this.valorClavePublicaEsclavo.TabIndex = 17;
            // 
            // button11
            // 
            this.button11.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.button11.Location = new System.Drawing.Point(266, 422);
            this.button11.Name = "button11";
            this.button11.Size = new System.Drawing.Size(189, 53);
            this.button11.TabIndex = 16;
            this.button11.Text = "Exportar mensaje a xml";
            this.button11.UseVisualStyleBackColor = true;
            this.button11.Click += new System.EventHandler(this.button11_Click_1);
            // 
            // textBox1
            // 
            this.textBox1.Location = new System.Drawing.Point(278, 293);
            this.textBox1.Name = "textBox1";
            this.textBox1.Size = new System.Drawing.Size(247, 20);
            this.textBox1.TabIndex = 15;
            this.textBox1.TextChanged += new System.EventHandler(this.textBox1_TextChanged);
            // 
            // label12
            // 
            this.label12.AutoSize = true;
            this.label12.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label12.Location = new System.Drawing.Point(157, 294);
            this.label12.Name = "label12";
            this.label12.Size = new System.Drawing.Size(115, 16);
            this.label12.TabIndex = 14;
            this.label12.Text = "Introducir Texto";
            // 
            // button10
            // 
            this.button10.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.button10.Location = new System.Drawing.Point(161, 330);
            this.button10.Name = "button10";
            this.button10.Size = new System.Drawing.Size(378, 53);
            this.button10.TabIndex = 13;
            this.button10.Text = "Encriptar texto algoritmo TDES y clave TDES desencriptada";
            this.button10.UseVisualStyleBackColor = true;
            this.button10.Click += new System.EventHandler(this.button10_Click);
            // 
            // button9
            // 
            this.button9.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.button9.Location = new System.Drawing.Point(6, 194);
            this.button9.Name = "button9";
            this.button9.Size = new System.Drawing.Size(307, 72);
            this.button9.TabIndex = 12;
            this.button9.Text = "Desencriptar TDES de fichero";
            this.button9.UseVisualStyleBackColor = true;
            this.button9.Click += new System.EventHandler(this.button9_Click);
            // 
            // button8
            // 
            this.button8.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.button8.Location = new System.Drawing.Point(6, 86);
            this.button8.Name = "button8";
            this.button8.Size = new System.Drawing.Size(307, 72);
            this.button8.TabIndex = 11;
            this.button8.Text = "Importar clave TDES de fichero XML";
            this.button8.UseVisualStyleBackColor = true;
            this.button8.Click += new System.EventHandler(this.button8_Click);
            // 
            // button3
            // 
            this.button3.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.button3.Location = new System.Drawing.Point(596, 9);
            this.button3.Name = "button3";
            this.button3.Size = new System.Drawing.Size(111, 53);
            this.button3.TabIndex = 10;
            this.button3.Text = "Exportar xml clave pública";
            this.button3.UseVisualStyleBackColor = true;
            this.button3.Click += new System.EventHandler(this.button3_Click);
            // 
            // button2
            // 
            this.button2.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.button2.Location = new System.Drawing.Point(6, 6);
            this.button2.Name = "button2";
            this.button2.Size = new System.Drawing.Size(167, 53);
            this.button2.TabIndex = 5;
            this.button2.Text = "Generar Claves RSA ";
            this.button2.UseVisualStyleBackColor = true;
            this.button2.Click += new System.EventHandler(this.button2_Click);
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label7.Location = new System.Drawing.Point(179, 43);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(106, 16);
            this.label7.TabIndex = 8;
            this.label7.Text = "Clave Privada";
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label8.Location = new System.Drawing.Point(179, 9);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(104, 16);
            this.label8.TabIndex = 6;
            this.label8.Text = "Clave Publica";
            // 
            // claveTDESEncriptada1
            // 
            this.claveTDESEncriptada1.Location = new System.Drawing.Point(158, 246);
            this.claveTDESEncriptada1.Name = "claveTDESEncriptada1";
            this.claveTDESEncriptada1.Size = new System.Drawing.Size(364, 20);
            this.claveTDESEncriptada1.TabIndex = 20;
            // 
            // claveTDESEncriptada2
            // 
            this.claveTDESEncriptada2.Location = new System.Drawing.Point(158, 273);
            this.claveTDESEncriptada2.Name = "claveTDESEncriptada2";
            this.claveTDESEncriptada2.Size = new System.Drawing.Size(364, 20);
            this.claveTDESEncriptada2.TabIndex = 21;
            // 
            // claveTDESEncriptada3
            // 
            this.claveTDESEncriptada3.Location = new System.Drawing.Point(158, 299);
            this.claveTDESEncriptada3.Name = "claveTDESEncriptada3";
            this.claveTDESEncriptada3.Size = new System.Drawing.Size(364, 20);
            this.claveTDESEncriptada3.TabIndex = 22;
            // 
            // textoEncriptadoXML
            // 
            this.textoEncriptadoXML.Location = new System.Drawing.Point(239, 351);
            this.textoEncriptadoXML.Name = "textoEncriptadoXML";
            this.textoEncriptadoXML.Size = new System.Drawing.Size(364, 20);
            this.textoEncriptadoXML.TabIndex = 23;
            // 
            // textoDesencriptado
            // 
            this.textoDesencriptado.Location = new System.Drawing.Point(145, 441);
            this.textoDesencriptado.Name = "textoDesencriptado";
            this.textoDesencriptado.Size = new System.Drawing.Size(416, 20);
            this.textoDesencriptado.TabIndex = 24;
            // 
            // claveTDESEncriptadaEsclavo1
            // 
            this.claveTDESEncriptadaEsclavo1.Location = new System.Drawing.Point(319, 86);
            this.claveTDESEncriptadaEsclavo1.Name = "claveTDESEncriptadaEsclavo1";
            this.claveTDESEncriptadaEsclavo1.Size = new System.Drawing.Size(289, 20);
            this.claveTDESEncriptadaEsclavo1.TabIndex = 19;
            // 
            // claveTDESEncriptadaEsclavo2
            // 
            this.claveTDESEncriptadaEsclavo2.Location = new System.Drawing.Point(319, 112);
            this.claveTDESEncriptadaEsclavo2.Name = "claveTDESEncriptadaEsclavo2";
            this.claveTDESEncriptadaEsclavo2.Size = new System.Drawing.Size(289, 20);
            this.claveTDESEncriptadaEsclavo2.TabIndex = 20;
            // 
            // claveTDESEncriptadaEsclavo3
            // 
            this.claveTDESEncriptadaEsclavo3.Location = new System.Drawing.Point(319, 138);
            this.claveTDESEncriptadaEsclavo3.Name = "claveTDESEncriptadaEsclavo3";
            this.claveTDESEncriptadaEsclavo3.Size = new System.Drawing.Size(289, 20);
            this.claveTDESEncriptadaEsclavo3.TabIndex = 21;
            // 
            // claveTDESDesencriptada1
            // 
            this.claveTDESDesencriptada1.Location = new System.Drawing.Point(319, 194);
            this.claveTDESDesencriptada1.Name = "claveTDESDesencriptada1";
            this.claveTDESDesencriptada1.Size = new System.Drawing.Size(289, 20);
            this.claveTDESDesencriptada1.TabIndex = 22;
            // 
            // claveTDESDesencriptada2
            // 
            this.claveTDESDesencriptada2.Location = new System.Drawing.Point(319, 221);
            this.claveTDESDesencriptada2.Name = "claveTDESDesencriptada2";
            this.claveTDESDesencriptada2.Size = new System.Drawing.Size(289, 20);
            this.claveTDESDesencriptada2.TabIndex = 23;
            // 
            // claveTDESDesencriptada3
            // 
            this.claveTDESDesencriptada3.Location = new System.Drawing.Point(319, 247);
            this.claveTDESDesencriptada3.Name = "claveTDESDesencriptada3";
            this.claveTDESDesencriptada3.Size = new System.Drawing.Size(289, 20);
            this.claveTDESDesencriptada3.TabIndex = 24;
            // 
            // resultadoTextoEncriptado
            // 
            this.resultadoTextoEncriptado.Location = new System.Drawing.Point(161, 389);
            this.resultadoTextoEncriptado.Name = "resultadoTextoEncriptado";
            this.resultadoTextoEncriptado.Size = new System.Drawing.Size(378, 20);
            this.resultadoTextoEncriptado.TabIndex = 25;
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.ButtonFace;
            this.ClientSize = new System.Drawing.Size(745, 531);
            this.Controls.Add(this.tabControl1);
            this.Name = "Form1";
            this.Text = "Cripto";
            this.tabControl1.ResumeLayout(false);
            this.tabPage1.ResumeLayout(false);
            this.tabPage1.PerformLayout();
            this.tabPage2.ResumeLayout(false);
            this.tabPage2.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.TabControl tabControl1;
        private System.Windows.Forms.TabPage tabPage1;
        private System.Windows.Forms.TabPage tabPage2;
        private System.Windows.Forms.Button button2;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.Button button3;
        private System.Windows.Forms.Button button4;
        private System.Windows.Forms.Button button5;
        private System.Windows.Forms.Button button6;
        private System.Windows.Forms.Button button7;
        private System.Windows.Forms.Button button8;
        private System.Windows.Forms.Button button9;
        private System.Windows.Forms.TextBox textBox1;
        private System.Windows.Forms.Label label12;
        private System.Windows.Forms.Button button10;
        private System.Windows.Forms.Button button11;
        private System.Windows.Forms.Button button12;
        private System.Windows.Forms.Button button13;
        private System.Windows.Forms.TextBox valorClavePrivada;
        private System.Windows.Forms.TextBox valorClavePublica;
        private System.Windows.Forms.TextBox valorClavePrivadaEsclavo;
        private System.Windows.Forms.TextBox valorClavePublicaEsclavo;
        private System.Windows.Forms.TextBox importarClavePublicaEsclavo;
        private System.Windows.Forms.TextBox claveTDES3;
        private System.Windows.Forms.TextBox claveTDES2;
        private System.Windows.Forms.TextBox claveTDES1;
        private System.Windows.Forms.TextBox claveTDESEncriptada3;
        private System.Windows.Forms.TextBox claveTDESEncriptada2;
        private System.Windows.Forms.TextBox claveTDESEncriptada1;
        private System.Windows.Forms.TextBox textoDesencriptado;
        private System.Windows.Forms.TextBox textoEncriptadoXML;
        private System.Windows.Forms.TextBox claveTDESEncriptadaEsclavo3;
        private System.Windows.Forms.TextBox claveTDESEncriptadaEsclavo2;
        private System.Windows.Forms.TextBox claveTDESEncriptadaEsclavo1;
        private System.Windows.Forms.TextBox claveTDESDesencriptada3;
        private System.Windows.Forms.TextBox claveTDESDesencriptada2;
        private System.Windows.Forms.TextBox claveTDESDesencriptada1;
        private System.Windows.Forms.TextBox resultadoTextoEncriptado;
    }
}

