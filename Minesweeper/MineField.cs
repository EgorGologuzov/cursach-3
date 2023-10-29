using System;

namespace Minesweeper
{
    internal delegate void MineFieldCellEventHandler(object sender, MineFieldCellEventArgs e);

    internal class MineField
    {
        private MineFieldCell[,] _field;
        private int _nonOpenCellsCount;

        public int Width { get; private set; }
        public int Height { get; private set; }
        public int MineCount { get; private set; }

        public event EventHandler OnAllNonMinedCellsOpen;
        public event EventHandler OnMineOpen;
        public event MineFieldCellEventHandler OnPutFlag;
        public event MineFieldCellEventHandler OnDropFlag;
        public event MineFieldCellEventHandler OnOpenCell;

        private void InitField()
        {
            _field = new MineFieldCell[Width, Height];
            for (int x = 0; x < Width; x++)
            {
                for (int y = 0; y < Height; y++)
                {
                    _field[x, y] = new MineFieldCell();
                }
            }
        }

        private void InstallMines()
        {
            Random rand = new Random();
            int count = MineCount;
            while (count > 0)
            {
                int x = rand.Next(Width);
                int y = rand.Next(Height);
                if (_field[x, y].IsMine)
                {
                    continue;
                }
                else
                {
                    _field[x, y].IsMine = true;
                    count--;
                }
            }
        }

        private int CalcMineAroundCell(int x, int y)
        {
            int count = 0;

            for (int i = x - 1; i <= x + 1; i++)
            {
                for (int j = y - 1; j <= y + 1; j++)
                {
                    if (i > -1 && i < Width && j > -1 && j < Height)
                    {
                        if (_field[i, j].IsMine && !(_field[x, y].IsMine))
                        {
                            count++;
                        }
                    }
                }
            }

            return count;
        }

        private void CalcCellsMineCount()
        {
            for (int x = 0; x < Width; x++)
            {
                for (int y = 0; y < Height; y++)
                {
                    _field[x, y].MineCount = CalcMineAroundCell(x, y);
                }
            }
        }

        private void OpenEmptyNeightborCells(int x, int y)
        {
            if (_field[x, y].MineCount != 0)
            {
                return;
            }

            for (int i = x - 1; i <= x + 1; i++)
            {
                for (int j = y - 1; j <= y + 1; j++)
                {
                    if (i > -1 && i < Width && j > -1 && j < Height)
                    {
                        if (_field[i, j].Cap == CapType.Empty)
                        {
                            OpenCell(i, j);
                            OpenEmptyNeightborCells(i, j);
                        }
                    }
                }
            }
        }

        public MineField(int width, int height, int mineCount)
        {
            if (width < 1 || height < 1 || mineCount < 1)
                throw new ArgumentException("Значения ширины, высоты и количество мин должны быть больше 0");
            if (width * height < mineCount)
                throw new ArgumentException("Количество мин должно быть меньше, чем количество клеток на поле.");

            Width = width;
            Height = height;
            MineCount = mineCount;
            _nonOpenCellsCount = width * height;

            InitField();
            InstallMines();
            CalcCellsMineCount();
        }
        
        public void OpenCell(int x, int y)
        {
            switch (_field[x, y].Cap)
            {
                case CapType.Empty:
                    _field[x, y].Cap = CapType.No;
                    _nonOpenCellsCount--;

                    if (OnOpenCell != null)
                        OnOpenCell(this, new MineFieldCellEventArgs(x, y));

                    if (_field[x, y].IsMine)
                    {
                        if (OnMineOpen != null)
                            OnMineOpen(this, new EventArgs());
                    }
                    else if (_nonOpenCellsCount == MineCount)
                    {
                        if (OnAllNonMinedCellsOpen != null)
                            OnAllNonMinedCellsOpen(this, new EventArgs());
                    }
                    else if (_field[x, y].MineCount == 0)
                    {
                        OpenEmptyNeightborCells(x, y);
                    }

                    break;

                case CapType.No:
                    throw new InvalidOperationException("Эта ячейка уже открыта, ее нельзя открыть");
                case CapType.Flag: 
                    throw new InvalidOperationException("На этой ячейке установлен флаг, ее нельзя открыть");
                
            }
        }

        public void ChangeFlag(int x, int y)
        {
            if (_field[x, y].Cap == CapType.No)
            {
                throw new InvalidOperationException("Эта ячейка открыта, на ней нельзя поставить флаг");
            }
                
            if (_field[x, y].Cap == CapType.Empty)
            {
                _field[x, y].Cap = CapType.Flag;
                if (OnPutFlag != null)
                    OnPutFlag(this, new MineFieldCellEventArgs(x, y));
            }
            else if (_field[x, y].Cap == CapType.Flag)
            {
                _field[x, y].Cap = CapType.Empty;
                if (OnDropFlag != null)
                    OnDropFlag(this, new MineFieldCellEventArgs(x, y));
            }
        }

        public MineFieldCell this[int x, int y]
        {
            get { return _field[x, y]; }
        }
    }
}
