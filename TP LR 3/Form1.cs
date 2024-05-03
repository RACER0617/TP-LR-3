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
            // Создание объекта Chart для отображения графиков
            chart = new Chart();
            chart.Dock = DockStyle.Fill;
            Controls.Add(chart);

            // Создание объекта Series для отображения данных
            Series series = new Series();
            series.ChartType = SeriesChartType.Line;

            // Заполнение данными из таблицы
            foreach (DataGridViewRow row in dataGridView.Rows)
            {
                if (!row.IsNewRow)
                {
                    series.Points.AddXY(row.Cells[0].Value, row.Cells[1].Value);
                }
            }

            // Добавление серии на график
            chart.Series.Add(series);
        }

        private void btnLoadData_Click(object sender, EventArgs e)
        {
            // Диалоговое окно для выбора файла с данными
            OpenFileDialog openFileDialog = new OpenFileDialog();
            openFileDialog.Filter = "TXT files (*.txt)|*.txt";
            openFileDialog.Title = "Выберите файл с данными о курсе валют";

            if (openFileDialog.ShowDialog() == DialogResult.OK)
            {
                // Загрузка данных из файла
                monthData = LoadDataFromFile(openFileDialog.FileName);
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



    }
}
