using System;
using System.Windows.Forms;

namespace Pong
{
    public partial class GameForm : Form
    {
        GameHandler game;
        public static Panel gB;
        public static Button tB;
        public static GameForm gF;

        public GameForm()
        {
            InitializeComponent();
        }

        private void GameForm_Load(object sender, EventArgs e)
        {
            this.KeyDown += GameForm_KeyDown;
            gB = gamingPanel;
            tB = timerButton;
            gF = this;
            game = new GameHandler();
        }

        private void button1_Click(object sender, EventArgs e)
        {   
            button1.Visible = false;
            GameHandler.StartGame();
            gF.Focus();
        }

        private void GameForm_KeyDown(object sender, KeyEventArgs e)
        {
            Console.WriteLine(e.KeyData);
            switch (e.KeyData)
            {
                case Keys.W:
                    GameHandler.p1.PMove(new System.Drawing.Point(0, -10));
                    break;
                case Keys.S:
                    GameHandler.p1.PMove(new System.Drawing.Point(0, 10));
                    break;
                case Keys.Up:
                    GameHandler.p2.PMove(new System.Drawing.Point(0, -10));
                    break;
                case Keys.Down:
                    GameHandler.p2.PMove(new System.Drawing.Point(0, 10));
                    break;
            }
        }
    }
}
