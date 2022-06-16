namespace LanAgent_сервер
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
            this.btnStart = new System.Windows.Forms.Button();
            this.btnStop = new System.Windows.Forms.Button();
            this.btnSettings = new System.Windows.Forms.Button();
            this.dgvClients = new System.Windows.Forms.DataGridView();
            this.statusStrip1 = new System.Windows.Forms.StatusStrip();
            this.tslStatus = new System.Windows.Forms.ToolStripStatusLabel();
            this.notifyIcon1 = new System.Windows.Forms.NotifyIcon(this.components);
            this.timer1 = new System.Windows.Forms.Timer(this.components);
            this.Column1 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Column2 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Column3 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.TbxSearch = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.BtnSearchNext = new System.Windows.Forms.Button();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.RbtSearchIp = new System.Windows.Forms.RadioButton();
            this.RbtSearchNetName = new System.Windows.Forms.RadioButton();
            this.RbtSearchDateTime = new System.Windows.Forms.RadioButton();
            this.BtnDelEnabled = new System.Windows.Forms.Button();
            this.BtnClearAll = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.dgvClients)).BeginInit();
            this.statusStrip1.SuspendLayout();
            this.groupBox1.SuspendLayout();
            this.SuspendLayout();
            // 
            // btnStart
            // 
            this.btnStart.Location = new System.Drawing.Point(327, 10);
            this.btnStart.Margin = new System.Windows.Forms.Padding(2);
            this.btnStart.Name = "btnStart";
            this.btnStart.Size = new System.Drawing.Size(124, 22);
            this.btnStart.TabIndex = 0;
            this.btnStart.Text = "Запустить сервер";
            this.btnStart.UseVisualStyleBackColor = true;
            this.btnStart.Click += new System.EventHandler(this.btnStart_Click);
            // 
            // btnStop
            // 
            this.btnStop.Location = new System.Drawing.Point(327, 36);
            this.btnStop.Margin = new System.Windows.Forms.Padding(2);
            this.btnStop.Name = "btnStop";
            this.btnStop.Size = new System.Drawing.Size(124, 22);
            this.btnStop.TabIndex = 1;
            this.btnStop.Text = "Остановить сервер";
            this.btnStop.UseVisualStyleBackColor = true;
            this.btnStop.Click += new System.EventHandler(this.btnStop_Click);
            // 
            // btnSettings
            // 
            this.btnSettings.Location = new System.Drawing.Point(327, 61);
            this.btnSettings.Margin = new System.Windows.Forms.Padding(2);
            this.btnSettings.Name = "btnSettings";
            this.btnSettings.Size = new System.Drawing.Size(124, 22);
            this.btnSettings.TabIndex = 2;
            this.btnSettings.Text = "Настройки";
            this.btnSettings.UseVisualStyleBackColor = true;
            this.btnSettings.Click += new System.EventHandler(this.btnSettings_Click);
            // 
            // dgvClients
            // 
            this.dgvClients.AllowUserToAddRows = false;
            this.dgvClients.AllowUserToDeleteRows = false;
            this.dgvClients.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvClients.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.Column1,
            this.Column2,
            this.Column3});
            this.dgvClients.Location = new System.Drawing.Point(10, 86);
            this.dgvClients.Margin = new System.Windows.Forms.Padding(2);
            this.dgvClients.Name = "dgvClients";
            this.dgvClients.ReadOnly = true;
            this.dgvClients.RowHeadersVisible = false;
            this.dgvClients.RowTemplate.Height = 24;
            this.dgvClients.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dgvClients.Size = new System.Drawing.Size(572, 356);
            this.dgvClients.TabIndex = 3;
            this.dgvClients.CellClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgvClients_CellClick);
            this.dgvClients.CellDoubleClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgvClients_CellDoubleClick);
            // 
            // statusStrip1
            // 
            this.statusStrip1.ImageScalingSize = new System.Drawing.Size(20, 20);
            this.statusStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.tslStatus});
            this.statusStrip1.Location = new System.Drawing.Point(0, 451);
            this.statusStrip1.Name = "statusStrip1";
            this.statusStrip1.Padding = new System.Windows.Forms.Padding(1, 0, 10, 0);
            this.statusStrip1.Size = new System.Drawing.Size(593, 22);
            this.statusStrip1.TabIndex = 4;
            this.statusStrip1.Text = "statusStrip1";
            // 
            // tslStatus
            // 
            this.tslStatus.Name = "tslStatus";
            this.tslStatus.Size = new System.Drawing.Size(25, 17);
            this.tslStatus.Text = "      ";
            // 
            // notifyIcon1
            // 
            this.notifyIcon1.Icon = ((System.Drawing.Icon)(resources.GetObject("notifyIcon1.Icon")));
            this.notifyIcon1.Text = "notifyIcon1";
            this.notifyIcon1.DoubleClick += new System.EventHandler(this.notifyIcon1_DoubleClick);
            // 
            // timer1
            // 
            this.timer1.Interval = 500;
            this.timer1.Tick += new System.EventHandler(this.timer1_Tick);
            // 
            // Column1
            // 
            this.Column1.HeaderText = "IP-адрес клиента";
            this.Column1.Name = "Column1";
            this.Column1.ReadOnly = true;
            this.Column1.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable;
            this.Column1.Width = 150;
            // 
            // Column2
            // 
            this.Column2.HeaderText = "Сетевое имя";
            this.Column2.Name = "Column2";
            this.Column2.ReadOnly = true;
            this.Column2.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable;
            this.Column2.Width = 150;
            // 
            // Column3
            // 
            this.Column3.HeaderText = "Дата и время отчета";
            this.Column3.Name = "Column3";
            this.Column3.ReadOnly = true;
            this.Column3.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable;
            this.Column3.Width = 200;
            // 
            // TbxSearch
            // 
            this.TbxSearch.Location = new System.Drawing.Point(10, 63);
            this.TbxSearch.Name = "TbxSearch";
            this.TbxSearch.Size = new System.Drawing.Size(184, 20);
            this.TbxSearch.TabIndex = 5;
            this.TbxSearch.TextChanged += new System.EventHandler(this.TbxSearch_TextChanged);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(7, 4);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(89, 13);
            this.label1.TabIndex = 6;
            this.label1.Text = "Быстрый поиск:";
            // 
            // BtnSearchNext
            // 
            this.BtnSearchNext.Location = new System.Drawing.Point(200, 63);
            this.BtnSearchNext.Name = "BtnSearchNext";
            this.BtnSearchNext.Size = new System.Drawing.Size(122, 21);
            this.BtnSearchNext.TabIndex = 7;
            this.BtnSearchNext.Text = "Искать дальше";
            this.BtnSearchNext.UseVisualStyleBackColor = true;
            this.BtnSearchNext.Click += new System.EventHandler(this.BtnSearchNext_Click);
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.RbtSearchDateTime);
            this.groupBox1.Controls.Add(this.RbtSearchNetName);
            this.groupBox1.Controls.Add(this.RbtSearchIp);
            this.groupBox1.Location = new System.Drawing.Point(10, 20);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(271, 38);
            this.groupBox1.TabIndex = 8;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Искать по:";
            // 
            // RbtSearchIp
            // 
            this.RbtSearchIp.AutoSize = true;
            this.RbtSearchIp.Checked = true;
            this.RbtSearchIp.Location = new System.Drawing.Point(6, 14);
            this.RbtSearchIp.Name = "RbtSearchIp";
            this.RbtSearchIp.Size = new System.Drawing.Size(68, 17);
            this.RbtSearchIp.TabIndex = 0;
            this.RbtSearchIp.TabStop = true;
            this.RbtSearchIp.Text = "IP-адрес";
            this.RbtSearchIp.UseVisualStyleBackColor = true;
            // 
            // RbtSearchNetName
            // 
            this.RbtSearchNetName.AutoSize = true;
            this.RbtSearchNetName.Location = new System.Drawing.Point(80, 14);
            this.RbtSearchNetName.Name = "RbtSearchNetName";
            this.RbtSearchNetName.Size = new System.Drawing.Size(89, 17);
            this.RbtSearchNetName.TabIndex = 1;
            this.RbtSearchNetName.Text = "сетевое имя";
            this.RbtSearchNetName.UseVisualStyleBackColor = true;
            // 
            // RbtSearchDateTime
            // 
            this.RbtSearchDateTime.AutoSize = true;
            this.RbtSearchDateTime.Location = new System.Drawing.Point(175, 14);
            this.RbtSearchDateTime.Name = "RbtSearchDateTime";
            this.RbtSearchDateTime.Size = new System.Drawing.Size(92, 17);
            this.RbtSearchDateTime.TabIndex = 2;
            this.RbtSearchDateTime.Text = "дата и время";
            this.RbtSearchDateTime.UseVisualStyleBackColor = true;
            // 
            // BtnDelEnabled
            // 
            this.BtnDelEnabled.Location = new System.Drawing.Point(456, 36);
            this.BtnDelEnabled.Name = "BtnDelEnabled";
            this.BtnDelEnabled.Size = new System.Drawing.Size(125, 22);
            this.BtnDelEnabled.TabIndex = 9;
            this.BtnDelEnabled.Text = "Удалить выделенное";
            this.BtnDelEnabled.UseVisualStyleBackColor = true;
            this.BtnDelEnabled.Click += new System.EventHandler(this.BtnDelEnabled_Click);
            // 
            // BtnClearAll
            // 
            this.BtnClearAll.Location = new System.Drawing.Point(456, 61);
            this.BtnClearAll.Name = "BtnClearAll";
            this.BtnClearAll.Size = new System.Drawing.Size(125, 23);
            this.BtnClearAll.TabIndex = 10;
            this.BtnClearAll.Text = "Очистить все";
            this.BtnClearAll.UseVisualStyleBackColor = true;
            this.BtnClearAll.Click += new System.EventHandler(this.BtnClearAll_Click);
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(593, 473);
            this.Controls.Add(this.BtnClearAll);
            this.Controls.Add(this.BtnDelEnabled);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.BtnSearchNext);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.TbxSearch);
            this.Controls.Add(this.statusStrip1);
            this.Controls.Add(this.dgvClients);
            this.Controls.Add(this.btnSettings);
            this.Controls.Add(this.btnStop);
            this.Controls.Add(this.btnStart);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.Fixed3D;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Margin = new System.Windows.Forms.Padding(2);
            this.MaximizeBox = false;
            this.Name = "Form1";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "LanAgent (сервер)";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.Form1_FormClosing);
            this.Load += new System.EventHandler(this.Form1_Load);
            this.Resize += new System.EventHandler(this.Form1_Resize);
            ((System.ComponentModel.ISupportInitialize)(this.dgvClients)).EndInit();
            this.statusStrip1.ResumeLayout(false);
            this.statusStrip1.PerformLayout();
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button btnStart;
        private System.Windows.Forms.Button btnStop;
        private System.Windows.Forms.Button btnSettings;
        private System.Windows.Forms.DataGridView dgvClients;
        private System.Windows.Forms.StatusStrip statusStrip1;
        private System.Windows.Forms.ToolStripStatusLabel tslStatus;
        private System.Windows.Forms.NotifyIcon notifyIcon1;
        private System.Windows.Forms.Timer timer1;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column1;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column2;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column3;
        private System.Windows.Forms.TextBox TbxSearch;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button BtnSearchNext;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.RadioButton RbtSearchDateTime;
        private System.Windows.Forms.RadioButton RbtSearchNetName;
        private System.Windows.Forms.RadioButton RbtSearchIp;
        private System.Windows.Forms.Button BtnDelEnabled;
        private System.Windows.Forms.Button BtnClearAll;
    }
}

