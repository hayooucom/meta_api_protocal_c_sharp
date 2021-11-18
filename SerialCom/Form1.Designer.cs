namespace SerialCom
{
    partial class MainForm
    {
        /// <summary>
        /// 必需的设计器变量。
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// 清理所有正在使用的资源。
        /// </summary>
        /// <param name="disposing">如果应释放托管资源，为 true；否则为 false。</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows 窗体设计器生成的代码

        /// <summary>
        /// 设计器支持所需的方法 - 不要修改
        /// 使用代码编辑器修改此方法的内容。
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(MainForm));
            this.menuStrip1 = new System.Windows.Forms.MenuStrip();
            this.MenuFile = new System.Windows.Forms.ToolStripMenuItem();
            this.SaveReceiveDataToFileToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.ExitToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.MenuSetting = new System.Windows.Forms.ToolStripMenuItem();
            this.ResetPortConfToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.MenuIHelp = new System.Windows.Forms.ToolStripMenuItem();
            this.AboutToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.AuthorToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.ContributorSylvesterLiToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStrip1 = new System.Windows.Forms.ToolStrip();
            this.groupBoxSerialPortSetting = new System.Windows.Forms.GroupBox();
            this.comboBox_protocal = new System.Windows.Forms.ComboBox();
            this.protocal = new System.Windows.Forms.Label();
            this.comboBox_port = new System.Windows.Forms.ComboBox();
            this.port = new System.Windows.Forms.Label();
            this.comboBox_ip = new System.Windows.Forms.ComboBox();
            this.comboBoxCom = new System.Windows.Forms.ComboBox();
            this.unreal_ip = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.buttonOpenCloseCom = new System.Windows.Forms.Button();
            this.radioButtonSendDataHex = new System.Windows.Forms.RadioButton();
            this.radioButtonSendDataASCII = new System.Windows.Forms.RadioButton();
            this.groupBoxFileSaveSetting = new System.Windows.Forms.GroupBox();
            this.radioButtonFileSave = new System.Windows.Forms.RadioButton();
            this.groupBoxReceiveData = new System.Windows.Forms.GroupBox();
            this.buttonClearRecData = new System.Windows.Forms.Button();
            this.textBoxReceive = new System.Windows.Forms.TextBox();
            this.groupBoxSendData = new System.Windows.Forms.GroupBox();
            this.buttonSendData = new System.Windows.Forms.Button();
            this.textBoxSend = new System.Windows.Forms.TextBox();
            this.Button_Refresh = new System.Windows.Forms.Button();
            this.imageList1 = new System.Windows.Forms.ImageList(this.components);
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.btn_pause_play_file_data = new System.Windows.Forms.Button();
            this.btn_stop_play_file = new System.Windows.Forms.Button();
            this.btn_play_load_file = new System.Windows.Forms.Button();
            this.btn_load_file = new System.Windows.Forms.Button();
            this.menuStrip1.SuspendLayout();
            this.groupBoxSerialPortSetting.SuspendLayout();
            this.groupBoxFileSaveSetting.SuspendLayout();
            this.groupBoxReceiveData.SuspendLayout();
            this.groupBoxSendData.SuspendLayout();
            this.groupBox1.SuspendLayout();
            this.SuspendLayout();
            // 
            // menuStrip1
            // 
            this.menuStrip1.ImageScalingSize = new System.Drawing.Size(20, 20);
            this.menuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.MenuFile,
            this.MenuSetting,
            this.MenuIHelp});
            this.menuStrip1.Location = new System.Drawing.Point(0, 0);
            this.menuStrip1.Name = "menuStrip1";
            this.menuStrip1.Size = new System.Drawing.Size(711, 28);
            this.menuStrip1.TabIndex = 0;
            this.menuStrip1.Text = "menuStrip1";
            // 
            // MenuFile
            // 
            this.MenuFile.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.SaveReceiveDataToFileToolStripMenuItem,
            this.ExitToolStripMenuItem});
            this.MenuFile.Name = "MenuFile";
            this.MenuFile.Size = new System.Drawing.Size(48, 24);
            this.MenuFile.Text = "File";
            // 
            // SaveReceiveDataToFileToolStripMenuItem
            // 
            this.SaveReceiveDataToFileToolStripMenuItem.Name = "SaveReceiveDataToFileToolStripMenuItem";
            this.SaveReceiveDataToFileToolStripMenuItem.Size = new System.Drawing.Size(208, 26);
            this.SaveReceiveDataToFileToolStripMenuItem.Text = "Save data to file";
            this.SaveReceiveDataToFileToolStripMenuItem.Click += new System.EventHandler(this.SaveReceiveDataToFileToolStripMenuItem_Click);
            // 
            // ExitToolStripMenuItem
            // 
            this.ExitToolStripMenuItem.Name = "ExitToolStripMenuItem";
            this.ExitToolStripMenuItem.Size = new System.Drawing.Size(208, 26);
            this.ExitToolStripMenuItem.Text = "Exit";
            this.ExitToolStripMenuItem.Click += new System.EventHandler(this.ExitToolStripMenuItem_Click);
            // 
            // MenuSetting
            // 
            this.MenuSetting.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.ResetPortConfToolStripMenuItem});
            this.MenuSetting.Name = "MenuSetting";
            this.MenuSetting.Size = new System.Drawing.Size(83, 24);
            this.MenuSetting.Text = "Settings";
            // 
            // ResetPortConfToolStripMenuItem
            // 
            this.ResetPortConfToolStripMenuItem.Name = "ResetPortConfToolStripMenuItem";
            this.ResetPortConfToolStripMenuItem.Size = new System.Drawing.Size(274, 26);
            this.ResetPortConfToolStripMenuItem.Text = "Reset connection setting";
            this.ResetPortConfToolStripMenuItem.Click += new System.EventHandler(this.ResetPortConfToolStripMenuItem_Click);
            // 
            // MenuIHelp
            // 
            this.MenuIHelp.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.AboutToolStripMenuItem});
            this.MenuIHelp.Name = "MenuIHelp";
            this.MenuIHelp.Size = new System.Drawing.Size(58, 24);
            this.MenuIHelp.Text = "Help";
            // 
            // AboutToolStripMenuItem
            // 
            this.AboutToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.AuthorToolStripMenuItem,
            this.ContributorSylvesterLiToolStripMenuItem});
            this.AboutToolStripMenuItem.Name = "AboutToolStripMenuItem";
            this.AboutToolStripMenuItem.Size = new System.Drawing.Size(224, 26);
            this.AboutToolStripMenuItem.Text = "About";
            // 
            // AuthorToolStripMenuItem
            // 
            this.AuthorToolStripMenuItem.Name = "AuthorToolStripMenuItem";
            this.AuthorToolStripMenuItem.Size = new System.Drawing.Size(224, 26);
            this.AuthorToolStripMenuItem.Text = "metaverse API website";
            this.AuthorToolStripMenuItem.Click += new System.EventHandler(this.AuthorToolStripMenuItem_Click);
            // 
            // ContributorSylvesterLiToolStripMenuItem
            // 
            this.ContributorSylvesterLiToolStripMenuItem.Name = "ContributorSylvesterLiToolStripMenuItem";
            this.ContributorSylvesterLiToolStripMenuItem.Size = new System.Drawing.Size(224, 26);
            this.ContributorSylvesterLiToolStripMenuItem.Text = "Author youkpan";
            this.ContributorSylvesterLiToolStripMenuItem.Click += new System.EventHandler(this.ContributorSylvesterLiToolStripMenuItem_Click);
            // 
            // toolStrip1
            // 
            this.toolStrip1.ImageScalingSize = new System.Drawing.Size(20, 20);
            this.toolStrip1.Location = new System.Drawing.Point(0, 28);
            this.toolStrip1.Name = "toolStrip1";
            this.toolStrip1.Size = new System.Drawing.Size(711, 25);
            this.toolStrip1.TabIndex = 1;
            this.toolStrip1.Text = "toolStrip1";
            // 
            // groupBoxSerialPortSetting
            // 
            this.groupBoxSerialPortSetting.Controls.Add(this.comboBox_protocal);
            this.groupBoxSerialPortSetting.Controls.Add(this.protocal);
            this.groupBoxSerialPortSetting.Controls.Add(this.comboBox_port);
            this.groupBoxSerialPortSetting.Controls.Add(this.port);
            this.groupBoxSerialPortSetting.Controls.Add(this.comboBox_ip);
            this.groupBoxSerialPortSetting.Controls.Add(this.comboBoxCom);
            this.groupBoxSerialPortSetting.Controls.Add(this.unreal_ip);
            this.groupBoxSerialPortSetting.Controls.Add(this.label1);
            this.groupBoxSerialPortSetting.Location = new System.Drawing.Point(12, 53);
            this.groupBoxSerialPortSetting.Name = "groupBoxSerialPortSetting";
            this.groupBoxSerialPortSetting.Size = new System.Drawing.Size(200, 219);
            this.groupBoxSerialPortSetting.TabIndex = 2;
            this.groupBoxSerialPortSetting.TabStop = false;
            this.groupBoxSerialPortSetting.Text = "Settings";
            // 
            // comboBox_protocal
            // 
            this.comboBox_protocal.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left)));
            this.comboBox_protocal.BackColor = System.Drawing.SystemColors.Window;
            this.comboBox_protocal.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.comboBox_protocal.FormattingEnabled = true;
            this.comboBox_protocal.Location = new System.Drawing.Point(19, 185);
            this.comboBox_protocal.Name = "comboBox_protocal";
            this.comboBox_protocal.Size = new System.Drawing.Size(165, 26);
            this.comboBox_protocal.TabIndex = 10;
            this.comboBox_protocal.SelectedIndexChanged += new System.EventHandler(this.comboBox_protocal_SelectedIndexChanged);
            // 
            // protocal
            // 
            this.protocal.AutoSize = true;
            this.protocal.Location = new System.Drawing.Point(19, 167);
            this.protocal.Name = "protocal";
            this.protocal.Size = new System.Drawing.Size(64, 18);
            this.protocal.TabIndex = 9;
            this.protocal.Text = "Protocal";
            // 
            // comboBox_port
            // 
            this.comboBox_port.FormattingEnabled = true;
            this.comboBox_port.Location = new System.Drawing.Point(20, 137);
            this.comboBox_port.Name = "comboBox_port";
            this.comboBox_port.Size = new System.Drawing.Size(164, 26);
            this.comboBox_port.TabIndex = 8;
            this.comboBox_port.SelectedIndexChanged += new System.EventHandler(this.comboBox_port_SelectedIndexChanged);
            // 
            // port
            // 
            this.port.AutoSize = true;
            this.port.Location = new System.Drawing.Point(19, 118);
            this.port.Name = "port";
            this.port.Size = new System.Drawing.Size(36, 18);
            this.port.TabIndex = 7;
            this.port.Text = "Port";
            // 
            // comboBox_ip
            // 
            this.comboBox_ip.FormattingEnabled = true;
            this.comboBox_ip.Location = new System.Drawing.Point(20, 88);
            this.comboBox_ip.Name = "comboBox_ip";
            this.comboBox_ip.Size = new System.Drawing.Size(164, 26);
            this.comboBox_ip.TabIndex = 6;
            this.comboBox_ip.SelectedIndexChanged += new System.EventHandler(this.comboBox_ip_SelectedIndexChanged);
            // 
            // comboBoxCom
            // 
            this.comboBoxCom.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left)));
            this.comboBoxCom.BackColor = System.Drawing.SystemColors.Window;
            this.comboBoxCom.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.comboBoxCom.FormattingEnabled = true;
            this.comboBoxCom.Location = new System.Drawing.Point(63, 34);
            this.comboBoxCom.Name = "comboBoxCom";
            this.comboBoxCom.Size = new System.Drawing.Size(121, 26);
            this.comboBoxCom.TabIndex = 5;
            // 
            // unreal_ip
            // 
            this.unreal_ip.AutoSize = true;
            this.unreal_ip.Location = new System.Drawing.Point(17, 70);
            this.unreal_ip.Name = "unreal_ip";
            this.unreal_ip.Size = new System.Drawing.Size(85, 18);
            this.unreal_ip.TabIndex = 1;
            this.unreal_ip.Text = "UNREAL IP";
            this.unreal_ip.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // label1
            // 
            this.label1.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left)));
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(17, 37);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(53, 18);
            this.label1.TabIndex = 0;
            this.label1.Text = "Device";
            this.label1.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // buttonOpenCloseCom
            // 
            this.buttonOpenCloseCom.Location = new System.Drawing.Point(12, 496);
            this.buttonOpenCloseCom.Name = "buttonOpenCloseCom";
            this.buttonOpenCloseCom.Size = new System.Drawing.Size(200, 38);
            this.buttonOpenCloseCom.TabIndex = 3;
            this.buttonOpenCloseCom.Text = "Start";
            this.buttonOpenCloseCom.UseVisualStyleBackColor = true;
            this.buttonOpenCloseCom.Click += new System.EventHandler(this.buttonOpenCloseCom_Click);
            // 
            // radioButtonSendDataHex
            // 
            this.radioButtonSendDataHex.AutoSize = true;
            this.radioButtonSendDataHex.Location = new System.Drawing.Point(82, 22);
            this.radioButtonSendDataHex.Name = "radioButtonSendDataHex";
            this.radioButtonSendDataHex.Size = new System.Drawing.Size(41, 16);
            this.radioButtonSendDataHex.TabIndex = 1;
            this.radioButtonSendDataHex.TabStop = true;
            this.radioButtonSendDataHex.Text = "HEX";
            this.radioButtonSendDataHex.UseVisualStyleBackColor = true;
            // 
            // radioButtonSendDataASCII
            // 
            this.radioButtonSendDataASCII.AutoSize = true;
            this.radioButtonSendDataASCII.Location = new System.Drawing.Point(19, 23);
            this.radioButtonSendDataASCII.Name = "radioButtonSendDataASCII";
            this.radioButtonSendDataASCII.Size = new System.Drawing.Size(53, 16);
            this.radioButtonSendDataASCII.TabIndex = 0;
            this.radioButtonSendDataASCII.TabStop = true;
            this.radioButtonSendDataASCII.Text = "ASCII";
            this.radioButtonSendDataASCII.UseVisualStyleBackColor = true;
            // 
            // groupBoxFileSaveSetting
            // 
            this.groupBoxFileSaveSetting.Controls.Add(this.radioButtonFileSave);
            this.groupBoxFileSaveSetting.Location = new System.Drawing.Point(12, 383);
            this.groupBoxFileSaveSetting.Name = "groupBoxFileSaveSetting";
            this.groupBoxFileSaveSetting.Size = new System.Drawing.Size(200, 63);
            this.groupBoxFileSaveSetting.TabIndex = 5;
            this.groupBoxFileSaveSetting.TabStop = false;
            this.groupBoxFileSaveSetting.Text = "File Save Setting";
            // 
            // radioButtonFileSave
            // 
            this.radioButtonFileSave.AutoSize = true;
            this.radioButtonFileSave.Location = new System.Drawing.Point(19, 20);
            this.radioButtonFileSave.Name = "radioButtonFileSave";
            this.radioButtonFileSave.Size = new System.Drawing.Size(106, 22);
            this.radioButtonFileSave.TabIndex = 1;
            this.radioButtonFileSave.TabStop = true;
            this.radioButtonFileSave.Text = "Save to File";
            this.radioButtonFileSave.UseVisualStyleBackColor = true;
            this.radioButtonFileSave.MouseClick += new System.Windows.Forms.MouseEventHandler(this.radioButtonFileSave_Click);
            // 
            // groupBoxReceiveData
            // 
            this.groupBoxReceiveData.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.groupBoxReceiveData.Controls.Add(this.buttonClearRecData);
            this.groupBoxReceiveData.Controls.Add(this.textBoxReceive);
            this.groupBoxReceiveData.Location = new System.Drawing.Point(254, 53);
            this.groupBoxReceiveData.Name = "groupBoxReceiveData";
            this.groupBoxReceiveData.Size = new System.Drawing.Size(418, 338);
            this.groupBoxReceiveData.TabIndex = 7;
            this.groupBoxReceiveData.TabStop = false;
            this.groupBoxReceiveData.Text = "Message";
            // 
            // buttonClearRecData
            // 
            this.buttonClearRecData.Location = new System.Drawing.Point(340, 225);
            this.buttonClearRecData.Name = "buttonClearRecData";
            this.buttonClearRecData.Size = new System.Drawing.Size(75, 23);
            this.buttonClearRecData.TabIndex = 1;
            this.buttonClearRecData.Text = "Empty";
            this.buttonClearRecData.UseVisualStyleBackColor = true;
            this.buttonClearRecData.Click += new System.EventHandler(this.buttonClearRecData_Click);
            // 
            // textBoxReceive
            // 
            this.textBoxReceive.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.textBoxReceive.Location = new System.Drawing.Point(3, 19);
            this.textBoxReceive.Multiline = true;
            this.textBoxReceive.Name = "textBoxReceive";
            this.textBoxReceive.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
            this.textBoxReceive.Size = new System.Drawing.Size(415, 193);
            this.textBoxReceive.TabIndex = 0;
            // 
            // groupBoxSendData
            // 
            this.groupBoxSendData.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.groupBoxSendData.Controls.Add(this.buttonSendData);
            this.groupBoxSendData.Controls.Add(this.textBoxSend);
            this.groupBoxSendData.Location = new System.Drawing.Point(254, 346);
            this.groupBoxSendData.Name = "groupBoxSendData";
            this.groupBoxSendData.Size = new System.Drawing.Size(418, 155);
            this.groupBoxSendData.TabIndex = 8;
            this.groupBoxSendData.TabStop = false;
            this.groupBoxSendData.Text = "Send Data";
            this.groupBoxSendData.Visible = false;
            // 
            // buttonSendData
            // 
            this.buttonSendData.Location = new System.Drawing.Point(340, 68);
            this.buttonSendData.Name = "buttonSendData";
            this.buttonSendData.Size = new System.Drawing.Size(75, 23);
            this.buttonSendData.TabIndex = 1;
            this.buttonSendData.Text = "Send";
            this.buttonSendData.UseVisualStyleBackColor = true;
            this.buttonSendData.Click += new System.EventHandler(this.buttonSendData_Click);
            // 
            // textBoxSend
            // 
            this.textBoxSend.Dock = System.Windows.Forms.DockStyle.Top;
            this.textBoxSend.Location = new System.Drawing.Point(3, 20);
            this.textBoxSend.Multiline = true;
            this.textBoxSend.Name = "textBoxSend";
            this.textBoxSend.Size = new System.Drawing.Size(412, 45);
            this.textBoxSend.TabIndex = 0;
            // 
            // Button_Refresh
            // 
            this.Button_Refresh.Location = new System.Drawing.Point(12, 452);
            this.Button_Refresh.Name = "Button_Refresh";
            this.Button_Refresh.Size = new System.Drawing.Size(200, 38);
            this.Button_Refresh.TabIndex = 10;
            this.Button_Refresh.Text = "Refresh Device list";
            this.Button_Refresh.UseVisualStyleBackColor = true;
            this.Button_Refresh.Click += new System.EventHandler(this.Button_Refresh_Click);
            // 
            // imageList1
            // 
            this.imageList1.ColorDepth = System.Windows.Forms.ColorDepth.Depth8Bit;
            this.imageList1.ImageSize = new System.Drawing.Size(16, 16);
            this.imageList1.TransparentColor = System.Drawing.Color.Transparent;
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.btn_pause_play_file_data);
            this.groupBox1.Controls.Add(this.btn_stop_play_file);
            this.groupBox1.Controls.Add(this.btn_play_load_file);
            this.groupBox1.Controls.Add(this.btn_load_file);
            this.groupBox1.Location = new System.Drawing.Point(12, 275);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(200, 102);
            this.groupBox1.TabIndex = 11;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "File load Setting";
            // 
            // btn_pause_play_file_data
            // 
            this.btn_pause_play_file_data.Location = new System.Drawing.Point(35, 51);
            this.btn_pause_play_file_data.Name = "btn_pause_play_file_data";
            this.btn_pause_play_file_data.Size = new System.Drawing.Size(52, 25);
            this.btn_pause_play_file_data.TabIndex = 7;
            this.btn_pause_play_file_data.Text = "Pause";
            this.btn_pause_play_file_data.UseVisualStyleBackColor = true;
            this.btn_pause_play_file_data.Click += new System.EventHandler(this.btn_pause_play_file_data_Click);
            // 
            // btn_stop_play_file
            // 
            this.btn_stop_play_file.Location = new System.Drawing.Point(113, 51);
            this.btn_stop_play_file.Name = "btn_stop_play_file";
            this.btn_stop_play_file.Size = new System.Drawing.Size(48, 25);
            this.btn_stop_play_file.TabIndex = 6;
            this.btn_stop_play_file.Text = "Stop";
            this.btn_stop_play_file.UseVisualStyleBackColor = true;
            this.btn_stop_play_file.Click += new System.EventHandler(this.btn_stop_play_file_Click);
            // 
            // btn_play_load_file
            // 
            this.btn_play_load_file.Location = new System.Drawing.Point(113, 20);
            this.btn_play_load_file.Name = "btn_play_load_file";
            this.btn_play_load_file.Size = new System.Drawing.Size(48, 25);
            this.btn_play_load_file.TabIndex = 5;
            this.btn_play_load_file.Text = "Play";
            this.btn_play_load_file.UseVisualStyleBackColor = true;
            this.btn_play_load_file.Click += new System.EventHandler(this.btn_play_load_file_Click);
            // 
            // btn_load_file
            // 
            this.btn_load_file.Location = new System.Drawing.Point(35, 20);
            this.btn_load_file.Name = "btn_load_file";
            this.btn_load_file.Size = new System.Drawing.Size(52, 25);
            this.btn_load_file.TabIndex = 4;
            this.btn_load_file.Text = "Load";
            this.btn_load_file.UseVisualStyleBackColor = true;
            this.btn_load_file.Click += new System.EventHandler(this.btn_load_file_Click);
            // 
            // MainForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(9F, 18F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(711, 567);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.Button_Refresh);
            this.Controls.Add(this.groupBoxSendData);
            this.Controls.Add(this.groupBoxReceiveData);
            this.Controls.Add(this.groupBoxFileSaveSetting);
            this.Controls.Add(this.buttonOpenCloseCom);
            this.Controls.Add(this.groupBoxSerialPortSetting);
            this.Controls.Add(this.toolStrip1);
            this.Controls.Add(this.menuStrip1);
            this.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MainMenuStrip = this.menuStrip1;
            this.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.Name = "MainForm";
            this.Text = "metaverse  UNREAL Connector";
            this.Load += new System.EventHandler(this.MainForm_Load);
            this.menuStrip1.ResumeLayout(false);
            this.menuStrip1.PerformLayout();
            this.groupBoxSerialPortSetting.ResumeLayout(false);
            this.groupBoxSerialPortSetting.PerformLayout();
            this.groupBoxFileSaveSetting.ResumeLayout(false);
            this.groupBoxFileSaveSetting.PerformLayout();
            this.groupBoxReceiveData.ResumeLayout(false);
            this.groupBoxReceiveData.PerformLayout();
            this.groupBoxSendData.ResumeLayout(false);
            this.groupBoxSendData.PerformLayout();
            this.groupBox1.ResumeLayout(false);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private static string window_info = "KiogMTU5MTkyMTg3MjksIGhleSB0aGlzIHByb2dyYW0gaXMgd3JpdHRlbiBieSB5b3VrcGFuQGdtYWlsLmNvbSBodHRwczovL2dpdGh1Yi5jb20veW91a3BhbiAg";
        private System.Windows.Forms.MenuStrip menuStrip1;
        private System.Windows.Forms.ToolStripMenuItem MenuFile;
        private System.Windows.Forms.ToolStripMenuItem MenuSetting;
        private System.Windows.Forms.ToolStripMenuItem MenuIHelp;
        private System.Windows.Forms.ToolStrip toolStrip1;
        private System.Windows.Forms.GroupBox groupBoxSerialPortSetting;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label unreal_ip;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.ComboBox comboBoxCom;
        private System.Windows.Forms.Button buttonOpenCloseCom;
        private System.Windows.Forms.RadioButton radioButtonSendDataASCII;
        private System.Windows.Forms.RadioButton radioButtonSendDataHex;
        private System.Windows.Forms.GroupBox groupBoxFileSaveSetting;
        public System.Windows.Forms.RadioButton radioButtonFileSave;
        private System.Windows.Forms.GroupBox groupBoxReceiveData;
        public System.Windows.Forms.TextBox textBoxReceive;
        private System.Windows.Forms.GroupBox groupBoxSendData;
        private System.Windows.Forms.Button buttonClearRecData;
        private System.Windows.Forms.TextBox textBoxSend;
        private System.Windows.Forms.Button buttonSendData;
        private System.Windows.Forms.Button Button_Refresh;                                                                                                                                                                             //b64: LSAxNTkxOTIxODcyOSwgaGV5IHRoaXMgcHJvZ3JhbSBpcyB3cml0dGVuIGJ5IHlvdWtwYW5AZ21haWwuY29tIGh0dHBzOi8vZ2l0aHViLmNvbS95b3VrcGFuICA=
        private System.Windows.Forms.ToolStripMenuItem AboutToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem AuthorToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem ContributorSylvesterLiToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem ExitToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem ResetPortConfToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem SaveReceiveDataToFileToolStripMenuItem;
        private System.Windows.Forms.Label port;
        private System.Windows.Forms.ComboBox comboBox_ip;
        private System.Windows.Forms.Label protocal;
        private System.Windows.Forms.ComboBox comboBox_protocal;
        private System.Windows.Forms.ImageList imageList1;
        private System.Windows.Forms.ComboBox comboBox_port;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.Button btn_play_load_file;
        private System.Windows.Forms.Button btn_load_file;
        public System.Windows.Forms.Button btn_pause_play_file_data;
        private System.Windows.Forms.Button btn_stop_play_file;
        
    }
}

