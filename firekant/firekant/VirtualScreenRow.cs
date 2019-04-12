using System;

namespace firekant
{
    class VirtualScreenRow
    {
        private VirtualScreenCell[] _cells;

        public VirtualScreenRow(int width)
        {
            _cells = new VirtualScreenCell[width];
            for (var i = 0; i < width; i++)
            {
                _cells[i] = new VirtualScreenCell();
            }
        }
        public void AddBoxTopRow(int i, int width)
        {
            var cell = _cells[i];
            if(i == 0) cell.AddUpperLeftCorner();
            else if (i == width - 1) cell.AddUpperRightCorner();
            else cell.AddHorizontal();
        }
        public void AddBoxBottomRow(int i, int width)
        {
            var cell = _cells[i];
            if (i == 0) cell.AddLowerLeftCorner();
            else if (i == width - 1) cell.AddLowerRightCorner();
            else cell.AddHorizontal();
        }
        public void AddBoxMiddleRow(int i, int width)
        {
            var cell = _cells[i];
            if (i == 0 || i == width - 1) cell.AddVertical();
        }

        public void Show()
        {
            for(int i = 0; i < _cells.Length; i++)
            {
                var innhold = _cells[i].GetCharacter();
                Console.Write(innhold);
            }
            Console.Write(Environment.NewLine);
        }

    }
}
