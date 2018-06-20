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
    public partial class FinReport : Form
    {
        DateTimePicker dtp = new DateTimePicker();
        Rectangle _Rectangle;
        public const int WM_NCLBUTTONDOWN = 0xA1;
        public const int HT_CAPTION = 0x2;

        [System.Runtime.InteropServices.DllImportAttribute("user32.dll")]
        public static extern int SendMessage(IntPtr hWnd, int Msg, int wParam, int lParam);
        [System.Runtime.InteropServices.DllImportAttribute("user32.dll")]
        public static extern bool ReleaseCapture();
        public FinReport()
        {
            InitializeComponent();

            final_paperDataGridView.Controls.Add(dtp);
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

        private void panel1_MouseDown(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Left)
            {
                ReleaseCapture();
                SendMessage(Handle, WM_NCLBUTTONDOWN, HT_CAPTION, 0);
            }
        }

        private void final_paperBindingNavigatorSaveItem_Click(object sender, EventArgs e)
        {
            this.Validate();
            this.final_paperBindingSource.EndEdit();
            this.tableAdapterManager.UpdateAll(this.bd_dip_furDataSet);

        }

        private void FinReport_Load(object sender, EventArgs e)
        {
            // TODO: данная строка кода позволяет загрузить данные в таблицу "bd_dip_furDataSet.all_reports". При необходимости она может быть перемещена или удалена.
            this.all_reportsTableAdapter.Fill(this.bd_dip_furDataSet.all_reports);
            // TODO: данная строка кода позволяет загрузить данные в таблицу "bd_dip_furDataSet.staff". При необходимости она может быть перемещена или удалена.
            this.staffTableAdapter.Fill(this.bd_dip_furDataSet.staff);
            // TODO: данная строка кода позволяет загрузить данные в таблицу "bd_dip_furDataSet.final_paper". При необходимости она может быть перемещена или удалена.
            this.final_paperTableAdapter.Fill(this.bd_dip_furDataSet.final_paper);

            this.reportViewer1.RefreshReport();
        }

        private void final_paperDataGridView_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            switch (final_paperDataGridView.Columns[e.ColumnIndex].Name)
            {
                case "dataGridViewTextBoxColumn4":
                    _Rectangle = final_paperDataGridView.GetCellDisplayRectangle(e.ColumnIndex, e.RowIndex, true);
                    dtp.Size = new Size(_Rectangle.Width, _Rectangle.Height);
                    dtp.Location = new Point(_Rectangle.X, _Rectangle.Y);
                    dtp.Visible = true;

                    break;
            }
        }
        private void dtp_TextChange(object sender, EventArgs e)
        {
            final_paperDataGridView.CurrentCell.Value = dtp.Text.ToString();
        }

        private void final_paperDataGridView_ColumnWidthChanged(object sender, DataGridViewColumnEventArgs e)
        {
            dtp.Visible = false;
        }

        private void final_paperDataGridView_Scroll(object sender, ScrollEventArgs e)
        {
            dtp.Visible = false;
        }
    }
}
