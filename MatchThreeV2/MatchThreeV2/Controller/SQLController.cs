using System;
using System.Configuration;
using System.Data.SqlClient;
using System.Linq;
using System.Threading.Tasks;
using MatchThreeV2.Models;
using MatchThreeV2.SQLTasks;
using MatchThreeV2.View;

namespace MatchThreeV2.Controller
{
     class SqlController
     {
         public static SqlConnection Connection()
         {
             var connectionString = ConfigurationManager.ConnectionStrings["Network"].ConnectionString;
             var connection = new SqlConnection(connectionString);
             return connection;

         }
        public static async Task BoardUpdate(Board board)
         {
            var onlineBoard = new BoardRepository(Connection());
            var updatedBoard = await onlineBoard.FetchBoard();
            foreach (var content in updatedBoard)
            {
                var obj = board.Container.FirstOrDefault(x => x.Id == content.Id);
                if (obj != null) obj.Id = content.Id;
                Convert(content, board);
            }
            BoardView.DrawBoard(board.BoardState());
         }
         public static async Task NextTurn(Board board)
         {
             var onlineBoard = new BoardRepository(Connection());
             var nextPlayer = board.CurrentPlayer == "Player 1" ? "Player 2" : board.CurrentPlayer == "Player 2" ? "Player 1" : " ";
             await onlineBoard.UpdateCounter(nextPlayer);
         }


        public static void BoardSend(Board board, int input, string letter)
        {
            var onlineBoard = new BoardRepository(Connection());
            onlineBoard.UpdateBoard(letter, input).Wait();
        }

        public static async Task<string> GetPlayer()
        {
            var onlineBoard = new BoardRepository(Connection());
            var updatedBoard = await onlineBoard.FetchCounter();
            var playerId = updatedBoard.FirstOrDefault();
            return playerId?.Between ?? " ";
        }


        public static void Convert(BoxObject content, Board board)
        {
            var converted = content.Id - 1;
            switch (content.Between)
            {
                case "X":
                    board.Container[converted].InnerContent = Panel.X;
                    break;
                case "O":
                    board.Container[converted].InnerContent = Panel.O;
                    break;
                default:
                    board.Container[converted].InnerContent = Panel.Empty;
                    break;
            }
        }
     }
}
