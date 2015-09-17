namespace PrinterScanner
{
	partial class MainForm
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
			this.textBoxIpFrom = new System.Windows.Forms.TextBox();
			this.textBoxIpTo = new System.Windows.Forms.TextBox();
			this.radioButtonSearchIp = new System.Windows.Forms.RadioButton();
			this.radioButtonUseList = new System.Windows.Forms.RadioButton();
			this.panelRadioButton = new System.Windows.Forms.Panel();
			this.label2 = new System.Windows.Forms.Label();
			this.label1 = new System.Windows.Forms.Label();
			this.buttonScanRefresh = new System.Windows.Forms.Button();
			this.dataGridViewPrinters = new System.Windows.Forms.DataGridView();
			this.dataGridViewTextBoxColumn8 = new System.Windows.Forms.DataGridViewTextBoxColumn();
			this.dataGridViewTextBoxColumn9 = new System.Windows.Forms.DataGridViewTextBoxColumn();
			this.dataGridViewTextBoxColumn10 = new System.Windows.Forms.DataGridViewTextBoxColumn();
			this.lastStatusDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
			this.printerBindingSource = new System.Windows.Forms.BindingSource(this.components);
			this.buttonClean = new System.Windows.Forms.Button();
			this.textBoxCommunity = new System.Windows.Forms.TextBox();
			this.label3 = new System.Windows.Forms.Label();
			this.backgroundWorker = new System.ComponentModel.BackgroundWorker();
			this.progressBar = new System.Windows.Forms.ProgressBar();
			this.panelRadioButton.SuspendLayout();
			((System.ComponentModel.ISupportInitialize)(this.dataGridViewPrinters)).BeginInit();
			((System.ComponentModel.ISupportInitialize)(this.printerBindingSource)).BeginInit();
			this.SuspendLayout();
			// 
			// textBoxIpFrom
			// 
			this.textBoxIpFrom.Location = new System.Drawing.Point(315, 2);
			this.textBoxIpFrom.Name = "textBoxIpFrom";
			this.textBoxIpFrom.Size = new System.Drawing.Size(136, 20);
			this.textBoxIpFrom.TabIndex = 2;
			this.textBoxIpFrom.Text = "172.16.0.89";
			// 
			// textBoxIpTo
			// 
			this.textBoxIpTo.Location = new System.Drawing.Point(541, 2);
			this.textBoxIpTo.Name = "textBoxIpTo";
			this.textBoxIpTo.Size = new System.Drawing.Size(136, 20);
			this.textBoxIpTo.TabIndex = 3;
			this.textBoxIpTo.Text = "172.16.0.110";
			// 
			// radioButtonSearchIp
			// 
			this.radioButtonSearchIp.AutoSize = true;
			this.radioButtonSearchIp.Checked = true;
			this.radioButtonSearchIp.Location = new System.Drawing.Point(3, 3);
			this.radioButtonSearchIp.Name = "radioButtonSearchIp";
			this.radioButtonSearchIp.Size = new System.Drawing.Size(205, 17);
			this.radioButtonSearchIp.TabIndex = 0;
			this.radioButtonSearchIp.TabStop = true;
			this.radioButtonSearchIp.Text = "Poszukiwanie czynnych usług SNMP:";
			this.radioButtonSearchIp.UseVisualStyleBackColor = true;
			this.radioButtonSearchIp.CheckedChanged += new System.EventHandler(this.CheckedChanged);
			// 
			// radioButtonUseList
			// 
			this.radioButtonUseList.AutoSize = true;
			this.radioButtonUseList.Location = new System.Drawing.Point(3, 26);
			this.radioButtonUseList.Name = "radioButtonUseList";
			this.radioButtonUseList.Size = new System.Drawing.Size(178, 17);
			this.radioButtonUseList.TabIndex = 1;
			this.radioButtonUseList.TabStop = true;
			this.radioButtonUseList.Text = "Użyj listy wcześniej znalezionych";
			this.radioButtonUseList.UseVisualStyleBackColor = true;
			this.radioButtonUseList.CheckedChanged += new System.EventHandler(this.CheckedChanged);
			// 
			// panelRadioButton
			// 
			this.panelRadioButton.Controls.Add(this.label2);
			this.panelRadioButton.Controls.Add(this.label1);
			this.panelRadioButton.Controls.Add(this.textBoxIpTo);
			this.panelRadioButton.Controls.Add(this.radioButtonSearchIp);
			this.panelRadioButton.Controls.Add(this.radioButtonUseList);
			this.panelRadioButton.Controls.Add(this.textBoxIpFrom);
			this.panelRadioButton.Location = new System.Drawing.Point(4, 4);
			this.panelRadioButton.Name = "panelRadioButton";
			this.panelRadioButton.Size = new System.Drawing.Size(936, 49);
			this.panelRadioButton.TabIndex = 5;
			// 
			// label2
			// 
			this.label2.AutoSize = true;
			this.label2.Location = new System.Drawing.Point(462, 5);
			this.label2.Name = "label2";
			this.label2.Size = new System.Drawing.Size(73, 13);
			this.label2.TabIndex = 6;
			this.label2.Text = "Adres IP (Do):";
			// 
			// label1
			// 
			this.label1.AutoSize = true;
			this.label1.Location = new System.Drawing.Point(236, 5);
			this.label1.Name = "label1";
			this.label1.Size = new System.Drawing.Size(73, 13);
			this.label1.TabIndex = 5;
			this.label1.Text = "Adres IP (Od):";
			// 
			// buttonScanRefresh
			// 
			this.buttonScanRefresh.Location = new System.Drawing.Point(4, 83);
			this.buttonScanRefresh.Name = "buttonScanRefresh";
			this.buttonScanRefresh.Size = new System.Drawing.Size(110, 23);
			this.buttonScanRefresh.TabIndex = 0;
			this.buttonScanRefresh.Text = "Skanuj";
			this.buttonScanRefresh.UseVisualStyleBackColor = true;
			this.buttonScanRefresh.TextChanged += new System.EventHandler(this.ButtonScanRefreshTextChanged);
			this.buttonScanRefresh.Click += new System.EventHandler(this.ButtonScanRefreshClick);
			// 
			// dataGridViewPrinters
			// 
			this.dataGridViewPrinters.AllowUserToAddRows = false;
			this.dataGridViewPrinters.AllowUserToDeleteRows = false;
			this.dataGridViewPrinters.AllowUserToResizeRows = false;
			this.dataGridViewPrinters.AutoGenerateColumns = false;
			this.dataGridViewPrinters.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
			this.dataGridViewPrinters.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.dataGridViewTextBoxColumn8,
            this.dataGridViewTextBoxColumn9,
            this.dataGridViewTextBoxColumn10,
            this.lastStatusDataGridViewTextBoxColumn});
			this.dataGridViewPrinters.DataSource = this.printerBindingSource;
			this.dataGridViewPrinters.Location = new System.Drawing.Point(4, 112);
			this.dataGridViewPrinters.MultiSelect = false;
			this.dataGridViewPrinters.Name = "dataGridViewPrinters";
			this.dataGridViewPrinters.ReadOnly = true;
			this.dataGridViewPrinters.RowHeadersVisible = false;
			this.dataGridViewPrinters.RowHeadersWidthSizeMode = System.Windows.Forms.DataGridViewRowHeadersWidthSizeMode.AutoSizeToAllHeaders;
			this.dataGridViewPrinters.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
			this.dataGridViewPrinters.ShowEditingIcon = false;
			this.dataGridViewPrinters.Size = new System.Drawing.Size(936, 271);
			this.dataGridViewPrinters.TabIndex = 6;
			// 
			// dataGridViewTextBoxColumn8
			// 
			this.dataGridViewTextBoxColumn8.DataPropertyName = "ID";
			this.dataGridViewTextBoxColumn8.HeaderText = "ID";
			this.dataGridViewTextBoxColumn8.Name = "dataGridViewTextBoxColumn8";
			this.dataGridViewTextBoxColumn8.ReadOnly = true;
			this.dataGridViewTextBoxColumn8.Visible = false;
			// 
			// dataGridViewTextBoxColumn9
			// 
			this.dataGridViewTextBoxColumn9.DataPropertyName = "IpAddress";
			this.dataGridViewTextBoxColumn9.HeaderText = "Adres IP";
			this.dataGridViewTextBoxColumn9.Name = "dataGridViewTextBoxColumn9";
			this.dataGridViewTextBoxColumn9.ReadOnly = true;
			// 
			// dataGridViewTextBoxColumn10
			// 
			this.dataGridViewTextBoxColumn10.DataPropertyName = "MacAddress";
			this.dataGridViewTextBoxColumn10.HeaderText = "Adres MAC";
			this.dataGridViewTextBoxColumn10.Name = "dataGridViewTextBoxColumn10";
			this.dataGridViewTextBoxColumn10.ReadOnly = true;
			// 
			// lastStatusDataGridViewTextBoxColumn
			// 
			this.lastStatusDataGridViewTextBoxColumn.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
			this.lastStatusDataGridViewTextBoxColumn.DataPropertyName = "LastStatus";
			this.lastStatusDataGridViewTextBoxColumn.HeaderText = "Ostatni komunikat";
			this.lastStatusDataGridViewTextBoxColumn.Name = "lastStatusDataGridViewTextBoxColumn";
			this.lastStatusDataGridViewTextBoxColumn.ReadOnly = true;
			// 
			// printerBindingSource
			// 
			this.printerBindingSource.DataSource = typeof(PrinterScanner.Printer);
			// 
			// buttonClean
			// 
			this.buttonClean.Location = new System.Drawing.Point(865, 83);
			this.buttonClean.Name = "buttonClean";
			this.buttonClean.Size = new System.Drawing.Size(75, 23);
			this.buttonClean.TabIndex = 7;
			this.buttonClean.Text = "Wyczyść";
			this.buttonClean.UseVisualStyleBackColor = true;
			this.buttonClean.Click += new System.EventHandler(this.ButtonCleanClick);
			// 
			// textBoxCommunity
			// 
			this.textBoxCommunity.Location = new System.Drawing.Point(149, 56);
			this.textBoxCommunity.Name = "textBoxCommunity";
			this.textBoxCommunity.Size = new System.Drawing.Size(123, 20);
			this.textBoxCommunity.TabIndex = 8;
			this.textBoxCommunity.Text = "public";
			// 
			// label3
			// 
			this.label3.AutoSize = true;
			this.label3.Location = new System.Drawing.Point(4, 59);
			this.label3.Name = "label3";
			this.label3.Size = new System.Drawing.Size(139, 13);
			this.label3.TabIndex = 9;
			this.label3.Text = "Community string (in. hasło):";
			// 
			// backgroundWorker
			// 
			this.backgroundWorker.WorkerReportsProgress = true;
			this.backgroundWorker.DoWork += new System.ComponentModel.DoWorkEventHandler(this.BackgroundWorkerDoWork);
			this.backgroundWorker.ProgressChanged += new System.ComponentModel.ProgressChangedEventHandler(this.BackgroundWorkerProgressChanged);
			this.backgroundWorker.RunWorkerCompleted += new System.ComponentModel.RunWorkerCompletedEventHandler(this.BackgroundWorkerRunWorkerCompleted);
			// 
			// progressBar
			// 
			this.progressBar.Location = new System.Drawing.Point(120, 83);
			this.progressBar.Name = "progressBar";
			this.progressBar.Size = new System.Drawing.Size(152, 23);
			this.progressBar.Step = 1;
			this.progressBar.TabIndex = 10;
			// 
			// MainForm
			// 
			this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			this.ClientSize = new System.Drawing.Size(945, 388);
			this.Controls.Add(this.progressBar);
			this.Controls.Add(this.label3);
			this.Controls.Add(this.textBoxCommunity);
			this.Controls.Add(this.buttonClean);
			this.Controls.Add(this.dataGridViewPrinters);
			this.Controls.Add(this.buttonScanRefresh);
			this.Controls.Add(this.panelRadioButton);
			this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
			this.Name = "MainForm";
			this.Text = "SnmpProg - Check status";
			this.Load += new System.EventHandler(this.MainFormLoad);
			this.panelRadioButton.ResumeLayout(false);
			this.panelRadioButton.PerformLayout();
			((System.ComponentModel.ISupportInitialize)(this.dataGridViewPrinters)).EndInit();
			((System.ComponentModel.ISupportInitialize)(this.printerBindingSource)).EndInit();
			this.ResumeLayout(false);
			this.PerformLayout();

		}

		#endregion

		private System.Windows.Forms.TextBox textBoxIpFrom;
		private System.Windows.Forms.TextBox textBoxIpTo;
		private System.Windows.Forms.RadioButton radioButtonSearchIp;
		private System.Windows.Forms.RadioButton radioButtonUseList;
		private System.Windows.Forms.Panel panelRadioButton;
		private System.Windows.Forms.Label label2;
		private System.Windows.Forms.Label label1;
		private System.Windows.Forms.Button buttonScanRefresh;
		private System.Windows.Forms.DataGridView dataGridViewPrinters;
		private System.Windows.Forms.DataGridViewTextBoxColumn ipAddressDataGridViewTextBoxColumn;
		private System.Windows.Forms.DataGridViewTextBoxColumn macDataGridViewTextBoxColumn;
		private System.Windows.Forms.DataGridViewTextBoxColumn lastStateDataGridViewTextBoxColumn;
		private System.Windows.Forms.DataGridViewTextBoxColumn iDDataGridViewTextBoxColumn;
		private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn1;
		private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn2;
		private System.Windows.Forms.DataGridViewTextBoxColumn macAddressDataGridViewTextBoxColumn;
		private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn3;
		private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn4;
		private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn5;
		private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn6;
		private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn7;
		private System.Windows.Forms.BindingSource printerBindingSource;
		private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn8;
		private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn9;
		private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn10;
		private System.Windows.Forms.DataGridViewTextBoxColumn lastStatusDataGridViewTextBoxColumn;
		private System.Windows.Forms.Button buttonClean;
		private System.Windows.Forms.TextBox textBoxCommunity;
		private System.Windows.Forms.Label label3;
		private System.ComponentModel.BackgroundWorker backgroundWorker;
		private System.Windows.Forms.ProgressBar progressBar;
	}
}

