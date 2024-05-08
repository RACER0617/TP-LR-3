
namespace TP_LR_3
{
    partial class LarasForm
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

        #region Код, автоматически созданный конструктором форм Windows

        /// <summary>
        /// Требуемый метод для поддержки конструктора — не изменяйте 
        /// содержимое этого метода с помощью редактора кода.
        /// </summary>
        private void InitializeComponent()
        {
            System.Windows.Forms.DataVisualization.Charting.ChartArea chartArea1 = new System.Windows.Forms.DataVisualization.Charting.ChartArea();
            System.Windows.Forms.DataVisualization.Charting.Legend legend1 = new System.Windows.Forms.DataVisualization.Charting.Legend();
            System.Windows.Forms.DataVisualization.Charting.Series series1 = new System.Windows.Forms.DataVisualization.Charting.Series();
            this.ChartPopulation = new System.Windows.Forms.DataVisualization.Charting.Chart();
            this.openFileDialog1 = new System.Windows.Forms.OpenFileDialog();
            this.IblMaxGrowth = new System.Windows.Forms.Label();
            this.IblMaxDecline = new System.Windows.Forms.Label();
            this.DataGridView = new System.Windows.Forms.DataGridView();
            this.ButtonOpenFile = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.ChartPopulation)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.DataGridView)).BeginInit();
            this.SuspendLayout();
            // 
            // ChartPopulation
            // 
            chartArea1.Name = "ChartArea1";
            this.ChartPopulation.ChartAreas.Add(chartArea1);
            legend1.Name = "Legend1";
            this.ChartPopulation.Legends.Add(legend1);
            this.ChartPopulation.Location = new System.Drawing.Point(476, 61);
            this.ChartPopulation.Name = "ChartPopulation";
            series1.ChartArea = "ChartArea1";
            series1.Legend = "Legend1";
            series1.Name = "Series1";
            this.ChartPopulation.Series.Add(series1);
            this.ChartPopulation.Size = new System.Drawing.Size(829, 496);
            this.ChartPopulation.TabIndex = 0;
            this.ChartPopulation.Text = "chart1";
            // 
            // openFileDialog1
            // 
            this.openFileDialog1.FileName = "openFileDialog1";
            // 
            // IblMaxGrowth
            // 
            this.IblMaxGrowth.AutoSize = true;
            this.IblMaxGrowth.Location = new System.Drawing.Point(21, 39);
            this.IblMaxGrowth.Name = "IblMaxGrowth";
            this.IblMaxGrowth.Size = new System.Drawing.Size(35, 13);
            this.IblMaxGrowth.TabIndex = 1;
            this.IblMaxGrowth.Text = "label1";
            // 
            // IblMaxDecline
            // 
            this.IblMaxDecline.AutoSize = true;
            this.IblMaxDecline.Location = new System.Drawing.Point(21, 159);
            this.IblMaxDecline.Name = "IblMaxDecline";
            this.IblMaxDecline.Size = new System.Drawing.Size(35, 13);
            this.IblMaxDecline.TabIndex = 2;
            this.IblMaxDecline.Text = "label2";
            // 
            // DataGridView
            // 
            this.DataGridView.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.DataGridView.Location = new System.Drawing.Point(24, 261);
            this.DataGridView.Name = "DataGridView";
            this.DataGridView.Size = new System.Drawing.Size(394, 253);
            this.DataGridView.TabIndex = 3;
            // 
            // ButtonOpenFile
            // 
            this.ButtonOpenFile.Location = new System.Drawing.Point(24, 207);
            this.ButtonOpenFile.Name = "ButtonOpenFile";
            this.ButtonOpenFile.Size = new System.Drawing.Size(75, 23);
            this.ButtonOpenFile.TabIndex = 4;
            this.ButtonOpenFile.Text = "button1";
            this.ButtonOpenFile.UseVisualStyleBackColor = true;
            this.ButtonOpenFile.Click += new System.EventHandler(this.ButtonOpenFile_Click);
            // 
            // LarasForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1392, 689);
            this.Controls.Add(this.ButtonOpenFile);
            this.Controls.Add(this.DataGridView);
            this.Controls.Add(this.IblMaxDecline);
            this.Controls.Add(this.IblMaxGrowth);
            this.Controls.Add(this.ChartPopulation);
            this.Name = "LarasForm";
            this.Text = "Form1";
            ((System.ComponentModel.ISupportInitialize)(this.ChartPopulation)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.DataGridView)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.DataVisualization.Charting.Chart ChartPopulation;
        private System.Windows.Forms.OpenFileDialog openFileDialog1;
        private System.Windows.Forms.Label IblMaxGrowth;
        private System.Windows.Forms.Label IblMaxDecline;
        private System.Windows.Forms.DataGridView DataGridView;
        private System.Windows.Forms.Button ButtonOpenFile;
    }
}

