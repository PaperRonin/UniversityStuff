using System;
using System.Drawing;
using System.Windows.Forms;

namespace Pong
{
    class Ball : Animated
    {    
        private PictureBox pb;
        private Point direction;
        static Random random = new Random();
        private static int speed = 5;
        public override void Move()
        {
            switch (CheckCollision(pb, direction))
            {
                case "plank":
                    speed++;
                    direction.X /= Math.Abs(direction.X);
                    direction.X *= -1 * speed;
                    direction.Y /= direction.Y != 0 ? Math.Abs(direction.Y) : 1;
                    direction.Y = random.Next(-speed, speed);
                    break;

                case "left":
                    GameHandler.Win(2);
                    break;

                case "right":
                    GameHandler.Win(1);
                    break;

                case "top":
                case "bot":
                    direction.Y *= -1;
                    Move(pb, direction);
                    break;
                default:
                    Move(pb, direction);
                    break;
            }
        }

        public Ball(Panel GameBoard)
        {
            pb = new PictureBox();
            pb.Image = Properties.Resources._0Square;
            pb.Size = new Size(40, 40);
            pb.BackColor = Color.Transparent;
            GameBoard.Controls.Add(pb);
        }

        public void SetPosition(Point location, Point vector)
        {
            speed = 5;
            pb.Visible = true;
            direction = vector;
            pb.Location = location;
        }

        public void Hide()
        {
            pb.Visible = false;
        }
    }
}
