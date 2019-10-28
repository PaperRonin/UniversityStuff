using System;
using System.Windows.Forms;

namespace Pong
{
    public partial class GameForm : Form
    {
        public static Panel GameBoard;
        TPoint game;
        public GameForm()
        {
            InitializeComponent(); 
        }

        private void GameForm_Load(object sender, EventArgs e)
        {
            GameBoard = GamingPanel;
            game = new TPoint();
            game.StartGame();
        }
    }
}
