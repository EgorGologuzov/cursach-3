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
    public partial class DealViewForm : Form
    {
        public DealViewForm()
        {
            InitializeComponent();
            LoadData();
        }

        private void LoadData()
        {
            try
            {
                grid.Rows.Clear();

                string userQuery = queryTextBox.Text.ToLower();
                string fromDate = fromDataPicker.Value.ToString("d");
                string toDate = toDatePicker.Value.ToString("d");

                string query =
                    "SELECT Deal.Id AS Id, ClientName, ConclusionDate, PriceForDeal, AlreadyPaid " +
                    "FROM Deal INNER JOIN Client ON Client.Id = Deal.Client " +
                    $"WHERE (InStr(1, LCase(ClientName), '{userQuery}') <> 0) AND (ConclusionDate BETWEEN CDate('{fromDate}') AND CDate('{toDate}'))";

                OleDbCommand command = new OleDbCommand(query, MainForm.conn);
                OleDbDataReader reader = command.ExecuteReader();

                if (reader.HasRows)
                {
                    while (reader.Read())
                    {
                        grid.Rows.Add(reader["Id"], reader["ClientName"], reader["ConclusionDate"], reader["PriceForDeal"], reader["AlreadyPaid"]);
                    }
                }
                else
                {
                    MessageBox.Show("Ничего не найдено.");
                }
                
                reader.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Не удалось выполнить фильтрацию. {ex.Message}");
            }
        }

        private void searchButton_Click(object sender, EventArgs e)
        {
            LoadData();
        }
    }
}
