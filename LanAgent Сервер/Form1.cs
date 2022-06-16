using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Net;
using System.Net.Sockets;
using System.Runtime.Serialization.Formatters.Binary;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;
using DllStruct;
using System.Diagnostics;
using Microsoft.Win32;

namespace LanAgent_сервер
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        TcpListener server = null;
        Thread thread1;

       public static string addr = "127.0.0.1";
       public static int port = 9595;
       public static int DelDay = 3;  // через сколько дней удалять записи
       public static int DelCnt = 20;  // максимальное кол-во записей для хранения
       public static bool AutoStart = false;  // автоматическое включение сервера при запуске
       public static bool Autorun = false;

        // список для хранения данных, полученных от клиентов
        List<info> lstComp = new List<info>();

        // форма для отображения детальной информации
        FormShowDetail frmDetail = new FormShowDetail();

        info ByteToStruct(byte[] data)
        {
            // объект - сериализатор
            BinaryFormatter bf = new BinaryFormatter();
            // поток в ОЗУ для вывода в него байт
            MemoryStream ms = new MemoryStream();
            // вывести все байты из массива в поток
            ms.Write(data, 0, data.Length);
            // установить указатель на нулевой байт в потоке
            ms.Position = 0;
            // выполнить десериализацию (результат - структура данных)
            return (info)bf.Deserialize(ms);
        }

        void SaveToFile(string fname)
        {
            BinaryFormatter bf = new BinaryFormatter();
            FileStream f = File.OpenWrite(fname);
            bf.Serialize(f, lstComp);
            f.Close();
        }

        void LoadFromFile(string fname)
        {
            BinaryFormatter bf = new BinaryFormatter();
            FileStream f = File.OpenRead(fname);
            lstComp = (List<info>)bf.Deserialize(f);
            f.Close();

            dgvClients.Rows.Clear();
            foreach (info comp in lstComp)
            {
                dgvClients.Rows.Add(comp.ip, comp.netname, comp.dt);
            }
        }

        void WorkServer()
        {
            while (true)
            {
                byte[] buf = new byte[10000000];  // буфер для принимаемых данных
                // ожидать запросов от клиентов
                TcpClient client = server.AcceptTcpClient();
                // создать сетевой поток и связать его с клиентом
                NetworkStream stream = client.GetStream();
                try
                {
                    // прочитать данные из потока и записать в массив
                    // начиная с нулевого элемента, макс. кол-вом - длина массива
                    stream.Read(buf, 0, buf.Length);
                    info comp = ByteToStruct(buf);

                    Invoke(new MethodInvoker(delegate
                    {
                        lstComp.Add(comp);
                        dgvClients.Rows.Add(comp.ip, comp.netname, comp.dt);
                    }));
                }
                catch
                {
                    Invoke(new MethodInvoker(delegate
                    {
                        tslStatus.Text = "Ошибка получения данных " +
                            DateTime.Now.ToString();
                    }));
                }
                client.Close();  // закрыть подключение к клиенту
            }
        }

        private void btnStart_Click(object sender, EventArgs e)
        {
            if (server == null)
            {
                IPAddress addr1 = IPAddress.Parse(addr);
                try
                {
                    server = new TcpListener(addr1, port);
                    server.Start();  // запустить сервер
                }
                catch
                {
                    tslStatus.Text = "Ошибка запуска сервера " + DateTime.Now.ToString();
                    return;
                }

                thread1 = new Thread(WorkServer);
                thread1.Start();
                tslStatus.Text = "Сервер запущен.";
            }
            else
                tslStatus.Text = "Сервер уже запущен.";
        }

        private void btnStop_Click(object sender, EventArgs e)
        {
            if (server != null)
            {
                server.Stop();  // остановить сервер
                thread1.Abort();  // прервать поток
                tslStatus.Text = "Сервер остановлен.";
                server = null;
            }
            else
                tslStatus.Text = "Сервер еще не запущен.";
        }

        private void Form1_FormClosing(object sender, FormClosingEventArgs e)
        {
            if (server != null)
            {
                server.Stop();  // остановить сервер
                thread1.Abort();  // прервать поток
            }

            try
            {
                SaveToFile(Application.StartupPath + "\\lanagent.dat");
            }
            catch {}

            RegistryKey rk = Registry.CurrentUser.CreateSubKey(@"Software\LanAgentServerSettings");
            rk.SetValue("adress", addr);
            rk.SetValue("port", port);
            rk.SetValue("Days", DelDay);
            rk.SetValue("DelCnt", DelCnt);
            if (Autorun)
                rk.SetValue("Autorun", 1);
            else
                rk.SetValue("Autorun", 0);
            if(AutoStart)
                rk.SetValue("Autostart", 1);
            else
                rk.SetValue("Autostart", 0);

            rk.Close();
        }

        private void dgvClients_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex < 0)
                return;
            frmDetail.Show();  // показать форму с детальной информацией
        }

        private void dgvClients_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex < 0)
                return;
            int ind = e.RowIndex;//номер строки, на которой выполнили щелчок
            frmDetail.lblIP.Text = lstComp[ind].ip;
            frmDetail.lblNetName.Text = lstComp[ind].netname;
            frmDetail.lblUserName.Text = lstComp[ind].username;
            frmDetail.lblDateTime.Text = lstComp[ind].dt.ToString();
            frmDetail.pbxScreen.Image = lstComp[ind].scr;
            DriveInfo[] disks = lstComp[ind].allDrives;
            foreach (DriveInfo d in disks)
            {
                frmDetail.tbxDrives.Text += "Диск: " + d.Name + "\r\n" + "Тип диска: " + d.DriveType + "\r\n";
                if (d.IsReady)
                {
                    frmDetail.tbxDrives.Text += " файловая система: " + d.DriveFormat + "\r\n"
                        + " метка диска: " + d.VolumeLabel + "\r\n" + " размер диска: " + d.TotalSize +
                        "\r\n" + " свободно: " + d.TotalFreeSpace + "\r\n";
                }
            }
            Process[] macproc = Process.GetProcesses();
            foreach (Process proc in macproc)
                try
                {
                    frmDetail.tbxProcess.Text += proc.ProcessName + " "
                        + proc.PrivateMemorySize64
                        + " " + proc.TotalProcessorTime + "\r\n";
                }
                catch
                { }
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            if (File.Exists(Application.StartupPath + "\\lanagent.dat"))
            {
                try
                {
                    LoadFromFile(Application.StartupPath + "\\lanagent.dat");
                }
                catch { }
            }

            String[] arg = Environment.GetCommandLineArgs();
            if(arg.Length > 1)
                if(arg[1] == "/min")
                {
                    ShowInTaskbar = false;
                    WindowState = FormWindowState.Minimized;
                }

            RegistryKey rk = Registry.CurrentUser.OpenSubKey(@"Software\LanAgentServerSettings");
            try
            {
                addr = rk.GetValue("adress").ToString();
                port = int.Parse(rk.GetValue("port").ToString());
                DelDay = int.Parse(rk.GetValue("Days").ToString());
                DelCnt = int.Parse(rk.GetValue("DelCnt").ToString());
                int start = int.Parse(rk.GetValue("AutoStart").ToString());
                if (start == 1)
                    AutoStart = true;
                else AutoStart = false;
                int run = int.Parse(rk.GetValue("AutoRun").ToString());
                if (run == 1)
                    Autorun = true;
                else Autorun = false;

                rk.Close();
            }
            catch
            {
                addr = "127.0.0.1";
                port = 9595;
                DelDay = 3; 
                DelCnt = 20;  
                AutoStart = false;  
                Autorun = false;
            }

            if (AutoStart)
            {
                btnStart_Click(sender, e);
            }
        }

        private void btnSettings_Click(object sender, EventArgs e)
        {
            FormSettings frm = new FormSettings();
            frm.ShowDialog();
        }

        private void Form1_Resize(object sender, EventArgs e)
        {
            if(WindowState == FormWindowState.Minimized)
            {
                notifyIcon1.Visible = true;
                Hide();
            }
        }

        private void notifyIcon1_DoubleClick(object sender, EventArgs e)
        {
            Show();
            WindowState = FormWindowState.Normal;
            notifyIcon1.Visible = false;
            ShowInTaskbar = true;
        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            while (lstComp.Count > DelCnt)
            {
                lstComp.RemoveAt(0);
                dgvClients.Rows.RemoveAt(0);
            }
            DateTime CurDate = DateTime.Now;
            TimeSpan ts;//разность между датами и временем
            for (int i = lstComp.Count - 1; i >= 0; i--)
            {
                ts = CurDate - lstComp[i].dt;
                if (ts.TotalDays > DelDay)
                {
                    lstComp.RemoveAt(i);
                    dgvClients.Rows.RemoveAt(i);
                }
            }
        }

        string t;
        private void TbxSearch_TextChanged(object sender, EventArgs e)
        {
            t = TbxSearch.Text.ToLower().Trim();
            if (t == "")
                return;
            dgvClients.ClearSelection();//очистить выделение в таблице
            for (int i = 0; i <= dgvClients.Rows.Count - 1; i++)
            {
                string t1 = "";
                if (RbtSearchIp.Checked)
                    t1 = lstComp[i].ip.ToString().ToLower();
                if (RbtSearchNetName.Checked)
                    t1 = lstComp[i].netname.ToLower();
                if (RbtSearchDateTime.Checked)
                    t1 = lstComp[i].dt.ToString();
                if (t1.Contains(t))
                {
                    dgvClients.CurrentCell = dgvClients.Rows[i].Cells[0];
                    dgvClients.Rows[i].Selected = true;
                    break;
                }
            }
        }

        private void BtnSearchNext_Click(object sender, EventArgs e)
        {
            t = TbxSearch.Text.ToLower().Trim();
            if (t == "")
                return;
            dgvClients.ClearSelection();//очистить выделение в таблице
            for (int i = dgvClients.CurrentRow.Index + 1; i <= dgvClients.Rows.Count - 1; i++)
            {
                string t1 = "";
                if (RbtSearchIp.Checked)
                    t1 = lstComp[i].ip.ToString().ToLower();
                if (RbtSearchNetName.Checked)
                    t1 = lstComp[i].netname.ToLower();
                if (RbtSearchDateTime.Checked)
                    t1 = lstComp[i].dt.ToString();
                if (t1.Contains(t))
                {
                    dgvClients.CurrentCell = dgvClients.Rows[i].Cells[0];
                    dgvClients.Rows[i].Selected = true;
                    break;
                }
            }
        }

        private void BtnDelEnabled_Click(object sender, EventArgs e)
        {
            DialogResult rez = MessageBox.Show("Удалить выделенные элементы?", "Внимание!", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            if (rez == DialogResult.No)
                return;
            foreach (DataGridViewRow row in dgvClients.SelectedRows)
            {
                lstComp.RemoveAt(row.Index);
                dgvClients.Rows.Remove(row);
            }
        }

        private void BtnClearAll_Click(object sender, EventArgs e)
        {
            DialogResult rez = MessageBox.Show("Удалить все элементы?", "Внимание!", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            if (rez == DialogResult.No)
                return;
            dgvClients.Rows.Clear();
            lstComp.Clear();
        }
    }
}
