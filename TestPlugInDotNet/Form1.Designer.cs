namespace TestPlugInDotNet
{
    partial class pluginDotNet
    {
        /// <summary>
        /// Variable nécessaire au concepteur.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Nettoyage des ressources utilisées.
        /// </summary>
        /// <param name="disposing">true si les ressources managées doivent être supprimées ; sinon, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Code généré par le Concepteur Windows Form

        /// <summary>
        /// Méthode requise pour la prise en charge du concepteur - ne modifiez pas
        /// le contenu de cette méthode avec l'éditeur de code.
        /// </summary>
        private void InitializeComponent()
        {
            this.b_for_compression = new System.Windows.Forms.Button();
            this.rtb_for_compression = new System.Windows.Forms.RichTextBox();
            this.rtb_for_decompression = new System.Windows.Forms.RichTextBox();
            this.b_for_decompression = new System.Windows.Forms.Button();
            this.rtb_for_compressed = new System.Windows.Forms.RichTextBox();
            this.l_for_compression = new System.Windows.Forms.Label();
            this.l_for_decompression = new System.Windows.Forms.Label();
            this.l_for_compressed = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // b_for_compression
            // 
            this.b_for_compression.Location = new System.Drawing.Point(11, 165);
            this.b_for_compression.Margin = new System.Windows.Forms.Padding(2);
            this.b_for_compression.Name = "b_for_compression";
            this.b_for_compression.Size = new System.Drawing.Size(143, 33);
            this.b_for_compression.TabIndex = 6;
            this.b_for_compression.Text = "Compresser";
            this.b_for_compression.UseVisualStyleBackColor = true;
            this.b_for_compression.Click += new System.EventHandler(this.b_for_compression_Click);
            // 
            // rtb_for_compression
            // 
            this.rtb_for_compression.Location = new System.Drawing.Point(12, 25);
            this.rtb_for_compression.Name = "rtb_for_compression";
            this.rtb_for_compression.Size = new System.Drawing.Size(695, 135);
            this.rtb_for_compression.TabIndex = 1;
            this.rtb_for_compression.Text = "";
            // 
            // rtb_for_decompression
            // 
            this.rtb_for_decompression.Enabled = false;
            this.rtb_for_decompression.Location = new System.Drawing.Point(12, 265);
            this.rtb_for_decompression.Name = "rtb_for_decompression";
            this.rtb_for_decompression.Size = new System.Drawing.Size(695, 128);
            this.rtb_for_decompression.TabIndex = 5;
            this.rtb_for_decompression.Text = "";
            // 
            // b_for_decompression
            // 
            this.b_for_decompression.Location = new System.Drawing.Point(12, 203);
            this.b_for_decompression.Name = "b_for_decompression";
            this.b_for_decompression.Size = new System.Drawing.Size(142, 34);
            this.b_for_decompression.TabIndex = 7;
            this.b_for_decompression.Text = "Décompresser";
            this.b_for_decompression.UseVisualStyleBackColor = true;
            this.b_for_decompression.Click += new System.EventHandler(this.b_for_decompression_Click);
            // 
            // rtb_for_compressed
            // 
            this.rtb_for_compressed.Enabled = false;
            this.rtb_for_compressed.Location = new System.Drawing.Point(159, 182);
            this.rtb_for_compressed.Name = "rtb_for_compressed";
            this.rtb_for_compressed.Size = new System.Drawing.Size(548, 77);
            this.rtb_for_compressed.TabIndex = 3;
            this.rtb_for_compressed.Text = "";
            // 
            // l_for_compression
            // 
            this.l_for_compression.AutoSize = true;
            this.l_for_compression.Location = new System.Drawing.Point(12, 9);
            this.l_for_compression.Name = "l_for_compression";
            this.l_for_compression.Size = new System.Drawing.Size(106, 13);
            this.l_for_compression.TabIndex = 0;
            this.l_for_compression.Text = "Texte à compresser :";
            // 
            // l_for_decompression
            // 
            this.l_for_decompression.AutoSize = true;
            this.l_for_decompression.Location = new System.Drawing.Point(12, 249);
            this.l_for_decompression.Name = "l_for_decompression";
            this.l_for_decompression.Size = new System.Drawing.Size(118, 13);
            this.l_for_decompression.TabIndex = 4;
            this.l_for_decompression.Text = "Texte à décompresser :";
            // 
            // l_for_compressed
            // 
            this.l_for_compressed.AutoSize = true;
            this.l_for_compressed.Location = new System.Drawing.Point(160, 166);
            this.l_for_compressed.Name = "l_for_compressed";
            this.l_for_compressed.Size = new System.Drawing.Size(94, 13);
            this.l_for_compressed.TabIndex = 2;
            this.l_for_compressed.Text = "Texte compressé :";
            // 
            // pluginDotNet
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(719, 405);
            this.Controls.Add(this.l_for_compressed);
            this.Controls.Add(this.l_for_decompression);
            this.Controls.Add(this.l_for_compression);
            this.Controls.Add(this.rtb_for_compressed);
            this.Controls.Add(this.b_for_decompression);
            this.Controls.Add(this.rtb_for_decompression);
            this.Controls.Add(this.rtb_for_compression);
            this.Controls.Add(this.b_for_compression);
            this.Margin = new System.Windows.Forms.Padding(2);
            this.MaximizeBox = false;
            this.Name = "pluginDotNet";
            this.Text = "Compression/Décompression de texte";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button b_for_compression;
        private System.Windows.Forms.RichTextBox rtb_for_compression;
        private System.Windows.Forms.RichTextBox rtb_for_decompression;
        private System.Windows.Forms.Button b_for_decompression;
        private System.Windows.Forms.RichTextBox rtb_for_compressed;
        private System.Windows.Forms.Label l_for_compression;
        private System.Windows.Forms.Label l_for_decompression;
        private System.Windows.Forms.Label l_for_compressed;
    }
}

