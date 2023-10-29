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
    public partial class ClientsCatalogForm : Form
    {
        private OleDbCommand command = new OleDbCommand();

        public ClientsCatalogForm()
        {
            InitializeComponent();

            command.Connection = MainForm.conn;
            FillTable();
        }

        private void FillTable()
        {
            command.CommandText = "SELECT * FROM Client";
            OleDbDataReader reader = command.ExecuteReader();
            grid.Rows.Clear();

            while (reader.Read())
            {
                grid.Rows.Add(
                    reader[0],
                    reader[1],
                    reader[2],
                    reader[3],
                    reader[4],
                    "0"
                );
            }

            reader.Close();
        }

        private void addButton_Click(object sender, EventArgs e)
        {
            grid.ClearSelection();
            grid.Rows.Add(null, "Новый клиент", "", "", "", "1");
            grid.CurrentCell = grid.Rows[grid.RowCount - 1].Cells[1];
            statusLabel.Text = "Изменения не сохранены";
        }

        private void saveChangesButton_Click(object sender, EventArgs e)
        {
            grid.EndEdit();
            foreach (DataGridViewRow row in grid.Rows)
            {
                if (row.Cells[5].Value.ToString() == "1")
                {
                    string name = row.Cells[1].Value.ToString();
                    string activity = row.Cells[2].Value.ToString();
                    string adress = row.Cells[3].Value.ToString();
                    string phone = row.Cells[4].Value.ToString();

                    if (row.Cells[0].Value == null)
                    {
                        command.CommandText =
                        "INSERT INTO Client (ClientName, TypeOfActivity, Adress, PhoneNumber) " +
                        $"VALUES ('{name}', '{activity}', '{adress}', '{phone}')";

                        try
                        {
                            command.ExecuteNonQuery();
                        }
                        catch
                        {
                            grid.CurrentCell = row.Cells[1];
                            MessageBox.Show($"Ошибка в данных в строке {row.Index + 1}", "Ошибка!");
                            return;
                        }
                    }
                    else
                    {
                        command.CommandText =
                        $"UPDATE Client SET ClientName = '{name}', TypeOfActivity = '{activity}', Adress = '{adress}', PhoneNumber = '{phone}' " +
                        $"WHERE Id = {row.Cells[0].Value}";

                        try
                        {
                            command.ExecuteNonQuery();
                        }
                        catch (InvalidOperationException ex)
                        {
                            grid.CurrentCell = row.Cells[1];
                            MessageBox.Show($"Ошибка в данных в строке {row.Index + 1}, {ex.Message}", "Ошибка!");
                            return;
                        }
                    }

                    row.Cells[5].Value = "0";
                }
            }

            statusLabel.Text = "Изменения сохранены";
            FillTable();
        }

        private void deleteButton_Click(object sender, EventArgs e)
        {
            if (grid.SelectedCells.Count != 0)
            {
                DataGridViewCell cell = grid.SelectedCells[0];

                if (MessageBox.Show("Вы уверены, что хотите удалить клиента? Это приведет и удалению всех его сделок.", "Предупрежление!", MessageBoxButtons.YesNo) == DialogResult.Yes)
                {
                    if (grid.Rows[cell.RowIndex].Cells[0].Value == null)
                    {
                        grid.Rows.RemoveAt(cell.RowIndex);
                    }
                    else
                    {
                        command.CommandText =
                        $"DELETE FROM Client WHERE Id = {grid.Rows[cell.RowIndex].Cells[0].Value}";

                        try
                        {
                            command.ExecuteNonQuery();
                            grid.Rows.RemoveAt(cell.RowIndex);
                        }
                        catch (InvalidOperationException ex)
                        {
                            MessageBox.Show(ex.Message.ToString(), "Ошибка!");
                            return;
                        }
                    }
                }
            }
            else
            {
                MessageBox.Show("Не выбрана строка для удаления.", "Ошибка!");
            }
        }

        private void grid_CellEndEdit(object sender, DataGridViewCellEventArgs e)
        {
            grid.Rows[e.RowIndex].Cells[5].Value = "1";
            statusLabel.Text = "Изменения не сохранены";

            if (grid.Rows[e.RowIndex].Cells[e.ColumnIndex].Value == null)
            {
                grid.Rows[e.RowIndex].Cells[e.ColumnIndex].Value = "";
            }
        }

        private void ClientsCatalogForm_FormClosing(object sender, FormClosingEventArgs e)
        {
            try
            {
                saveChangesButton_Click(null, null);
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Не удалось сохранить изменения. {ex.Message}");
            }
        }
    }
}
