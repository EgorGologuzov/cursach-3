using System;
using System.Drawing;

namespace Minesweeper
{
    internal class MineFieldCellEventArgs : EventArgs
    {
        public Point Position { get; private set; }

        public MineFieldCellEventArgs(int x, int y)
        {
            Position = new Point(x, y);
        }
    }
}
