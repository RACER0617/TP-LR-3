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
            }
        }

        private void UpdateTableAndGraph(string filePath)
        {
            // Чтение данных из CSV файла
            string[] lines = File.ReadAllLines(filePath);

            // Очистка таблицы перед вставкой новых данных
            dataGridView.Rows.Clear();

            // Вставка данных из файла в таблицу
            foreach (string line in lines)
            {
                string[] values = line.Split(';');

                // Проверка наличия всех требуемых значений в строке
                if (values.Length >= 3)
                {
                    // Добавление значений в соответствующие столбцы таблицы
                    dataGridView.Rows.Add(values[0], values[1], values[2]);
                }
                else
                {
                    // Обработка неполных строк, если такие есть
                    MessageBox.Show($"Неполные данные в строке: {line}", "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }

            // Построение графика с учетом новых данных
            PlotExchangeRateGraph();
        }







    }
}
