using System;
using System.Drawing;
using System.Windows.Forms;

namespace Pong
{
    class GameHandler
    {
        static Timer moveDelay, matchDelay;
        public static playerControls p1, p2;
        static int p1Score = 0;
        static int p2Score = 0;
        static Ball ball;
        static Point location, vector;
        static Random random = new Random();
        static int tCounter = 3;
        const int _size = 30;


        static GameHandler()
        {
            location = new Point(_size * 3, random.Next(_size, GameForm.gB.Height) - _size);
            vector = new Point(random.Next(3, 6), random.Next(0, 5));
            ball = new Ball(GameForm.gB);
            ball.Hide();

            p1 = new playerControls(GameForm.gB, new Point(1, GameForm.gB.Height / 4));
            p2 = new playerControls(GameForm.gB, new Point(GameForm.gB.Width - 41, GameForm.gB.Height / 4));

            moveDelay = new Timer();
            moveDelay.Tick += new EventHandler(MoveOnTick);
            moveDelay.Interval = 20;


            matchDelay = new Timer();
            matchDelay.Tick += new EventHandler(ShowTimer);
            matchDelay.Interval = 800;
        }

        public static void StartGame()
        {
            try
            {
                GameForm.tB.Text = p1Score + " : " + p2Score + "\n" + tCounter;
                GameForm.tB.Visible = true;
                location = new Point(_size * 3, random.Next(_size, GameForm.gB.Height) - _size);
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
            GameForm.tB.Text = p1Score + " : " + p2Score + "\n" + tCounter;
            if (tCounter == 0)
            {
                tCounter = 3;
                matchDelay.Stop();
                ball.SetPosition(location, vector);
                moveDelay.Start();
                GameForm.tB.Visible = false;
            }
        }

        private static void MoveOnTick(Object myObject, EventArgs myEventArgs)
        {
            GameForm.gF.Focus();
            ball.Move();
        }
        public static void Win(int player)
        {
            switch (player)
            {
                case 1:
                    p1Score++;
                    break;
                case 2:
                    p2Score++;
                    break;
                default:
                    break;
            }
            moveDelay.Stop();
            ball.Hide();
            StartGame();
            GameForm.gF.Focus();
        }
    }
}
