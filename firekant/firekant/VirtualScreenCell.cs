using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace firekant
{
    class VirtualScreenCell
    {
        public bool Up { get; private set; }
        public bool Down { get; private set; }
        public bool Left { get; private set; }
        public bool Right { get; private set; }

        public char GetCharacter()
        {
            if (Up && !Down && !Left && Right) return '┌';
            if (!Up && !Down && Left && Right) return '─';
            if (!Up && Down && Left && !Right) return '┐';
            if (Up && !Down && !Left && Right) return '└';
            if (Up && !Down && Left && !Right) return '┘';
            if (Up && Down && !Left && !Right) return '│';
            if (Up && Down && Left && Right) return '┼';
            if (!Up && Down && Left && Right) return '┬';
            if (Up && Down && Left && !Right) return '┤';
            if (Up && Down && !Left && Right) return '├';
            if (Up && !Down && Left && Right) return '┴';
            return ' ';
        }





        public void AddHorizontal() => Left = Right = true;
        public void AddVertical() => Up = Down = true;
        public void AddLowerLeftCorner() => Down = Left = true;
        public void AddUpperLeftCorner() => Up = Left = true;
        public void AddUpperRightCorner() => Up = Right = true;
        public void AddLowerRightCorner() => Down = Right = true;

    }
}
