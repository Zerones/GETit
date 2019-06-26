using MatchThreeV2.Models;
using System;
using System.Text;
using System.Threading;

namespace MatchThreeV2.View
{
    class BoardView
    {
        public static void XWon(Board board)
        {
            Console.Clear();
            Console.WriteLine(board.CurrentPlayer.ToLower() == "player 1" ? "Congratulations you won!" : "You lost!");
            Thread.Sleep(6000);
        }
        public static void OWon(Board board)
        {
            Console.Clear();
            Console.WriteLine(board.CurrentPlayer.ToLower() == "player 2" ? "Congratulations you won!" : "You lost!");
            Thread.Sleep(6000);
        }

        public static void StaticText(string letter)
        {
            Console.Write($"Type which square you want to place an {letter} in:");
        }

        public static void DotText(Board board)
        {
            Thread.Sleep(500);
            Console.Write(".");
            Thread.Sleep(500);
            Console.Write(".");
            Thread.Sleep(500);
            Console.Write(".");
            Thread.Sleep(500);
            Console.Clear();
            DrawBoard(board.BoardArray);
        }

        public static void WaitingForMove(Board board)
        {
            Console.Write("Waiting for your opponent to make a move");
            DotText(board);
        }

        public static void WaitForNewPlayer(Board board)
        {
            Console.Write("Waiting for another player to connect");
            DotText(board);
        }

        public static void DrawBoard(string[] array)
        {
            var builder = new StringBuilder();
            builder.Append("_______" + Environment.NewLine);
            for (var i = 0; i < array.Length / 3; i++)
                builder.Append($"|{array[i * 3]}|{array[1 + i * 3]}|{array[2 + i * 3]}|" + Environment.NewLine);

            builder.Append("-------");
            Console.WriteLine(builder.ToString());
        }

        public static void GameError(Board board, int id)
        {
            Console.WriteLine(id == 1 ? "Invalid input, outside of range(1-9)" : "Invalid input, not a number");
            Thread.Sleep(3000);
            Console.Clear();
            DrawBoard(board.BoardState());
        }

    }
}
