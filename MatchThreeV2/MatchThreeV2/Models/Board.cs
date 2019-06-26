using System.Collections.Generic;

namespace MatchThreeV2.Models
{
    class Board
    {
        public List<BoxObject> Container { get; set; }
        public string[] BoardArray { get; set; }
        public string CurrentPlayer { get; set; }

        public Board(string player)
        {
            CurrentPlayer = player;
        }

        public List<BoxObject> CreateBoard()
        {
            var list = new List<BoxObject>();
            for (var i = 0; i < 9; i++)
            {
                var panel = new BoxObject {Id = i + 1};
                list.Add(panel);
            }

            Container = list;
            return list;
        }

        public void PlayerAction(int id, Panel piece)
        {
            Container[id].InnerContent = piece;
        }

        public string[] BoardState()
        {
            var gameState = new List<string>();
            foreach (var t in Container)
            {
                var content = t.InnerContent == Panel.O ? "O" : t.InnerContent == Panel.X ? "X" : " ";
                gameState.Add(content);
            }

            BoardArray = gameState.ToArray();
            return BoardArray;
        }
    }
}
