using System.Drawing;
using System.Windows.Forms;

namespace Pong
{
    abstract class Animated
    {
        abstract public void Move();

        protected static void Move(PictureBox pb, Point direction)
        {
            pb.Location = new Point(pb.Location.X + direction.X, pb.Location.Y + direction.Y);
        }
        protected static string CheckCollision(PictureBox pb, Point direction)
        {
            if (pb.Location.Y + pb.Height + direction.Y > GameForm.gB.Height)//bottom hit
            {
                return "bot";
            }
            else if (pb.Location.Y + direction.Y < 0)//top hit
            {
                return "top";
            }
            if (pb.Location.X + pb.Width > GameForm.gB.Width - 30)//left side hit
            {
                return "left";
            }
            else if (pb.Location.X + direction.X < 30)//right side hit
            {
                return "right";
            }
            if (pb.Location.X + direction.X < 40)//left plank hit
            {
                if (pb.Location.Y + pb.Height > GameHandler.p1.pb.Location.Y &&
                    pb.Location.Y < GameHandler.p1.pb.Location.Y + GameHandler.p1.pb.Height)
                {
                    return "plank";
                }
            }
            if (pb.Location.X + pb.Width + direction.X > GameForm.gB.Width - 40) //right plank hit
            {
                if (pb.Location.Y + pb.Height > GameHandler.p2.pb.Location.Y && 
                    pb.Location.Y < GameHandler.p2.pb.Location.Y + GameHandler.p2.pb.Height)
                {
                    return "plank";
                }
            }
            return "clear";
        }
    }
}
