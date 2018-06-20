using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using MaterialSkin.Controls;
using MaterialSkin.Animations;
using MaterialSkin;

namespace dip_app_fur
{
    
public partial class MainWindow : Form
    {
        DateTimePicker dtp = new DateTimePicker();
        Rectangle _Rectangle;
        public const int WM_NCLBUTTONDOWN = 0xA1;
        public const int HT_CAPTION = 0x2;

        [System.Runtime.InteropServices.DllImportAttribute("user32.dll")]
        public static extern int SendMessage(IntPtr hWnd, int Msg, int wParam, int lParam);
        [System.Runtime.InteropServices.DllImportAttribute("user32.dll")]
        public static extern bool ReleaseCapture();

        public MainWindow()
        {
            InitializeComponent();

            orderDataGridView.Controls.Add(dtp);
            dtp.Visible = false;
            dtp.Format = DateTimePickerFormat.Custom;
            dtp.TextChanged += new EventHandler(dtp_TextChange);
            //this.MaximizedBounds = Screen.FromHandle(this.Handle).WorkingArea;
            //this.WindowState = FormWindowState.Maximized;
        }

        private void orderBindingNavigatorSaveItem_Click(object sender, EventArgs e)
        {
            this.Validate();
            this.orderBindingSource.EndEdit();
            this.tableAdapterManager.UpdateAll(this.bd_dip_furDataSet);

        }

        private void Form1_Load(object sender, EventArgs e)
        {
            // TODO: данная строка кода позволяет загрузить данные в таблицу "bd_dip_furDataSet.staff". При необходимости она может быть перемещена или удалена.
            this.staffTableAdapter.Fill(this.bd_dip_furDataSet.staff);
            // TODO: данная строка кода позволяет загрузить данные в таблицу "bd_dip_furDataSet.order". При необходимости она может быть перемещена или удалена.
            this.orderTableAdapter.Fill(this.bd_dip_furDataSet.order);
            // TODO: данная строка кода позволяет загрузить данные в таблицу "bd_dip_furDataSet.categories". При необходимости она может быть перемещена или удалена.
            //this.categoriesTableAdapter.Fill(this.bd_dip_furDataSet.categories);
            // TODO: данная строка кода позволяет загрузить данные в таблицу "bd_dip_furDataSet1.staff". При необходимости она может быть перемещена или удалена.
            this.staffTableAdapter.Fill(this.bd_dip_furDataSet1.staff);
            // TODO: данная строка кода позволяет загрузить данные в таблицу "bd_dip_furDataSet1.staff". При необходимости она может быть перемещена или удалена.
            this.staffTableAdapter.Fill(this.bd_dip_furDataSet1.staff);
            // TODO: данная строка кода позволяет загрузить данные в таблицу "bd_dip_furDataSet.clients". При необходимости она может быть перемещена или удалена.
            this.clientsTableAdapter.Fill(this.bd_dip_furDataSet.clients);
            // TODO: данная строка кода позволяет загрузить данные в таблицу "bd_dip_furDataSet.clients". При необходимости она может быть перемещена или удалена.
            this.clientsTableAdapter.Fill(this.bd_dip_furDataSet.clients);
            // TODO: данная строка кода позволяет загрузить данные в таблицу "bd_dip_furDataSet.order". При необходимости она может быть перемещена или удалена.
            this.orderTableAdapter.Fill(this.bd_dip_furDataSet.order);

        }

        private void orderDataGridView_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void orderDataGridView_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            switch (orderDataGridView.Columns[e.ColumnIndex].Name)
            {
                case "dataGridViewTextBoxColumn5":
                    _Rectangle = orderDataGridView.GetCellDisplayRectangle(e.ColumnIndex, e.RowIndex, true);
                    dtp.Size = new Size(_Rectangle.Width, _Rectangle.Height);
                    dtp.Location = new Point(_Rectangle.X, _Rectangle.Y);
                    dtp.Visible = true;

                    break;
            }
        }

        private void dtp_TextChange (object sender, EventArgs e)
        {
            orderDataGridView.CurrentCell.Value = dtp.Text.ToString();
        }

        private void orderDataGridView_ColumnWidthChanged(object sender, DataGridViewColumnEventArgs e)
        {
            dtp.Visible = false;
        }

        private void orderDataGridView_Scroll(object sender, ScrollEventArgs e)
        {
            dtp.Visible = false;
        }

        private void panel3_MouseDown(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Left)
            {
                ReleaseCapture();
                SendMessage(Handle, WM_NCLBUTTONDOWN, HT_CAPTION, 0);
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            this.WindowState = FormWindowState.Minimized;
        }

        private void button3_Click(object sender, EventArgs e)
        {
            Clients clients = new Clients();
            clients.Show();
        }

        private void button4_Click(object sender, EventArgs e)
        {
            Products products = new Products();
            products.Show();
        }

        private void button5_Click(object sender, EventArgs e)
        {
            Staff staff = new Staff();
            staff.Show();
        }

        private void button6_Click(object sender, EventArgs e)
        {
            Shipments shipments = new Shipments();
            shipments.Show();
        }

        private void button7_Click(object sender, EventArgs e)
        {
            ProductsSold productssold = new ProductsSold();
            productssold.Show();
        }

        private void button8_Click(object sender, EventArgs e)
        {
            Suppliers suppliers = new Suppliers();
            suppliers.Show();
        }

        private void button9_Click(object sender, EventArgs e)
        {
            FinReport finreport = new FinReport();
            finreport.Show();
        }

        private void label1_MouseDown(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Left)
            {
                ReleaseCapture();
                SendMessage(Handle, WM_NCLBUTTONDOWN, HT_CAPTION, 0);
            }
        }

        private void button10_Click(object sender, EventArgs e)
        {
            if (orderDataGridView.CurrentCell.ColumnIndex == 0)
            {
                //this.tableAdapterManager.UpdateAll(this.bd_dip_furDataSet1);
                //bd_dip_furDataSet1.Tables["staff"].AcceptChanges();
                //this.Invalidate();
                //bd_dip_furDataSet1.Reset();
                //bd_dip_furDataSet.staff.clear();
                //this.close();
                string order_number = orderDataGridView.CurrentCell.Value.ToString();
                List<string> id = new List<string>();
                List<decimal> rating = new List<decimal>();
                List<string> name = new List<string>();
                decimal max = 0;
                int max_id = 0;
                Random rand = new Random();


                foreach (DataRow dr in bd_dip_furDataSet.staff.Rows)
                {
                    if (dr["status"].ToString() == "False" && dr["job_id"].ToString() == "3")
                    {
                        decimal d = Convert.ToDecimal(dr["rating"].ToString());
                        rating.Add(d);
                        string s = dr["id_staff"].ToString();
                        id.Add(s);
                        string n = dr["fullName"].ToString();
                        name.Add(n);
                    }
                }
                for (int i = 0; i < id.Count; i++)
                {
                    rating[i] = rand.Next(Convert.ToInt32(rating[i])) * rating[i];
                    rating[i] *= 10;
                    if (rating[i] > max)
                    {
                        max = rating[i];
                        max_id = i;
                    }
                }
                if (name.Count == 0)
                {
                    MessageBox.Show("Свободных исполнителей нет");
                }
                else
                {
                    string result = String.Format("Рекомендуется назначить заказ под номером '{0}' исполнителю {1}",
                    orderDataGridView.CurrentCell.Value.ToString(), name[max_id]);
                    MessageBox.Show(result);
                }

            }
        }
    }
}
