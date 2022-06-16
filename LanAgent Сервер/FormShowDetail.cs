using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace LanAgent_сервер
{
    public partial class FormShowDetail : Form
    {
        public FormShowDetail()
        {
            InitializeComponent();
        }

        private void FormShowDetail_FormClosing(object sender, FormClosingEventArgs e)
        {
            e.Cancel = true;  // отменить выполняющееся событие (запретить закрытие формы)
            this.Hide();  // скрыть форму
        }

        private void FormShowDetail_Load(object sender, EventArgs e)
        {
        }
    }
}
