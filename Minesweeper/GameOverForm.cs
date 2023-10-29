using System;
using System.Data.OleDb;
using System.Windows.Forms;

namespace Minesweeper
{
    public enum GameOverFormMode
    {
        Win, Defeat
    }

    public partial class GameOverForm : Form
    {
        private GameOverFormMode _formMode;
        private HardMode _hardMode;
        private int _time;

        public GameOverForm()
        {
            InitializeComponent();
        }
        public GameOverForm(GameOverFormMode formMode, HardMode hardMode, int time)
        {

            InitializeComponent();
            CenterToParent();

            _formMode = formMode;
            _hardMode = hardMode;  
            _time = time;

            if (formMode == GameOverFormMode.Win)
            {
                nameTextBox.Visible = true;
                string name = Properties.Settings.Default.LastUserName;
                nameTextBox.Text = name;
                nameTextBox.Focus();
                nameTextBox.SelectAll();

                messageLabel.Text = "Вы успешно разминировали поле!" + Environment.NewLine + "Введите свое имя:";
                this.Text = "Победа!";
            }
            else if (formMode == GameOverFormMode.Defeat)
            {
                messageLabel.Text = "К сожелению это конец.";
                this.Text = "Игра окончена.";
            }
        }

        private void GameOverForm_FormClosing(object sender, FormClosingEventArgs e)
        {
            if (_formMode == GameOverFormMode.Win)
            {
                try
                {
                    string name = nameTextBox.Text;
                    Properties.Settings.Default.LastUserName = name;
                    Properties.Settings.Default.Save();

                    DataBaseTool.InsertRecord(name, _time, _hardMode);
                }
                catch (Exception ex)
                {
                    MessageBox.Show($"Не удалось записать рекорд. {ex.Message}");
                }
            }
        }
    }
}
