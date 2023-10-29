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
using System.Windows.Forms.DataVisualization.Charting;

namespace NotarialOffice
{
    public partial class ServiceDiagramForm : Form
    {
        public ServiceDiagramForm()
        {
            InitializeComponent();
        }

        private void ServiceDiagramForm_Load(object sender, EventArgs e)
        {
            chart.Series.Clear();
            
            string query =
                "SELECT Service.Title AS Title, Count(DealData.Service) AS CountService " +
                "FROM Service INNER JOIN DealData ON Service.Id = DealData.Service " +
                "GROUP BY Service.Title";

            OleDbCommand command = new OleDbCommand(query, MainForm.conn);
            OleDbDataReader reader = command.ExecuteReader();

            while (reader.Read())
            {
                Series series = new Series(reader["Title"].ToString());
                series.Points.AddXY(0, Convert.ToDouble(reader["CountService"]));
                chart.Series.Add(series);
            }
        }
    }
}
