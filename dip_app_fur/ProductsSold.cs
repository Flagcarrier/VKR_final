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
    public partial class ProductsSold : Form
    {
        public const int WM_NCLBUTTONDOWN = 0xA1;
        public const int HT_CAPTION = 0x2;

        [System.Runtime.InteropServices.DllImportAttribute("user32.dll")]
        public static extern int SendMessage(IntPtr hWnd, int Msg, int wParam, int lParam);
        [System.Runtime.InteropServices.DllImportAttribute("user32.dll")]
        public static extern bool ReleaseCapture();
        public ProductsSold()
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

        private void product_listBindingNavigatorSaveItem_Click(object sender, EventArgs e)
        {
            this.Validate();
            this.product_listBindingSource.EndEdit();
            this.tableAdapterManager.UpdateAll(this.bd_dip_furDataSet);

        }

        private void ProductsSold_Load(object sender, EventArgs e)
        {
            // TODO: данная строка кода позволяет загрузить данные в таблицу "bd_dip_furDataSet.products". При необходимости она может быть перемещена или удалена.
            this.productsTableAdapter.Fill(this.bd_dip_furDataSet.products);
            // TODO: данная строка кода позволяет загрузить данные в таблицу "bd_dip_furDataSet.product_list". При необходимости она может быть перемещена или удалена.
            this.product_listTableAdapter.Fill(this.bd_dip_furDataSet.product_list);

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
            decimal input = Convert.ToDecimal(textBox1.Text.ToString());
            product_listBindingSource.Filter = string.Format("order_id = '{0}'", input);

            //(product_listDataGridView.DataSource as DataTable).DefaultView.RowFilter = string.Format("order_id = '{0}'", textBox1.Text);
        }
    }
}
