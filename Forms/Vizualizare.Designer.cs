namespace PollutionMap.Forms
{
    partial class Vizualizare
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Vizualizare));
            this.tabControl1 = new System.Windows.Forms.TabControl();
            this.VeziHarta = new System.Windows.Forms.TabPage();
            this.resetButton = new System.Windows.Forms.Button();
            this.filtrareButton = new System.Windows.Forms.Button();
            this.dateTimePicker = new System.Windows.Forms.DateTimePicker();
            this.filtruComboBox = new System.Windows.Forms.ComboBox();
            this.hartiComboBox = new System.Windows.Forms.ComboBox();
            this.label3 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.utilizatorLabel = new System.Windows.Forms.Label();
            this.hartaPictureBox = new System.Windows.Forms.PictureBox();
            this.Traseu = new System.Windows.Forms.TabPage();
            this.textBox1 = new System.Windows.Forms.TextBox();
            this.traseuPictureBox = new System.Windows.Forms.PictureBox();
            this.tabControl1.SuspendLayout();
            this.VeziHarta.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.hartaPictureBox)).BeginInit();
            this.Traseu.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.traseuPictureBox)).BeginInit();
            this.SuspendLayout();
            // 
            // tabControl1
            // 
            this.tabControl1.Controls.Add(this.VeziHarta);
            this.tabControl1.Controls.Add(this.Traseu);
            this.tabControl1.Location = new System.Drawing.Point(12, 12);
            this.tabControl1.Name = "tabControl1";
            this.tabControl1.SelectedIndex = 0;
            this.tabControl1.Size = new System.Drawing.Size(1271, 753);
            this.tabControl1.TabIndex = 0;
            this.tabControl1.SelectedIndexChanged += new System.EventHandler(this.tabControl1_SelectedIndexChanged);
            // 
            // VeziHarta
            // 
            this.VeziHarta.Controls.Add(this.resetButton);
            this.VeziHarta.Controls.Add(this.filtrareButton);
            this.VeziHarta.Controls.Add(this.dateTimePicker);
            this.VeziHarta.Controls.Add(this.filtruComboBox);
            this.VeziHarta.Controls.Add(this.hartiComboBox);
            this.VeziHarta.Controls.Add(this.label3);
            this.VeziHarta.Controls.Add(this.label2);
            this.VeziHarta.Controls.Add(this.label1);
            this.VeziHarta.Controls.Add(this.utilizatorLabel);
            this.VeziHarta.Controls.Add(this.hartaPictureBox);
            this.VeziHarta.Location = new System.Drawing.Point(8, 39);
            this.VeziHarta.Name = "VeziHarta";
            this.VeziHarta.Padding = new System.Windows.Forms.Padding(3);
            this.VeziHarta.Size = new System.Drawing.Size(1255, 706);
            this.VeziHarta.TabIndex = 0;
            this.VeziHarta.Text = "Harta";
            this.VeziHarta.UseVisualStyleBackColor = true;
            // 
            // resetButton
            // 
            this.resetButton.Location = new System.Drawing.Point(271, 531);
            this.resetButton.Name = "resetButton";
            this.resetButton.Size = new System.Drawing.Size(159, 61);
            this.resetButton.TabIndex = 9;
            this.resetButton.Text = "Resetare filtru";
            this.resetButton.UseVisualStyleBackColor = true;
            this.resetButton.Click += new System.EventHandler(this.resetButton_Click);
            // 
            // filtrareButton
            // 
            this.filtrareButton.Location = new System.Drawing.Point(53, 531);
            this.filtrareButton.Name = "filtrareButton";
            this.filtrareButton.Size = new System.Drawing.Size(159, 61);
            this.filtrareButton.TabIndex = 8;
            this.filtrareButton.Text = "Filtrare";
            this.filtrareButton.UseVisualStyleBackColor = true;
            this.filtrareButton.Click += new System.EventHandler(this.filtrareButton_Click);
            // 
            // dateTimePicker
            // 
            this.dateTimePicker.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
            this.dateTimePicker.Location = new System.Drawing.Point(109, 296);
            this.dateTimePicker.Name = "dateTimePicker";
            this.dateTimePicker.Size = new System.Drawing.Size(394, 31);
            this.dateTimePicker.TabIndex = 7;
            // 
            // filtruComboBox
            // 
            this.filtruComboBox.FormattingEnabled = true;
            this.filtruComboBox.Location = new System.Drawing.Point(122, 396);
            this.filtruComboBox.Name = "filtruComboBox";
            this.filtruComboBox.Size = new System.Drawing.Size(121, 33);
            this.filtruComboBox.TabIndex = 6;
            // 
            // hartiComboBox
            // 
            this.hartiComboBox.FormattingEnabled = true;
            this.hartiComboBox.Location = new System.Drawing.Point(134, 183);
            this.hartiComboBox.Name = "hartiComboBox";
            this.hartiComboBox.Size = new System.Drawing.Size(266, 33);
            this.hartiComboBox.TabIndex = 5;
            this.hartiComboBox.SelectedIndexChanged += new System.EventHandler(this.hartiComboBox_SelectedIndexChanged);
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(40, 396);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(66, 25);
            this.label3.TabIndex = 4;
            this.label3.Text = "Filtru:";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(40, 296);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(63, 25);
            this.label2.TabIndex = 3;
            this.label2.Text = "Data:";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(40, 183);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(70, 25);
            this.label1.TabIndex = 2;
            this.label1.Text = "Harta:";
            // 
            // utilizatorLabel
            // 
            this.utilizatorLabel.AutoSize = true;
            this.utilizatorLabel.Location = new System.Drawing.Point(48, 75);
            this.utilizatorLabel.Name = "utilizatorLabel";
            this.utilizatorLabel.Size = new System.Drawing.Size(70, 25);
            this.utilizatorLabel.TabIndex = 1;
            this.utilizatorLabel.Text = "label1";
            // 
            // hartaPictureBox
            // 
            this.hartaPictureBox.Location = new System.Drawing.Point(582, 112);
            this.hartaPictureBox.Name = "hartaPictureBox";
            this.hartaPictureBox.Size = new System.Drawing.Size(640, 480);
            this.hartaPictureBox.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.hartaPictureBox.TabIndex = 0;
            this.hartaPictureBox.TabStop = false;
            this.hartaPictureBox.MouseDown += new System.Windows.Forms.MouseEventHandler(this.hartaPictureBox_MouseDown);
            // 
            // Traseu
            // 
            this.Traseu.Controls.Add(this.traseuPictureBox);
            this.Traseu.Controls.Add(this.textBox1);
            this.Traseu.Location = new System.Drawing.Point(8, 39);
            this.Traseu.Name = "Traseu";
            this.Traseu.Padding = new System.Windows.Forms.Padding(3);
            this.Traseu.Size = new System.Drawing.Size(1255, 706);
            this.Traseu.TabIndex = 1;
            this.Traseu.Text = "Traseu";
            this.Traseu.UseVisualStyleBackColor = true;
            // 
            // textBox1
            // 
            this.textBox1.Location = new System.Drawing.Point(928, 62);
            this.textBox1.Multiline = true;
            this.textBox1.Name = "textBox1";
            this.textBox1.ReadOnly = true;
            this.textBox1.Size = new System.Drawing.Size(305, 245);
            this.textBox1.TabIndex = 1;
            this.textBox1.Text = resources.GetString("textBox1.Text");
            // 
            // traseuPictureBox
            // 
            this.traseuPictureBox.Location = new System.Drawing.Point(55, 14);
            this.traseuPictureBox.Name = "traseuPictureBox";
            this.traseuPictureBox.Size = new System.Drawing.Size(718, 686);
            this.traseuPictureBox.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.traseuPictureBox.TabIndex = 2;
            this.traseuPictureBox.TabStop = false;
            this.traseuPictureBox.MouseDown += new System.Windows.Forms.MouseEventHandler(this.traseuPictureBox_MouseDown);
            // 
            // Vizualizare
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(12F, 25F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1283, 767);
            this.Controls.Add(this.tabControl1);
            this.Name = "Vizualizare";
            this.Text = "Vizualizare";
            this.Load += new System.EventHandler(this.Vizualizare_Load);
            this.tabControl1.ResumeLayout(false);
            this.VeziHarta.ResumeLayout(false);
            this.VeziHarta.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.hartaPictureBox)).EndInit();
            this.Traseu.ResumeLayout(false);
            this.Traseu.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.traseuPictureBox)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.TabControl tabControl1;
        private System.Windows.Forms.TabPage VeziHarta;
        private System.Windows.Forms.PictureBox hartaPictureBox;
        private System.Windows.Forms.TabPage Traseu;
        private System.Windows.Forms.Label utilizatorLabel;
        private System.Windows.Forms.DateTimePicker dateTimePicker;
        private System.Windows.Forms.ComboBox filtruComboBox;
        private System.Windows.Forms.ComboBox hartiComboBox;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button resetButton;
        private System.Windows.Forms.Button filtrareButton;
        private System.Windows.Forms.TextBox textBox1;
        private System.Windows.Forms.PictureBox traseuPictureBox;
    }
}