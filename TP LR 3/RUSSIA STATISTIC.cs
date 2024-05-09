using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace TP_LR_3
{
    public partial class RUSSIA_STATISTIC : Form
    {
        public RUSSIA_STATISTIC()
        {
            InitializeComponent();
        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            // Создаем новый экземпляр формы LarasForm
            LarasForm larasForm = new LarasForm();

            // Отображаем форму LarasForm
            larasForm.Show();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            // Создаем новый экземпляр формы Form1
            Form1 form1 = new Form1();

            // Отображаем форму Form1
            form1.Show();
        }
    }
}
