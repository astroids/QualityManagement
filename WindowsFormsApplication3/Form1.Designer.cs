namespace WindowsFormsApplication3
{
    partial class Form1
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Form1));
            this.menuStrip1 = new System.Windows.Forms.MenuStrip();
            this.personeToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.listeleToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.p_grid = new System.Windows.Forms.DataGridView();
            this.personelDataSet = new WindowsFormsApplication3.PersonelDataSet();
            this.personelBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.personelTableAdapter = new WindowsFormsApplication3.PersonelDataSetTableAdapters.PersonelTableAdapter();
            this.p_Close = new System.Windows.Forms.Button();
            this.printPreviewDialog1 = new System.Windows.Forms.PrintPreviewDialog();
            this.p_Alim = new System.Windows.Forms.ToolStripMenuItem();
            this.helpProvider1 = new System.Windows.Forms.HelpProvider();
            this.p_AlimPop = new System.Windows.Forms.Panel();
            this.textBox1 = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.textBox2 = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.textBox3 = new System.Windows.Forms.TextBox();
            this.label4 = new System.Windows.Forms.Label();
            this.textBox4 = new System.Windows.Forms.TextBox();
            this.label5 = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.textBox6 = new System.Windows.Forms.TextBox();
            this.comboBox1 = new System.Windows.Forms.ComboBox();
            this.p_Alim_Close = new System.Windows.Forms.Button();
            this.label7 = new System.Windows.Forms.Label();
            this.label8 = new System.Windows.Forms.Label();
            this.textBox7 = new System.Windows.Forms.TextBox();
            this.comboBox2 = new System.Windows.Forms.ComboBox();
            this.label9 = new System.Windows.Forms.Label();
            this.comboBox3 = new System.Windows.Forms.ComboBox();
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.p_Alim_Ekle = new System.Windows.Forms.Button();
            this.personelDataSet1 = new WindowsFormsApplication3.PersonelDataSet1();
            this.sirketBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.sirketTableAdapter = new WindowsFormsApplication3.PersonelDataSet1TableAdapters.SirketTableAdapter();
            this.menuStrip1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.p_grid)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.personelDataSet)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.personelBindingSource)).BeginInit();
            this.p_AlimPop.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.personelDataSet1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.sirketBindingSource)).BeginInit();
            this.SuspendLayout();
            // 
            // menuStrip1
            // 
            this.menuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.personeToolStripMenuItem});
            this.menuStrip1.Location = new System.Drawing.Point(0, 0);
            this.menuStrip1.Name = "menuStrip1";
            this.menuStrip1.Size = new System.Drawing.Size(1138, 24);
            this.menuStrip1.TabIndex = 0;
            this.menuStrip1.Text = "menuStrip1";
            // 
            // personeToolStripMenuItem
            // 
            this.personeToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.listeleToolStripMenuItem,
            this.p_Alim});
            this.personeToolStripMenuItem.Name = "personeToolStripMenuItem";
            this.personeToolStripMenuItem.Size = new System.Drawing.Size(64, 20);
            this.personeToolStripMenuItem.Text = "Personel";
            // 
            // listeleToolStripMenuItem
            // 
            this.listeleToolStripMenuItem.Name = "listeleToolStripMenuItem";
            this.listeleToolStripMenuItem.Size = new System.Drawing.Size(152, 22);
            this.listeleToolStripMenuItem.Text = "Listele";
            this.listeleToolStripMenuItem.Click += new System.EventHandler(this.listeleToolStripMenuItem_Click);
            // 
            // p_grid
            // 
            this.p_grid.AllowUserToAddRows = false;
            this.p_grid.AllowUserToDeleteRows = false;
            this.p_grid.AllowUserToOrderColumns = true;
            this.p_grid.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.p_grid.Location = new System.Drawing.Point(-10, 27);
            this.p_grid.Name = "p_grid";
            this.p_grid.ReadOnly = true;
            this.p_grid.Size = new System.Drawing.Size(1114, 603);
            this.p_grid.TabIndex = 1;
            this.p_grid.Visible = false;
            // 
            // personelDataSet
            // 
            this.personelDataSet.DataSetName = "PersonelDataSet";
            this.personelDataSet.SchemaSerializationMode = System.Data.SchemaSerializationMode.IncludeSchema;
            // 
            // personelBindingSource
            // 
            this.personelBindingSource.DataMember = "Personel";
            this.personelBindingSource.DataSource = this.personelDataSet;
            // 
            // personelTableAdapter
            // 
            this.personelTableAdapter.ClearBeforeFill = true;
            // 
            // p_Close
            // 
            this.p_Close.BackColor = System.Drawing.Color.Red;
            this.p_Close.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("p_Close.BackgroundImage")));
            this.p_Close.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.p_Close.Location = new System.Drawing.Point(1078, 0);
            this.p_Close.Name = "p_Close";
            this.p_Close.Size = new System.Drawing.Size(26, 24);
            this.p_Close.TabIndex = 2;
            this.p_Close.UseVisualStyleBackColor = false;
            this.p_Close.Visible = false;
            this.p_Close.Click += new System.EventHandler(this.button1_Click);
            // 
            // printPreviewDialog1
            // 
            this.printPreviewDialog1.AutoScrollMargin = new System.Drawing.Size(0, 0);
            this.printPreviewDialog1.AutoScrollMinSize = new System.Drawing.Size(0, 0);
            this.printPreviewDialog1.ClientSize = new System.Drawing.Size(400, 300);
            this.printPreviewDialog1.Enabled = true;
            this.printPreviewDialog1.Icon = ((System.Drawing.Icon)(resources.GetObject("printPreviewDialog1.Icon")));
            this.printPreviewDialog1.Name = "printPreviewDialog1";
            this.printPreviewDialog1.Visible = false;
            // 
            // p_Alim
            // 
            this.p_Alim.Name = "p_Alim";
            this.p_Alim.Size = new System.Drawing.Size(152, 22);
            this.p_Alim.Text = "Alim";
            this.p_Alim.Click += new System.EventHandler(this.p_Alim_Click);
            // 
            // p_AlimPop
            // 
            this.p_AlimPop.BackColor = System.Drawing.Color.LightGray;
            this.p_AlimPop.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.p_AlimPop.Controls.Add(this.p_Alim_Ekle);
            this.p_AlimPop.Controls.Add(this.pictureBox1);
            this.p_AlimPop.Controls.Add(this.comboBox3);
            this.p_AlimPop.Controls.Add(this.comboBox2);
            this.p_AlimPop.Controls.Add(this.label9);
            this.p_AlimPop.Controls.Add(this.label7);
            this.p_AlimPop.Controls.Add(this.label8);
            this.p_AlimPop.Controls.Add(this.textBox7);
            this.p_AlimPop.Controls.Add(this.comboBox1);
            this.p_AlimPop.Controls.Add(this.label5);
            this.p_AlimPop.Controls.Add(this.label6);
            this.p_AlimPop.Controls.Add(this.textBox6);
            this.p_AlimPop.Controls.Add(this.label3);
            this.p_AlimPop.Controls.Add(this.textBox3);
            this.p_AlimPop.Controls.Add(this.label4);
            this.p_AlimPop.Controls.Add(this.textBox4);
            this.p_AlimPop.Controls.Add(this.label2);
            this.p_AlimPop.Controls.Add(this.textBox2);
            this.p_AlimPop.Controls.Add(this.label1);
            this.p_AlimPop.Controls.Add(this.textBox1);
            this.p_AlimPop.Location = new System.Drawing.Point(159, 110);
            this.p_AlimPop.Name = "p_AlimPop";
            this.p_AlimPop.Size = new System.Drawing.Size(654, 328);
            this.p_AlimPop.TabIndex = 3;
            this.p_AlimPop.Visible = false;
            // 
            // textBox1
            // 
            this.textBox1.Location = new System.Drawing.Point(106, 32);
            this.textBox1.Name = "textBox1";
            this.textBox1.Size = new System.Drawing.Size(223, 20);
            this.textBox1.TabIndex = 0;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(15, 35);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(75, 17);
            this.label1.TabIndex = 1;
            this.label1.Text = "Adi Soyadi";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.Location = new System.Drawing.Point(15, 72);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(88, 17);
            this.label2.TabIndex = 3;
            this.label2.Text = "TC Kimlik No";
            // 
            // textBox2
            // 
            this.textBox2.Location = new System.Drawing.Point(106, 69);
            this.textBox2.Name = "textBox2";
            this.textBox2.Size = new System.Drawing.Size(223, 20);
            this.textBox2.TabIndex = 2;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.Location = new System.Drawing.Point(15, 153);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(86, 17);
            this.label3.TabIndex = 7;
            this.label3.Text = "Telefon No2";
            // 
            // textBox3
            // 
            this.textBox3.Location = new System.Drawing.Point(106, 150);
            this.textBox3.Name = "textBox3";
            this.textBox3.Size = new System.Drawing.Size(223, 20);
            this.textBox3.TabIndex = 6;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label4.Location = new System.Drawing.Point(15, 116);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(78, 17);
            this.label4.TabIndex = 5;
            this.label4.Text = "Telefon No";
            // 
            // textBox4
            // 
            this.textBox4.Location = new System.Drawing.Point(106, 113);
            this.textBox4.Name = "textBox4";
            this.textBox4.Size = new System.Drawing.Size(223, 20);
            this.textBox4.TabIndex = 4;
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label5.Location = new System.Drawing.Point(15, 236);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(57, 17);
            this.label5.TabIndex = 11;
            this.label5.Text = "Cinsiyet";
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label6.Location = new System.Drawing.Point(15, 199);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(42, 17);
            this.label6.TabIndex = 9;
            this.label6.Text = "Email";
            // 
            // textBox6
            // 
            this.textBox6.Location = new System.Drawing.Point(106, 196);
            this.textBox6.Name = "textBox6";
            this.textBox6.Size = new System.Drawing.Size(223, 20);
            this.textBox6.TabIndex = 8;
            // 
            // comboBox1
            // 
            this.comboBox1.FormattingEnabled = true;
            this.comboBox1.Items.AddRange(new object[] {
            "Erkek",
            "Kadın"});
            this.comboBox1.Location = new System.Drawing.Point(106, 232);
            this.comboBox1.Name = "comboBox1";
            this.comboBox1.Size = new System.Drawing.Size(121, 21);
            this.comboBox1.TabIndex = 12;
            // 
            // p_Alim_Close
            // 
            this.p_Alim_Close.BackColor = System.Drawing.Color.Red;
            this.p_Alim_Close.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("p_Alim_Close.BackgroundImage")));
            this.p_Alim_Close.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.p_Alim_Close.Location = new System.Drawing.Point(783, 90);
            this.p_Alim_Close.Name = "p_Alim_Close";
            this.p_Alim_Close.Size = new System.Drawing.Size(26, 24);
            this.p_Alim_Close.TabIndex = 4;
            this.p_Alim_Close.UseVisualStyleBackColor = false;
            this.p_Alim_Close.Visible = false;
            this.p_Alim_Close.Click += new System.EventHandler(this.p_Alim_Close_Click);
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label7.Location = new System.Drawing.Point(335, 199);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(44, 17);
            this.label7.TabIndex = 16;
            this.label7.Text = "Sirket";
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label8.Location = new System.Drawing.Point(335, 153);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(78, 17);
            this.label8.TabIndex = 14;
            this.label8.Text = "Departman";
            // 
            // textBox7
            // 
            this.textBox7.Location = new System.Drawing.Point(426, 150);
            this.textBox7.Name = "textBox7";
            this.textBox7.Size = new System.Drawing.Size(193, 20);
            this.textBox7.TabIndex = 13;
            // 
            // comboBox2
            // 
            this.comboBox2.FormattingEnabled = true;
            this.comboBox2.Items.AddRange(new object[] {
            "Erkek",
            "Kadın"});
            this.comboBox2.Location = new System.Drawing.Point(426, 250);
            this.comboBox2.Name = "comboBox2";
            this.comboBox2.Size = new System.Drawing.Size(121, 21);
            this.comboBox2.TabIndex = 18;
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label9.Location = new System.Drawing.Point(335, 254);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(40, 17);
            this.label9.TabIndex = 17;
            this.label9.Text = "Aday";
            // 
            // comboBox3
            // 
            this.comboBox3.DataBindings.Add(new System.Windows.Forms.Binding("SelectedValue", this.sirketBindingSource, "s_KAdi", true));
            this.comboBox3.DataSource = this.sirketBindingSource;
            this.comboBox3.DisplayMember = "s_KAdi";
            this.comboBox3.FormattingEnabled = true;
            this.comboBox3.Location = new System.Drawing.Point(426, 195);
            this.comboBox3.Name = "comboBox3";
            this.comboBox3.Size = new System.Drawing.Size(121, 21);
            this.comboBox3.TabIndex = 19;
            this.comboBox3.ValueMember = "s_KAdi";
            // 
            // pictureBox1
            // 
            this.pictureBox1.Location = new System.Drawing.Point(463, 32);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(100, 101);
            this.pictureBox1.TabIndex = 20;
            this.pictureBox1.TabStop = false;
            // 
            // p_Alim_Ekle
            // 
            this.p_Alim_Ekle.Location = new System.Drawing.Point(558, 290);
            this.p_Alim_Ekle.Name = "p_Alim_Ekle";
            this.p_Alim_Ekle.Size = new System.Drawing.Size(75, 23);
            this.p_Alim_Ekle.TabIndex = 21;
            this.p_Alim_Ekle.Text = "button1";
            this.p_Alim_Ekle.UseVisualStyleBackColor = true;
            this.p_Alim_Ekle.Click += new System.EventHandler(this.p_Alim_Ekle_Click);
            // 
            // personelDataSet1
            // 
            this.personelDataSet1.DataSetName = "PersonelDataSet1";
            this.personelDataSet1.SchemaSerializationMode = System.Data.SchemaSerializationMode.IncludeSchema;
            // 
            // sirketBindingSource
            // 
            this.sirketBindingSource.DataMember = "Sirket";
            this.sirketBindingSource.DataSource = this.personelDataSet1;
            // 
            // sirketTableAdapter
            // 
            this.sirketTableAdapter.ClearBeforeFill = true;
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1138, 665);
            this.Controls.Add(this.p_Alim_Close);
            this.Controls.Add(this.p_AlimPop);
            this.Controls.Add(this.p_Close);
            this.Controls.Add(this.p_grid);
            this.Controls.Add(this.menuStrip1);
            this.MainMenuStrip = this.menuStrip1;
            this.Name = "Form1";
            this.Text = "Form1";
            this.Load += new System.EventHandler(this.Form1_Load);
            this.menuStrip1.ResumeLayout(false);
            this.menuStrip1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.p_grid)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.personelDataSet)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.personelBindingSource)).EndInit();
            this.p_AlimPop.ResumeLayout(false);
            this.p_AlimPop.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.personelDataSet1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.sirketBindingSource)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.MenuStrip menuStrip1;
        private System.Windows.Forms.ToolStripMenuItem personeToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem listeleToolStripMenuItem;
        private System.Windows.Forms.DataGridView p_grid;
        private PersonelDataSet personelDataSet;
        private System.Windows.Forms.BindingSource personelBindingSource;
        private PersonelDataSetTableAdapters.PersonelTableAdapter personelTableAdapter;
        private System.Windows.Forms.Button p_Close;
        private System.Windows.Forms.PrintPreviewDialog printPreviewDialog1;
        private System.Windows.Forms.ToolStripMenuItem p_Alim;
        private System.Windows.Forms.HelpProvider helpProvider1;
        private System.Windows.Forms.Panel p_AlimPop;
        private System.Windows.Forms.ComboBox comboBox1;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.TextBox textBox6;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.TextBox textBox3;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.TextBox textBox4;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox textBox2;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox textBox1;
        private System.Windows.Forms.Button p_Alim_Close;
        private System.Windows.Forms.ComboBox comboBox3;
        private System.Windows.Forms.ComboBox comboBox2;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.TextBox textBox7;
        private System.Windows.Forms.Button p_Alim_Ekle;
        private System.Windows.Forms.PictureBox pictureBox1;
        private PersonelDataSet1 personelDataSet1;
        private System.Windows.Forms.BindingSource sirketBindingSource;
        private PersonelDataSet1TableAdapters.SirketTableAdapter sirketTableAdapter;
    }
}

