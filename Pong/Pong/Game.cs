using System;
using System.Drawing;
using System.Windows.Forms;

namespace Pong
{
    class Game
    {
        private static Timer moveDelay;
        private static Ball ball;
        private static Random random;
        private static Point location, vector;
        private const int _size = 40;


        static Game()
        {
            random = new Random();
            ball = new Ball(GameForm.GameBoard);
            location = new Point(_size + 5, random.Next(GameForm.GameBoard.Height - _size));
            vector = new Point(random.Next(3, 9), random.Next(-8, 8));
            ball.SetPosition(location, vector);
            ball.Hide();
            moveDelay = new Timer();
            moveDelay.Tick += new EventHandler(MoveOnTick);
            moveDelay.Interval = 10;
        }

        public void StartGame()
        {
            location = new Point(_size + 5, random.Next(GameForm.GameBoard.Height - _size));
            vector = new Point(random.Next(3, 9), random.Next(-8, 8));
            ball.SetPosition(location, vector);
            moveDelay.Start();
        }

        public void Pause() => moveDelay.Stop();

        public void UnPause() => moveDelay.Start();

        private static void MoveOnTick(Object myObject, EventArgs myEventArgs)
        {
            ball.Move();
        }
        public static void Win(int player)
         {
            moveDelay.Stop();
            ball.Hide();
            GameForm.GameBoardForm.OnWin(player);
        }
    }
}
