using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Minesweeper
{
    internal enum CapType
    {
        No, Empty, Flag
    }

    internal class MineFieldCell
    {
        private int _mineCount;

        public bool IsMine { get; set; }
        public CapType Cap { get; set; }
        public int MineCount 
        { 
            get { return _mineCount; } 
            set 
            { 
                if (value < 0 || value > 8) 
                    throw new ArgumentException("Значение ячейки должно быть в диапозоне от 0 до 8");
                _mineCount = value;
            } 
        }

        public MineFieldCell()
        {
            IsMine = false;
            Cap = CapType.Empty;
            MineCount = 0;
        }
    }
}
