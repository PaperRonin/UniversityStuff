using System;
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

        protected static void SetPosition(PictureBox pb, Point location)
        {
            pb.Visible = true;
            pb.Location = location;
        }
        protected static void Hide(PictureBox pb)
        {
            pb.Visible = false;
        }

        protected static string CheckCollision(PictureBox pb, Point direction)
        {
            if (pb.Location.Y + pb.Height + direction.Y > GlobalVariables.gB.Height)//bottom hit
            {
                Move(pb, new Point(direction.X, GlobalVariables.gB.Height - pb.Location.Y - pb.Height));
                return "bot";
            }
            else if (pb.Location.Y + direction.Y < 0)//top hit
            {
                Move(pb, new Point(direction.X, -pb.Location.Y));
                return "top";
            }

            if (pb.Location.X + direction.X < GlobalVariables.ballSize)//left plank hit
                if (pb.Location.Y + pb.Height > GlobalVariables.p1.pb.Location.Y &&
                        pb.Location.Y < GlobalVariables.p1.pb.Location.Y + GlobalVariables.p1.pb.Height)
                {
                    Move(pb, new Point(-pb.Location.X + GlobalVariables.ballSize,
                        direction.Y));
                    return "plank";
                }


            if (pb.Location.X + pb.Width + direction.X > GlobalVariables.gB.Width - GlobalVariables.ballSize) //right plank hit
                if (pb.Location.Y + pb.Height > GlobalVariables.p2.pb.Location.Y &&
                        pb.Location.Y < GlobalVariables.p2.pb.Location.Y + GlobalVariables.p2.pb.Height)
                {
                    Move(pb, new Point(GlobalVariables.gB.Width - GlobalVariables.ballSize - pb.Location.X - pb.Width,
                        direction.Y));
                    return "plank";
                }


            if (pb.Location.X + pb.Width > GlobalVariables.gB.Width - 25)//right side hit
                return "right";


            else if (pb.Location.X < 25)//left side hit          
                return "left";


            return "clear";
        }
    }
}
