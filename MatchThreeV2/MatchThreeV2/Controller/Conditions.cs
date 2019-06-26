using MatchThreeV2.Models;
using MatchThreeV2.View;
using System.Collections.Generic;

namespace MatchThreeV2.Controller
{
    class Conditions
    {
        public static int[][] Solutions()
        {
            var array = new int[][]
                {
                    new int[]{1, 2, 3},
                    new int[]{4, 5, 6},
                    new int[]{7, 8, 9},
                    new int[]{1, 4, 7},
                    new int[]{2, 5, 8},
                    new int[]{ 3, 6, 9 },
                    new int[]{ 1, 5, 9 },
                    new int[]{ 3, 5, 7 }
                };
            return array;
        }
        public static bool GameEnd(Board board)
        {
            var map = BoardMap(board);
            var result = CheckForGameEnd(map, board);
            switch (result)
            {
                case 1:
                    BoardView.XWon(board);
                    return true;
                case -1:
                    BoardView.OWon(board);
                    return true;
                default:
                    break;
            }
            return false;
        }

        private static int CheckForGameEnd(IReadOnlyList<int> list, Board board)
        {
            var arrayStack = Solutions();
            foreach (var solution in arrayStack)
            {
                for (var i = 0; i < solution[0]; i++)
                {
                    for (var j = 0; j < solution[1]; j++)
                    {
                        for (var k = 0; k < solution[2]; k++)
                        {
                            if (list[i] != (solution[0])) continue;
                            if (list[j] != (solution[1])) continue;
                            if (list[k] != (solution[2])) continue;
                            var line = new int[] { i, j, k};
                            var counter = 0;
                            foreach (var number in line)
                            {
                                switch (board.Container[number].InnerContent)
                                {
                                    case Panel.X:
                                        counter++;
                                        break;
                                    case Panel.O:
                                        counter--;
                                        break;
                                }
                            }
                            switch (counter)
                            {
                                case 3:
                                    return 1;
                                case -3:
                                    return -1;
                                default:
                                    break;
                            }
                        }
                    }
                }
            }

            return 0;
        }

        public static List<int> BoardMap(Board board)
        {
            var list = new List<int>();
            foreach (var content in board.Container)
            {
                list.Add(content.Id);
            }
            return list;
        }
    }
}
