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
            Point location = new Point(random.Next(10, GameForm.GameBoard.Width - _size), random.Next(10, GameForm.GameBoard.Height - _size));
            Point vector = new Point(random.Next(-5, 5), random.Next(-5, 5));
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

    }
}
