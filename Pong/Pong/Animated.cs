using System.Drawing;
using System.Windows.Forms;

namespace Pong
{
    abstract class Animated
    {
        const int _speed = 3;
        abstract public void RotateImage();
        abstract public void Move();

        protected static void Move(ref PictureBox pb, ref Point direction)
        {
            CheckLoc(pb, ref direction, GameForm.GameBoard);
            pb.Location = new Point(pb.Location.X + direction.X, pb.Location.Y + direction.Y);
        }
        protected static void CheckLoc(PictureBox pb, ref Point direction, Panel GameBoard)
        {
            if (pb.Location.X + pb.Width > GameBoard.Width + 5)//left side
            {
                direction.X = -_speed; 
            }
            else if (pb.Location.X + direction.X < -5)//right side
            {
                direction.X = _speed;
            }
            if (pb.Location.Y + pb.Height > GameBoard.Height + 5)//bottom
            {
                direction.Y = -_speed;
            }
            else if (pb.Location.Y + direction.Y < -8)//top
            {
                direction.Y = _speed;
            }
        }
    }
}
