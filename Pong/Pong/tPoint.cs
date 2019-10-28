using System;
using System.Collections.Generic;
using System.Drawing;
using System.Windows.Forms;

namespace Pong
{
    class tPoint
    {
        static Timer moveDelay;
        static Timer rotateDelay;
        static Ball s;
        static Random random;
        const int _size = 40;


        static tPoint()
        {
            random = new Random();
            moveDelay = new Timer();
            moveDelay.Tick += new EventHandler(MoveOnTick);
            moveDelay.Interval = 10;
            moveDelay.Start();
        }

        public void StartGame()
        {
            Point location = new Point(random.Next(10, GameForm.GameBoard.Width - _size), random.Next(10, GameForm.GameBoard.Height - _size));
            Point vector = new Point(random.Next(-5, 5), random.Next(-5, 5));
            Ball s = new Ball(location, vector, GameForm.GameBoard);
        }

        private static void MoveOnTick(Object myObject, EventArgs myEventArgs)
        {
                s.Move();
        }

    }
}
