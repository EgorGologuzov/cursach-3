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
    public partial class ServiceCatalogForm : Form
    {
        private bool changesAreSaved = true;

        public ServiceCatalogForm()
        {
            InitializeComponent();
            FillTable();
        }

        private void FillTable()
        {
            try
            {
                grid.Rows.Clear();
                
                string query = "SELECT * FROM Service";
                OleDbCommand command = new OleDbCommand(query, MainForm.conn);
                OleDbDataReader reader = command.ExecuteReader();

                while (reader.Read())
                {
                    grid.Rows.Add(reader["Id"], reader["Title"], reader["Description"], "0");
                }

                reader.Close();

                if (grid.Rows.Count > 0)
                {
                    // grid.CurrentCell = grid.Rows[0].Cells["Title"];
                    textBox.Text = grid.Rows[0].Cells["Description"].Value.ToString();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Не удалось загрузить таблицу. {ex.Message}");
            }
        }

        private void ChangesNotSaved()
        {
            if (changesAreSaved)
            {
                changesAreSaved = false;
                statusLabel.Text = "Изменения не сохранены";
            }
        }

        private void ChangesAreSaved()
        {
            if ( ! changesAreSaved)
            {
                changesAreSaved = true;
                statusLabel.Text = "Изменения сохранены";
            }
        }

        private void addButton_Click(object sender, EventArgs e)
        {
            grid.Rows.Add(null, "Новая услуга", "", "1");
            grid.CurrentCell = grid.Rows[grid.RowCount - 1].Cells["Title"];
        }

        private void saveChangesButton_Click(object sender, EventArgs e)
        {
            grid.EndEdit();
            try
            {
                foreach (DataGridViewRow row in grid.Rows)
                {
                    if (row.Cells["Changed"].Value.ToString() == "1")
                    {
                        string title = row.Cells["Title"].Value.ToString();
                        string description = row.Cells["Description"].Value.ToString();

                        if (row.Cells["Id"].Value == null)
                        {
                            string query = 
                                $"INSERT INTO Service (Title, Description) VALUES ('{title}', '{description}')";
                            OleDbCommand command = new OleDbCommand(query, MainForm.conn);
                            command.ExecuteNonQuery();
                        }
                        else
                        {
                            string query =
                                $"UPDATE Service SET Title = '{title}', Description = '{description}' " +
                                $"WHERE Id = {row.Cells["Id"].Value}";
                            OleDbCommand command = new OleDbCommand(query, MainForm.conn);
                            command.ExecuteNonQuery();
                        }
                    }
                }  
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Не удалось сохранить таблицу. {ex.Message}");
            }

            FillTable();
            ChangesAreSaved();
        }

        private void deleteButton_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show(
                "Вы уверенны, что хотите удалить сервис. Вместе с ним будут удалены все связанные договоры.",
                "Предупреждение!",
                MessageBoxButtons.YesNo) == DialogResult.Yes)
            {
                if (grid.CurrentRow != null)
                {
                    if (grid.CurrentRow.Cells["Id"].Value == null)
                    {
                        grid.Rows.Remove(grid.CurrentRow);
                        return;
                    }

                    try
                    {
                        string query = $"DELETE FROM Service WHERE Id = {grid.CurrentRow.Cells["Id"].Value}";
                        OleDbCommand command = new OleDbCommand(query, MainForm.conn);
                        command.ExecuteNonQuery();
                        grid.Rows.Remove(grid.CurrentRow);
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show($"Не удалось выполнить удаление. {ex.Message}");
                    }
                }
                else
                {
                    MessageBox.Show("Не выбрана строка для удаления.", "Ошибка!");
                }
            }
        }

        private void grid_CellBeginEdit(object sender, DataGridViewCellCancelEventArgs e)
        {
            grid.Rows[e.RowIndex].Cells["Changed"].Value = "1";
            ChangesNotSaved();
        }

        private void grid_SelectionChanged(object sender, EventArgs e)
        {
            if (grid.SelectedCells.Count != 0)
            {
                textBox.Text = grid.Rows[grid.SelectedCells[0].RowIndex].Cells["Description"].Value.ToString();
            }
        }

        private void textBox_TextChanged(object sender, EventArgs e)
        {
            try
            {
                if (grid.SelectedCells.Count != 0 && textBox.Focused)
                {
                    grid.Rows[grid.SelectedCells[0].RowIndex].Cells["Description"].Value = textBox.Text;
                    grid.Rows[grid.SelectedCells[0].RowIndex].Cells["Changed"].Value = "1";
                    ChangesNotSaved();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Не удалось обновить описание. {ex.Message}");
            }
        }

        private void grid_CellEndEdit(object sender, DataGridViewCellEventArgs e)
        {
            if (grid.Rows[e.RowIndex].Cells[e.ColumnIndex].Value == null)
            {
                grid.Rows[e.RowIndex].Cells[e.ColumnIndex].Value = "";
            }
        }

        private void ServiceCatalogForm_FormClosing(object sender, FormClosingEventArgs e)
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
