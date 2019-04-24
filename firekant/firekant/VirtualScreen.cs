using System;

namespace firekant
{
    public class VirtualScreen
    {
        private VirtualScreenRow[] _rows;

        public VirtualScreen(int width, int height)
        {
            _rows = new VirtualScreenRow[height];
            for (int i = 0; i < height; i++)
            {
                _rows[i] = new VirtualScreenRow(width, 1);
            }
        }

        public void Add(Box box)
        {
            _rows[box.StartY].AddBoxTopRow(box.X, box.Width);
            for (var i = box.StartY + 1; i < box.EndY; i++)
            {
                _rows[i].AddBoxMiddleRow(box.X, box.Width);
            }
            _rows[box.EndY].AddBoxBottomRow(box.X, box.Width);
        }

        public void Show()
        {
            Console.Clear();
            foreach (var screenRow in _rows)
            {
                screenRow.Show();
            }
        }
    }
}
