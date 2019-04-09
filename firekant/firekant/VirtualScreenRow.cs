using System;

namespace firekant
{
    class VirtualScreenRow
    {
        private VirtualScreenCell[] _cells;
        private int _screenWidth;

        public VirtualScreenRow(int screenWidth)
        {
        }

        public void Show()
        {
            var koo = new VirtualScreenCell[9];
            for (int i = 0; i < 9; i++)
            {
                var cell = new VirtualScreenCell();
                cell.AddVertical();
                koo[i] = cell;
            }
            foreach (var cell in koo)
            {
                char e = cell.GetCharacter();
                Console.Write(e);
            }


        }

    }
}
