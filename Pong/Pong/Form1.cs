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
            //this.KeyDown += GameForm_KeyDown;
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

        //private void GameForm_KeyDown(object sender, KeyEventArgs e)
        //{
        //    Console.WriteLine(e.KeyData);
        //    switch (e.KeyData)
        //    {
        //        case Keys.W:
        //            GameHandler.p1.PMove(new System.Drawing.Point(0, -10));
        //            break;
        //        case Keys.S:
        //            GameHandler.p1.PMove(new System.Drawing.Point(0, 10));
        //            break;
        //        case Keys.Up:
        //            GameHandler.p2.PMove(new System.Drawing.Point(0, -10));
        //            break;
        //        case Keys.Down:
        //            GameHandler.p2.PMove(new System.Drawing.Point(0, 10));
        //            break;
        //    }
        //}

        protected override void WndProc(ref Message m)
        {
            if (m.Msg == KeyHandler.WM_HOTKEY_MSG_ID)
                HandleHotkey(m);
            base.WndProc(ref m);
        }

        private void HandleHotkey(Message m)
        {
            switch (m.WParam.ToInt32())
            {
                case 1:
                    GameHandler.p1.PMove(new System.Drawing.Point(0, -30));
                    break;
                case 2:
                    GameHandler.p1.PMove(new System.Drawing.Point(0, 30));
                    break;
                case 3:
                    GameHandler.p2.PMove(new System.Drawing.Point(0, -30));
                    break;
                case 4:
                    GameHandler.p2.PMove(new System.Drawing.Point(0, 30));
                    break;
            }
        }
    }
}
