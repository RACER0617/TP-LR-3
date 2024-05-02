
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
            this.btnLoadData = new System.Windows.Forms.Button();
            this.dataGridView = new System.Windows.Forms.DataGridView();
            this.chart = new System.Windows.Forms.DataVisualization.Charting.Chart();
            this.txtMaxGainCurrency1 = new System.Windows.Forms.TextBox();
            this.txtMaxGainCurrency2 = new System.Windows.Forms.TextBox();
            this.txtMaxLossCurrency1 = new System.Windows.Forms.TextBox();
            this.txtMaxLossCurrency2 = new System.Windows.Forms.TextBox();
            this.forecastChart = new System.Windows.Forms.DataVisualization.Charting.Chart();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.chart)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.forecastChart)).BeginInit();
            this.SuspendLayout();
            // 
            // btnLoadData
            // 
            this.btnLoadData.Location = new System.Drawing.Point(12, 12);
            this.btnLoadData.Name = "btnLoadData";
            this.btnLoadData.Size = new System.Drawing.Size(75, 23);
            this.btnLoadData.TabIndex = 0;
            this.btnLoadData.Text = "Загрузить данные";
            this.btnLoadData.UseVisualStyleBackColor = true;
            this.btnLoadData.Click += new System.EventHandler(this.btnLoadData_Click);
            // 
            // dataGridView
            // 
            this.dataGridView.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridView.Location = new System.Drawing.Point(12, 50);
            this.dataGridView.Name = "dataGridView";
            this.dataGridView.Size = new System.Drawing.Size(400, 200);
            this.dataGridView.TabIndex = 1;
            // 
            // chart
            // 
            this.chart.Location = new System.Drawing.Point(12, 256);
            this.chart.Name = "chart";
            this.chart.Size = new System.Drawing.Size(400, 150);
            this.chart.TabIndex = 2;
            // 
            // txtMaxGainCurrency1
            // 
            this.txtMaxGainCurrency1.Location = new System.Drawing.Point(435, 50);
            this.txtMaxGainCurrency1.Name = "txtMaxGainCurrency1";
            this.txtMaxGainCurrency1.Size = new System.Drawing.Size(100, 20);
            this.txtMaxGainCurrency1.TabIndex = 3;
            // 
            // txtMaxGainCurrency2
            // 
            this.txtMaxGainCurrency2.Location = new System.Drawing.Point(435, 90);
            this.txtMaxGainCurrency2.Name = "txtMaxGainCurrency2";
            this.txtMaxGainCurrency2.Size = new System.Drawing.Size(100, 20);
            this.txtMaxGainCurrency2.TabIndex = 4;
            // 
            // txtMaxLossCurrency1
            // 
            this.txtMaxLossCurrency1.Location = new System.Drawing.Point(435, 130);
            this.txtMaxLossCurrency1.Name = "txtMaxLossCurrency1";
            this.txtMaxLossCurrency1.Size = new System.Drawing.Size(100, 20);
            this.txtMaxLossCurrency1.TabIndex = 5;
            // 
            // txtMaxLossCurrency2
            // 
            this.txtMaxLossCurrency2.Location = new System.Drawing.Point(435, 170);
            this.txtMaxLossCurrency2.Name = "txtMaxLossCurrency2";
            this.txtMaxLossCurrency2.Size = new System.Drawing.Size(100, 20);
            this.txtMaxLossCurrency2.TabIndex = 6;
            // 
            // forecastChart
            // 
            this.forecastChart.Location = new System.Drawing.Point(435, 256);
            this.forecastChart.Name = "forecastChart";
            this.forecastChart.Size = new System.Drawing.Size(350, 150);
            this.forecastChart.TabIndex = 7;
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.forecastChart);
            this.Controls.Add(this.txtMaxLossCurrency2);
            this.Controls.Add(this.txtMaxLossCurrency1);
            this.Controls.Add(this.txtMaxGainCurrency2);
            this.Controls.Add(this.txtMaxGainCurrency1);
            this.Controls.Add(this.chart);
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
    }
}

