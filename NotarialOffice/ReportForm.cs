using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.OleDb;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace NotarialOffice
{
    public partial class ReportForm : Form
    {
        public enum ReportVars
        {
            AllTime, Month, Year
        }
        
        private Font conclusionFont = new Font("Microsoft Sans Serif", 12, FontStyle.Bold);

        public ReportForm(ReportVars reportVar)
        {
            InitializeComponent();

            saveFileDialog.FileName = this.Text;

            switch (reportVar)
            {
                case ReportVars.AllTime:
                    LoadReportForAllTime();
                    this.Name = "ReportForAllTime";
                    this.Text = "Финансовый отчет за все время";
                    break;
                case ReportVars.Month:
                    LoadReportForLastDays(30);
                    this.Name = "ReportForMonth";
                    this.Text = "Финансовый отчет за месяц";
                    break;
                case ReportVars.Year:
                    LoadReportForLastDays(365);
                    this.Name = "ReportForYear";
                    this.Text = "Финансовый отчет за год";
                    break;
            }
        }

        private void ExportReport(object sender, EventArgs e)
        {
            try
            {
                Bitmap b = new Bitmap(this.Size.Width, this.Size.Height);
                Graphics g = Graphics.FromImage(b);
                g.CopyFromScreen(this.RectangleToScreen(this.ClientRectangle).Location, new Point(0, 0), this.ClientRectangle.Size);

                if (saveFileDialog.ShowDialog() == DialogResult.OK)
                {
                    b.Save(saveFileDialog.FileName + ".png", System.Drawing.Imaging.ImageFormat.Png);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Не удалось экспортировать отчет. {ex.Message}");
            }
        }

        private void LoadReportForAllTime()
        {
            // заполнение таблицы
            string query =
               "SELECT ClientName, Deal.Id AS Id, Sum(PriceForDeal) AS PriceForDeal, Sum(AlreadyPaid) AS AlreadyPaid, Sum(PriceForDeal - AlreadyPaid) AS Debt " +
               "FROM (Client INNER JOIN Deal ON Client.Id = Deal.Client) " +
               "GROUP BY ClientName, Deal.Id";
            OleDbCommand command = new OleDbCommand(query, MainForm.conn);
            OleDbDataReader reader = command.ExecuteReader();

            while (reader.Read())
            {
                grid.Rows.Add(reader["ClientName"], reader["Id"], reader["PriceForDeal"], reader["AlreadyPaid"], reader["Debt"]);
            }

            reader.Close();

            // подведение итогов
            query = "SELECT Sum(PriceForDeal) AS S1, Sum(AlreadyPaid) AS S2, Sum(PriceForDeal - AlreadyPaid) AS S3 FROM Deal";
            command.CommandText = query;
            reader = command.ExecuteReader();
            reader.Read();

            grid.Rows.Add("Итого:", null, reader["S1"], reader["S2"], reader["S3"]);
            grid.Rows[grid.RowCount - 1].DefaultCellStyle.Font = conclusionFont;

            // заполнение графика
            chart.Series["PaidSeries"].Points[0].YValues[0] = Convert.ToDouble(reader["S2"]);
            chart.Series["NotPaidSeries"].Points[0].YValues[0] = Convert.ToDouble(reader["S3"]);

            reader.Close();
        }

        private void LoadReportForLastDays(int days)
        {
            // заполнение таблицы
            string query =
               "SELECT ClientName, Deal.Id AS Id, PriceForDeal, AlreadyPaid, PriceForDeal - AlreadyPaid AS Debt " +
               "FROM Client INNER JOIN Deal ON Client.Id = Deal.Client " +
               $"WHERE ConclusionDate BETWEEN Now() - {days} AND Now()";
            OleDbCommand command = new OleDbCommand(query, MainForm.conn);
            OleDbDataReader reader = command.ExecuteReader();

            while (reader.Read())
            {
                grid.Rows.Add(reader["ClientName"], reader["Id"], reader["PriceForDeal"], reader["AlreadyPaid"], reader["Debt"]);
            }

            reader.Close();

            // подведение итогов
            query = 
                "SELECT Sum(PriceForDeal) AS S1, Sum(AlreadyPaid) AS S2, Sum(PriceForDeal - AlreadyPaid) AS S3 " +
                "FROM Deal " +
                $"WHERE ConclusionDate BETWEEN Now() - {days} AND Now()";
            command.CommandText = query;
            reader = command.ExecuteReader();
            reader.Read();

            grid.Rows.Add("Итого:", null, reader["S1"], reader["S2"], reader["S3"]);
            grid.Rows[grid.RowCount - 1].DefaultCellStyle.Font = conclusionFont;

            // заполнение графика
            chart.Series["PaidSeries"].Points[0].YValues[0] = Convert.ToDouble(reader["S2"]);
            chart.Series["NotPaidSeries"].Points[0].YValues[0] = Convert.ToDouble(reader["S3"]);

            reader.Close();
        }

        private void toolStripButton2_Click(object sender, EventArgs e)
        {
            printDialog1.ShowDialog();
        }
    }
}
