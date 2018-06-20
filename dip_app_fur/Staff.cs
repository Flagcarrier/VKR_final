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
    public partial class Staff : Form
    {
        public const int WM_NCLBUTTONDOWN = 0xA1;
        public const int HT_CAPTION = 0x2;

        [System.Runtime.InteropServices.DllImportAttribute("user32.dll")]
        public static extern int SendMessage(IntPtr hWnd, int Msg, int wParam, int lParam);
        [System.Runtime.InteropServices.DllImportAttribute("user32.dll")]
        public static extern bool ReleaseCapture();
        public Staff()
        {
            InitializeComponent();
            //staffDataGridView.Sort(staffDataGridView.Columns[0], ListSortDirection.Ascending);
        }

        private void button2_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            this.WindowState = FormWindowState.Minimized;
        }

        private void staffBindingNavigatorSaveItem_Click(object sender, EventArgs e)
        {
            this.Validate();
            this.staffBindingSource.EndEdit();
            this.tableAdapterManager.UpdateAll(this.bd_dip_furDataSet);

        }

        private void Staff_Load(object sender, EventArgs e)
        {
            // TODO: данная строка кода позволяет загрузить данные в таблицу "bd_dip_furDataSet.jobs". При необходимости она может быть перемещена или удалена.
            this.jobsTableAdapter.Fill(this.bd_dip_furDataSet.jobs);
            // TODO: данная строка кода позволяет загрузить данные в таблицу "bd_dip_furDataSet.staff". При необходимости она может быть перемещена или удалена.
            this.staffTableAdapter1.Fill(this.bd_dip_furDataSet.staff);

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
            this.Size = new Size(561, 529);
            chart1.Series["Сотрудники"].Sort(System.Windows.Forms.DataVisualization.Charting.PointSortOrder.Descending, "X");
            chart1.Visible = true;
            //  PopulateChart();
            //chart1.Series.Clear();
            //chart1.Series[0] = new System.Windows.Forms.DataVisualization.Charting.Series();
            //chart1.Series[0].XValueMember = staffDataGridView.Columns[0].DataPropertyName;
            //chart1.Series[0].YValueMembers = staffDataGridView.Columns[3].DataPropertyName;
        }

    }
}
