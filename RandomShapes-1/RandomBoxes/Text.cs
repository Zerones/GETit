using System;

namespace RandomBoxes
{
    class Text : Shape
    {
        private string _text;

        public Text(int x, int y)
        {
            X = x;
            Y = y;
        }
        public Text(int x, int y, string text, Random random) : base(random)
        {
            Y = y;
            X = x;
            _text = text;
        }

        public override string GetCharacter(int row, int col)
        {
            if (row != Y || col < X || col >= X + _text.Length) return null;
            var index = col - X;
            return _text[index].ToString();
        }
    }
}
