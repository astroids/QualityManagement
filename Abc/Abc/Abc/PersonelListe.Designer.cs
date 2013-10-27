namespace Abc
{
    partial class PersonelListe
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
            this.p_grid = new System.Windows.Forms.DataGridView();
            this.menuStrip1 = new System.Windows.Forms.MenuStrip();
            this.ekleToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.düzenleToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.silToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.ızinToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.ızinIsteToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.izindeOlanlarToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.ızinOnaylaToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.izinGeçmişiToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.izinOnayBekleyenlerToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.textBox1 = new System.Windows.Forms.TextBox();
            this.arama = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.p_grid)).BeginInit();
            this.menuStrip1.SuspendLayout();
            this.SuspendLayout();
            // 
            // p_grid
            // 
            this.p_grid.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.p_grid.Location = new System.Drawing.Point(12, 27);
            this.p_grid.MultiSelect = false;
            this.p_grid.Name = "p_grid";
            this.p_grid.ReadOnly = true;
            this.p_grid.Size = new System.Drawing.Size(723, 379);
            this.p_grid.TabIndex = 0;
            this.p_grid.CellContentClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.p_grid_CellContentClick);
            // 
            // menuStrip1
            // 
            this.menuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.ekleToolStripMenuItem,
            this.düzenleToolStripMenuItem,
            this.silToolStripMenuItem,
            this.ızinToolStripMenuItem});
            this.menuStrip1.Location = new System.Drawing.Point(0, 0);
            this.menuStrip1.Name = "menuStrip1";
            this.menuStrip1.Size = new System.Drawing.Size(747, 24);
            this.menuStrip1.TabIndex = 6;
            this.menuStrip1.Text = "menuStrip1";
            this.menuStrip1.ItemClicked += new System.Windows.Forms.ToolStripItemClickedEventHandler(this.menuStrip1_ItemClicked);
            // 
            // ekleToolStripMenuItem
            // 
            this.ekleToolStripMenuItem.Name = "ekleToolStripMenuItem";
            this.ekleToolStripMenuItem.Size = new System.Drawing.Size(40, 20);
            this.ekleToolStripMenuItem.Text = "Ekle";
            this.ekleToolStripMenuItem.Click += new System.EventHandler(this.ekleToolStripMenuItem_Click);
            // 
            // düzenleToolStripMenuItem
            // 
            this.düzenleToolStripMenuItem.Name = "düzenleToolStripMenuItem";
            this.düzenleToolStripMenuItem.Size = new System.Drawing.Size(61, 20);
            this.düzenleToolStripMenuItem.Text = "Düzenle";
            // 
            // silToolStripMenuItem
            // 
            this.silToolStripMenuItem.Name = "silToolStripMenuItem";
            this.silToolStripMenuItem.Size = new System.Drawing.Size(31, 20);
            this.silToolStripMenuItem.Text = "Sil";
            // 
            // ızinToolStripMenuItem
            // 
            this.ızinToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.ızinIsteToolStripMenuItem,
            this.izindeOlanlarToolStripMenuItem,
            this.ızinOnaylaToolStripMenuItem,
            this.izinGeçmişiToolStripMenuItem,
            this.izinOnayBekleyenlerToolStripMenuItem});
            this.ızinToolStripMenuItem.Name = "ızinToolStripMenuItem";
            this.ızinToolStripMenuItem.Size = new System.Drawing.Size(37, 20);
            this.ızinToolStripMenuItem.Text = "Izin";
            // 
            // ızinIsteToolStripMenuItem
            // 
            this.ızinIsteToolStripMenuItem.Name = "ızinIsteToolStripMenuItem";
            this.ızinIsteToolStripMenuItem.Size = new System.Drawing.Size(186, 22);
            this.ızinIsteToolStripMenuItem.Text = "Izin Iste";
            this.ızinIsteToolStripMenuItem.Click += new System.EventHandler(this.ızinIsteToolStripMenuItem_Click);
            // 
            // izindeOlanlarToolStripMenuItem
            // 
            this.izindeOlanlarToolStripMenuItem.Name = "izindeOlanlarToolStripMenuItem";
            this.izindeOlanlarToolStripMenuItem.Size = new System.Drawing.Size(186, 22);
            this.izindeOlanlarToolStripMenuItem.Text = "İzinde Olanlar";
            // 
            // ızinOnaylaToolStripMenuItem
            // 
            this.ızinOnaylaToolStripMenuItem.Name = "ızinOnaylaToolStripMenuItem";
            this.ızinOnaylaToolStripMenuItem.Size = new System.Drawing.Size(186, 22);
            this.ızinOnaylaToolStripMenuItem.Text = "Izin Onayla";
            this.ızinOnaylaToolStripMenuItem.Click += new System.EventHandler(this.ızinOnaylaToolStripMenuItem_Click);
            // 
            // izinGeçmişiToolStripMenuItem
            // 
            this.izinGeçmişiToolStripMenuItem.Name = "izinGeçmişiToolStripMenuItem";
            this.izinGeçmişiToolStripMenuItem.Size = new System.Drawing.Size(186, 22);
            this.izinGeçmişiToolStripMenuItem.Text = "İzin Geçmişi";
            // 
            // izinOnayBekleyenlerToolStripMenuItem
            // 
            this.izinOnayBekleyenlerToolStripMenuItem.Name = "izinOnayBekleyenlerToolStripMenuItem";
            this.izinOnayBekleyenlerToolStripMenuItem.Size = new System.Drawing.Size(186, 22);
            this.izinOnayBekleyenlerToolStripMenuItem.Text = "İzin Onay Bekleyenler";
            // 
            // textBox1
            // 
            this.textBox1.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.textBox1.Location = new System.Drawing.Point(609, 5);
            this.textBox1.Name = "textBox1";
            this.textBox1.Size = new System.Drawing.Size(100, 20);
            this.textBox1.TabIndex = 7;
            this.textBox1.TextChanged += new System.EventHandler(this.textBox1_TextChanged);
            // 
            // arama
            // 
            this.arama.AutoSize = true;
            this.arama.Font = new System.Drawing.Font("Verdana", 9.75F, System.Drawing.FontStyle.Italic, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.arama.Location = new System.Drawing.Point(552, 9);
            this.arama.Name = "arama";
            this.arama.Size = new System.Drawing.Size(51, 16);
            this.arama.TabIndex = 8;
            this.arama.Text = "Arama";
            // 
            // PersonelListe
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(747, 418);
            this.Controls.Add(this.arama);
            this.Controls.Add(this.textBox1);
            this.Controls.Add(this.p_grid);
            this.Controls.Add(this.menuStrip1);
            this.MainMenuStrip = this.menuStrip1;
            this.Name = "PersonelListe";
            this.Text = "Personel Listesi";
            this.Load += new System.EventHandler(this.PersonelListe_Load);
            ((System.ComponentModel.ISupportInitialize)(this.p_grid)).EndInit();
            this.menuStrip1.ResumeLayout(false);
            this.menuStrip1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.DataGridView p_grid;
        private System.Windows.Forms.MenuStrip menuStrip1;
        private System.Windows.Forms.ToolStripMenuItem ekleToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem silToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem ızinToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem ızinIsteToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem ızinOnaylaToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem izindeOlanlarToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem izinGeçmişiToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem izinOnayBekleyenlerToolStripMenuItem;
        private System.Windows.Forms.TextBox textBox1;
        private System.Windows.Forms.Label arama;
        private System.Windows.Forms.ToolStripMenuItem düzenleToolStripMenuItem;
    }
}