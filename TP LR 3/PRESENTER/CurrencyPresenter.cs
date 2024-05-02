using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TP_LR_3.MODEL;

namespace TP_LR_3.PRESENTER
{
    public class CurrencyPresenter
    {
        private readonly ICurrencyView _view;
        private readonly CurrencyModel _model;

        public CurrencyPresenter(ICurrencyView view)
        {
            _view = view;
            _model = new CurrencyModel();
        }

        public void AddData(DateTime date, Dictionary<string, double> exchangeRates)
        {
            var data = new CurrencyData(date, exchangeRates);
            _model.AddData(data);
        }

        // Другие методы презентера могут быть добавлены по мере необходимости
    }

}
