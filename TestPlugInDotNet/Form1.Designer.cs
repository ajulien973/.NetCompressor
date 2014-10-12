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
            this.tab_control = new System.Windows.Forms.TabControl();
            this.tab_page_main = new System.Windows.Forms.TabPage();
            this.l_size_decompression = new System.Windows.Forms.Label();
            this.l_size_compressed = new System.Windows.Forms.Label();
            this.l_size_compression = new System.Windows.Forms.Label();
            this.l_for_compressed = new System.Windows.Forms.Label();
            this.l_for_decompression = new System.Windows.Forms.Label();
            this.l_for_compression = new System.Windows.Forms.Label();
            this.rtb_for_compressed = new System.Windows.Forms.RichTextBox();
            this.b_for_decompression = new System.Windows.Forms.Button();
            this.rtb_for_decompression = new System.Windows.Forms.RichTextBox();
            this.rtb_for_compression = new System.Windows.Forms.RichTextBox();
            this.b_for_compression = new System.Windows.Forms.Button();
            this.tab_pzge_fraquency = new System.Windows.Forms.TabPage();
            this.lb_frequency = new System.Windows.Forms.ListBox();
            this.tab_control.SuspendLayout();
            this.tab_page_main.SuspendLayout();
            this.tab_pzge_fraquency.SuspendLayout();
            this.SuspendLayout();
            // 
            // tab_control
            // 
            this.tab_control.Controls.Add(this.tab_page_main);
            this.tab_control.Controls.Add(this.tab_pzge_fraquency);
            this.tab_control.Location = new System.Drawing.Point(12, 12);
            this.tab_control.Name = "tab_control";
            this.tab_control.SelectedIndex = 0;
            this.tab_control.Size = new System.Drawing.Size(695, 381);
            this.tab_control.TabIndex = 0;
            // 
            // tab_page_main
            // 
            this.tab_page_main.Controls.Add(this.l_size_decompression);
            this.tab_page_main.Controls.Add(this.l_size_compressed);
            this.tab_page_main.Controls.Add(this.l_size_compression);
            this.tab_page_main.Controls.Add(this.l_for_compressed);
            this.tab_page_main.Controls.Add(this.l_for_decompression);
            this.tab_page_main.Controls.Add(this.l_for_compression);
            this.tab_page_main.Controls.Add(this.rtb_for_compressed);
            this.tab_page_main.Controls.Add(this.b_for_decompression);
            this.tab_page_main.Controls.Add(this.rtb_for_decompression);
            this.tab_page_main.Controls.Add(this.rtb_for_compression);
            this.tab_page_main.Controls.Add(this.b_for_compression);
            this.tab_page_main.Location = new System.Drawing.Point(4, 22);
            this.tab_page_main.Name = "tab_page_main";
            this.tab_page_main.Padding = new System.Windows.Forms.Padding(3);
            this.tab_page_main.Size = new System.Drawing.Size(687, 355);
            this.tab_page_main.TabIndex = 0;
            this.tab_page_main.Text = "Compression / Décompression";
            this.tab_page_main.UseVisualStyleBackColor = true;
            // 
            // l_size_decompression
            // 
            this.l_size_decompression.AutoSize = true;
            this.l_size_decompression.Location = new System.Drawing.Point(613, 229);
            this.l_size_decompression.Name = "l_size_decompression";
            this.l_size_decompression.Size = new System.Drawing.Size(0, 13);
            this.l_size_decompression.TabIndex = 10;
            // 
            // l_size_compressed
            // 
            this.l_size_compressed.AutoSize = true;
            this.l_size_compressed.Location = new System.Drawing.Point(613, 129);
            this.l_size_compressed.Name = "l_size_compressed";
            this.l_size_compressed.Size = new System.Drawing.Size(0, 13);
            this.l_size_compressed.TabIndex = 7;
            // 
            // l_size_compression
            // 
            this.l_size_compression.AutoSize = true;
            this.l_size_compression.Location = new System.Drawing.Point(613, 3);
            this.l_size_compression.Name = "l_size_compression";
            this.l_size_compression.Size = new System.Drawing.Size(0, 13);
            this.l_size_compression.TabIndex = 2;
            // 
            // l_for_compressed
            // 
            this.l_for_compressed.AutoSize = true;
            this.l_for_compressed.Location = new System.Drawing.Point(143, 129);
            this.l_for_compressed.Name = "l_for_compressed";
            this.l_for_compressed.Size = new System.Drawing.Size(94, 13);
            this.l_for_compressed.TabIndex = 6;
            this.l_for_compressed.Text = "Texte compressé :";
            // 
            // l_for_decompression
            // 
            this.l_for_decompression.AutoSize = true;
            this.l_for_decompression.Location = new System.Drawing.Point(6, 229);
            this.l_for_decompression.Name = "l_for_decompression";
            this.l_for_decompression.Size = new System.Drawing.Size(118, 13);
            this.l_for_decompression.TabIndex = 9;
            this.l_for_decompression.Text = "Texte à décompresser :";
            // 
            // l_for_compression
            // 
            this.l_for_compression.AutoSize = true;
            this.l_for_compression.Location = new System.Drawing.Point(6, 3);
            this.l_for_compression.Name = "l_for_compression";
            this.l_for_compression.Size = new System.Drawing.Size(106, 13);
            this.l_for_compression.TabIndex = 1;
            this.l_for_compression.Text = "Texte à compresser :";
            // 
            // rtb_for_compressed
            // 
            this.rtb_for_compressed.Location = new System.Drawing.Point(143, 145);
            this.rtb_for_compressed.Name = "rtb_for_compressed";
            this.rtb_for_compressed.ReadOnly = true;
            this.rtb_for_compressed.Size = new System.Drawing.Size(538, 81);
            this.rtb_for_compressed.TabIndex = 8;
            this.rtb_for_compressed.Text = "";
            // 
            // b_for_decompression
            // 
            this.b_for_decompression.Location = new System.Drawing.Point(6, 183);
            this.b_for_decompression.Name = "b_for_decompression";
            this.b_for_decompression.Size = new System.Drawing.Size(129, 34);
            this.b_for_decompression.TabIndex = 5;
            this.b_for_decompression.Text = "Décompresser";
            this.b_for_decompression.UseVisualStyleBackColor = true;
            this.b_for_decompression.Click += new System.EventHandler(this.b_for_decompression_Click);
            // 
            // rtb_for_decompression
            // 
            this.rtb_for_decompression.Location = new System.Drawing.Point(6, 245);
            this.rtb_for_decompression.Name = "rtb_for_decompression";
            this.rtb_for_decompression.ReadOnly = true;
            this.rtb_for_decompression.Size = new System.Drawing.Size(675, 107);
            this.rtb_for_decompression.TabIndex = 11;
            this.rtb_for_decompression.Text = "";
            // 
            // rtb_for_compression
            // 
            this.rtb_for_compression.Location = new System.Drawing.Point(6, 19);
            this.rtb_for_compression.Name = "rtb_for_compression";
            this.rtb_for_compression.Size = new System.Drawing.Size(675, 107);
            this.rtb_for_compression.TabIndex = 3;
            this.rtb_for_compression.Text = "";
            // 
            // b_for_compression
            // 
            this.b_for_compression.Location = new System.Drawing.Point(5, 145);
            this.b_for_compression.Margin = new System.Windows.Forms.Padding(2);
            this.b_for_compression.Name = "b_for_compression";
            this.b_for_compression.Size = new System.Drawing.Size(129, 33);
            this.b_for_compression.TabIndex = 4;
            this.b_for_compression.Text = "Compresser";
            this.b_for_compression.UseVisualStyleBackColor = true;
            this.b_for_compression.Click += new System.EventHandler(this.b_for_compression_Click);
            // 
            // tab_pzge_fraquency
            // 
            this.tab_pzge_fraquency.Controls.Add(this.lb_frequency);
            this.tab_pzge_fraquency.Location = new System.Drawing.Point(4, 22);
            this.tab_pzge_fraquency.Name = "tab_pzge_fraquency";
            this.tab_pzge_fraquency.Padding = new System.Windows.Forms.Padding(3);
            this.tab_pzge_fraquency.Size = new System.Drawing.Size(687, 355);
            this.tab_pzge_fraquency.TabIndex = 1;
            this.tab_pzge_fraquency.Text = "Fréquences";
            this.tab_pzge_fraquency.UseVisualStyleBackColor = true;
            // 
            // lb_frequency
            // 
            this.lb_frequency.ColumnWidth = 150;
            this.lb_frequency.FormattingEnabled = true;
            this.lb_frequency.Location = new System.Drawing.Point(6, 6);
            this.lb_frequency.MultiColumn = true;
            this.lb_frequency.Name = "lb_frequency";
            this.lb_frequency.ScrollAlwaysVisible = true;
            this.lb_frequency.SelectionMode = System.Windows.Forms.SelectionMode.None;
            this.lb_frequency.Size = new System.Drawing.Size(675, 342);
            this.lb_frequency.TabIndex = 12;
            // 
            // pluginDotNet
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(719, 405);
            this.Controls.Add(this.tab_control);
            this.Margin = new System.Windows.Forms.Padding(2);
            this.MaximizeBox = false;
            this.Name = "pluginDotNet";
            this.Text = "Compression/Décompression de texte";
            this.tab_control.ResumeLayout(false);
            this.tab_page_main.ResumeLayout(false);
            this.tab_page_main.PerformLayout();
            this.tab_pzge_fraquency.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.TabControl tab_control;
        private System.Windows.Forms.TabPage tab_page_main;
        private System.Windows.Forms.Label l_size_decompression;
        private System.Windows.Forms.Label l_size_compressed;
        private System.Windows.Forms.Label l_size_compression;
        private System.Windows.Forms.Label l_for_compressed;
        private System.Windows.Forms.Label l_for_decompression;
        private System.Windows.Forms.Label l_for_compression;
        private System.Windows.Forms.RichTextBox rtb_for_compressed;
        private System.Windows.Forms.Button b_for_decompression;
        private System.Windows.Forms.RichTextBox rtb_for_decompression;
        private System.Windows.Forms.RichTextBox rtb_for_compression;
        private System.Windows.Forms.Button b_for_compression;
        private System.Windows.Forms.TabPage tab_pzge_fraquency;
        private System.Windows.Forms.ListBox lb_frequency;

    }
}

