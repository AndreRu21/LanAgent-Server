using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Microsoft.Win32;

namespace LanAgent_сервер
{
    public partial class FormSettings : Form
    {
        public FormSettings()
        {
            InitializeComponent();
        }

        private void FormSettings_Load(object sender, EventArgs e)
        {
            tbxIP.Text = Form1.addr;
            tbxPort.Text = Form1.port.ToString();
            tbxDays.Text = Form1.DelDay.ToString();
            tbxZap.Text = Form1.DelCnt.ToString();

            cbxAutorun.Checked = Form1.Autorun;
            cbxServerStart.Checked = Form1.AutoStart;
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        void SetAutorun(bool autorun)
        {
            string ExePath = Application.ExecutablePath;

            RegistryKey rk = Registry.CurrentUser.CreateSubKey(@"Software\Microsoft\Windows\CurrentVersion\Run");
            try
            {
                if (autorun)
                {
                    rk.SetValue("LanAgent", "\"" + ExePath + "\" /min");
                }
                else
                    rk.DeleteValue("LanAgent");

                rk.Close();
            }
            catch { }
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            Form1.addr = tbxIP.Text;
            Form1.port = int.Parse(tbxPort.Text);
            Form1.DelDay = int.Parse(tbxDays.Text);
            Form1.DelCnt = int.Parse(tbxZap.Text);
            Form1.Autorun = cbxAutorun.Checked;
            Form1.AutoStart = cbxServerStart.Checked;

            this.Close();
        }

        private void cbxAutorun_CheckedChanged(object sender, EventArgs e)
        {
            SetAutorun(cbxAutorun.Checked);
        }
    }
}
