using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TP_LR_3.MODEL
{
    // Класс, представляющий данные о курсе валют за один день
    public class CurrencyRate
    {
        public DateTime Date { get; set; }
        public string Currency1 { get; set; }
        public string Currency2 { get; set; }
        public double Rate1 { get; set; }
        public double Rate2 { get; set; }
    }

    // Класс для работы с набором данных о курсе валют за месяц
    public class CurrencyData
    {
        private List<CurrencyRate> rates = new List<CurrencyRate>();

        // Метод для добавления данных о курсе за один день
        public void AddRate(CurrencyRate rate)
        {
            rates.Add(rate);
        }

        // Метод для получения всех данных о курсе валют за месяц
        public List<CurrencyRate> GetAllRates()
        {
            return rates;
        }

        // Метод для получения данных о курсе валют за определенный день
        public CurrencyRate GetRateByDate(DateTime date)
        {
            return rates.Find(rate => rate.Date == date);
        }
    }

    // Класс для статистического анализа данных о курсе валют
    public class CurrencyStatistics
    {
        public static double CalculateMaxIncrease(CurrencyData data, string currency)
        {
            double maxIncrease = 0;
            foreach (var rate in data.GetAllRates())
            {
                if (currency == rate.Currency1)
                {
                    maxIncrease = Math.Max(maxIncrease, rate.Rate1);
                }
                else if (currency == rate.Currency2)
                {
                    maxIncrease = Math.Max(maxIncrease, rate.Rate2);
                }
            }
            return maxIncrease;
        }

        public static double CalculateMaxDecrease(CurrencyData data, string currency)
        {
            double maxDecrease = double.MaxValue;
            foreach (var rate in data.GetAllRates())
            {
                if (currency == rate.Currency1)
                {
                    maxDecrease = Math.Min(maxDecrease, rate.Rate1);
                }
                else if (currency == rate.Currency2)
                {
                    maxDecrease = Math.Min(maxDecrease, rate.Rate2);
                }
            }
            return maxDecrease;
        }

        // Метод для статистического прогнозирования методом экстраполяции по скользящей средней на N дней
        public static List<double> ExtrapolateMovingAverage(CurrencyData data, string currency, int N)
        {
            List<double> extrapolatedRates = new List<double>();
            List<CurrencyRate> rates = data.GetAllRates();
            int count = rates.Count;
            for (int i = 0; i < count - N; i++)
            {
                double sum = 0;
                for (int j = i; j < i + N; j++)
                {
                    if (currency == rates[j].Currency1)
                    {
                        sum += rates[j].Rate1;
                    }
                    else if (currency == rates[j].Currency2)
                    {
                        sum += rates[j].Rate2;
                    }
                }
                extrapolatedRates.Add(sum / N);
            }
            return extrapolatedRates;
        }
    }
}
