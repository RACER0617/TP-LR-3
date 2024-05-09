using System;
using System.Collections.Generic;
using System.Globalization;
using System.IO;
using System.Linq;
using System.Windows.Forms;
using System.Windows.Forms.DataVisualization.Charting;
using CsvHelper;
using CsvHelper.Configuration;
using LiveCharts;
using LiveCharts.Defaults;
using LiveCharts.WinForms;
using LiveCharts.Wpf;
using Microsoft.Win32;

namespace TP_LR_3
{
    public partial class LarasForm : Form
    {
        private List<PopulationData> populationDataList;

        public LarasForm()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            // Добавляем ось X с заголовком "Год"
            ChartPopulation.ChartAreas[0].AxisX.Title = "Год";

            // Добавляем ось Y с заголовком "Численность населения"
            ChartPopulation.ChartAreas[0].AxisY.Title = "Численность населения";
        }

        private void ButtonOpenFile_Click(object sender, EventArgs e)
        {
            if (openFileDialog1.ShowDialog() == DialogResult.OK)
            {
                var csvConfig = new CsvConfiguration(CultureInfo.InvariantCulture)
                {
                    Delimiter = ";", // Указываем табуляцию как разделитель
                    HeaderValidated = null // Игнорируем проверку заголовков
                };

                using (var reader = new StreamReader(openFileDialog1.FileName))
                using (var csv = new CsvReader(reader, csvConfig))
                {
                    populationDataList = csv.GetRecords<PopulationData>().ToList();
                }

                DisplayDataInTable();
                DrawPopulationChart();
                CalculateGrowthAndDecline();
            }
        }

        private void DisplayDataInTable()
        {
            DataGridView.DataSource = populationDataList;
        }

        private void DrawPopulationChart()
        {
            ChartPopulation.Series.Clear();
            var series = ChartPopulation.Series.Add("Численность населения России");
            series.ChartType = SeriesChartType.Line;

            foreach (var data in populationDataList)
            {
                series.Points.AddXY(data.Year, data.Population);
            }
        }


        private void CalculateGrowthAndDecline()
        {
            double maxGrowth = 0;
            double maxDecline = 0;
            for (int i = 1; i < populationDataList.Count; i++)
            {
                double growthRate = (populationDataList[i].Population - populationDataList[i - 1].Population) / populationDataList[i - 1].Population * 100;
                if (growthRate > maxGrowth)
                {
                    maxGrowth = growthRate;
                }
                else if (growthRate < maxDecline)
                {
                    maxDecline = growthRate;
                }
            }

            IblMaxGrowth.Text = $"{maxGrowth}%";
            IblMaxDecline.Text = $"{maxDecline}%";
        }
    }

    public class PopulationData
    {
        public int Year { get; set; }
        public double Population { get; set; }
    }
}
