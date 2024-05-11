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
    
        private List<PopulationData> populationDataList;

        private CurrencyMonthData monthData;
        private TextBox txtMaxGainCurrency1;
        private TextBox txtMaxGainCurrency2;
        private TextBox txtMaxLossCurrency1;
        private TextBox txtMaxLossCurrency2;


        public Form1()
        {
            InitializeComponent();
            // Создание и отображение таблицы по умолчанию
            CreateDefaultTable();

        }

        private void CreateDefaultTable()
        {
            // Создание таблицы с данными по умолчанию
            string defaultData = @"Date Currency1 Currency2
01.01.2024 73.50 88.20
02.01.2024 73.60 88.10
03.01.2024 75.70 88.15
04.01.2024 75.80 89.00
05.01.2024 75.90 88.65
06.01.2024 76.00 90.00
07.01.2024 76.10 89.11
08.01.2024 76.20 89.05
09.01.2024 76.30 89.34
10.01.2024 76.40 89.71";

            // Разделение строк на массив строк
            string[] lines = defaultData.Split(new[] { '\r', '\n' }, StringSplitOptions.RemoveEmptyEntries);

            // Создание столбцов таблицы (если таблица не создана)
            if (dataGridView == null)
            {
                dataGridView = new DataGridView();
                dataGridView.Dock = DockStyle.Top;
                Controls.Add(dataGridView);

                // Создание столбцов таблицы
                string[] headers = lines[0].Split(new[] { ' ' }, StringSplitOptions.RemoveEmptyEntries);
                for (int i = 0; i < headers.Length; i++)
                {
                    dataGridView.Columns.Add(headers[i], headers[i]);
                }
            }

            // Заполнение таблицы данными
            for (int i = 1; i < lines.Length; i++)
            {
                string[] row = lines[i].Split(new[] { ' ' }, StringSplitOptions.RemoveEmptyEntries);
                dataGridView.Rows.Add(row);
            }

            // Построение графика зависимости от дня
            PlotExchangeRateGraph();
        }

        private void PlotExchangeRateGraph()
        {
            // Создание объекта Series для отображения данных в элементе chart
            Series seriesChart = new Series();
            seriesChart.ChartType = SeriesChartType.Line;

            // Создание объекта Series для отображения данных в элементе forecastChart
            Series seriesForecastChart = new Series();
            seriesForecastChart.ChartType = SeriesChartType.Line;

            // Заполнение данными из таблицы defaultData
            foreach (DataGridViewRow row in dataGridView.Rows)
            {
                if (!row.IsNewRow)
                {
                    // Добавление точек на график chart
                    seriesChart.Points.AddXY(row.Cells[0].Value, row.Cells[1].Value);

                    // Добавление точек на график forecastChart
                    seriesForecastChart.Points.AddXY(row.Cells[0].Value, row.Cells[2].Value);
                }
            }

            // Добавление серии на графики
            chart.Series.Clear();
            chart.Series.Add(seriesChart);

            forecastChart.Series.Clear();
            forecastChart.Series.Add(seriesForecastChart);
        }


        private void btnLoadData_Click(object sender, EventArgs e)
        {
            // Диалоговое окно для выбора файла с данными
            OpenFileDialog openFileDialog = new OpenFileDialog();
            openFileDialog.Filter = "CSV files (*.csv)|*.csv";
            openFileDialog.Title = "Выберите файл с данными о курсе валют";

            if (openFileDialog.ShowDialog() == DialogResult.OK)
            {
                // Обновление данных в таблице и графике
                UpdateTableAndGraph(openFileDialog.FileName);

                // Вычисление максимального прироста и убытка
                CalculateMaxGainAndLoss();
            }
        }

        private void UpdateTableAndGraph(string filePath)
        {
            // Инициализация объекта CurrencyMonthData
            monthData = new CurrencyMonthData();

            // Чтение данных из CSV файла
            string[] lines = File.ReadAllLines(filePath);

            // Очистка таблицы перед вставкой новых данных
            dataGridView.Rows.Clear();

            // Вставка данных из файла в таблицу и объект monthData
            foreach (string line in lines)
            {
                string[] values = line.Split(';');

                // Проверка наличия всех требуемых значений в строке
                if (values.Length >= 3)
                {
                    // Пробуем преобразовать дату и значения в числа
                    if (DateTime.TryParseExact(values[0], "dd.MM.yyyy", CultureInfo.InvariantCulture, DateTimeStyles.None, out DateTime date) &&
                        decimal.TryParse(values[1], NumberStyles.Number, CultureInfo.InvariantCulture, out decimal currency1) &&
                        decimal.TryParse(values[2], NumberStyles.Number, CultureInfo.InvariantCulture, out decimal currency2))
                    {
                        // Добавление значений в соответствующие столбцы таблицы
                        dataGridView.Rows.Add(values[0], values[1], values[2]);

                        // Добавление данных в объект monthData
                        CurrencyData data = new CurrencyData(date);
                        data.AddExchangeRate("Currency1", currency1);
                        data.AddExchangeRate("Currency2", currency2);
                        monthData.AddDailyData(data);
                    }
                    else
                    {
                        // Выводим сообщение об ошибке, если формат неверный
                        MessageBox.Show($"Неверный формат данных в строке: {line}", "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                }
                else
                {
                    // Обработка неполных строк, если такие есть
                    MessageBox.Show($"Неполные данные в строке: {line}", "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }

            // Построение графика с учетом новых данных
            PlotExchangeRateGraph();

            // Вычисление максимального прироста и убытка после загрузки данных
            CalculateMaxGainAndLoss();
        }




        private void CalculateMaxGainAndLoss()
        {
            decimal maxGainCurrency1 = monthData.MaxGain("Currency1");
            decimal maxLossCurrency1 = monthData.MaxLoss("Currency1");
            decimal maxGainCurrency2 = monthData.MaxGain("Currency2");
            decimal maxLossCurrency2 = monthData.MaxLoss("Currency2");

            // Вывод результатов на текстовые поля
            txtMaxGainCurrency1.Text = maxGainCurrency1.ToString();
            txtMaxLossCurrency1.Text = maxLossCurrency1.ToString();
            txtMaxGainCurrency2.Text = maxGainCurrency2.ToString();
            txtMaxLossCurrency2.Text = maxLossCurrency2.ToString();
        }

        private void ForecastExchangeRate(int N)
        {
            // Проверяем, что monthData не равен null
            if (monthData != null)
            {
                // Получаем среднегодовой темп прироста и убытка для каждой валюты
                decimal averageGrowthRateCurrency1 = CalculateAverageGrowthRate("Currency1");
                decimal averageGrowthRateCurrency2 = CalculateAverageGrowthRate("Currency2");

                // Получаем последние известные значения курса валют
                decimal lastValueCurrency1 = monthData.LastExchangeRate("Currency1");
                decimal lastValueCurrency2 = monthData.LastExchangeRate("Currency2");

                // Создаем объекты Series для отображения прогнозов на графике
                Series seriesForecastCurrency1 = new Series();
                seriesForecastCurrency1.ChartType = SeriesChartType.Line;
                Series seriesForecastCurrency2 = new Series();
                seriesForecastCurrency2.ChartType = SeriesChartType.Line;

                // Прогнозируем данные на N дней вперед
                for (int i = 0; i < N; i++)
                {
                    // Прогнозируем на основе последнего известного значения и среднегодового темпа прироста/убытка
                    lastValueCurrency1 *= (1 + (averageGrowthRateCurrency1 / 100));
                    lastValueCurrency2 *= (1 + (averageGrowthRateCurrency2 / 100));

                    // Добавляем точки для прогноза на N дней
                    seriesForecastCurrency1.Points.AddXY(i + 1, lastValueCurrency1);
                    seriesForecastCurrency2.Points.AddXY(i + 1, lastValueCurrency2);
                }

                // Добавляем серии на график
                chartFuture.Series.Clear();
                chartFuture.Series.Add(seriesForecastCurrency1);
                chartFuture.Series.Add(seriesForecastCurrency2);

                // Обновляем текстовое поле с информацией о прогнозе
                futureTextBox.Text = $"Прогноз на {N} дней:\n\n" +
                                     $"Валюта 1: {lastValueCurrency1}\n" +
                                     $"Валюта 2: {lastValueCurrency2}";
            }
            else
            {
                MessageBox.Show("Ошибка: объект monthData не инициализирован.", "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
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
        private decimal CalculateAverageGrowthRate(string currency)
        {
            // Получаем данные по указанной валюте
            List<decimal> exchangeRates = monthData.GetExchangeRates(currency);

            // Вычисляем годовой темп прироста/убытка
            decimal firstValue = exchangeRates.First();
            decimal lastValue = exchangeRates.Last();
            decimal growthRate = ((lastValue - firstValue) / firstValue) * 100;

            // Возвращаем среднегодовой темп прироста/убытка
            return growthRate / exchangeRates.Count;
        }


        private void btnForecast_Click(object sender, EventArgs e)
        {
            // Считываем значение N из текстового поля
            if (int.TryParse(ntextbox.Text, out int N))
            {
                // Прогнозирование и отображение на графике
                ForecastExchangeRate(N);
            }
            else
            {
                // Если введено некорректное значение, выводим сообщение об ошибке
                MessageBox.Show("Введите корректное значение N", "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

    }
}
