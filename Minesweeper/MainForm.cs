using System;
using System.Drawing;
using System.Windows.Forms;

namespace Minesweeper
{
    public partial class MainForm : Form
    {
        private const int _pixelCellWidth = 40;
        private MineField _field;
        private int _time, _flagCount;
        private HardMode _hardMode;

        private int Time
        {
            get { return _time; }
            set { _time = value; timeLabel.Text = _time.ToString("0000000000"); }
        }

        private int FlagCount
        {
            get { return _flagCount; }
            set { _flagCount = value;  flagCountLabel.Text = _flagCount.ToString("0000"); }
        }

        public MainForm()
        {
            InitializeComponent();
            NewGame();
        }

        private void Win(object sender, EventArgs e)
        {
            smilePictureBox.Image = Properties.Resources.CoolSmile;
            timer.Enabled = false;

            _field.OnAllNonMinedCellsOpen -= Win;
            _field.OnMineOpen -= Defeat;
            _field.OnPutFlag -= OnPutFlag_Handler;
            _field.OnDropFlag -= OnDropFlag_Handler;
            _field.OnOpenCell -= OnOpenCell_Handler;

            if ((new GameOverForm(GameOverFormMode.Win, _hardMode, _time)).ShowDialog(this) == DialogResult.Retry)
            {
                NewGame();
            }
        }

        private void Defeat(object sender, EventArgs e)
        {
            smilePictureBox.Image = Properties.Resources.SadSmile;
            timer.Enabled = false;

            _field.OnAllNonMinedCellsOpen -= Win;
            _field.OnMineOpen -= Defeat;
            _field.OnPutFlag -= OnPutFlag_Handler;
            _field.OnDropFlag -= OnDropFlag_Handler;

            for (int x = 0; x < _field.Width; x++)
            {
                for (int y = 0; y < _field.Height; y++)
                {
                    if (_field[x, y].Cap == CapType.Flag)
                    {
                        _field.ChangeFlag(x, y);
                    }
                    if (_field[x, y].Cap != CapType.No)
                    {
                        _field.OpenCell(x, y);
                    }
                }
            }

            _field.OnOpenCell -= OnOpenCell_Handler;
                
            if ((new GameOverForm(GameOverFormMode.Defeat, _hardMode, _time)).ShowDialog(this) == DialogResult.Retry)
            {
                NewGame();
            }
        }

        private void OnPutFlag_Handler(object sender, MineFieldCellEventArgs e)
        {
            DataGridViewImageCell cell = (DataGridViewImageCell)grid[e.Position.X, e.Position.Y];
            cell.Value = (Image)Properties.Resources.Flag;
            FlagCount -= 1;
        }

        private void OnDropFlag_Handler(object sender, MineFieldCellEventArgs e)
        {
            DataGridViewImageCell cell = (DataGridViewImageCell)grid[e.Position.X, e.Position.Y];
            cell.Value = (Image)Properties.Resources.Cap;
            FlagCount += 1;
        }

        private void OnOpenCell_Handler(object sender, MineFieldCellEventArgs e)
        {
            SetCellImageByMineCount(e.Position.X, e.Position.Y);
        }

        private void NewGame()
        {
            int width = (int)Properties.Settings.Default.FieldWidth;
            int height = (int)Properties.Settings.Default.FieldHeight;
            int minesCount = (int)Properties.Settings.Default.MinesCount;

            _hardMode = (HardMode)Properties.Settings.Default.ModeIndex;

            _field = new MineField(width, height, minesCount);
            _field.OnAllNonMinedCellsOpen += Win;
            _field.OnMineOpen += Defeat;
            _field.OnPutFlag += OnPutFlag_Handler;
            _field.OnDropFlag += OnDropFlag_Handler;
            _field.OnOpenCell += OnOpenCell_Handler;

            FillGridByCells();
            FillGridByImages();

            smilePictureBox.Image = Properties.Resources.SmilingSmile;

            Time = 0;
            timer.Enabled = true;
            FlagCount = minesCount;
        }

        private void SetCellImageByMineCount(int x, int y)
        {
            MineFieldCell fCell = _field[x, y];
            DataGridViewImageCell gCell = (DataGridViewImageCell)grid[x, y];

            if (fCell.IsMine)
            {
                gCell.Value = (Image)Properties.Resources.Bomb;
            }
            else
            {
                switch (fCell.MineCount)
                {
                    case 0: gCell.Value = (Image)Properties.Resources._0; break;
                    case 1: gCell.Value = (Image)Properties.Resources._1; break;
                    case 2: gCell.Value = (Image)Properties.Resources._2; break;
                    case 3: gCell.Value = (Image)Properties.Resources._3; break;
                    case 4: gCell.Value = (Image)Properties.Resources._4; break;
                    case 5: gCell.Value = (Image)Properties.Resources._5; break;
                    case 6: gCell.Value = (Image)Properties.Resources._6; break;
                    case 7: gCell.Value = (Image)Properties.Resources._7; break;
                    case 8: gCell.Value = (Image)Properties.Resources._8; break;
                    default: throw new Exception("Недопустимое значение свойства Value ячейки.");
                }
            }
        }

        private void FillGridByImages()
        {
            for (int x = 0; x < _field.Width; x++)
            {
                for (int y = 0; y < _field.Height; y++)
                {
                    MineFieldCell fCell = _field[x, y];
                    if (fCell.Cap == CapType.No)
                    {
                        SetCellImageByMineCount(x, y);
                    }
                    else if (fCell.Cap == CapType.Empty)
                    {
                        DataGridViewImageCell gCell = (DataGridViewImageCell)grid[x, y];
                        gCell.Value = (Image)Properties.Resources.Cap;
                    }
                }
            }
        }

        private void smilePictureBox_Click(object sender, EventArgs e)
        {
            NewGame();
        }

        private void settingsPictureBox_Click(object sender, EventArgs e)
        {
            SettingsForm settingsForm = new SettingsForm();
            if (settingsForm.ShowDialog(this) == DialogResult.Retry)
            {
                NewGame();
            }
        }

        private void FillGridByCells()
        {
            grid.Columns.Clear();

            for (int i = 0; i < _field.Width; i++)
            {
                DataGridViewImageColumn col = new DataGridViewImageColumn();
                col.Width = _pixelCellWidth;
                //col.ImageLayout = DataGridViewImageCellLayout.Zoom;
                grid.Columns.Add(col);
            }

            for (int i = 0; i < _field.Height; i++)
            {
                grid.Rows.Add();
                grid.Rows[grid.RowCount - 1].Height = _pixelCellWidth;
            }
        }

        private void grid_CellMouseClick(object sender, DataGridViewCellMouseEventArgs e)
        {
            if (e.Button == MouseButtons.Left)
            {
                try
                {
                    _field.OpenCell(e.ColumnIndex, e.RowIndex);
                }
                catch
                {
                    return;
                }
            }
            else if (e.Button == MouseButtons.Right)
            {
                try
                {
                    _field.ChangeFlag(e.ColumnIndex, e.RowIndex);
                }
                catch
                {
                    return;
                }
            }
        }

        private void topPictureBox_Click(object sender, EventArgs e)
        {
            TopViewForm topViewForm = new TopViewForm();
            topViewForm.ShowDialog(this);
        }

        private void helpPictureBox_Click(object sender, EventArgs e)
        {
            AboutForm aboutForm = new AboutForm();
            aboutForm.ShowDialog(this);
        }

        private void timer_Tick(object sender, EventArgs e)
        {
            Time += 1;
        }
    }
}
