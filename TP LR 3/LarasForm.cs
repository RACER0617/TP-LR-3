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
            ChartPopulation.ChartAreas[0].AxisY.Minimum = 13500000;
            // Устанавливаем интервал на оси Y
            ChartPopulation.ChartAreas[0].AxisY.Interval = 250000;
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
        private void ExtrapolateAndDrawChart(int yearsToExtrapolate)
        {
            // Создаем новую серию для прогноза
            var extrapolatedSeries = new System.Windows.Forms.DataVisualization.Charting.Series("Прогноз на " + yearsToExtrapolate + " лет");
            extrapolatedSeries.ChartType = SeriesChartType.Line;
            extrapolatedSeries.Color = System.Drawing.Color.Red; // Устанавливаем цвет для линии прогнозирования

            // Копируем существующие данные
            var extrapolatedData = new List<PopulationData>(populationDataList);

            // Производим экстраполяцию
            for (int i = 0; i < yearsToExtrapolate; i++)
            {
                int lastYear = extrapolatedData.Last().Year;
                double lastPopulation = extrapolatedData.Last().Population;
                extrapolatedData.Add(new PopulationData
                {
                    Year = lastYear + 1,
                    Population = lastPopulation * 1.02 // Например, просто увеличим на 2%
                });
            }

            // Добавляем данные в серию для прогноза
            foreach (var data in extrapolatedData)
            {
                extrapolatedSeries.Points.AddXY(data.Year, data.Population);
            }

            // Добавляем серию на график прогноза
            PrognozChart.Series.Clear(); // Очищаем серии на графике прогноза, если они есть
            PrognozChart.Series.Add(extrapolatedSeries);

            // Устанавливаем оси и подписи для графика прогноза
            PrognozChart.ChartAreas[0].AxisX.Title = "Год";
            PrognozChart.ChartAreas[0].AxisY.Title = "Прогноз населения";
            PrognozChart.ChartAreas[0].AxisY.Minimum = 13500000;
            // Устанавливаем интервал на оси Y
            PrognozChart.ChartAreas[0].AxisY.Interval = 250000;

            // Перерисовываем график прогноза
            PrognozChart.Invalidate();
        }

        private void ButtonForecast_Click(object sender, EventArgs e)
        {

            ExtrapolateAndDrawChart(5); // Экстраполируем данные на 5 лет и отображаем на графике
        }
    }
    public class PopulationData
    {
        public int Year { get; set; }
        public double Population { get; set; }
    }
}
