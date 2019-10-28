using System;
using System.Collections.Generic;
using System.Drawing;
using System.Windows.Forms;

namespace Pong
{
    class TPoint
    {
        static Timer moveDelay;
        static Ball ball;
        static Random random;
        const int _size = 40;


        static TPoint()
        {
            random = new Random();
            Point location = new Point((GameForm.GameBoard.Width - _size) / 2, (GameForm.GameBoard.Height - _size) / 2);
            Point vector = new Point(1, 1);
            ball = new Ball(location, vector, GameForm.GameBoard);
        }

        public void StartGame()
        {
            moveDelay = new Timer();
            moveDelay.Tick += new EventHandler(MoveOnTick);
            moveDelay.Interval = 10;
            moveDelay.Start();
        }

        private static void MoveOnTick(Object myObject, EventArgs myEventArgs)
        {
            ball.Move();
        }
        public static void Win(int player)
        {
            moveDelay.Stop();
        }
    }
}
