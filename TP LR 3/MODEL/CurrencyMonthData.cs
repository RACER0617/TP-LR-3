using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TP_LR_3.MODEL
{
    public class CurrencyMonthData
    {
        public List<CurrencyData> DailyData { get; private set; }

        public CurrencyMonthData()
        {
            DailyData = new List<CurrencyData>();
        }

        public void AddDailyData(CurrencyData data)
        {
            DailyData.Add(data);
        }

        public decimal MaxGain(string currency)
        {
            decimal maxGain = 0;
            foreach (var data in DailyData)
            {
                decimal todayRate = data.GetExchangeRate(currency);
                decimal yesterdayRate = (DailyData.IndexOf(data) > 0) ? DailyData[DailyData.IndexOf(data) - 1].GetExchangeRate(currency) : 0;
                decimal gain = todayRate - yesterdayRate;
                if (gain > maxGain)
                    maxGain = gain;
            }
            return maxGain;
        }

        public decimal MaxLoss(string currency)
        {
            decimal maxLoss = 0;
            foreach (var data in DailyData)
            {
                decimal todayRate = data.GetExchangeRate(currency);
                decimal yesterdayRate = (DailyData.IndexOf(data) > 0) ? DailyData[DailyData.IndexOf(data) - 1].GetExchangeRate(currency) : 0;
                decimal loss = yesterdayRate - todayRate;
                if (loss > maxLoss)
                    maxLoss = loss;
            }
            return maxLoss;
        }

        public decimal[] MovingAverage(int N, string currency)
        {
            decimal[] movingAverages = new decimal[DailyData.Count - N + 1];
            for (int i = 0; i < DailyData.Count - N + 1; i++)
            {
                decimal sum = 0;
                for (int j = 0; j < N; j++)
                {
                    sum += DailyData[i + j].GetExchangeRate(currency);
                }
                movingAverages[i] = sum / N;
            }
            return movingAverages;
        }

        // Метод для получения списка курсов валют по заданной валюте
        public List<decimal> GetExchangeRates(string currency)
        {
            List<decimal> exchangeRates = new List<decimal>();
            foreach (var data in DailyData)
            {
                exchangeRates.Add(data.GetExchangeRate(currency));
            }
            return exchangeRates;
        }

        // Метод для получения последнего известного курса валюты
        public decimal LastExchangeRate(string currency)
        {
            if (DailyData.Count > 0)
            {
                return DailyData.Last().GetExchangeRate(currency);
            }
            else
            {
                // Если данных нет, возвращаем 0
                return 0;
            }
        }
    }
}
