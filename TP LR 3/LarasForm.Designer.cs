
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
            System.Windows.Forms.DataVisualization.Charting.ChartArea chartArea2 = new System.Windows.Forms.DataVisualization.Charting.ChartArea();
            System.Windows.Forms.DataVisualization.Charting.Legend legend2 = new System.Windows.Forms.DataVisualization.Charting.Legend();
            System.Windows.Forms.DataVisualization.Charting.Series series2 = new System.Windows.Forms.DataVisualization.Charting.Series();
            this.ChartPopulation = new System.Windows.Forms.DataVisualization.Charting.Chart();
            this.openFileDialog1 = new System.Windows.Forms.OpenFileDialog();
            this.IblMaxGrowth = new System.Windows.Forms.Label();
            this.IblMaxDecline = new System.Windows.Forms.Label();
            this.DataGridView = new System.Windows.Forms.DataGridView();
            this.ButtonOpenFile = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.ButtonForecast = new System.Windows.Forms.Button();
            this.panel1 = new System.Windows.Forms.Panel();
            ((System.ComponentModel.ISupportInitialize)(this.ChartPopulation)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.DataGridView)).BeginInit();
            this.panel1.SuspendLayout();
            this.SuspendLayout();
            // 
            // ChartPopulation
            // 
            chartArea2.Name = "ChartArea1";
            this.ChartPopulation.ChartAreas.Add(chartArea2);
            legend2.Name = "Legend1";
            this.ChartPopulation.Legends.Add(legend2);
            this.ChartPopulation.Location = new System.Drawing.Point(449, 12);
            this.ChartPopulation.Name = "ChartPopulation";
            series2.ChartArea = "ChartArea1";
            series2.Legend = "Legend1";
            series2.Name = "Series1";
            this.ChartPopulation.Series.Add(series2);
            this.ChartPopulation.Size = new System.Drawing.Size(788, 359);
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
            this.IblMaxGrowth.Font = new System.Drawing.Font("Modern No. 20", 18F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.IblMaxGrowth.Location = new System.Drawing.Point(14, 53);
            this.IblMaxGrowth.Name = "IblMaxGrowth";
            this.IblMaxGrowth.Size = new System.Drawing.Size(68, 25);
            this.IblMaxGrowth.TabIndex = 1;
            this.IblMaxGrowth.Text = "fgdhh";
            // 
            // IblMaxDecline
            // 
            this.IblMaxDecline.AutoSize = true;
            this.IblMaxDecline.Font = new System.Drawing.Font("Modern No. 20", 18F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.IblMaxDecline.Location = new System.Drawing.Point(14, 124);
            this.IblMaxDecline.Name = "IblMaxDecline";
            this.IblMaxDecline.Size = new System.Drawing.Size(74, 25);
            this.IblMaxDecline.TabIndex = 2;
            this.IblMaxDecline.Text = "fghgfh";
            // 
            // DataGridView
            // 
            this.DataGridView.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.DataGridView.Location = new System.Drawing.Point(24, 261);
            this.DataGridView.Name = "DataGridView";
            this.DataGridView.Size = new System.Drawing.Size(262, 332);
            this.DataGridView.TabIndex = 3;
            // 
            // ButtonOpenFile
            // 
            this.ButtonOpenFile.Location = new System.Drawing.Point(24, 201);
            this.ButtonOpenFile.Name = "ButtonOpenFile";
            this.ButtonOpenFile.Size = new System.Drawing.Size(129, 42);
            this.ButtonOpenFile.TabIndex = 4;
            this.ButtonOpenFile.Text = "Загрузить файл";
            this.ButtonOpenFile.UseVisualStyleBackColor = true;
            this.ButtonOpenFile.Click += new System.EventHandler(this.ButtonOpenFile_Click);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Modern No. 20", 18F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(3, 13);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(331, 25);
            this.label1.TabIndex = 5;
            this.label1.Text = "Максимальный прирост населения";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Modern No. 20", 18F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.Location = new System.Drawing.Point(3, 87);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(306, 25);
            this.label2.TabIndex = 6;
            this.label2.Text = "Максимальная убыль населения";
            // 
            // ButtonForecast
            // 
            this.ButtonForecast.Location = new System.Drawing.Point(159, 201);
            this.ButtonForecast.Name = "ButtonForecast";
            this.ButtonForecast.Size = new System.Drawing.Size(129, 42);
            this.ButtonForecast.TabIndex = 7;
            this.ButtonForecast.Text = "Прогноз на N лет по скользящей средней";
            this.ButtonForecast.UseVisualStyleBackColor = true;
            this.ButtonForecast.Click += new System.EventHandler(this.ButtonForecast_Click);
            // 
            // panel1
            // 
            this.panel1.BackColor = System.Drawing.SystemColors.ButtonHighlight;
            this.panel1.Controls.Add(this.label2);
            this.panel1.Controls.Add(this.label1);
            this.panel1.Controls.Add(this.IblMaxDecline);
            this.panel1.Controls.Add(this.IblMaxGrowth);
            this.panel1.Location = new System.Drawing.Point(24, 12);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(419, 166);
            this.panel1.TabIndex = 8;
            // 
            // LarasForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1392, 645);
            this.Controls.Add(this.ButtonForecast);
            this.Controls.Add(this.ButtonOpenFile);
            this.Controls.Add(this.DataGridView);
            this.Controls.Add(this.ChartPopulation);
            this.Controls.Add(this.panel1);
            this.Name = "LarasForm";
            this.Text = "Form1";
            ((System.ComponentModel.ISupportInitialize)(this.ChartPopulation)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.DataGridView)).EndInit();
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.DataVisualization.Charting.Chart ChartPopulation;
        private System.Windows.Forms.OpenFileDialog openFileDialog1;
        private System.Windows.Forms.Label IblMaxGrowth;
        private System.Windows.Forms.Label IblMaxDecline;
        private System.Windows.Forms.DataGridView DataGridView;
        private System.Windows.Forms.Button ButtonOpenFile;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Button ButtonForecast;
        private System.Windows.Forms.Panel panel1;
    }
}

