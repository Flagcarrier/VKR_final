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
    public partial class Shipments : Form
    {
        DateTimePicker dtp = new DateTimePicker();
        Rectangle _Rectangle;
        public const int WM_NCLBUTTONDOWN = 0xA1;
        public const int HT_CAPTION = 0x2;

        [System.Runtime.InteropServices.DllImportAttribute("user32.dll")]
        public static extern int SendMessage(IntPtr hWnd, int Msg, int wParam, int lParam);
        [System.Runtime.InteropServices.DllImportAttribute("user32.dll")]
        public static extern bool ReleaseCapture();
        public Shipments()
        {
            InitializeComponent();
            shipmentsDataGridView.Controls.Add(dtp);
            dtp.Visible = false;
            dtp.Format = DateTimePickerFormat.Custom;
            dtp.TextChanged += new EventHandler(dtp_TextChange);
        }

        private void button1_Click(object sender, EventArgs e)
        {
            this.WindowState = FormWindowState.Minimized;
        }

        private void button2_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void panel1_MouseDown(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Left)
            {
                ReleaseCapture();
                SendMessage(Handle, WM_NCLBUTTONDOWN, HT_CAPTION, 0);
            }
        }

        private void shipment_listBindingNavigatorSaveItem_Click(object sender, EventArgs e)
        {
            this.Validate();
            this.shipment_listBindingSource.EndEdit();
            this.tableAdapterManager.UpdateAll(this.bd_dip_furDataSet);

        }

        private void Shipments_Load(object sender, EventArgs e)
        {
            // TODO: данная строка кода позволяет загрузить данные в таблицу "bd_dip_furDataSet.suppliers". При необходимости она может быть перемещена или удалена.
            this.suppliersTableAdapter.Fill(this.bd_dip_furDataSet.suppliers);
            // TODO: данная строка кода позволяет загрузить данные в таблицу "bd_dip_furDataSet.shipments". При необходимости она может быть перемещена или удалена.
            this.shipmentsTableAdapter.Fill(this.bd_dip_furDataSet.shipments);
            // TODO: данная строка кода позволяет загрузить данные в таблицу "bd_dip_furDataSet.products". При необходимости она может быть перемещена или удалена.
            this.productsTableAdapter.Fill(this.bd_dip_furDataSet.products);
            // TODO: данная строка кода позволяет загрузить данные в таблицу "bd_dip_furDataSet.shipment_list". При необходимости она может быть перемещена или удалена.
            this.shipment_listTableAdapter.Fill(this.bd_dip_furDataSet.shipment_list);

        }

        private void toolStripButton7_Click(object sender, EventArgs e)
        {
            this.Validate();
            this.shipmentsBindingSource.EndEdit();
            this.tableAdapterManager.UpdateAll(this.bd_dip_furDataSet);
        }

        private void shipmentsDataGridView_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            switch (shipmentsDataGridView.Columns[e.ColumnIndex].Name)
            {
                case "ship_date":
                    _Rectangle = shipmentsDataGridView.GetCellDisplayRectangle(e.ColumnIndex, e.RowIndex, true);
                    dtp.Size = new Size(_Rectangle.Width, _Rectangle.Height);
                    dtp.Location = new Point(_Rectangle.X, _Rectangle.Y);
                    dtp.Visible = true;

                    break;
            }
        }
        private void dtp_TextChange(object sender, EventArgs e)
        {
            shipmentsDataGridView.CurrentCell.Value = dtp.Text.ToString();
        }

        private void shipmentsDataGridView_ColumnWidthChanged(object sender, DataGridViewColumnEventArgs e)
        {
            dtp.Visible = false;
        }

        private void shipmentsDataGridView_Scroll(object sender, ScrollEventArgs e)
        {
            dtp.Visible = false;
        }

        private void button3_Click(object sender, EventArgs e)
        {
            //decimal input = Convert.ToDecimal(textBox1.Text.ToString());
            decimal input = Convert.ToDecimal(shipmentsDataGridView.CurrentCell.Value.ToString());
            shipment_listBindingSource.Filter = string.Format("shipment_id = '{0}'", input);
        }
    }
}
