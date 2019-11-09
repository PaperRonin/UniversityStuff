using System;
using System.Windows.Forms;

namespace Pong
{
    public partial class GameForm : Form
    {
        GameHandler game;

        public GameForm()
        {
            InitializeComponent();
            KeyHandler ghk = new KeyHandler(Keys.W, this, 1);
            ghk.Register();
            ghk = new KeyHandler(Keys.S, this, 2);
            ghk.Register();
            ghk = new KeyHandler(Keys.Up, this, 3);
            ghk.Register();
            ghk = new KeyHandler(Keys.Down, this, 4);
            ghk.Register();
        }

        private void GameForm_Load(object sender, EventArgs e)
        {
            GlobalVariables.gB = gamingPanel;
            GlobalVariables.tB = timerButton;
            GlobalVariables.gF = this;
            game = new GameHandler();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            button1.Visible = false;
            GameHandler.StartGame();
        }

        protected override void WndProc(ref Message m)
        {
            if (m.Msg == GlobalVariables.WM_HOTKEY_MSG_ID)
                HandleHotkey(m);
            base.WndProc(ref m);
        }

        private void HandleHotkey(Message m)
        {
            switch (m.WParam.ToInt32())
            {
                case 1:
                    GlobalVariables.wIsPressed = true;
                    break;
                case 2:
                    GlobalVariables.sIsPressed = true;
                    break;
                case 3:
                    GlobalVariables.upIsPressed = true;
                    break;
                case 4:
                    GlobalVariables.downIsPressed = true;
                    break;
            }
        }
    }
}
