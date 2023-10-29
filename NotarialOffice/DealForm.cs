using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Data.OleDb;

namespace NotarialOffice
{
    public partial class DealForm : Form
    {

        public DealForm()
        {
            InitializeComponent();
            comissionPercentComboBox.SelectedItem = "10%";
            LoadClientList();
            LoadServiceList();
        }

        private void LoadClientList()
        {
            string query = "SELECT ClientName FROM Client";
            OleDbCommand command = new OleDbCommand(query, MainForm.conn);
            OleDbDataReader reader = command.ExecuteReader();

            clientComboBox.Items.Clear();
            while (reader.Read())
            {
                clientComboBox.Items.Add(reader["ClientName"]);
            }
            reader.Close();

            if (clientComboBox.Items.Count != 0)
            {
                clientComboBox.SelectedIndex = clientComboBox.Items.Count - 1;
            }
        }

        private void LoadServiceList()
        {
            string query = "SELECT Title FROM Service";
            OleDbCommand command = new OleDbCommand(query, MainForm.conn);
            OleDbDataReader reader = command.ExecuteReader();

            DataGridViewComboBoxColumn col = (DataGridViewComboBoxColumn)grid.Columns["Title"];
            col.Items.Clear();
            while (reader.Read())
            {
                col.Items.Add(reader["Title"]);
            }
            reader.Close();
        }

        private bool TryFindAndActivateFrom(string name)
        {
            foreach (Form form in Application.OpenForms)
            {
                if (form.Name == name)
                {
                    form.BringToFront();
                    return true;
                }
            }
            return false;
        }

        private string GetClientId(string name)
        {
            string query = $"SELECT Id FROM Client WHERE ClientName = '{name}'";
            OleDbCommand command = new OleDbCommand(query, MainForm.conn);
            OleDbDataReader reader = command.ExecuteReader();
            reader.Read();
            return reader["Id"].ToString();
        }

        private string GetServiceId(string name)
        {
            string query = $"SELECT Id FROM Service WHERE Title = '{name}'";
            OleDbCommand command = new OleDbCommand(query, MainForm.conn);
            OleDbDataReader reader = command.ExecuteReader();
            reader.Read();
            return reader["Id"].ToString();
        }

        private string GetCurrentDealId()
        {
            string query = $"SELECT Max(Id) AS Id FROM Deal";
            OleDbCommand command = new OleDbCommand(query, MainForm.conn);
            OleDbDataReader reader = command.ExecuteReader();
            reader.Read();
            return reader["Id"].ToString();
        }

        private void addButton_Click(object sender, EventArgs e)
        {
            try
            {
                // вставка сделки
                string amount = Convert.ToDouble(amountTextBox.Text).ToString().Replace(',', '.');
                string comission = Convert.ToDouble(comissionTextBox.Text).ToString().Replace(',', '.');
                string date = conclusionDatePicker.Value.ToString("d");
                string client = GetClientId(clientComboBox.SelectedItem.ToString());
                string description = descriptionTextBox.Text;

                string query =
                    "INSERT INTO Deal (Client, PriceForDeal, Comission, ConclusionDate, AlreadyPaid, Description)" +
                    $"VALUES ({client}, {amount}, {comission}, '{date}', 0, '{description}')";

                OleDbCommand command = new OleDbCommand(query, MainForm.conn);
                command.ExecuteNonQuery();

                // вставка всех услуг
                foreach (DataGridViewRow row in grid.Rows)
                {
                    DataGridViewComboBoxCell serviceCell = (DataGridViewComboBoxCell)row.Cells["Title"];

                    if (serviceCell.Value != null)
                    {
                        if (row.Cells["Description"].Value == null)
                        {
                            description = " ";
                        }
                        else
                        {
                            description = row.Cells["Description"].Value.ToString();
                        }
                        query =
                            $"INSERT INTO DealData VALUES ({GetCurrentDealId()}, {GetServiceId(serviceCell.Value.ToString())}, FALSE, '{description}')";
                        command.CommandText = query;
                        command.ExecuteNonQuery();
                    }
                }

                this.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Не удалось добавить сделку. {ex.Message}.");
            }
        }

        private void updateComission(object sender, EventArgs e)
        {
            try
            {
                double amount = Convert.ToDouble(amountTextBox.Text);
                double comission = -1;
                switch (comissionPercentComboBox.SelectedItem.ToString())
                {
                    case "5%": comission = Math.Round(amount * 0.05, 2); break;
                    case "10%": comission = Math.Round(amount * 0.10, 2); break;
                    case "15%": comission = Math.Round(amount * 0.15, 2); break;
                    case "20%": comission = Math.Round(amount * 0.20, 2); break;
                }
                if (comission != -1)
                {
                    comissionTextBox.Text = comission.ToString();
                }
            }
            catch
            {
                comissionTextBox.Text = "0";
            }
        }

        private void acceptOnlyDigitSymbols(object sender, KeyPressEventArgs e)
        {
            char ch = e.KeyChar;
            TextBox s = (TextBox)sender;
            if ( !(char.IsDigit(ch) || char.IsControl(ch) || (ch == ',' && !s.Text.Contains(ch))))
            {
                e.Handled = true;
            }
        }

        private void userChangeComission(object sender, EventArgs e)
        {
            if (comissionTextBox.Focused)
            {
                comissionPercentComboBox.SelectedItem = "Другая";
            }
        }

        private void leaveTextBox(object sender, EventArgs e)
        {
            TextBox s = (TextBox)sender;

            if (s.Text.Length == 0)
            {
                s.Text = "0";
                return;
            }

            try
            {
                s.Text = Math.Round(Convert.ToDouble(s.Text), 2).ToString();
            }
            catch
            {
                s.Text = "0";
            }
        }

        private void newClientButton_Click(object sender, EventArgs e)
        {
            if (TryFindAndActivateFrom("ClientsCatalogForm"))
            {
                return;
            }

            ClientsCatalogForm clientsCatalogForm = new ClientsCatalogForm();
            clientsCatalogForm.MdiParent = Application.OpenForms["MainForm"];
            clientsCatalogForm.Show();
        }

        private void DealForm_Activated(object sender, EventArgs e)
        {
            LoadClientList();
        }

        private void cancelButton_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
