using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TP_LR_3.MODEL
{
    public class CurrencyData
    {
        public DateTime Date { get; set; }
        public Dictionary<string, decimal> ExchangeRates { get; set; } // Ключ - название валюты, значение - курс

        public CurrencyData(DateTime date)
        {
            Date = date;
            ExchangeRates = new Dictionary<string, decimal>();
        }

        public void AddExchangeRate(string currency, decimal rate)
        {
            ExchangeRates[currency] = rate;
        }

        public decimal GetExchangeRate(string currency)
        {
            return ExchangeRates.ContainsKey(currency) ? ExchangeRates[currency] : 0; // Если валюта не найдена, возвращаем 0
        }
    }
}
