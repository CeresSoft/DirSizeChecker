namespace DirSizeChecker
{
    partial class MainForm
    {
        /// <summary>
        /// 必要なデザイナー変数です。
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// 使用中のリソースをすべてクリーンアップします。
        /// </summary>
        /// <param name="disposing">マネージ リソースが破棄される場合 true、破棄されない場合は false です。</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows フォーム デザイナーで生成されたコード

        /// <summary>
        /// デザイナー サポートに必要なメソッドです。このメソッドの内容を
        /// コード エディターで変更しないでください。
        /// </summary>
        private void InitializeComponent()
        {
			this.components = new System.ComponentModel.Container();
			System.Windows.Forms.DataVisualization.Charting.ChartArea chartArea1 = new System.Windows.Forms.DataVisualization.Charting.ChartArea();
			System.Windows.Forms.DataVisualization.Charting.Legend legend1 = new System.Windows.Forms.DataVisualization.Charting.Legend();
			System.Windows.Forms.DataVisualization.Charting.Series series1 = new System.Windows.Forms.DataVisualization.Charting.Series();
			System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle1 = new System.Windows.Forms.DataGridViewCellStyle();
			System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle2 = new System.Windows.Forms.DataGridViewCellStyle();
			System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(MainForm));
			this.mainSplit = new System.Windows.Forms.SplitContainer();
			this.volumeGraph = new System.Windows.Forms.DataVisualization.Charting.Chart();
			this.directoriesBindingSource = new System.Windows.Forms.BindingSource(this.components);
			this.directoryDataSet = new DirSizeChecker.DirectoryDataSet();
			this.labelFullPath = new System.Windows.Forms.Label();
			this.buttonExecute = new DirSizeChecker.VisualButton();
			this.buttonReload = new DirSizeChecker.VisualButton();
			this.buttonMoveUp = new DirSizeChecker.VisualButton();
			this.directoryList = new System.Windows.Forms.DataGridView();
			this.bgReader = new System.ComponentModel.BackgroundWorker();
			((System.ComponentModel.ISupportInitialize)(this.mainSplit)).BeginInit();
			this.mainSplit.Panel1.SuspendLayout();
			this.mainSplit.Panel2.SuspendLayout();
			this.mainSplit.SuspendLayout();
			((System.ComponentModel.ISupportInitialize)(this.volumeGraph)).BeginInit();
			((System.ComponentModel.ISupportInitialize)(this.directoriesBindingSource)).BeginInit();
			((System.ComponentModel.ISupportInitialize)(this.directoryDataSet)).BeginInit();
			((System.ComponentModel.ISupportInitialize)(this.directoryList)).BeginInit();
			this.SuspendLayout();
			// 
			// mainSplit
			// 
			this.mainSplit.BackColor = System.Drawing.Color.White;
			this.mainSplit.Dock = System.Windows.Forms.DockStyle.Fill;
			this.mainSplit.Location = new System.Drawing.Point(0, 0);
			this.mainSplit.Margin = new System.Windows.Forms.Padding(0);
			this.mainSplit.Name = "mainSplit";
			// 
			// mainSplit.Panel1
			// 
			this.mainSplit.Panel1.BackColor = System.Drawing.Color.White;
			this.mainSplit.Panel1.Controls.Add(this.volumeGraph);
			this.mainSplit.Panel1.Controls.Add(this.labelFullPath);
			// 
			// mainSplit.Panel2
			// 
			this.mainSplit.Panel2.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(228)))), ((int)(((byte)(235)))), ((int)(((byte)(240)))));
			this.mainSplit.Panel2.Controls.Add(this.buttonExecute);
			this.mainSplit.Panel2.Controls.Add(this.buttonReload);
			this.mainSplit.Panel2.Controls.Add(this.buttonMoveUp);
			this.mainSplit.Panel2.Controls.Add(this.directoryList);
			this.mainSplit.Size = new System.Drawing.Size(640, 456);
			this.mainSplit.SplitterDistance = 398;
			this.mainSplit.SplitterWidth = 2;
			this.mainSplit.TabIndex = 1;
			// 
			// volumeGraph
			// 
			chartArea1.BorderWidth = 0;
			chartArea1.Name = "ChartArea1";
			chartArea1.Position.Auto = false;
			chartArea1.Position.Height = 82F;
			chartArea1.Position.Width = 100F;
			chartArea1.Position.Y = 1F;
			this.volumeGraph.ChartAreas.Add(chartArea1);
			this.volumeGraph.DataSource = this.directoriesBindingSource;
			this.volumeGraph.Dock = System.Windows.Forms.DockStyle.Fill;
			legend1.Docking = System.Windows.Forms.DataVisualization.Charting.Docking.Bottom;
			legend1.Font = new System.Drawing.Font("Meiryo UI", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			legend1.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(108)))), ((int)(((byte)(108)))), ((int)(((byte)(108)))));
			legend1.IsTextAutoFit = false;
			legend1.Name = "Legend1";
			this.volumeGraph.Legends.Add(legend1);
			this.volumeGraph.Location = new System.Drawing.Point(0, 24);
			this.volumeGraph.Name = "volumeGraph";
			series1.ChartArea = "ChartArea1";
			series1.ChartType = System.Windows.Forms.DataVisualization.Charting.SeriesChartType.Pie;
			series1.CustomProperties = "CollectedThreshold=5, PieStartAngle=270";
			series1.Label = "#PERCENT{P2}";
			series1.LabelForeColor = System.Drawing.Color.White;
			series1.Legend = "Legend1";
			series1.LegendText = "#VALX";
			series1.Name = "Series1";
			series1.XValueMember = "Name";
			series1.XValueType = System.Windows.Forms.DataVisualization.Charting.ChartValueType.String;
			series1.YValueMembers = "Size";
			this.volumeGraph.Series.Add(series1);
			this.volumeGraph.Size = new System.Drawing.Size(398, 432);
			this.volumeGraph.TabIndex = 0;
			this.volumeGraph.Text = "Volume Graph";
			// 
			// directoriesBindingSource
			// 
			this.directoriesBindingSource.DataMember = "Directories";
			this.directoriesBindingSource.DataSource = this.directoryDataSet;
			// 
			// directoryDataSet
			// 
			this.directoryDataSet.DataSetName = "DirectoryDataSet";
			this.directoryDataSet.SchemaSerializationMode = System.Data.SchemaSerializationMode.IncludeSchema;
			// 
			// labelFullPath
			// 
			this.labelFullPath.AutoEllipsis = true;
			this.labelFullPath.Dock = System.Windows.Forms.DockStyle.Top;
			this.labelFullPath.Font = new System.Drawing.Font("メイリオ", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(128)));
			this.labelFullPath.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(93)))), ((int)(((byte)(109)))), ((int)(((byte)(122)))));
			this.labelFullPath.Location = new System.Drawing.Point(0, 0);
			this.labelFullPath.Name = "labelFullPath";
			this.labelFullPath.Size = new System.Drawing.Size(398, 24);
			this.labelFullPath.TabIndex = 2;
			this.labelFullPath.Text = "-";
			this.labelFullPath.TextAlign = System.Drawing.ContentAlignment.TopCenter;
			// 
			// buttonExecute
			// 
			this.buttonExecute.Anchor = System.Windows.Forms.AnchorStyles.Bottom;
			this.buttonExecute.BackColor = System.Drawing.Color.Transparent;
			this.buttonExecute.BackgroundImage = global::DirSizeChecker.Properties.Resources.button_analyze;
			this.buttonExecute.FlatAppearance.BorderSize = 0;
			this.buttonExecute.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
			this.buttonExecute.ImageDisabled = global::DirSizeChecker.Properties.Resources.button_analyze_disabled;
			this.buttonExecute.ImageOnDown = global::DirSizeChecker.Properties.Resources.button_analyze_down;
			this.buttonExecute.ImageOnHover = global::DirSizeChecker.Properties.Resources.button_analyze_hover;
			this.buttonExecute.ImageOnUp = global::DirSizeChecker.Properties.Resources.button_analyze;
			this.buttonExecute.Location = new System.Drawing.Point(24, 416);
			this.buttonExecute.Name = "buttonExecute";
			this.buttonExecute.Size = new System.Drawing.Size(192, 32);
			this.buttonExecute.TabIndex = 6;
			this.buttonExecute.UseVisualStyleBackColor = false;
			this.buttonExecute.Click += new System.EventHandler(this.ButtonExecute_Click);
			// 
			// buttonReload
			// 
			this.buttonReload.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
			this.buttonReload.BackColor = System.Drawing.Color.Transparent;
			this.buttonReload.BackgroundImage = global::DirSizeChecker.Properties.Resources.button_reload;
			this.buttonReload.FlatAppearance.BorderSize = 0;
			this.buttonReload.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
			this.buttonReload.ImageDisabled = global::DirSizeChecker.Properties.Resources.button_reload_disabled;
			this.buttonReload.ImageOnDown = global::DirSizeChecker.Properties.Resources.button_reload_down;
			this.buttonReload.ImageOnHover = global::DirSizeChecker.Properties.Resources.button_reload_hover;
			this.buttonReload.ImageOnUp = global::DirSizeChecker.Properties.Resources.button_reload;
			this.buttonReload.Location = new System.Drawing.Point(176, 8);
			this.buttonReload.Name = "buttonReload";
			this.buttonReload.Size = new System.Drawing.Size(56, 32);
			this.buttonReload.TabIndex = 5;
			this.buttonReload.UseVisualStyleBackColor = false;
			this.buttonReload.Click += new System.EventHandler(this.ButtonReload_Click);
			// 
			// buttonMoveUp
			// 
			this.buttonMoveUp.BackColor = System.Drawing.Color.Transparent;
			this.buttonMoveUp.BackgroundImage = global::DirSizeChecker.Properties.Resources.button_up;
			this.buttonMoveUp.FlatAppearance.BorderSize = 0;
			this.buttonMoveUp.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
			this.buttonMoveUp.ImageDisabled = global::DirSizeChecker.Properties.Resources.button_up_disabled;
			this.buttonMoveUp.ImageOnDown = global::DirSizeChecker.Properties.Resources.button_up_down;
			this.buttonMoveUp.ImageOnHover = global::DirSizeChecker.Properties.Resources.button_up_hover;
			this.buttonMoveUp.ImageOnUp = global::DirSizeChecker.Properties.Resources.button_up;
			this.buttonMoveUp.Location = new System.Drawing.Point(8, 0);
			this.buttonMoveUp.Name = "buttonMoveUp";
			this.buttonMoveUp.Size = new System.Drawing.Size(80, 32);
			this.buttonMoveUp.TabIndex = 4;
			this.buttonMoveUp.UseVisualStyleBackColor = false;
			this.buttonMoveUp.Click += new System.EventHandler(this.ButtonMoveUp_Click);
			// 
			// directoryList
			// 
			this.directoryList.AllowUserToAddRows = false;
			this.directoryList.AllowUserToDeleteRows = false;
			this.directoryList.AllowUserToResizeRows = false;
			this.directoryList.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
			this.directoryList.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
			this.directoryList.BackgroundColor = System.Drawing.SystemColors.Window;
			this.directoryList.CellBorderStyle = System.Windows.Forms.DataGridViewCellBorderStyle.SingleHorizontal;
			this.directoryList.ColumnHeadersBorderStyle = System.Windows.Forms.DataGridViewHeaderBorderStyle.None;
			dataGridViewCellStyle1.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
			dataGridViewCellStyle1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(155)))), ((int)(((byte)(183)))), ((int)(((byte)(204)))));
			dataGridViewCellStyle1.Font = new System.Drawing.Font("メイリオ", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(128)));
			dataGridViewCellStyle1.ForeColor = System.Drawing.Color.White;
			dataGridViewCellStyle1.SelectionBackColor = System.Drawing.Color.LightSlateGray;
			dataGridViewCellStyle1.SelectionForeColor = System.Drawing.Color.White;
			dataGridViewCellStyle1.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
			this.directoryList.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle1;
			this.directoryList.ColumnHeadersHeight = 24;
			this.directoryList.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.DisableResizing;
			dataGridViewCellStyle2.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
			dataGridViewCellStyle2.BackColor = System.Drawing.SystemColors.Window;
			dataGridViewCellStyle2.Font = new System.Drawing.Font("メイリオ", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(128)));
			dataGridViewCellStyle2.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(93)))), ((int)(((byte)(109)))), ((int)(((byte)(122)))));
			dataGridViewCellStyle2.Padding = new System.Windows.Forms.Padding(8, 0, 0, 0);
			dataGridViewCellStyle2.SelectionBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(190)))), ((int)(((byte)(208)))), ((int)(((byte)(220)))));
			dataGridViewCellStyle2.SelectionForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(93)))), ((int)(((byte)(109)))), ((int)(((byte)(122)))));
			dataGridViewCellStyle2.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
			this.directoryList.DefaultCellStyle = dataGridViewCellStyle2;
			this.directoryList.EnableHeadersVisualStyles = false;
			this.directoryList.GridColor = System.Drawing.Color.FromArgb(((int)(((byte)(228)))), ((int)(((byte)(235)))), ((int)(((byte)(240)))));
			this.directoryList.Location = new System.Drawing.Point(8, 40);
			this.directoryList.MultiSelect = false;
			this.directoryList.Name = "directoryList";
			this.directoryList.ReadOnly = true;
			this.directoryList.RowHeadersVisible = false;
			this.directoryList.RowTemplate.Height = 32;
			this.directoryList.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
			this.directoryList.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
			this.directoryList.Size = new System.Drawing.Size(224, 368);
			this.directoryList.TabIndex = 3;
			this.directoryList.DataError += new System.Windows.Forms.DataGridViewDataErrorEventHandler(this.directoryList_DataError);
			this.directoryList.Sorted += new System.EventHandler(this.directoryList_Sorted);
			// 
			// bgReader
			// 
			this.bgReader.WorkerReportsProgress = true;
			this.bgReader.DoWork += new System.ComponentModel.DoWorkEventHandler(this.bgReader_DoWork);
			this.bgReader.ProgressChanged += new System.ComponentModel.ProgressChangedEventHandler(this.bgReader_ProgressChanged);
			this.bgReader.RunWorkerCompleted += new System.ComponentModel.RunWorkerCompletedEventHandler(this.bgReader_RunWorkerCompleted);
			// 
			// MainForm
			// 
			this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			this.ClientSize = new System.Drawing.Size(640, 456);
			this.Controls.Add(this.mainSplit);
			this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
			this.Name = "MainForm";
			this.Text = "DirSizeChecker";
			this.Load += new System.EventHandler(this.MainForm_Load);
			this.mainSplit.Panel1.ResumeLayout(false);
			this.mainSplit.Panel2.ResumeLayout(false);
			((System.ComponentModel.ISupportInitialize)(this.mainSplit)).EndInit();
			this.mainSplit.ResumeLayout(false);
			((System.ComponentModel.ISupportInitialize)(this.volumeGraph)).EndInit();
			((System.ComponentModel.ISupportInitialize)(this.directoriesBindingSource)).EndInit();
			((System.ComponentModel.ISupportInitialize)(this.directoryDataSet)).EndInit();
			((System.ComponentModel.ISupportInitialize)(this.directoryList)).EndInit();
			this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.SplitContainer mainSplit;
        private System.Windows.Forms.DataVisualization.Charting.Chart volumeGraph;
        private System.Windows.Forms.Label labelFullPath;
        private System.Windows.Forms.DataGridView directoryList;
        private System.ComponentModel.BackgroundWorker bgReader;
        private VisualButton buttonMoveUp;
        private VisualButton buttonReload;
		private VisualButton buttonExecute;
		private System.Windows.Forms.BindingSource directoriesBindingSource;
		private DirectoryDataSet directoryDataSet;
    }
}

