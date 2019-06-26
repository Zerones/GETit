using System;
using MatchThreeV2.Models;
using MatchThreeV2.View;

namespace MatchThreeV2.Controller
{
    class PlayerController
    {
        public static void StartGame()
        {
            var player = SqlController.GetPlayer();
            var board = new Board(player.Result);
            board.CreateBoard();
            SqlController.BoardUpdate(board).Wait();
            SqlController.NextTurn(board).Wait();
            while (true)
            {
                if (Conditions.GameEnd(board)) return;
                var currentPlayer = SqlController.GetPlayer();
                if (currentPlayer.Result == board.CurrentPlayer) break;
                BoardView.WaitForNewPlayer(board);
            }
            Console.Clear();
            SqlController.BoardUpdate(board).Wait();
            if (!Conditions.GameEnd(board)) PlayerTurn(board);
        }



        public static void PlayerTurn(Board board)
        {
            while (!Conditions.GameEnd(board))
            {
                Console.Clear();
                SqlController.BoardUpdate(board).Wait();
                BoardView.StaticText(PlayerLetter(board));
                var input = Console.ReadLine();
                int.TryParse(input, out var result);
                if (string.IsNullOrWhiteSpace(input) || result == 0)
                {
                    BoardView.GameError(board, 0);
                    continue;
                }
                var inputToNumber = int.Parse(input);
                if (inputToNumber < 0 || inputToNumber > 9)
                {
                    BoardView.GameError(board, 1);
                    continue;
                }
                var panel = PlayerLetter(board);
                board.PlayerAction(inputToNumber - 1, panel == "X" ? Panel.X : panel == "O" ? Panel.O : Panel.Empty);
                SqlController.BoardSend(board, result, PlayerLetter(board));
                Console.Clear();
                SqlController.BoardUpdate(board).Wait();
                SqlController.NextTurn(board).Wait();
                break;
            }
            if (!Conditions.GameEnd(board)) OpponentTurn(board);
        }

        private static void OpponentTurn(Board board)
        {
            while (true)
            {
                if (Conditions.GameEnd(board)) return;
                var currentPlayer = SqlController.GetPlayer();
                if (currentPlayer.Result == board.CurrentPlayer) break;
                BoardView.WaitingForMove(board);
            }
            if (!Conditions.GameEnd(board)) PlayerTurn(board);
        }

        public static string PlayerLetter(Board board)
        {
            return board.CurrentPlayer.ToLower() == "player 1" ? "X" : board.CurrentPlayer.ToLower() == "player 2" ? "O" : " ";
        }
    }
}
