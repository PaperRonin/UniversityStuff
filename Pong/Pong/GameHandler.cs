using System;
using System.Drawing;
using System.Windows.Forms;

namespace Pong
{
    class GameHandler
    {
        private static Timer moveDelay, matchDelay;
        private static int p1Score = 0;
        private static int p2Score = 0;
        private static Ball ball;
        private static Point location, vector;
        private static Random random = new Random();
        private static int tCounter = 3;


        static GameHandler()
        {
            location = new Point(GlobalVariables.ballSize * 3, random.Next(GlobalVariables.ballSize, GlobalVariables.gB.Height) - GlobalVariables.ballSize);
            vector = new Point(random.Next(4, 6), random.Next(0, 5));
            ball = new Ball(GlobalVariables.gB);
            ball.Hide();

            GlobalVariables.p1 = new PlayerControls(GlobalVariables.gB, new Point(1, GlobalVariables.gB.Height / 4));
            GlobalVariables.p2 = new PlayerControls(GlobalVariables.gB, new Point(GlobalVariables.gB.Width - 41,
                GlobalVariables.gB.Height / 4));
            GlobalVariables.p1.Hide();
            GlobalVariables.p2.Hide();

            moveDelay = new Timer();
            moveDelay.Tick += new EventHandler(MoveOnTick);
            moveDelay.Interval = 30;


            matchDelay = new Timer();
            matchDelay.Tick += new EventHandler(ShowTimer);
            matchDelay.Interval = 800;
        }

        public static void StartGame()
        {
            try
            {
                GlobalVariables.tB.Text = p1Score + " : " + p2Score + "\n" + tCounter;
                GlobalVariables.tB.Visible = true;
                location = new Point(GlobalVariables.ballSize * 3,
                    random.Next(GlobalVariables.ballSize * 2, GlobalVariables.gB.Height) - GlobalVariables.ballSize * 2);
                vector = new Point(random.Next(3, 6), random.Next(0, 5));
                matchDelay.Start();
            }
            catch (Exception e)
            {
                throw e;
            }
        }

        private static void ShowTimer(Object myObject, EventArgs myEventArgs)
        {
            --tCounter;
            GlobalVariables.tB.Text = p1Score + " : " + p2Score + "\n" + tCounter;
            if (tCounter == 0)
            {
                tCounter = 3;
                matchDelay.Stop();
                ball.SetPosition(location, vector);
                moveDelay.Start();
                GlobalVariables.tB.Visible = false;
                GlobalVariables.p1.SetPosition(new Point(0, 200));
                GlobalVariables.p2.SetPosition(new Point(GlobalVariables.gB.Width - 30, 200));
            }
        }

        private static void MoveOnTick(Object myObject, EventArgs myEventArgs)
        {
            if (GlobalVariables.wIsPressed)
            {
                GlobalVariables.wIsPressed = false;
                GlobalVariables.p1.PMove(new System.Drawing.Point(0, -GlobalVariables.ballSize * 2));
            }
            if (GlobalVariables.sIsPressed)
            {
                GlobalVariables.sIsPressed = false;
                GlobalVariables.p1.PMove(new System.Drawing.Point(0, GlobalVariables.ballSize * 2));
            }
            if (GlobalVariables.upIsPressed)
            {
                GlobalVariables.upIsPressed = false;
                GlobalVariables.p2.PMove(new System.Drawing.Point(0, -GlobalVariables.ballSize * 2));
            }
            if (GlobalVariables.downIsPressed)
            {
                GlobalVariables.downIsPressed = false;
                GlobalVariables.p2.PMove(new System.Drawing.Point(0, GlobalVariables.ballSize * 2));
            }
            ball.Move();
        }
        public static void Win(int player)
        {
            GlobalVariables.speed = 5;
            switch (player)
            {
                case 1:
                    p1Score++;
                    break;
                case 2:
                    p2Score++;
                    break;
            }
            moveDelay.Stop();
            ball.Hide();
            GlobalVariables.p1.Hide();
            GlobalVariables.p2.Hide();
            StartGame();
        }
    }
}
