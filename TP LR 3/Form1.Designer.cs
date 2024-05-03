
namespace TP_LR_3
{
    partial class Form1
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
            System.Windows.Forms.DataVisualization.Charting.ChartArea chartArea2 = new System.Windows.Forms.DataVisualization.Charting.ChartArea();
            System.Windows.Forms.DataVisualization.Charting.Legend legend2 = new System.Windows.Forms.DataVisualization.Charting.Legend();
            System.Windows.Forms.DataVisualization.Charting.Series series2 = new System.Windows.Forms.DataVisualization.Charting.Series();
            this.btnLoadData = new System.Windows.Forms.Button();
            this.txtMaxGainCurrency1 = new System.Windows.Forms.TextBox();
            this.txtMaxGainCurrency2 = new System.Windows.Forms.TextBox();
            this.txtMaxLossCurrency1 = new System.Windows.Forms.TextBox();
            this.txtMaxLossCurrency2 = new System.Windows.Forms.TextBox();
            this.dataGridView = new System.Windows.Forms.DataGridView();
            this.Data = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Currency1 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Currency2 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.chart = new System.Windows.Forms.DataVisualization.Charting.Chart();
            this.forecastChart = new System.Windows.Forms.DataVisualization.Charting.Chart();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.chart)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.forecastChart)).BeginInit();
            this.SuspendLayout();
            // 
            // btnLoadData
            // 
            this.btnLoadData.Location = new System.Drawing.Point(503, 298);
            this.btnLoadData.Name = "btnLoadData";
            this.btnLoadData.Size = new System.Drawing.Size(75, 23);
            this.btnLoadData.TabIndex = 0;
            this.btnLoadData.Text = "Загрузить данные";
            this.btnLoadData.UseVisualStyleBackColor = true;
            this.btnLoadData.Click += new System.EventHandler(this.btnLoadData_Click);
            // 
            // txtMaxGainCurrency1
            // 
            this.txtMaxGainCurrency1.Location = new System.Drawing.Point(12, 298);
            this.txtMaxGainCurrency1.Name = "txtMaxGainCurrency1";
            this.txtMaxGainCurrency1.Size = new System.Drawing.Size(100, 20);
            this.txtMaxGainCurrency1.TabIndex = 3;
            // 
            // txtMaxGainCurrency2
            // 
            this.txtMaxGainCurrency2.Location = new System.Drawing.Point(129, 298);
            this.txtMaxGainCurrency2.Name = "txtMaxGainCurrency2";
            this.txtMaxGainCurrency2.Size = new System.Drawing.Size(100, 20);
            this.txtMaxGainCurrency2.TabIndex = 4;
            // 
            // txtMaxLossCurrency1
            // 
            this.txtMaxLossCurrency1.Location = new System.Drawing.Point(248, 298);
            this.txtMaxLossCurrency1.Name = "txtMaxLossCurrency1";
            this.txtMaxLossCurrency1.Size = new System.Drawing.Size(100, 20);
            this.txtMaxLossCurrency1.TabIndex = 5;
            // 
            // txtMaxLossCurrency2
            // 
            this.txtMaxLossCurrency2.Location = new System.Drawing.Point(370, 298);
            this.txtMaxLossCurrency2.Name = "txtMaxLossCurrency2";
            this.txtMaxLossCurrency2.Size = new System.Drawing.Size(100, 20);
            this.txtMaxLossCurrency2.TabIndex = 6;
            // 
            // dataGridView
            // 
            this.dataGridView.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridView.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.Data,
            this.Currency1,
            this.Currency2});
            this.dataGridView.Location = new System.Drawing.Point(12, 50);
            this.dataGridView.Name = "dataGridView";
            this.dataGridView.Size = new System.Drawing.Size(776, 232);
            this.dataGridView.TabIndex = 1;
            // 
            // Data
            // 
            this.Data.HeaderText = "Data";
            this.Data.Name = "Data";
            // 
            // Currency1
            // 
            this.Currency1.HeaderText = "Currency1";
            this.Currency1.Name = "Currency1";
            // 
            // Currency2
            // 
            this.Currency2.HeaderText = "Currency2";
            this.Currency2.Name = "Currency2";
            // 
            // chart
            // 
            chartArea1.Name = "ChartArea1";
            this.chart.ChartAreas.Add(chartArea1);
            legend1.Name = "Legend1";
            this.chart.Legends.Add(legend1);
            this.chart.Location = new System.Drawing.Point(12, 338);
            this.chart.Name = "chart";
            series1.ChartArea = "ChartArea1";
            series1.Legend = "Legend1";
            series1.Name = "Series1";
            this.chart.Series.Add(series1);
            this.chart.Size = new System.Drawing.Size(300, 246);
            this.chart.TabIndex = 7;
            this.chart.Text = "chart";
            // 
            // forecastChart
            // 
            chartArea2.Name = "ChartArea1";
            this.forecastChart.ChartAreas.Add(chartArea2);
            legend2.Name = "Legend1";
            this.forecastChart.Legends.Add(legend2);
            this.forecastChart.Location = new System.Drawing.Point(488, 338);
            this.forecastChart.Name = "forecastChart";
            series2.ChartArea = "ChartArea1";
            series2.Legend = "Legend1";
            series2.Name = "Series1";
            this.forecastChart.Series.Add(series2);
            this.forecastChart.Size = new System.Drawing.Size(300, 246);
            this.forecastChart.TabIndex = 8;
            this.forecastChart.Text = "chart1";
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 596);
            this.Controls.Add(this.forecastChart);
            this.Controls.Add(this.chart);
            this.Controls.Add(this.txtMaxLossCurrency2);
            this.Controls.Add(this.txtMaxLossCurrency1);
            this.Controls.Add(this.txtMaxGainCurrency2);
            this.Controls.Add(this.txtMaxGainCurrency1);
            this.Controls.Add(this.dataGridView);
            this.Controls.Add(this.btnLoadData);
            this.Name = "Form1";
            this.Text = "Анализ курса валют";
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.chart)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.forecastChart)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button btnLoadData;
        private System.Windows.Forms.DataGridView dataGridView;
        private System.Windows.Forms.DataGridViewTextBoxColumn Data;
        private System.Windows.Forms.DataGridViewTextBoxColumn Currency1;
        private System.Windows.Forms.DataGridViewTextBoxColumn Currency2;
        private System.Windows.Forms.DataVisualization.Charting.Chart chart;
        private System.Windows.Forms.DataVisualization.Charting.Chart forecastChart;
    }
}

