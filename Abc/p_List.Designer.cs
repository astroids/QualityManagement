namespace Abc
{
    partial class p_List
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
            this.p_Ekle = new System.Windows.Forms.Button();
            this.p_Duzen = new System.Windows.Forms.Button();
            this.p_Sil = new System.Windows.Forms.Button();
            this.button4 = new System.Windows.Forms.Button();
            this.button5 = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.p_grid)).BeginInit();
            this.SuspendLayout();
            // 
            // p_grid
            // 
            this.p_grid.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.p_grid.Location = new System.Drawing.Point(12, 63);
            this.p_grid.Name = "p_grid";
            this.p_grid.Size = new System.Drawing.Size(723, 343);
            this.p_grid.TabIndex = 0;
            // 
            // p_Ekle
            // 
            this.p_Ekle.Location = new System.Drawing.Point(12, 12);
            this.p_Ekle.Name = "p_Ekle";
            this.p_Ekle.Size = new System.Drawing.Size(75, 23);
            this.p_Ekle.TabIndex = 1;
            this.p_Ekle.Text = "Ekle";
            this.p_Ekle.UseVisualStyleBackColor = true;
            this.p_Ekle.Click += new System.EventHandler(this.p_Ekle_Click);
            // 
            // p_Duzen
            // 
            this.p_Duzen.Location = new System.Drawing.Point(114, 12);
            this.p_Duzen.Name = "p_Duzen";
            this.p_Duzen.Size = new System.Drawing.Size(75, 23);
            this.p_Duzen.TabIndex = 2;
            this.p_Duzen.Text = "Düzenle";
            this.p_Duzen.UseVisualStyleBackColor = true;
            // 
            // p_Sil
            // 
            this.p_Sil.Location = new System.Drawing.Point(225, 12);
            this.p_Sil.Name = "p_Sil";
            this.p_Sil.Size = new System.Drawing.Size(75, 23);
            this.p_Sil.TabIndex = 3;
            this.p_Sil.Text = "Sil";
            this.p_Sil.UseVisualStyleBackColor = true;
            // 
            // button4
            // 
            this.button4.Location = new System.Drawing.Point(400, 12);
            this.button4.Name = "button4";
            this.button4.Size = new System.Drawing.Size(75, 23);
            this.button4.TabIndex = 4;
            this.button4.Text = "button4";
            this.button4.UseVisualStyleBackColor = true;
            // 
            // button5
            // 
            this.button5.Location = new System.Drawing.Point(541, 12);
            this.button5.Name = "button5";
            this.button5.Size = new System.Drawing.Size(75, 23);
            this.button5.TabIndex = 5;
            this.button5.Text = "button5";
            this.button5.UseVisualStyleBackColor = true;
            // 
            // p_List
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(747, 418);
            this.Controls.Add(this.button5);
            this.Controls.Add(this.button4);
            this.Controls.Add(this.p_Sil);
            this.Controls.Add(this.p_Duzen);
            this.Controls.Add(this.p_Ekle);
            this.Controls.Add(this.p_grid);
            this.Name = "p_List";
            this.Text = "p_List";
            ((System.ComponentModel.ISupportInitialize)(this.p_grid)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.DataGridView p_grid;
        private System.Windows.Forms.Button p_Ekle;
        private System.Windows.Forms.Button p_Duzen;
        private System.Windows.Forms.Button p_Sil;
        private System.Windows.Forms.Button button4;
        private System.Windows.Forms.Button button5;
    }
}