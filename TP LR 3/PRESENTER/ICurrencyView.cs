using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TP_LR_3.PRESENTER
{
    public interface ICurrencyView
    {
        void DisplayData(string[,] data); // Метод для отображения данных в табличной форме
        // Другие методы представления могут быть добавлены по мере необходимости
    }
}
