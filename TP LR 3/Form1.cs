using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Globalization;
using System.IO;
using TP_LR_3.MODEL;
using System.Windows.Forms.DataVisualization.Charting;

namespace TP_LR_3
{
    public partial class Form1 : Form
    {
        private CurrencyMonthData monthData;
        private DataGridView dataGridView;
        private Chart chart;
        private TextBox txtMaxGainCurrency1;
        private TextBox txtMaxGainCurrency2;
        private TextBox txtMaxLossCurrency1;
        private TextBox txtMaxLossCurrency2;
        private Chart forecastChart;

        public Form1()
        {
            InitializeComponent();
            {
              
            }
        }

        
        private void btnLoadData_Click(object sender, EventArgs e)
        {
            // Диалоговое окно для выбора файла с данными
            OpenFileDialog openFileDialog = new OpenFileDialog();
            openFileDialog.Filter = "CSV files (*.csv)|*.csv";
            openFileDialog.Title = "Выберите файл с данными о курсе валют";

            if (openFileDialog.ShowDialog() == DialogResult.OK)
            {
                // Загрузка данных из файла
                monthData = LoadDataFromFile(openFileDialog.FileName);

                // Вывод данных на экран в табличном формате
                DisplayDataInTable();

                // Построение графиков зависимости от дня
                PlotExchangeRateGraph();

                // Вычисление максимального прироста и потерь рубля относительно каждой валюты
                CalculateMaxGainAndLoss();

                // Статистическое прогнозирование методом экстраполяции по скользящей средней
                PlotMovingAverageForecast();
            }
        }

        private CurrencyMonthData LoadDataFromFile(string filePath)
        {
            CurrencyMonthData data = new CurrencyMonthData();

            try
            {
                string[] lines = File.ReadAllLines(filePath);
                foreach (string line in lines)
                {
                    string[] parts = line.Split(' '); // разбиваем строку по пробелу
                    DateTime date = DateTime.ParseExact(parts[0], "dd.MM.yyyy", CultureInfo.InvariantCulture);
                    CurrencyData currencyData = new CurrencyData(date);

                    // Курсы валют могут содержать запятые, их нужно убрать
                    decimal currency1Rate = decimal.Parse(parts[1].Replace(".", CultureInfo.CurrentCulture.NumberFormat.NumberDecimalSeparator));
                    decimal currency2Rate = decimal.Parse(parts[2].Replace(".", CultureInfo.CurrentCulture.NumberFormat.NumberDecimalSeparator));

                    currencyData.AddExchangeRate("Currency1", currency1Rate);
                    currencyData.AddExchangeRate("Currency2", currency2Rate);

                    data.AddDailyData(currencyData);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Ошибка при чтении файла: " + ex.Message);
            }

            return data;
        }






        private void DisplayDataInTable()
        {
            // Здесь добавьте код для вывода данных в табличном формате на форму
            dataGridView = new DataGridView();
            dataGridView.DataSource = monthData.DailyData;
            dataGridView.Dock = DockStyle.Top;
            Controls.Add(dataGridView);
        }

        private void PlotExchangeRateGraph()
        {
            // Здесь добавьте код для построения графиков зависимости от дня на форме
            chart = new Chart();
            chart.Dock = DockStyle.Fill;
            // Добавьте код для настройки графика
            Controls.Add(chart);
        }

        private void CalculateMaxGainAndLoss()
        {
            // Здесь добавьте код для вычисления максимального прироста и потерь рубля относительно каждой валюты
            // и вывод результатов на форму
            txtMaxGainCurrency1 = new TextBox();
            txtMaxGainCurrency2 = new TextBox();
            txtMaxLossCurrency1 = new TextBox();
            txtMaxLossCurrency2 = new TextBox();
            // Добавьте код для размещения текстовых полей на форме
        }

        private void PlotMovingAverageForecast()
        {
            // Здесь добавьте код для статистического прогнозирования методом экстраполяции по скользящей средней
            // и построение графика прогноза на форме
            forecastChart = new Chart();
            forecastChart.Dock = DockStyle.Bottom;
            // Добавьте код для настройки графика прогноза
            Controls.Add(forecastChart);
        }



    }
}
