using System;

namespace firekant
{
    class VirtualScreenRow
    {
        private VirtualScreenCell[] _cells;

        public VirtualScreenRow(int width)
        {
            _cells = new VirtualScreenCell[width];
            for (var i = 0; i < _cells.Length; i++)
            {
                _cells[i] = new VirtualScreenCell();
                if (i == 0 || i == width - 1) AddBoxTopRow(i, width);
                else
                {
                    _cells[i].AddHorizontal();
                }
            }
        }
        public void AddBoxTopRow(int boxX, int boxWidth)
        {
            if(boxX == 0)
            {
                _cells[boxX].AddUpperLeftCorner();
            }
            if(boxX == boxWidth - 1)
            {
                _cells[boxWidth - 1].AddUpperRightCorner();
            }
        }
        public void Show()
        {
            foreach (var cell in _cells)
            {
                char e = cell.GetCharacter();
                Console.Write(e);
            }


        }

    }
}
