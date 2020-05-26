namespace FlexASIO_GUI
{
    partial class Form1
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
            this.components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Form1));
            this.comboBoxBackend = new System.Windows.Forms.ComboBox();
            this.labelEndpoint = new System.Windows.Forms.Label();
            this.comboBoxISamT = new System.Windows.Forms.ComboBox();
            this.label2 = new System.Windows.Forms.Label();
            this.comboBoxIDev = new System.Windows.Forms.ComboBox();
            this.label3 = new System.Windows.Forms.Label();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.checkBoxIConv = new System.Windows.Forms.CheckBox();
            this.checkBoxIEx = new System.Windows.Forms.CheckBox();
            this.numericUpDownIChan = new System.Windows.Forms.NumericUpDown();
            this.textBoxILat = new System.Windows.Forms.TextBox();
            this.label6 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.textBoxBuff = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.checkBoxOConv = new System.Windows.Forms.CheckBox();
            this.checkBoxOEx = new System.Windows.Forms.CheckBox();
            this.numericUpDownOChan = new System.Windows.Forms.NumericUpDown();
            this.textBoxOLat = new System.Windows.Forms.TextBox();
            this.label5 = new System.Windows.Forms.Label();
            this.label7 = new System.Windows.Forms.Label();
            this.label8 = new System.Windows.Forms.Label();
            this.comboBoxOSamT = new System.Windows.Forms.ComboBox();
            this.comboBoxODev = new System.Windows.Forms.ComboBox();
            this.label9 = new System.Windows.Forms.Label();
            this.toolTip1 = new System.Windows.Forms.ToolTip(this.components);
            this.buttonSave = new System.Windows.Forms.Button();
            this.buttonClose = new System.Windows.Forms.Button();
            this.buttonOpenFolder = new System.Windows.Forms.Button();
            this.groupBox1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDownIChan)).BeginInit();
            this.groupBox2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDownOChan)).BeginInit();
            this.SuspendLayout();
            // 
            // comboBoxBackend
            // 
            this.comboBoxBackend.FormattingEnabled = true;
            this.comboBoxBackend.Items.AddRange(new object[] {
            "-",
            "MME",
            "Windows DirectSound",
            "Windows WASAPI",
            "Windows WDM-KS"});
            this.comboBoxBackend.Location = new System.Drawing.Point(12, 31);
            this.comboBoxBackend.Name = "comboBoxBackend";
            this.comboBoxBackend.Size = new System.Drawing.Size(172, 21);
            this.comboBoxBackend.TabIndex = 0;
            // 
            // labelEndpoint
            // 
            this.labelEndpoint.AutoSize = true;
            this.labelEndpoint.Location = new System.Drawing.Point(24, 15);
            this.labelEndpoint.Name = "labelEndpoint";
            this.labelEndpoint.Size = new System.Drawing.Size(159, 13);
            this.labelEndpoint.TabIndex = 1;
            this.labelEndpoint.Text = "Backend (default DirectSound) :";
            // 
            // comboBoxISamT
            // 
            this.comboBoxISamT.FormattingEnabled = true;
            this.comboBoxISamT.Items.AddRange(new object[] {
            "-",
            "Int32",
            "Int24",
            "Int16",
            "Float32"});
            this.comboBoxISamT.Location = new System.Drawing.Point(177, 111);
            this.comboBoxISamT.Name = "comboBoxISamT";
            this.comboBoxISamT.Size = new System.Drawing.Size(85, 21);
            this.comboBoxISamT.TabIndex = 0;
            this.toolTip1.SetToolTip(this.comboBoxISamT, "Set to \"-\" to ignore");
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(11, 114);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(154, 13);
            this.label2.TabIndex = 1;
            this.label2.Text = "Sample Type (default Float32) :";
            this.toolTip1.SetToolTip(this.label2, "Set to \"-\" to ignore");
            // 
            // comboBoxIDev
            // 
            this.comboBoxIDev.FormattingEnabled = true;
            this.comboBoxIDev.Location = new System.Drawing.Point(5, 32);
            this.comboBoxIDev.Name = "comboBoxIDev";
            this.comboBoxIDev.Size = new System.Drawing.Size(432, 21);
            this.comboBoxIDev.TabIndex = 0;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(17, 16);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(47, 13);
            this.label3.TabIndex = 1;
            this.label3.Text = "Device :";
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.checkBoxIConv);
            this.groupBox1.Controls.Add(this.checkBoxIEx);
            this.groupBox1.Controls.Add(this.numericUpDownIChan);
            this.groupBox1.Controls.Add(this.textBoxILat);
            this.groupBox1.Controls.Add(this.label3);
            this.groupBox1.Controls.Add(this.label6);
            this.groupBox1.Controls.Add(this.label4);
            this.groupBox1.Controls.Add(this.comboBoxISamT);
            this.groupBox1.Controls.Add(this.comboBoxIDev);
            this.groupBox1.Controls.Add(this.label2);
            this.groupBox1.Location = new System.Drawing.Point(12, 67);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(443, 198);
            this.groupBox1.TabIndex = 2;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "INPUT";
            // 
            // checkBoxIConv
            // 
            this.checkBoxIConv.AutoSize = true;
            this.checkBoxIConv.CheckAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.checkBoxIConv.Checked = true;
            this.checkBoxIConv.CheckState = System.Windows.Forms.CheckState.Checked;
            this.checkBoxIConv.Location = new System.Drawing.Point(14, 161);
            this.checkBoxIConv.Name = "checkBoxIConv";
            this.checkBoxIConv.Size = new System.Drawing.Size(191, 17);
            this.checkBoxIConv.TabIndex = 4;
            this.checkBoxIConv.Text = "Wasapi Autoconvert (default true) :";
            this.checkBoxIConv.UseVisualStyleBackColor = true;
            // 
            // checkBoxIEx
            // 
            this.checkBoxIEx.AutoSize = true;
            this.checkBoxIEx.CheckAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.checkBoxIEx.Location = new System.Drawing.Point(14, 138);
            this.checkBoxIEx.Name = "checkBoxIEx";
            this.checkBoxIEx.Size = new System.Drawing.Size(212, 17);
            this.checkBoxIEx.TabIndex = 4;
            this.checkBoxIEx.Text = "Wasapi Exclusive Mode (default false) :";
            this.checkBoxIEx.UseVisualStyleBackColor = true;
            // 
            // numericUpDownIChan
            // 
            this.numericUpDownIChan.Location = new System.Drawing.Point(68, 59);
            this.numericUpDownIChan.Name = "numericUpDownIChan";
            this.numericUpDownIChan.Size = new System.Drawing.Size(57, 20);
            this.numericUpDownIChan.TabIndex = 3;
            this.toolTip1.SetToolTip(this.numericUpDownIChan, "Set to 0 to ignore");
            this.numericUpDownIChan.Value = new decimal(new int[] {
            2,
            0,
            0,
            0});
            // 
            // textBoxILat
            // 
            this.textBoxILat.Location = new System.Drawing.Point(177, 85);
            this.textBoxILat.Name = "textBoxILat";
            this.textBoxILat.Size = new System.Drawing.Size(85, 20);
            this.textBoxILat.TabIndex = 2;
            this.toolTip1.SetToolTip(this.textBoxILat, resources.GetString("textBoxILat.ToolTip"));
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(11, 61);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(57, 13);
            this.label6.TabIndex = 1;
            this.label6.Text = "Channels :";
            this.toolTip1.SetToolTip(this.label6, "Set to -1 to ignore");
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(11, 88);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(154, 13);
            this.label4.TabIndex = 1;
            this.label4.Text = "Suggested Latency (seconds) :";
            this.toolTip1.SetToolTip(this.label4, "\"0.0\" (no quotes) may try to help in reducing latency, in some cases.\r\nLeave empt" +
        "y to ignore.");
            // 
            // textBoxBuff
            // 
            this.textBoxBuff.Location = new System.Drawing.Point(235, 31);
            this.textBoxBuff.Name = "textBoxBuff";
            this.textBoxBuff.Size = new System.Drawing.Size(100, 20);
            this.textBoxBuff.TabIndex = 2;
            this.textBoxBuff.Text = "512";
            this.toolTip1.SetToolTip(this.textBoxBuff, "Leave this empty if you want it to be ignored.");
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(248, 15);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(64, 13);
            this.label1.TabIndex = 1;
            this.label1.Text = "Buffer Size :";
            this.toolTip1.SetToolTip(this.label1, "Leave this empty if you want it to be ignored.");
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.checkBoxOConv);
            this.groupBox2.Controls.Add(this.checkBoxOEx);
            this.groupBox2.Controls.Add(this.numericUpDownOChan);
            this.groupBox2.Controls.Add(this.textBoxOLat);
            this.groupBox2.Controls.Add(this.label5);
            this.groupBox2.Controls.Add(this.label7);
            this.groupBox2.Controls.Add(this.label8);
            this.groupBox2.Controls.Add(this.comboBoxOSamT);
            this.groupBox2.Controls.Add(this.comboBoxODev);
            this.groupBox2.Controls.Add(this.label9);
            this.groupBox2.Location = new System.Drawing.Point(12, 271);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(444, 198);
            this.groupBox2.TabIndex = 2;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "OUTPUT";
            // 
            // checkBoxOConv
            // 
            this.checkBoxOConv.AutoSize = true;
            this.checkBoxOConv.CheckAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.checkBoxOConv.Checked = true;
            this.checkBoxOConv.CheckState = System.Windows.Forms.CheckState.Checked;
            this.checkBoxOConv.Location = new System.Drawing.Point(14, 161);
            this.checkBoxOConv.Name = "checkBoxOConv";
            this.checkBoxOConv.Size = new System.Drawing.Size(191, 17);
            this.checkBoxOConv.TabIndex = 4;
            this.checkBoxOConv.Text = "Wasapi Autoconvert (default true) :";
            this.checkBoxOConv.UseVisualStyleBackColor = true;
            // 
            // checkBoxOEx
            // 
            this.checkBoxOEx.AutoSize = true;
            this.checkBoxOEx.CheckAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.checkBoxOEx.Location = new System.Drawing.Point(14, 138);
            this.checkBoxOEx.Name = "checkBoxOEx";
            this.checkBoxOEx.Size = new System.Drawing.Size(212, 17);
            this.checkBoxOEx.TabIndex = 4;
            this.checkBoxOEx.Text = "Wasapi Exclusive Mode (default false) :";
            this.checkBoxOEx.UseVisualStyleBackColor = true;
            // 
            // numericUpDownOChan
            // 
            this.numericUpDownOChan.Location = new System.Drawing.Point(68, 59);
            this.numericUpDownOChan.Name = "numericUpDownOChan";
            this.numericUpDownOChan.Size = new System.Drawing.Size(57, 20);
            this.numericUpDownOChan.TabIndex = 3;
            this.toolTip1.SetToolTip(this.numericUpDownOChan, "Set to 0 to ignore");
            this.numericUpDownOChan.Value = new decimal(new int[] {
            2,
            0,
            0,
            0});
            // 
            // textBoxOLat
            // 
            this.textBoxOLat.Location = new System.Drawing.Point(177, 85);
            this.textBoxOLat.Name = "textBoxOLat";
            this.textBoxOLat.Size = new System.Drawing.Size(85, 20);
            this.textBoxOLat.TabIndex = 2;
            this.toolTip1.SetToolTip(this.textBoxOLat, resources.GetString("textBoxOLat.ToolTip"));
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(17, 16);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(47, 13);
            this.label5.TabIndex = 1;
            this.label5.Text = "Device :";
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(11, 61);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(57, 13);
            this.label7.TabIndex = 1;
            this.label7.Text = "Channels :";
            this.toolTip1.SetToolTip(this.label7, "Set to -1 to ignore");
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Location = new System.Drawing.Point(11, 88);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(154, 13);
            this.label8.TabIndex = 1;
            this.label8.Text = "Suggested Latency (seconds) :";
            this.toolTip1.SetToolTip(this.label8, "\"0.0\" (no quotes) may try to help in reducing latency, in some cases.\r\nLeave empt" +
        "y to ignore.");
            // 
            // comboBoxOSamT
            // 
            this.comboBoxOSamT.FormattingEnabled = true;
            this.comboBoxOSamT.Items.AddRange(new object[] {
            "-",
            "Int32",
            "Int24",
            "Int16",
            "Float32"});
            this.comboBoxOSamT.Location = new System.Drawing.Point(177, 111);
            this.comboBoxOSamT.Name = "comboBoxOSamT";
            this.comboBoxOSamT.Size = new System.Drawing.Size(85, 21);
            this.comboBoxOSamT.TabIndex = 0;
            this.toolTip1.SetToolTip(this.comboBoxOSamT, "Set to \"-\" to ignore");
            // 
            // comboBoxODev
            // 
            this.comboBoxODev.FormattingEnabled = true;
            this.comboBoxODev.Location = new System.Drawing.Point(5, 32);
            this.comboBoxODev.Name = "comboBoxODev";
            this.comboBoxODev.Size = new System.Drawing.Size(433, 21);
            this.comboBoxODev.TabIndex = 0;
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.Location = new System.Drawing.Point(11, 114);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(154, 13);
            this.label9.TabIndex = 1;
            this.label9.Text = "Sample Type (default Float32) :";
            this.toolTip1.SetToolTip(this.label9, "Set to \"-\" to ignore");
            // 
            // buttonSave
            // 
            this.buttonSave.Location = new System.Drawing.Point(374, 484);
            this.buttonSave.Name = "buttonSave";
            this.buttonSave.Size = new System.Drawing.Size(75, 23);
            this.buttonSave.TabIndex = 3;
            this.buttonSave.Text = "SAVE";
            this.toolTip1.SetToolTip(this.buttonSave, "Overwrite the existing \"FlexASIO.toml\" with your fresh-cooked configuration!");
            this.buttonSave.UseVisualStyleBackColor = true;
            this.buttonSave.Click += new System.EventHandler(this.buttonSave_Click);
            // 
            // buttonClose
            // 
            this.buttonClose.Location = new System.Drawing.Point(276, 484);
            this.buttonClose.Name = "buttonClose";
            this.buttonClose.Size = new System.Drawing.Size(75, 23);
            this.buttonClose.TabIndex = 4;
            this.buttonClose.Text = "Close";
            this.toolTip1.SetToolTip(this.buttonClose, "Close without saving.");
            this.buttonClose.UseVisualStyleBackColor = true;
            this.buttonClose.Click += new System.EventHandler(this.buttonClose_Click);
            // 
            // buttonOpenFolder
            // 
            this.buttonOpenFolder.Location = new System.Drawing.Point(381, 5);
            this.buttonOpenFolder.Name = "buttonOpenFolder";
            this.buttonOpenFolder.Size = new System.Drawing.Size(75, 23);
            this.buttonOpenFolder.TabIndex = 5;
            this.buttonOpenFolder.Text = "Open folder";
            this.buttonOpenFolder.UseVisualStyleBackColor = true;
            this.buttonOpenFolder.Click += new System.EventHandler(this.buttonOpenFolder_Click);
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(468, 519);
            this.Controls.Add(this.buttonOpenFolder);
            this.Controls.Add(this.buttonClose);
            this.Controls.Add(this.buttonSave);
            this.Controls.Add(this.textBoxBuff);
            this.Controls.Add(this.groupBox2);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.labelEndpoint);
            this.Controls.Add(this.comboBoxBackend);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "Form1";
            this.Text = "FlexASIO configuration helper by nam";
            this.Load += new System.EventHandler(this.Form1_Load);
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDownIChan)).EndInit();
            this.groupBox2.ResumeLayout(false);
            this.groupBox2.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDownOChan)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.ComboBox comboBoxBackend;
        private System.Windows.Forms.Label labelEndpoint;
        private System.Windows.Forms.ComboBox comboBoxISamT;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.ComboBox comboBoxIDev;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.TextBox textBoxBuff;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.NumericUpDown numericUpDownIChan;
        private System.Windows.Forms.TextBox textBoxILat;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.CheckBox checkBoxIConv;
        private System.Windows.Forms.CheckBox checkBoxIEx;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.CheckBox checkBoxOConv;
        private System.Windows.Forms.CheckBox checkBoxOEx;
        private System.Windows.Forms.NumericUpDown numericUpDownOChan;
        private System.Windows.Forms.TextBox textBoxOLat;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.ComboBox comboBoxOSamT;
        private System.Windows.Forms.ComboBox comboBoxODev;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.ToolTip toolTip1;
        private System.Windows.Forms.Button buttonSave;
        private System.Windows.Forms.Button buttonClose;
        private System.Windows.Forms.Button buttonOpenFolder;
    }
}

