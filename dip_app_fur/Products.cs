using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace dip_app_fur
{
    public partial class Products : Form
    {
        public const int WM_NCLBUTTONDOWN = 0xA1;
        public const int HT_CAPTION = 0x2;

        [System.Runtime.InteropServices.DllImportAttribute("user32.dll")]
        public static extern int SendMessage(IntPtr hWnd, int Msg, int wParam, int lParam);
        [System.Runtime.InteropServices.DllImportAttribute("user32.dll")]
        public static extern bool ReleaseCapture();
        public Products()
        {
            InitializeComponent();      
        }

        private void button1_Click(object sender, EventArgs e)
        {
            this.WindowState = FormWindowState.Minimized;
        }

        private void button2_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void productsBindingNavigatorSaveItem_Click(object sender, EventArgs e)
        {
            this.Validate();
            this.productsBindingSource.EndEdit();
            this.tableAdapterManager.UpdateAll(this.bd_dip_furDataSet);

        }

        private void Products_Load(object sender, EventArgs e)
        {
            // TODO: данная строка кода позволяет загрузить данные в таблицу "bd_dip_furDataSet.categories". При необходимости она может быть перемещена или удалена.
            this.categoriesTableAdapter.Fill(this.bd_dip_furDataSet.categories);
            // TODO: данная строка кода позволяет загрузить данные в таблицу "bd_dip_furDataSet.colors". При необходимости она может быть перемещена или удалена.
            this.colorsTableAdapter.Fill(this.bd_dip_furDataSet.colors);
            // TODO: данная строка кода позволяет загрузить данные в таблицу "bd_dip_furDataSet.materials". При необходимости она может быть перемещена или удалена.
            this.materialsTableAdapter.Fill(this.bd_dip_furDataSet.materials);
            // TODO: данная строка кода позволяет загрузить данные в таблицу "bd_dip_furDataSet.products". При необходимости она может быть перемещена или удалена.
            this.productsTableAdapter.Fill(this.bd_dip_furDataSet.products);

        }

        private void panel1_MouseDown(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Left)
            {
                ReleaseCapture();
                SendMessage(Handle, WM_NCLBUTTONDOWN, HT_CAPTION, 0);
            }
        }

        private void button3_Click(object sender, EventArgs e)
        {
            
            for (int i = 0; i < chart1.Series[0].Points.Count; i++)
            {

                switch (chart1.Series[0].Points[i].XValue.ToString())
                {
                    case "1":
                        chart1.Series[0].Points[i].LegendText = "Кухни";
                        break;
                    case "2":
                        chart1.Series[0].Points[i].LegendText = "Кухонные мойки";
                        break;
                    case "3":
                        chart1.Series[0].Points[i].LegendText = "Фартуки";
                        break;
                    case "4":
                        chart1.Series[0].Points[i].LegendText = "Столешницы";
                        break;
                    case "5":
                        chart1.Series[0].Points[i].LegendText = "Смесители";
                        break;
                    case "6":
                        chart1.Series[0].Points[i].LegendText = "Аксессуары";
                        break;
                    case "7":
                        chart1.Series[0].Points[i].LegendText = "Техника";
                        break;
                    case "8":
                        chart1.Series[0].Points[i].LegendText = "Посуда";
                        break;
                    case "9":
                        chart1.Series[0].Points[i].LegendText = "Кухонная мебель";
                        break;
                }

            }
            
            System.Threading.Thread.Sleep(1000);
            chart1.Visible = true;


        }

        private void button4_Click(object sender, EventArgs e)
        {
            chart2.Visible = true;
        }
    }
}
