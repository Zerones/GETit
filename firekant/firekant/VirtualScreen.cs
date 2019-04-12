using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace firekant
{
    class VirtualScreen
    {
        private VirtualScreenRow[] _rows;

        public VirtualScreen(int width, int height)
        {
            _rows = new VirtualScreenRow[height];
            for(int i = 0; i < height; i++)
            {
                _rows[i] = new VirtualScreenRow(width);
                var row = _rows[i];
                for(int k = 0; k < width; k++)
                {
                    if (i == 0) row.AddBoxTopRow(k, width);
                    else if (i == height -1) row.AddBoxBottomRow(k, width);
                    else row.AddBoxMiddleRow(k, width);
                }
            }
        }
        public void Add(Box box)
        {

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
