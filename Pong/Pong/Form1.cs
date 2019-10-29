using System;
using System.Windows.Forms;

namespace Pong
{
    public partial class GameForm : Form
    {
        public static Panel GameBoard;
        TPoint game;
        int tCounter = 3;
        Timer matchDelay;
        public GameForm()
        {
            InitializeComponent(); 
        }

        private void GameForm_Load(object sender, EventArgs e)
        {
        }

        private void button1_Click(object sender, EventArgs e)
        {
            matchDelay = new Timer();
            matchDelay.Tick += new EventHandler(ShowTimer);
            matchDelay.Interval = 1000;
            button1.Enabled = false;
            button1.Visible = false;
            timerButton.Enabled = true;
            timerButton.Visible = true;
            matchDelay.Start();
            GameBoard = GamingPanel;
            game = new TPoint();
        }

        private void ShowTimer(Object myObject, EventArgs myEventArgs)
        {
            --tCounter;
            timerButton.Text = tCounter.ToString();
            if (tCounter == 0)
            {
                tCounter = 3;
                matchDelay.Stop();
                game.StartGame();
                timerButton.Enabled = false;
                timerButton.Visible = false;
            }
        }
    }
}
