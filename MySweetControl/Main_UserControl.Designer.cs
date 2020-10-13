namespace MySweetControl
{
    partial class Main_UserControl
    {
        /// <summary> 
        /// Обязательная переменная конструктора.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary> 
        /// Освободить все используемые ресурсы.
        /// </summary>
        /// <param name="disposing">истинно, если управляемый ресурс должен быть удален; иначе ложно.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Код, автоматически созданный конструктором компонентов

        /// <summary> 
        /// Требуемый метод для поддержки конструктора — не изменяйте 
        /// содержимое этого метода с помощью редактора кода.
        /// </summary>
        private void InitializeComponent()
        {
            this.EnterResultButton = new System.Windows.Forms.Button();
            this.ResultTextBox = new System.Windows.Forms.TextBox();
            this.panelGraphic = new System.Windows.Forms.Panel();
            this.groupBoxNewRes = new System.Windows.Forms.GroupBox();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.MainDataGridView = new System.Windows.Forms.DataGridView();
            this.groupBoxGraph = new System.Windows.Forms.GroupBox();
            this.Main_DateTimePicker = new System.Windows.Forms.DateTimePicker();
            this.groupBoxNewRes.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.MainDataGridView)).BeginInit();
            this.groupBoxGraph.SuspendLayout();
            this.SuspendLayout();
            // 
            // EnterResultButton
            // 
            this.EnterResultButton.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(125)))), ((int)(((byte)(22)))), ((int)(((byte)(176)))));
            this.EnterResultButton.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.EnterResultButton.ForeColor = System.Drawing.Color.White;
            this.EnterResultButton.Location = new System.Drawing.Point(384, 21);
            this.EnterResultButton.Name = "EnterResultButton";
            this.EnterResultButton.Size = new System.Drawing.Size(67, 24);
            this.EnterResultButton.TabIndex = 8;
            this.EnterResultButton.Text = "◆ Add ◆";
            this.EnterResultButton.UseVisualStyleBackColor = false;
            this.EnterResultButton.Click += new System.EventHandler(this.EnterResultButton_Click);
            // 
            // ResultTextBox
            // 
            this.ResultTextBox.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(15)))), ((int)(((byte)(64)))));
            this.ResultTextBox.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.ResultTextBox.ForeColor = System.Drawing.Color.White;
            this.ResultTextBox.Location = new System.Drawing.Point(13, 20);
            this.ResultTextBox.Name = "ResultTextBox";
            this.ResultTextBox.Size = new System.Drawing.Size(365, 26);
            this.ResultTextBox.TabIndex = 6;
            // 
            // panelGraphic
            // 
            this.panelGraphic.Location = new System.Drawing.Point(6, 19);
            this.panelGraphic.Name = "panelGraphic";
            this.panelGraphic.Size = new System.Drawing.Size(455, 336);
            this.panelGraphic.TabIndex = 12;
            // 
            // groupBoxNewRes
            // 
            this.groupBoxNewRes.Controls.Add(this.ResultTextBox);
            this.groupBoxNewRes.Controls.Add(this.EnterResultButton);
            this.groupBoxNewRes.ForeColor = System.Drawing.Color.White;
            this.groupBoxNewRes.Location = new System.Drawing.Point(6, 3);
            this.groupBoxNewRes.Name = "groupBoxNewRes";
            this.groupBoxNewRes.Size = new System.Drawing.Size(467, 61);
            this.groupBoxNewRes.TabIndex = 16;
            this.groupBoxNewRes.TabStop = false;
            this.groupBoxNewRes.Text = "Add new result";
            // 
            // groupBox1
            // 
            this.groupBox1.ForeColor = System.Drawing.Color.White;
            this.groupBox1.Location = new System.Drawing.Point(479, 3);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(278, 428);
            this.groupBox1.TabIndex = 17;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Last month results";
            // 
            // MainDataGridView
            // 
            this.MainDataGridView.BackgroundColor = System.Drawing.Color.FromArgb(((int)(((byte)(100)))), ((int)(((byte)(115)))), ((int)(((byte)(164)))));
            this.MainDataGridView.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.MainDataGridView.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.MainDataGridView.GridColor = System.Drawing.Color.Red;
            this.MainDataGridView.Location = new System.Drawing.Point(485, 17);
            this.MainDataGridView.Name = "MainDataGridView";
            this.MainDataGridView.ReadOnly = true;
            this.MainDataGridView.Size = new System.Drawing.Size(266, 408);
            this.MainDataGridView.TabIndex = 18;
            this.MainDataGridView.CellContentClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.MainDataGridView_CellContentClick);
            // 
            // groupBoxGraph
            // 
            this.groupBoxGraph.Controls.Add(this.panelGraphic);
            this.groupBoxGraph.ForeColor = System.Drawing.Color.White;
            this.groupBoxGraph.Location = new System.Drawing.Point(6, 70);
            this.groupBoxGraph.Name = "groupBoxGraph";
            this.groupBoxGraph.Size = new System.Drawing.Size(467, 361);
            this.groupBoxGraph.TabIndex = 19;
            this.groupBoxGraph.TabStop = false;
            this.groupBoxGraph.Text = "Graphic";
            // 
            // Main_DateTimePicker
            // 
            this.Main_DateTimePicker.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.Main_DateTimePicker.Format = System.Windows.Forms.DateTimePickerFormat.Short;
            this.Main_DateTimePicker.Location = new System.Drawing.Point(353, 98);
            this.Main_DateTimePicker.Name = "Main_DateTimePicker";
            this.Main_DateTimePicker.Size = new System.Drawing.Size(100, 26);
            this.Main_DateTimePicker.TabIndex = 20;
            this.Main_DateTimePicker.ValueChanged += new System.EventHandler(this.Main_DateTimePicker_ValueChanged);
            // 
            // Main_UserControl
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(100)))), ((int)(((byte)(115)))), ((int)(((byte)(164)))));
            this.Controls.Add(this.Main_DateTimePicker);
            this.Controls.Add(this.groupBoxGraph);
            this.Controls.Add(this.MainDataGridView);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.groupBoxNewRes);
            this.Name = "Main_UserControl";
            this.Size = new System.Drawing.Size(770, 437);
            this.groupBoxNewRes.ResumeLayout(false);
            this.groupBoxNewRes.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.MainDataGridView)).EndInit();
            this.groupBoxGraph.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion
        private System.Windows.Forms.Button EnterResultButton;
        private System.Windows.Forms.TextBox ResultTextBox;
        private System.Windows.Forms.Panel panelGraphic;
        private System.Windows.Forms.GroupBox groupBoxNewRes;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.DataGridView MainDataGridView;
        private System.Windows.Forms.GroupBox groupBoxGraph;
        private System.Windows.Forms.DateTimePicker Main_DateTimePicker;
    }
}
