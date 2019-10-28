using System.Drawing;
using System.Windows.Forms;

namespace Pong
{
    abstract class Animated
    {
        const int _speed = 3;
        abstract public void Move();

        protected static void Move(PictureBox pb, Point direction)
        {
            pb.Location = new Point(pb.Location.X + direction.X * _speed, pb.Location.Y + direction.Y * _speed);
        }
        protected static string CheckLoc(PictureBox pb, Point direction, Panel GameBoard)
        {
            if (pb.Location.X + pb.Width > GameBoard.Width + 5)//left side hit
            {
                return "left";
            }
            else if (pb.Location.X + direction.X < -5)//right side hit
            {
                return "right";
            }
            if (pb.Location.Y + pb.Height > GameBoard.Height + 5)//bottom hit
            {
                return "bot";
            }
            else if (pb.Location.Y + direction.Y < -8)//top hit
            {
                return "top";
            }
            return "clear";
        }
    }
}
