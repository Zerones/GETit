using System;

namespace RandomBoxes
{
    abstract class Shape
    {
        public int DirectionX { get; internal set; }
        public int DirectionY { get; internal set; }
        public int X { get; internal set; }
        public int Y { get; internal set; }

        protected Shape()
        {
        }

        protected Shape(Random random) 
        {
        }

        public void Move(Random random)
        {
            DirectionX = random.Next(-1, 2);
            DirectionY = random.Next(-1, 2);
            X += DirectionX;
            Y += DirectionY;
        }

        public abstract string GetCharacter(int row, int col);
    }
}
